using NumberToWordsLib;

namespace NumberToWordsLibTests
{
    [TestClass]
    public class UnitTests1
    {
        [TestMethod]
        public void ConvertAmountToWords_ShouldReturnCorrectString()
        {
            // Arrange
            decimal amount = 2523.04M;
            string expected = "Two thousand five hundred twenty-three and 04/100 dollars";

            // Act
            var processor = new NumberToWordsProcessor();
            string result = processor.Convert(amount);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertAmountToWords_LessThanTenDollars1()
        {
            // Arrange
            decimal amount = 9.12M;
            string expected = "Nine and 12/100 dollars";

            // Act
            var processor = new NumberToWordsProcessor();
            string result = processor.Convert(amount);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}