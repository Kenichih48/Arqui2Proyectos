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

        public byte[] data; 

        public CacheLine(int addr)
        {
            Valid = false;
            Dirty = false;
            State = ' ';
            Tag = -1;
            Block = -1;
            data = new byte[4];
        }
    }
}