﻿using log4net;
using System;

namespace Proyecto1
{
    /// <summary>
    /// Represents a cache used in a computer system.
    /// </summary>
    public class Cache
    {
        public int id {  get; set; }
        public List<CacheLine> cacheLines;
        private BusInterconnect Bus;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Cache"/> class.
        /// </summary>
        /// <param name="numberOfLines">The number of cache lines.</param>
        /// <param name="id">The identifier of the cache.</param>
        /// <param name="bus">The bus interconnect used for communication.</param>
        /// <param name="protocol">The cache protocol to be implemented.</param>

        public Cache(int numberOfLines, int id, BusInterconnect bus, string protocol)
        {
            this.id = id;
            Bus = bus;
            cacheLines = new List<CacheLine>(numberOfLines);
            for (int i = 0; i < numberOfLines; i++)
            {
                cacheLines.Add(new CacheLine(i, protocol));
            }
        }

        /// <summary>
        /// Sets the cache coherence protocol for the <see cref="Cache"/> class.
        /// </summary>
        /// <param name="protocol">The protocol to be set.</param>
        public void SetProtocol(string protocol) 
        { 
            foreach (var line in cacheLines)
            {
                line.SetProtocol(protocol);
            }
        }

        /// <summary>
        /// Cleans and resets the cache.
        /// </summary>
        public void Clean()
        {
            foreach (CacheLine line in cacheLines)
            {
                line.Clean();
            }
        }

        /// <summary>
        /// Reads data from the cache at the specified address by the PE.
        /// </summary>
        /// <param name="addr">The memory address to read from.</param>
        /// <returns>The data read from the cache.</returns>
        public byte ReadAddr(int addr)
        {
            LoggerT.LogReadReq(id, addr);
            // get tag, line and offset from address
            (int tag, int line, int offset) = ParseAddr(addr);

            CacheLine cacheline = cacheLines[line];

            lock (Bus)
            {
                // read hit
                if (cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() != StateMachine.State.Invalid)
                {

                    Console.WriteLine("Cache #" + id + " read hit " + addr);
                    Bus.ReadHit(tag, id, line);
                    cacheline.StateMachine.ReadHit();
                    return cacheline.data[offset]; // return read to PE

                }


                Console.WriteLine("Cache #" + id + " read Miss " + addr);
                // get line from other caches / memory
                (byte[] data, bool shared) = Bus.ReadMiss(addr, tag, id, line);

                // execute the replacement policy
                int linenum = ReplacementPolicy(data, addr, tag);

                // change state depending if read miss was shared or exclusive
                if (shared)
                {
                    cacheLines[linenum].StateMachine.ReadMissShared();
                }
                else
                {
                    cacheLines[linenum].StateMachine.ReadMissExclusive();
                }
                return data[offset]; // return read to PE

            }
        }

        /// <summary>
        /// Writes data to the cache at the specified address by the PE.
        /// </summary>
        /// <param name="addr">The memory address to write to.</param>
        /// <param name="data">The data to write.</param>
        public void WriteAddr(int addr, byte data)
        {
            LoggerT.LogWriteReq(id, addr);
            // get tag, line and offset from address
            (int tag, int line, int offset) = ParseAddr(addr);

            bool found = false;
            CacheLine cacheline = cacheLines[line];
            lock (Bus)
            {
                // write hit
                if (cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() != StateMachine.State.Invalid)
                {

                    Console.WriteLine("Cache #" + id + " write Hit " + addr);
                    Bus.WriteHit(cacheline, id, tag, line);
                    found = true;
                    cacheline.Dirty = true;
                    cacheline.data[offset] = data;
                }

                // write miss
                if (!found)
                {

                    Console.WriteLine("Cache #" + id + " write miss " + addr);
                    // get line from other caches / memory
                    byte[] newdata = Bus.WriteMiss(addr, tag, id, line);

                    // execute the replacement policy
                    int linenum = ReplacementPolicy(newdata, addr, tag);

                    cacheLines[linenum].StateMachine.WriteMiss();
                    cacheLines[linenum].Dirty = true;
                    cacheLines[linenum].data[offset] = data;
                }

            }
                
        }

        /// <summary>
        /// Implements the replacement policy for cache lines.
        /// </summary>
        /// <param name="data">The data being written to the cache.</param>
        /// <param name="addr">The memory address being accessed.</param>
        /// <param name="tag">The tag associated with the memory address.</param>
        /// <returns>The index of the cache line that was selected for replacement.</returns>
        private int ReplacementPolicy(byte[] data, int addr, int tag) {

            // get line from address
            int cachelinenum = ParseAddr(addr).line;
           

            // gets the memory line
            int memoryline = GetMemoryLine(tag, cachelinenum);
            

            // gets old cache line to update
            CacheLine oldline = cacheLines[cachelinenum];
            
            if (oldline.Protocol.Equals("MESI"))
            {
                if (oldline.Dirty)
                {
                    Bus.WriteBack(memoryline, data);
                }
            }

            else
            {
               
                if (oldline.StateMachine.GetCurrentState() == StateMachine.State.Owned)
                {

                    Bus.Invalidate(id, cacheLines[cachelinenum].Tag, cachelinenum);
                   
                }

                if (oldline.StateMachine.GetCurrentState() == StateMachine.State.Owned
                    || oldline.StateMachine.GetCurrentState() == StateMachine.State.Modified)
                {
                    
                    Bus.WriteBack(memoryline, data);
                }
            }
            cacheLines[cachelinenum].UpdateLine(data, tag, true, false);
            return cachelinenum;

        }

