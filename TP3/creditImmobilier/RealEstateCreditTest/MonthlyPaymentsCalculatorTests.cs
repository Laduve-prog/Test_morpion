using realEstateCredit;

namespace testCreditImmobilier
{
    public class MonthlyPaymentsCalculatorTests
    {
        [Fact]
        public void TestCalculateTotalAmount()
        {
            // Arrange
            decimal loanAmount = 0;
            int monthsDuration = 0;
            decimal nominalRate = 0;
            MonthlyPaymentsCalculator calculator = new MonthlyPaymentsCalculator(loanAmount, monthsDuration, nominalRate);

            // Act
            decimal totalAmount = calculator.CalculateTotalAmount();

            // Assert
            decimal expectedTotalAmount = 0;
            Assert.Equal(expectedTotalAmount, totalAmount);
        }
    }
}
