using System;
using System.Collections.Generic;

namespace Proyecto1 {
    public class CacheLine
    {
        public bool Valid { get; set; }
        public bool Dirty { get; set; }
        public char State { get; set; }
        public int Tag { get; set; }
        public int Block { get; set; }

        public byte data; //cambiar a 4

        public CacheLine(int tag)
        {
            Valid = false;
            Dirty = false;
            State = ' ';
            Tag = tag;
            Block = -1;
            data = 0;
        }
    }
}