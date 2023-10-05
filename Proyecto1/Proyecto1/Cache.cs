using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto1
{
    public class Cache
    {
        public int id {  get; set; }
        public List<CacheLine> cacheLines;
        private BusInterconnect Bus;
        
        //private controller CacheContoller;
        public Cache(int numberOfLines, int id, BusInterconnect bus)
        {
            this.id = id;
            cacheLines = new List<CacheLine>(numberOfLines);
            for (int i = 0; i < numberOfLines; i++)
            {
                cacheLines.Add(new CacheLine(i));
            }
            Bus = bus;
        }

        //Nota: puede modificarse para buscar tag, validez, y mas
        public byte ReadAddr(int addr)
        {
            (int tag, int line, int offset) = parseAddr(addr);
            CacheLine cacheline = cacheLines[line];

            if (cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() != StateMachineMESI.MesiState.Invalid)
            {
                Bus.ReadHit(tag, id);
                cacheline.StateMachine.ReadHit();
                return cacheline.data[offset]; //Hit
            }

             
            (byte[] data,bool shared) = Bus.ReadMiss(addr, tag, id, offset);

            int linenum = ReplacementPolicy(data,addr,tag);
            
            if (shared)
            {
                cacheLines[linenum].StateMachine.ReadMissShared();
            }
            else
            {
                cacheLines[linenum].StateMachine.ReadMissExclusive();
            }
            return data[offset];

            
        }

        public void WriteAddr(int addr, byte data)
        {
            (int tag, int line, int offset) =  parseAddr(addr);

            bool found = false;
            CacheLine cacheline = cacheLines[line];

            if(cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() != StateMachineMESI.MesiState.Invalid)
            {
                Bus.WriteHit(cacheline, id, tag);
                cacheline.Dirty = true;

                cacheline.data[offset] = data;
                found = true;
            }
            

            if (!found)
            {
                byte[] newdata = Bus.WriteMiss(addr, tag, id);

                int linenum = ReplacementPolicy(newdata, addr, tag);

                cacheLines[linenum].StateMachine.WriteMiss();
                cacheLines[linenum].data[offset] = data;
                cacheLines[linenum].Dirty = true;
            }
           
            

            // If no matching CacheLine is found, throw a KeyNotFoundException
            
        }

        private int ReplacementPolicy(byte[] data, int addr,int tag) {

            string binaryAddr = Convert.ToString(addr, 2);
            int desiredLength = 6;
            if (binaryAddr.Length < desiredLength)
            {
                binaryAddr = binaryAddr.PadLeft(desiredLength, '0');
            }
            
            string strLn = binaryAddr.Substring(2, 2);
            int cachelinenum = Convert.ToInt32(strLn, 2);

            int memoryline = getMemoryLine(tag, cachelinenum);

            CacheLine oldline = cacheLines[cachelinenum];

            if (oldline.Dirty)
            {
                Bus.WriteBack(memoryline,data);
                cacheLines[cachelinenum].updateLine(data, tag, true, false);
                
            }
            else
            {
                cacheLines[cachelinenum].updateLine(data, tag, true, false);   
            }

            return cachelinenum;
        }


        public CacheLine SearchAddrRH(int tag)
        {
           
            foreach (CacheLine line in cacheLines)
            {
                if (line.Tag == tag)
                {

                    return line;
                }
            }
            return null;
        }


        public (byte[],bool) SearchAddrRM(int tag)
        {
            foreach (CacheLine line in cacheLines)
            {
                if (line.Tag == tag && line.StateMachine.GetCurrentState() != StateMachineMESI.MesiState.Invalid)
                {
                    line.StateMachine.SnoopHitRead();
                    return (line.data, true);
                }
            }
            byte[] empty = new byte[4];
            return (empty,false);
        }

        public void SearchAddrWH(int tag)
        {
            foreach (CacheLine line in cacheLines)
            {
                if (line.Tag == tag)
                {
                    line.StateMachine.SnoopHitWrite();
                }
            }
        }

        public (byte[], bool) SearchAddrWM(int tag)
        {
            foreach (CacheLine line in cacheLines)
            {
                if (line.Tag == tag && line.StateMachine.GetCurrentState() != StateMachineMESI.MesiState.Invalid)
                {
                    line.StateMachine.SnoopHitWrite();
                    return (line.data,true);
                }
            }
            byte[] empty = new byte[4];
            return (empty, false);
        }


        public int getMemoryLine(int num1, int num2)
        {
            // Convert the integers to binary strings
            string binaryStr1 = Convert.ToString(num1, 2);
            string binaryStr2 = Convert.ToString(num2, 2);

            // Concatenate the binary strings
            string concatenatedBinaryStr = binaryStr1 + binaryStr2;

            // Convert the concatenated binary string back to an integer
            int result = Convert.ToInt32(concatenatedBinaryStr, 2);

            return result;
        }

        public (int tag,int line, int offset) parseAddr(int addr)
        {
            string binaryAddr = Convert.ToString(addr, 2);
            int desiredLength = 6;
            if (binaryAddr.Length < desiredLength)
            {
                binaryAddr = binaryAddr.PadLeft(desiredLength, '0');
            }
            string strTag = binaryAddr[..2];
            int tag = Convert.ToInt32(strTag, 2);

            string strOf = binaryAddr.Substring(4, 2);
            int offset = Convert.ToInt32(strOf, 2);

            string strLn = binaryAddr.Substring(2, 2);
            int line = Convert.ToInt32(strLn, 2);

            return (tag, line, offset);
        }
    }
}

