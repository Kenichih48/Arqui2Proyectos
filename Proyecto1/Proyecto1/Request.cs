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
        private int addr {  get; set; }
        private int type {  get; set; }
        private int id { get; set; }
        private int tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <param name="tag"></param>
        public Request(int addr, int type, int id, int tag) 
        { 
            this.addr = addr;
            this.type = type;
            this.id = id;
            this.tag = tag;
            
        }
    }
}
