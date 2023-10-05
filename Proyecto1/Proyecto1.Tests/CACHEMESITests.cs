using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Tests
{
    [TestClass]
    public class CACHEMESITests
    {

        [TestMethod]
        public void OneCacheTest()
        {
            TopLevel top = new TopLevel();

            top.Cache1.WriteAddr(0, 1);
            Assert.AreEqual(1, top.Cache1.cacheLines[0].data[0]);
            Assert.AreEqual(StateMachineMESI.MesiState.Modified, top.Cache1.cacheLines[0].StateMachine.GetCurrentState());
            
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
        public void BinaryAddress()
        {
            int addr = 0;

            string binaryAddr = Convert.ToString(addr, 2);
            int desiredLength = 6;
            if (binaryAddr.Length < desiredLength)
            {
                binaryAddr = binaryAddr.PadLeft(desiredLength, '0');
            }

            Assert.AreEqual("000000",binaryAddr );

            string strTag = binaryAddr[..2];
            int tag = Convert.ToInt32(strTag, 2);

            Assert.AreEqual(0, tag);

            string strOf = binaryAddr.Substring(4, 2);
            int offset = Convert.ToInt32(strOf, 2);

            Assert.AreEqual(0, offset);
        }
    }
}
