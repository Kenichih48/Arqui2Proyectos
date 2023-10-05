using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto1
{
    /// <summary>
    /// Represents the interconnection bus in a simulated system
    /// </summary>
    public class BusInterconnect
    {


        public int AddrBus;
        public byte[] DataBus;
        public byte[] SharedBus;
        private Queue<Request> queue;
        private List<Cache> caches;
        private Memory memory;


        /// <summary>
        /// Initializes a new instance of the <see cref="BusInterconnect"/> class.
        /// </summary>
        public BusInterconnect(Memory memory) 
        { 
            this.queue = new Queue<Request>();
            this.caches = new List<Cache>();
            this.memory = memory;
        }

        /// <summary>
        /// Adds request to a queue
        /// </summary>
        /// <param name="request"> Request made by the cache</param>
        public void MakeRequest(Request request)
        {
            this.queue.Enqueue(request);
        }

        /// <summary>
        /// Gets the next request in the queue
        /// </summary>
        /// <returns>the next  request made by a cache in the queue</returns>
        public Request GetNextRequest() { return this.queue.Dequeue(); }

        /// <summary>
        /// Updates the address bus
        /// </summary>
        /// <param name="addr">memory address that will be accessed</param>
        public void updateAddrBus(int addr)
        {
            this.AddrBus = addr;
        }

        /// <summary>
        /// Updates the DataBus
        /// </summary>
        /// <param name="data">Data returning from memory</param>
        public void updateDataBus(byte[] data) 
        {  
            this.DataBus = data; 
        }

        /// <summary>
        /// Updates the Shared data bus
        /// </summary>
        /// <param name="shared">shared data between caches</param>
        public void updateSharedBus(byte[] shared) 
        {  
            this.SharedBus = shared; 
        }   


        public void setCaches(List<Cache> caches)
        {
            this.caches = caches;
        }


        public void ReadHit(int tag, int id)
        {
            foreach (Cache cache in this.caches) { 
                if(cache.id != id)
                {
                    CacheLine cacheline = cache.SearchAddrRH(tag);

                    if (cacheline != null)
                    {
                        if(cacheline.StateMachine.GetCurrentState() == StateMachineMESI.MesiState.Modified)
                        {
                            int memoryline = cache.getMemoryLine(cacheline.Tag, cacheline.Line);
                            WriteBack(memoryline,cacheline.data);
                        }
                        cacheline.StateMachine.SnoopHitRead();
                        
                    }
                }
            }
        }

        public (byte[],bool) ReadMiss(int addr, int tag, int id, int offset) {
            bool shared = false;
            byte[] data = new byte[4];
            foreach (Cache cache in this.caches)
            {
                if (cache.id != id)
                {
                    (data, bool found) = cache.SearchAddrRM(tag);

                    if (found)
                    {
                        shared = true;
                    }
                }
            }
            if(shared)
            {
               return (data, shared);
            }
            else
            {
               //request
               //Wait hasta que memoria retorne

               data = memory.ReadAddr(addr);
               return (data, shared);
            }
            
        }

        public void WriteBack(int addr, byte[] data)
        {
            memory.WriteByte(addr, data);
        }

        public void WriteHit(CacheLine line,int id,int tag)
        {
            
            if (line.StateMachine.GetCurrentState() == StateMachineMESI.MesiState.Shared)
            {
                foreach (Cache cache in this.caches)
                {
                    if (cache.id != id) 
                    {
                        cache.SearchAddrWH(tag);
                    }
                    
                }
            }

            line.StateMachine.WriteHit();

        }


        public byte[] WriteMiss(int addr, int tag, int id)
        {
           
            byte[] data = new byte[4];
            foreach (Cache cache in this.caches)
            {
                if (cache.id != id)
                {
                    (data, bool found) = cache.SearchAddrWM(tag);

                    if (found)
                    {
                        return data;
                    }
                }
            }

            data = memory.ReadAddr(addr);
            return data;

        }


    }

    
}
