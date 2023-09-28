using System;
using System.Collections.Generic;

namespace Proyecto1 {
    public class CacheLine
    {
        public bool Valid { get; set; }
        public bool Dirty { get; set; }
        public int Tag { get; set; }
        public int Block { get; set; }
        public StateMachineMESI StateMachine;
        public byte[] data; 

        public CacheLine()
        {
            Valid = false;
            Dirty = false;
            Tag = -1;
            Block = -1;
            data = new byte[4];
            StateMachine = new StateMachineMESI();
        }
    }
}