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
        private List<CacheLine> cacheLines;
        //private controller CacheContoller;
        public Cache(int numberOfLines)
        {
            cacheLines = new List<CacheLine>(numberOfLines);
            for (int i = 0; i < numberOfLines; i++)
            {
                cacheLines.Add(new CacheLine(i));
            }
        }

        //Nota: puede modificarse para buscar tag, validez, y mas
        public byte ReadAddr(int tag)
        {
            foreach (CacheLine line in cacheLines)
            {
                if (line.Valid && line.Tag == tag)
                {
                    return line.data;
                }
            }

            throw new KeyNotFoundException($"CacheLine with tag {tag} not found.");
        }

        public void WriteAddr(int tag, byte data)
        {
            foreach (CacheLine line in cacheLines)
            {
                if (line.Tag == tag)
                {
                    line.data = data;
                    line.Valid = true;
                    line.Dirty = false;
                    line.State = 'E';
                    return; 
                }
            }

            // If no matching CacheLine is found, throw a KeyNotFoundException
            throw new KeyNotFoundException($"CacheLine with tag {tag} not found.");
        }
    }

}
