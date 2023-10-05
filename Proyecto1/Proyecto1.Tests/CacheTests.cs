using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Tests
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void testCache()
        {
            /*
            // Arrange
            Cache cache = new Cache(10);

            // Act
            cache.WriteAddr(7,15);

            test_byte = cache.ReadAddr(7);

            // Assert
            Assert.AreEqual(7, test_byte);
            */
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Cache_Exception()
        {
            // Arrange
            /*
            Memory memory = new(64);
            int invalidAddress = 100;

            // Act
            _ = memory.ReadAddr(invalidAddress);

            // Assert (Exception is expected)
            */
        }

    }
}


