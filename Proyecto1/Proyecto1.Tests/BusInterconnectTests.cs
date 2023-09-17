using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Tests
{
    [TestClass]
    public class BusInterconnectTests
    {
        //Arrange
        //Act
        //Assert

        /// <summary>
        /// Test the <see cref="BusInterconnect.MakeRequest(Request)"/> method
        /// </summary>
        [TestMethod]
        public void AddRequestTest()
        {
            //Arrange
            Cache cache = new Cache();
            Request request = new Request(0,0,cache);
            BusInterconnect Bus = new BusInterconnect();

            //Act

            Bus.MakeRequest(request);

            //Assert

            Request reqtest = Bus.GetNextRequest();

            Assert.IsNotNull(reqtest);
            Assert.AreEqual(request, reqtest);
        }

        [TestMethod]
        public void UpdateBus()
        {
            //Arrange
            BusInterconnect Bus = new BusInterconnect();

            //Act
            Bus.updateAddrBus(8);
            Bus.updateDataBus(1024);
            Bus.updateSharedBus(1024);

            //Assert

            Assert.AreEqual(8, Bus.AddrBus);
            Assert.AreEqual(1024, Bus.DataBus);
            Assert.AreEqual(1024, Bus.SharedBus);
        }
    }
}
