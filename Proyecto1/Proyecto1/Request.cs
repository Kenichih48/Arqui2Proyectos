using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    /// <summary>
    /// Represents a request made by a cache to the bus
    /// </summary>
    public class Request
    {
        private int Addr {  get; set; }
        private int TypeInstr {  get; set; }
        private byte Datawrite {  get; set; }
        private Cache cache {  get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="addr">Memory address requested</param>
        /// <param name="typeinstr">Number representing the type of instruction. (1:read,2:write)</param>
        /// <param name="cache">Reference to the Cache from where the request was made </param>
        /// <param name="datawrite"> Data in case of a write operation</param>
        public Request(int addr,int typeinstr,Cache cache) 
        { 
            this.Addr = addr;
            this.TypeInstr = typeinstr;
            this.cache = cache;
            
        }

        public Request(int addr, int typeinstr, Cache cache, byte data ) 
        {
            this.Addr = addr;
            this.TypeInstr = typeinstr;
            this.cache = cache;
            this.Datawrite = data;
        }
    }
}
