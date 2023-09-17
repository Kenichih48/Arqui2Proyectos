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
        public int DataBus;
        public int SharedBus;
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


        



    }

    
}
