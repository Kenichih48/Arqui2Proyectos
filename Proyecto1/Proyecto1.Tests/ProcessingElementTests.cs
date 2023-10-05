namespace Proyecto1.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="ProcessingElement"/> class.
    /// </summary>
    [TestClass]
    public class ProcessingElementTests
    {
        /// <summary>
        /// Tests the <see cref="ProcessingElement.GenerateInstructions"/> method.
        /// </summary>
        [TestMethod]
        public void TestGenerateInstructions()
        {
            /*
            // Arrange
            int id = 1;
            int minInstrs = 5;
            int maxInstrs = 10;
            ProcessingElement pe = new(id, minInstrs, maxInstrs);

            // Act
            pe.GenerateInstructions();

            // Assert
            Assert.IsNotNull(pe.InstrList);
            Assert.IsTrue(pe.InstrList.Count >= minInstrs && pe.InstrList.Count <= maxInstrs + 2);
            */
        }

        /// <summary>
        /// Tests an invalid instruction format scenario.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestInvalidInstructionFormat()
        {
            int id = 1;
            int minInstrs = 1;
            int maxInstrs = 1;
            TopLevel top = new TopLevel(minInstrs,maxInstrs);
            // Arrange
            
            ProcessingElement pe = top.PE1;
            pe.InstrList.Add("read 0x34 rax");

            // Act
            pe.ExecuteAll();
            
        }
    }
}