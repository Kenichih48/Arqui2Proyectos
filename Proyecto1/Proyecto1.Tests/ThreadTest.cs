using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Tests
{
    [TestClass]
    public class ThreadTest
    {


        [TestMethod]
        public void Test()
        {
            TopLevel top = new TopLevel("MOESI");

            top.PE1.instrList = new List<string>() { "read 0 r1", "incr r1","write 0 r1","read 16 r1" };
            top.PE2.instrList = new List<string>() { "read 0 r2", "incr r2", "incr r2", "write 0 r2", "read 16 r2" };
            top.PE3.instrList = new List<string>() { "read 4 r3", "incr r3", "write 0 r3", "read 16 r3"};

            top.StartThreads();
            
            byte[] data = top.Memory.ReadAddr(0);
            Assert.AreEqual(2, data[0]);
        }
    }
}
