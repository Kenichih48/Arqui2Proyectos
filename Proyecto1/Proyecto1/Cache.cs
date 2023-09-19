using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto1
{
    public class Cache
    {
        private int id;
        private List<CacheLine> cacheLines;
        
        //private controller CacheContoller;
        public Cache(int numberOfLines, int id)
        {
            cacheLines = new List<CacheLine>(numberOfLines);
            for (int i = 0; i < numberOfLines; i++)
            {
                cacheLines.Add(new CacheLine(i));
            }
        }

        //Nota: puede modificarse para buscar tag, validez, y mas
        public byte ReadAddr(int addr)
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

            foreach (CacheLine line in cacheLines)
            {
                if (line.Tag == tag)
                {
                    //controller.readHit(addr, id);
                    return line.data[offset]; //Hit
                }
            }
            //byte[] data = controller.readMiss(addr, id);
            //TODO: replacement policy

            throw new KeyNotFoundException($"CacheLine with address {addr} not found.");
        }

        public void WriteAddr(int addr, byte data)
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

            foreach (CacheLine line in cacheLines)
            {
                if (line.Tag == tag)
                {
                    //controller.writeHit(line, offset, data, id);
                    return; 
                }
            }
            //byte[] data = controller.writeMiss(addr, id);

            // If no matching CacheLine is found, throw a KeyNotFoundException
            throw new KeyNotFoundException($"CacheLine with address {addr} not found.");
        }
    }
}