        /// <summary>
        /// Searches for a cache line with a given tag for a Read Hit operation.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>The cache line if found, otherwise null.</returns>
        public CacheLine? SearchAddrRH(int tag, int line)
        {
            CacheLine cacheline = cacheLines[line];
      
            if (cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() != StateMachine.State.Invalid)
            {
                return cacheline;
            }
            else
            {
                return null;
            } 
        }

        /// <summary>
        /// Searches for a cache line with a given tag for a Read Miss operation.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <param name="line">The line to search for.</param>
        /// <returns>A tuple containing the data (if found) and a boolean indicating if it was found.</returns>
        public (byte[],bool) SearchAddrRM(int tag, int line)
        {
            CacheLine cacheline = cacheLines[line];
            if (cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() != StateMachine.State.Invalid)
            { 
                cacheline.StateMachine.SnoopHitRead();
                
                return (cacheline.data, true);    
            }
            else
            {
                byte[] empty = new byte[4];
                return (empty, false);
            }
        }
        /// <summary>
        /// Searches for a cache line with a given tag for a Read Miss operation in MOESI.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <param name="line">The line to search for.</param>
        /// <returns>A tuple containing the data (if found) and a boolean indicating if it was found.</returns>
        public (byte[], bool) SearchAddrRMMOESI(int tag, int line)
        {
            CacheLine cacheline = cacheLines[line];
            if (cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() != StateMachine.State.Invalid)
            {
                cacheline.StateMachine.SnoopHitRead();

                if(cacheline.StateMachine.GetCurrentState() == StateMachine.State.Owned)
                {
                    return (cacheline.data, true);
                }
                else
                {
                    byte[] empty = new byte[4];
                    return (empty, false);
                }
            }
            else
            {
                byte[] empty = new byte[4];
                return (empty, false);
            }
        }

        /// <summary>
        /// Updates a cache line with a given tag for a Write Hit operation.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <param name="line">The line to search for.</param>
        public void SearchAddrWH(int tag, int line)
        {
            CacheLine cacheline = cacheLines[line];
            if (cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() != StateMachine.State.Invalid)
            {
                int addr = GetMemoryLine(tag, line);
                LoggerT.LogInvReq(id, addr);
                Console.WriteLine("Invalidate> "  + addr);
                cacheline.StateMachine.SnoopHitWrite();
            }
        }

        /// <summary>
        /// Searches for a cache line with a given tag for a Write Miss operation.
        /// </summary>
        /// <param name="tag">The tag to search for.</param>
        /// <returns>A tuple containing the data (if found) and a boolean indicating whether the data is valid.</returns>
        public (byte[], bool) SearchAddrWM(int tag, int line)
        {
            CacheLine cacheline = cacheLines[line];
            if (cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() != StateMachine.State.Invalid)
            {
                int addr = GetMemoryLine(tag, line);
                LoggerT.LogInvReq(id, addr);
   
                cacheline.StateMachine.SnoopHitWrite();
                return (cacheline.data, true);
            }
            else
            {
                byte[] empty = new byte[4];
                return (empty, false);
            }
        }

        public void Invalidate(int tag, int line)
        {
            CacheLine cacheline = cacheLines[line];
            
            if (cacheline.Tag == tag && cacheline.StateMachine.GetCurrentState() == StateMachine.State.Shared)
            {
                int addr = GetMemoryLine(tag, line);
                LoggerT.LogInvReq(id, addr);
                cacheline.StateMachine.SnoopHitWrite();
            }

        }

        /// <summary>
        /// Converts two integers to a memory line address.
        /// </summary>
        /// <param name="num1">The first integer.</param>
        /// <param name="num2">The second integer.</param>
        /// <returns>The memory line address.</returns>
        public int GetMemoryLine(int num1, int num2)
        {
            // convert the integers to binary strings
            string binaryStr1 = Convert.ToString(num1, 2);
            string binaryStr2 = Convert.ToString(num2, 2);

            int desiredLength = 2;
            if (binaryStr1.Length < desiredLength)
            {
                binaryStr1 = binaryStr1.PadLeft(desiredLength, '0');
            }

            if (binaryStr2.Length < desiredLength)
            {
                binaryStr2 = binaryStr2.PadLeft(desiredLength, '0');
            }

            // concatenate the binary strings
            string concatenatedBinaryStr = binaryStr1 + binaryStr2;

            // convert the concatenated binary string back to an integer
            int result = Convert.ToInt32(concatenatedBinaryStr, 2);

            return result;
        }

        /// <summary>
        /// Parses a memory address into its components: tag, cache line, and offset.
        /// </summary>
        /// <param name="addr">The memory address to parse.</param>
        /// <returns>A tuple containing the parsed tag, cache line, and offset.</returns>
        public (int tag,int line, int offset) ParseAddr(int addr)
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

