using RealEstateCredit;

namespace RealEstateCreditTest
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(200000, 180, 0.02, 1287)]
        public void CalculateMonthlyPayment_ReturnsCorrectValue(double loanAmount, double monthsDuration, double nominalRate, double expected)
        {
            var result = _calculator.CalculateMonthlyPayment(loanAmount, monthsDuration, nominalRate);
            Assert.Equal(expected, result, 0);
        }

        [Theory]
        [InlineData(200000, 180, 0.02, 231663)]
        public void CalculateTotalAmount_ReturnsCorrectValue(double loanAmount, double monthsDuration, double nominalRate, double expected)
        {
            var result = _calculator.CalculateTotalAmount(loanAmount, monthsDuration, nominalRate);
            Assert.Equal(expected, result, 0);
        }

        [Theory]
        [InlineData(0.05, 0.00416666666666667)]
        public void CalculateMonthlyInterestRate_ReturnsCorrectValue(double interestRate, double expected)
        {
            var result = _calculator.CalculateMonthlyInterestRate(interestRate);
            Assert.Equal(expected, result, 15);
        }
    }
}
