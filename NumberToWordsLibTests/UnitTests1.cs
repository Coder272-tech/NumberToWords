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
        public void ConvertAmountToWords_TestMillions1()
        {
            // Arrange
            decimal amount = 5467087.89M;
            //string expected = "Two thousand five hundred twenty-three and 04/100 dollars";
            string expected = "Five million four hundred sixty-seven thousand eighty-seven and 89/100 dollars";

            // Act
            var processor = new NumberToWordsProcessor();
            string result = processor.Convert(amount);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertAmountToWords_TestBillions1()
        {
            // Arrange
            decimal amount = 238987123123.40M;
            //string expected = "Two thousand five hundred twenty-three and 04/100 dollars";
            string expected = "Two hundred thirty-eight billion nine hundred eighty-seven million one hundred twenty-three thousand one hundred twenty-three and 40/100 dollars";

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