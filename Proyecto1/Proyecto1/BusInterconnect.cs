﻿namespace Proyecto1
{
    /// <summary>
    /// Represents the bus interconnect used for communication between caches and memory.
    /// </summary>
    public class BusInterconnect
    {
        private List<Cache> caches;
        private readonly Memory memory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusInterconnect"/> class.
        /// </summary>
        /// <param name="memory">The memory module connected to the bus.</param>
        public BusInterconnect(Memory memory) 
        { 
            caches = new List<Cache>();
            this.memory = memory;
        }

        /// <summary>
        /// Sets the list of caches connected to the bus.
        /// </summary>
        /// <param name="caches">The list of cache instances.</param>
        public void SetCaches(List<Cache> caches)
        {
            this.caches = caches;
        }

        /// <summary>
        /// Handles a Read Hit operation on the bus.
        /// </summary>
        /// <param name="tag">The tag associated with the read operation.</param>
        /// <param name="id">The ID of the cache performing the read.</param>
        /// <param name="line">The line of the cache performing the read.</param>

        public void ReadHit(int tag, int id, int line)
        {
            foreach (Cache cache in this.caches) { 
                if(cache.id != id)
                {
                    CacheLine? cacheline = cache.SearchAddrRH(tag, line);
                    if (cacheline != null)
                    {
                        if(cacheline.StateMachine.GetCurrentState() == StateMachineMESI.MesiState.Modified)
                        {
                            // write back
                            int memoryline = cache.GetMemoryLine(cacheline.Tag, cacheline.Line);
                            WriteBack(memoryline,cacheline.data);
                        }
                        cacheline.StateMachine.SnoopHitRead();
                        
                    }
                }
            }
        }

        /// <summary>
        /// Handles a Read Miss operation on the bus.
        /// </summary>
        /// <param name="addr">The memory address for the read operation.</param>
        /// <param name="tag">The tag associated with the read operation.</param>
        /// <param name="id">The ID of the cache performing the read.</param>
        /// <param name="line">The line of the cache performing the read.</param>
        /// <returns>A tuple containing the read data and a flag indicating if the data is shared.</returns>
        public (byte[],bool) ReadMiss(int addr, int tag, int id,int line) {
            bool shared = false;
            byte[] Finaldata = new byte[4];
            foreach (Cache cache in this.caches)
            {
                if (cache.id != id)
                {
                    (byte[] data, bool found) = cache.SearchAddrRM(tag, line);
                    
                    if (found)
                    {
                        shared = true;
                        Finaldata = data;
                    }
                }
            }
            if(shared)
            {
               return (Finaldata, shared);
            }
            else
            {
               Finaldata = memory.ReadAddr(addr);
               return (Finaldata, shared);
            }
        }

        /// <summary>
        /// Writes back data to memory.
        /// </summary>
        /// <param name="addr">The memory address to write back to.</param>
        /// <param name="data">The data to write back.</param>
        public void WriteBack(int addr, byte[] data)
        {
            memory.WriteByte(addr, data);
        }

        /// <summary>
        /// Handles a Write Hit operation on the bus.
        /// </summary>
        /// <param name="line">The cache line associated with the write operation.</param>
        /// <param name="id">The ID of the cache performing the write.</param>
        /// <param name="tag">The tag associated with the write operation.</param>
        /// <param name="line">The line of the cache performing the write.</param>
        public void WriteHit(CacheLine cacheline,int id,int tag, int line)
        {
            
            if (cacheline.StateMachine.GetCurrentState() == StateMachineMESI.MesiState.Shared)
            {
                foreach (Cache cache in this.caches)
                {
                    if (cache.id != id) 
                    {
                        cache.SearchAddrWH(tag,line);
                    }
                }
            }
            cacheline.StateMachine.WriteHit();
        }

        /// <summary>
        /// Handles a Write Miss operation on the bus.
        /// </summary>
        /// <param name="addr">The memory address for the write operation.</param>
        /// <param name="tag">The tag associated with the write operation.</param>
        /// <param name="id">The ID of the cache performing the write.</param>
        /// <returns>The data to be written to the cache line.</returns>
        public byte[] WriteMiss(int addr, int tag, int id, int line)
        {
            
            byte[] finaldata = new byte[4];
            foreach (Cache cache in this.caches)
            {
                if (cache.id != id)
                {
                    (byte[] data, bool found) = cache.SearchAddrWM(tag,line);

                    if (found)
                    {
                       finaldata = data;
                    }
                }
            }
            finaldata = memory.ReadAddr(addr);
            return finaldata;
        }
    }
}
