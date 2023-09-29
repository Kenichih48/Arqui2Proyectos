using System;
using System.Collections.Generic;

namespace Proyecto1 {
    public class CacheLine
    {
        public bool Valid { get; set; }
        public bool Dirty { get; set; }
        public int Tag { get; set; }
        
        public StateMachineMESI StateMachine;
        public int Line {  get; set; }
        public byte[] data; 

        public CacheLine(int line)
        {
            Valid = false;
            Dirty = false;
            Tag = -1;
            data = new byte[4];
            StateMachine = new StateMachineMESI();
            Line = line;
        }

        public void updateLine(byte[] data,int tag, bool valid, bool dirty)
        {
            this.data = data;
            Tag = tag;
            Valid = valid;
            Dirty = dirty;
        }
    }
}