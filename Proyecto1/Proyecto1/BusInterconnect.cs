using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class BusInterconnect
    {
        static void Main(string[] args)
        {
            // Display the number of command line arguments.
            Console.WriteLine(args.Length);
        }

        private int AddrBus {  get; set; }
        private int DataBus {  get; set; }
        private int SharedBus { get; set; }
        private List<Request> queue {  get; set; }

        private BusInterconnect() 
        { 
            this.queue = new List<Request>();
        }

    }

    
}
