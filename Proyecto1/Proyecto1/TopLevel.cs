using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class TopLevel
    {
        public ProcessingElement PE1 {  get; set; }
        public ProcessingElement PE2 {  get; set; }
        public ProcessingElement PE3 {  get; set; }

        public Cache Cache1 { get; set; }
        public Cache Cache2 { get; set; }
        public Cache Cache3 { get; set; }

        public BusInterconnect Bus {  get; set; }
        public Memory memory { get; set; }
        

        private int minInstr = 7;
        private int maxInstr = 9;
        private int cachelines = 4;


        public TopLevel() {

            memory = new Memory();

            Bus = new BusInterconnect(memory);

            Cache1 = new Cache(cachelines, 0, Bus);
            Cache2 = new Cache(cachelines, 1, Bus);
            Cache3 = new Cache(cachelines, 2, Bus);

            PE1 = new ProcessingElement(0, Cache1, minInstr, maxInstr);
            PE2 = new ProcessingElement(1, Cache2, minInstr, maxInstr);
            PE3 = new ProcessingElement(2, Cache3, minInstr, maxInstr);

            List<Cache> cacheList = new() { Cache1, Cache2, Cache3 };

            Bus.setCaches(cacheList);

        }







    }
}
