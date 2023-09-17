namespace Proyecto1.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="Memory"/> class.
    /// </summary>
    [TestClass]
    public class MemoryTests
    {
        /// <summary>
        /// Verifies that a <see cref="Memory"/> instance is created with the specified size.
        /// </summary>
        [TestMethod]
        public void Memory_Constructor_SizeIsMultipleOf4()
        {
            // Arrange
            int sizeInBytes = 64;

            // Act
            Memory memory = new(sizeInBytes);

            // Assert
            Assert.IsNotNull(memory);
        }

        /// <summary>
        /// Verifies that attempting to create a <see cref="Memory"/> instance 
        /// with an invalid size throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Memory_Constructor_InvalidSize()
        {
            // Arrange
            int invalidSize = 45; // Not a multiple of 4

            // Act
            _ = new Memory(invalidSize);

            // Assert (Exception is expected)
        }

        /// <summary>
        /// Verifies that reading from a valid memory address returns the expected data.
        /// </summary>
        [TestMethod]
        public void Memory_ReadAddr_ValidAddress()
        {
            // Arrange
            Memory memory = new(64);
            int address = 10;
            byte expectedData = 42;

            // Act
            memory.WriteByte(address, expectedData);
            byte actualData = memory.ReadAddr(address);

            // Assert
            Assert.AreEqual(expectedData, actualData);
        }

        /// <summary>
        /// Verifies that attempting to read from an invalid memory address throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Memory_ReadAddr_InvalidAddress()
        {
            // Arrange
            Memory memory = new(64);
            int invalidAddress = 100;

            // Act
            _ = memory.ReadAddr(invalidAddress);

            // Assert (Exception is expected)
        }

        /// <summary>
        /// Verifies that attempting to write to an invalid memory address throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Memory_WriteByte_InvalidAddress()
        {
            // Arrange
            Memory memory = new(64);
            int invalidAddress = 100;
            byte data = 75;

            // Act
            memory.WriteByte(invalidAddress, data);

            // Assert (Exception is expected)
        }
    }
}