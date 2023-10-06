using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.Tests
{
    [TestClass]
    public  class CACHEMOESITests
    {


        [TestMethod]
        public void OneCacheTest()
        {

            TopLevel top = new TopLevel("MOESI");

            top.Cache1.WriteAddr(0, 1);
            Assert.AreEqual(1, top.Cache1.cacheLines[0].data[0]);
            Assert.AreEqual(StateMachine.State.Modified, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());

            top.Cache1.WriteAddr(1, 2);
            Assert.AreEqual(2, top.Cache1.cacheLines[0].data[1]);

            top.Cache1.WriteAddr(2, 3);
            Assert.AreEqual(3, top.Cache1.cacheLines[0].data[2]);

            top.Cache1.WriteAddr(1, 4);
            Assert.AreEqual(4, top.Cache1.cacheLines[0].data[1]);

            top.Cache1.WriteAddr(5, 8);
            Assert.AreEqual(8, top.Cache1.cacheLines[1].data[1]);

            byte data = top.Cache1.ReadAddr(0);
            Assert.AreEqual(1, data);

            byte data2 = top.Cache1.ReadAddr(1);
            Assert.AreEqual(4, data2);

            byte data3 = top.Cache1.ReadAddr(2);
            Assert.AreEqual(3, data3);
        }

        [TestMethod]
        public void TwoCacheTests()
        {
            TopLevel top = new TopLevel("MOESI");

            top.Cache1.WriteAddr(0, 1);
            Assert.AreEqual(1, top.Cache1.cacheLines[0].data[0]);


            byte data = top.Cache2.ReadAddr(0);
            Assert.AreEqual(StateMachine.State.Owned, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Shared, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            
            Assert.AreEqual(1, data);

            top.Cache2.WriteAddr(0, 2);
            Assert.AreEqual(2, top.Cache2.cacheLines[0].data[0]);

            Assert.AreEqual(StateMachine.State.Invalid, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Modified, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            byte data2 = top.Cache1.ReadAddr(0);
            Assert.AreEqual(StateMachine.State.Shared, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Owned, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(2, data2);

            top.Cache1.WriteAddr(0, 3);
            Assert.AreEqual(3, top.Cache1.cacheLines[0].data[0]);

            Assert.AreEqual(StateMachine.State.Invalid, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Modified, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            top.Cache2.ReadAddr(0);
            Assert.AreEqual(StateMachine.State.Owned, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Shared, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(2, data2);

            top.Cache1.ReadAddr(5);
            Assert.AreEqual(StateMachine.State.Exclusive, top.Cache1.cacheLines[1].StateMachine.GetCurrentState());
           
        }

        [TestMethod]
        public void ThreeCachetest()
        {
            TopLevel top = new TopLevel("MOESI");

            top.Cache1.WriteAddr(0, 1);
            Assert.AreEqual(1, top.Cache1.cacheLines[0].data[0]);

            byte data = top.Cache2.ReadAddr(0);
            Assert.AreEqual(StateMachine.State.Owned, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Shared, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(1, data);

            byte data2 = top.Cache3.ReadAddr(0);
            Assert.AreEqual(StateMachine.State.Owned, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Shared, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Shared, top.Cache3.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(1, data2);

            top.Cache3.WriteAddr(0, 5);
            
            Assert.AreEqual(StateMachine.State.Invalid, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Invalid, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Modified, top.Cache3.cacheLines[0].StateMachine.GetCurrentState());
            byte data3 = top.Cache2.ReadAddr(0);
            Assert.AreEqual(5, data3);

            Assert.AreEqual(StateMachine.State.Invalid, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Shared, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Owned, top.Cache3.cacheLines[0].StateMachine.GetCurrentState());

            byte data4 = top.Cache1.ReadAddr(5);
            Assert.AreEqual(StateMachine.State.Exclusive, top.Cache1.cacheLines[1].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Shared, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Owned, top.Cache3.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(0, data4);


        }

        [TestMethod]
        public void WriteBack()
        {
            TopLevel top = new TopLevel("MOESI");

            top.Cache1.WriteAddr(0, 10);
            Assert.AreEqual(10, top.Cache1.cacheLines[0].data[0]);
            Assert.AreEqual(StateMachine.State.Modified, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Console.WriteLine("-------");


            top.Cache1.ReadAddr(16);
            Assert.AreEqual(0, top.Cache1.cacheLines[0].data[0]);
            Assert.AreEqual(StateMachine.State.Exclusive, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            byte[] data = top.Memory.ReadAddr(0);
            Assert.AreEqual(10, data[0]);
            

            top.Cache1.ReadAddr(32);
            Assert.AreEqual(StateMachine.State.Exclusive, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            byte[] data2 = top.Memory.ReadAddr(0);
            Assert.AreEqual(10, data2[0]);
            

            top.Cache2.ReadAddr(32);
            Assert.AreEqual(StateMachine.State.Owned, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Shared, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(0, top.Cache2.cacheLines[0].data[0]);
            top.Cache1.cacheLines[0].data[0] = 30;
            
            top.Cache1.WriteAddr(48,20);
            Assert.AreEqual(StateMachine.State.Modified, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            byte[] data3 = top.Memory.ReadAddr(32);
            Assert.AreEqual(30, data3[0]);
            Assert.AreEqual(20, top.Cache1.cacheLines[0].data[0]);

        }

        [TestMethod]
        public void WriteBack2()
        {
            TopLevel top = new TopLevel("MOESI");

            top.Cache1.ReadAddr(0);
            Assert.AreEqual(0, top.Cache1.cacheLines[0].data[0]);
            Assert.AreEqual(StateMachine.State.Exclusive, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());

            top.Cache2.ReadAddr(0);
            Assert.AreEqual(StateMachine.State.Owned, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Shared, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());
            top.Cache1.cacheLines[0].data[0] = 10;

            top.Cache1.ReadAddr(16);
            Assert.AreEqual(StateMachine.State.Exclusive, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            Assert.AreEqual(StateMachine.State.Invalid, top.Cache2.cacheLines[0].StateMachine.GetCurrentState());

            byte[] data = top.Memory.ReadAddr(0);
            Assert.AreEqual(10, data[0]);
        }


    }
}
