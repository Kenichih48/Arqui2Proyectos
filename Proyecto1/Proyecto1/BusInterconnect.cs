using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        /// <summary>
        /// Initializes a new instance of the <see cref="BusInterconnect"/> class.
        /// </summary>
        public BusInterconnect() 
        { 
            this.queue = new Queue<Request>();
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



    }

    
}
