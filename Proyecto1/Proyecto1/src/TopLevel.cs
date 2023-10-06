﻿namespace Proyecto1
{
    public class TopLevel
    {
        public string Protocol {  get; set; }
        public ProcessingElement PE1 {  get; set; }
        public ProcessingElement PE2 {  get; set; }
        public ProcessingElement PE3 {  get; set; }

        public Cache Cache1 { get; set; }
        public Cache Cache2 { get; set; }
        public Cache Cache3 { get; set; }

        public BusInterconnect Bus {  get; set; }
        public Memory Memory { get; set; }

        private int minInstr = 7;
        private int maxInstr = 9;
        private int cachelines = 4;

        public List<Thread> threads = new List<Thread>();

        public TopLevel()
        {
            Memory = new Memory();

            Bus = new BusInterconnect(Memory);
        }
        public TopLevel(string protocol) {

            Protocol = protocol;

            Memory = new Memory();

            Bus = new BusInterconnect(Memory);

            Cache1 = new Cache(cachelines, 0, Bus, Protocol);
            Cache2 = new Cache(cachelines, 1, Bus, Protocol);
            Cache3 = new Cache(cachelines, 2, Bus, Protocol);

            PE1 = new ProcessingElement(Cache1, minInstr, maxInstr);
            PE2 = new ProcessingElement(Cache2, minInstr, maxInstr);
            PE3 = new ProcessingElement(Cache3, minInstr, maxInstr);

            List<Cache> cacheList = new() { Cache1, Cache2, Cache3 };

            Bus.SetCaches(cacheList);
        }


        public TopLevel(int minI, int maxI, string protocol)
        {
            Protocol = protocol;
            
            Memory = new Memory();

            Bus = new BusInterconnect(Memory);

            Cache1 = new Cache(cachelines, 0, Bus, Protocol);
            Cache2 = new Cache(cachelines, 1, Bus, Protocol);
            Cache3 = new Cache(cachelines, 2, Bus, Protocol);

            PE1 = new ProcessingElement(Cache1, minI, maxI);
            PE2 = new ProcessingElement(Cache2, minI, maxI);
            PE3 = new ProcessingElement(Cache3, minI, maxI);

            List<Cache> cacheList = new() { Cache1, Cache2, Cache3 };

            Bus.SetCaches(cacheList);
        }

        public void SetProtocol(string protocol)
        {
            Protocol = protocol;

            Cache1 = new Cache(cachelines, 0, Bus, Protocol);
            Cache2 = new Cache(cachelines, 1, Bus, Protocol);
            Cache3 = new Cache(cachelines, 2, Bus, Protocol);

            PE1 = new ProcessingElement(Cache1, minInstr, maxInstr);
            PE2 = new ProcessingElement(Cache2, minInstr, maxInstr);
            PE3 = new ProcessingElement(Cache3, minInstr, maxInstr);

            List<Cache> cacheList = new() { Cache1, Cache2, Cache3 };

            Bus.SetCaches(cacheList);

        }


        public void StartThreads()
        {
            Console.WriteLine("Begin Threads");
            Thread thread1 = new Thread(PE1.ExecuteAll);
            Thread thread2 = new Thread(PE2.ExecuteAll);
            Thread thread3 = new Thread(PE3.ExecuteAll);

            threads.Add(thread1); 
            threads.Add(thread2); 
            threads.Add(thread3);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            foreach (Thread thread in threads)
            {
                thread.Join(); // Esperar a que todos los hilos terminen
            }
        }

        public void Clean()
        {
            Cache1.Clean();
            Cache2.Clean();
            Cache3.Clean();
            
            PE1.Clean();
            PE2.Clean();
            PE3.Clean();

            Memory.Clean();
        }

    }
}
