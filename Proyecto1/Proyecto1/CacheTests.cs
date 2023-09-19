using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Proyecto1.Tests
{
    [TestClass]
    public class CacheTests
    {
        [TestMethod]
        public void testCache()
        {
            // Arrange
            Cache cache = new Cache(10);

            // Act
            cache.WriteAddr(7,15);

            byte test_byte = cache.ReadAddr(7);

            // Assert
            Assert.AreEqual(7, test_byte);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Cache_Exception()
        {
            // Arrange
            Cache cache = new Cache(10);

            // Act
            cache.WriteAddr(9, 20);

            byte test_byte = cache.ReadAddr(11);

            // Assert (Exception is expected)
        }

    }
}


