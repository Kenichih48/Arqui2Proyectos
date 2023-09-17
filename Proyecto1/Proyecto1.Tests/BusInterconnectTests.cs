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
    }
}
