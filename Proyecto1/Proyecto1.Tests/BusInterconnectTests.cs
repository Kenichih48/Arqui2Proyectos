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
            byte[] data = { 0b01101000 };
            Bus.updateAddrBus(8);
            Bus.updateDataBus(data);
            Bus.updateSharedBus(data);

            //Assert

            Assert.AreEqual(8, Bus.AddrBus);
            Assert.AreEqual(data, Bus.DataBus);
            Assert.AreEqual(data, Bus.SharedBus);
        }
    }
}
