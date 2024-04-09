using RealEstateCredit.UI;

namespace RealEstateCredit.Tests
{
    public class UserInputsTests
    {
        [Theory]
        [InlineData(new string[] { "100000", "108", "4,1" }, 100000, 108, 4.1)]
        [InlineData(new string[] { "200000", "300", "1,5" }, 200000, 300, 1.5)]
        public void UserInputs_ValidArgs_CreatesInstance(string[] args, int expectedAmount, int expectedDuration, double expectedRate)
        {
            var userInputs = new UserInputs(args);

            Assert.Equal(expectedDuration, userInputs.durationInMonths.value);
            Assert.Equal(expectedAmount, userInputs.amount.value);
            Assert.Equal(expectedRate, userInputs.nomimalRate.value);
        }


        [Theory]
        [InlineData(new string[] { "100000", "1", "-4" }, typeof(ArgumentOutOfRangeException))]
        [InlineData(new string[] { "100000", "-1", "4" }, typeof(ArgumentOutOfRangeException))]
        [InlineData(new string[] { "100000", "408", "4" }, typeof(ArgumentOutOfRangeException))]
        [InlineData(new string[] { "-1", "108", "4" }, typeof(ArgumentOutOfRangeException))]
        [InlineData(new string[] { "100000", "108", "," }, typeof(ArgumentException))]
        [InlineData(new string[] { ",", "108", "4,1" }, typeof(ArgumentException))]
        [InlineData(new string[] { "100000", ",", "4,1" }, typeof(ArgumentException))]
        public void UserInputs_InvalidArgs_ThrowsException(string[] args, Type expectedExceptionType)
        {
            // Arrange & Act & Assert
            Assert.Throws(expectedExceptionType, () => new UserInputs(args));
        }
    }
}