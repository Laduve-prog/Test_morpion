using RealEstateCredit.Domain;
using RealEstateCredit.Domain.ValueObjects;


namespace RealEstateCredit.Tests
{
    public class CreditInfoTests
    {
        [Theory]
        [InlineData(200000, 180, 2, 1287.02)]
        public void GetMonthlyPayment_ReturnsCorrectValue(double loanAmount, int monthsDuration, double nominalRate, double expected)
        {
            // Arrange
            var creditInfo = new CreditInfo(new LoanAmount(loanAmount), new CreditDurationInMonth(monthsDuration), new NominalRate(nominalRate));

            // Act
            var result = creditInfo.GetMonthlyPayment();

            // Assert
            Assert.Equal(expected, result, 2);
        }

        [Theory]
        [InlineData(200000, 180, 2, 231663.13)]
        public void GetTotalAmountWithInterest_ReturnsCorrectValue(double loanAmount, int monthsDuration, double nominalRate , double expected)
        {
            // Arrange
            var creditInfo = new CreditInfo(new LoanAmount(loanAmount), new CreditDurationInMonth(monthsDuration), new NominalRate(nominalRate));

            // Act
            var result = creditInfo.GetTotalAmountWithInterest();

            // Assert
            Assert.Equal(expected, result, 2); 
        }

        [Theory]
        [InlineData(200000, 180, 2, 179 , 1284.9)]
        [InlineData(200000, 180, 2, 0, 953.67)]
        [InlineData(200000, 180, 2, 1, 955.26)]
        public void GetAmortization_ReturnsCorrectValue(double loanAmount, int monthsDuration, double nominalRate, int monthPaid , double expectedTotalPrincipal)
        {
            // Arrange
            var creditInfo = new CreditInfo(new LoanAmount(loanAmount), new CreditDurationInMonth(monthsDuration), new NominalRate(nominalRate));

            // Act
            var result = creditInfo.GetAmortization();

            // Assert
            Assert.Equal(expectedTotalPrincipal, Math.Round(result[monthPaid],2), 1);
        }

        [Theory]
        [InlineData(200000, 180, 2, 179, 2.1)]
        [InlineData(200000, 180, 2, 0, 333.32)]
        [InlineData(200000, 180, 2, 1, 331.74)]
        public void GetInterests_ReturnsCorrectValue(double loanAmount, int monthsDuration, double nominalRate, int monthPaid, double expectedTotalInterest)
        {
            // Arrange
            var creditInfo = new CreditInfo(new LoanAmount(loanAmount), new CreditDurationInMonth(monthsDuration), new NominalRate(nominalRate));

            // Act
            var result = creditInfo.GetInterests();

            // Assert
            Assert.Equal(expectedTotalInterest, Math.Round(result[monthPaid], 2),1);
        }

        [Theory]
        [InlineData(200000, 180, 2, 3, 196175.72)]
        [InlineData(200000, 180, 2, 179, 0)]
        [InlineData(200000, 180, 2, 0, 199046.32)]
        public void GetRemainingPrincipalDue_ReturnsCorrectValue(double loanAmount, int monthsDuration, double nominalRate, int paidMonths, double expectedRemainingPrincipal)
        {
            // Arrange
            var creditInfo = new CreditInfo(new LoanAmount(loanAmount), new CreditDurationInMonth(monthsDuration), new NominalRate(nominalRate));

            // Act
            var result = creditInfo.GetRemainingPrincipalDue();

            // Assert
            Assert.Equal(expectedRemainingPrincipal, result[paidMonths], 1);
        }

        [Theory]
        [InlineData(200000, 180, 2, 200000)]
        public void GetCumulativeMonthlyPrincipalPayment_ReturnsCorrectValue(double loanAmount, int monthsDuration, double nominalRate, double expectedTotalCumulativePayment)
        {
            // Arrange
            var creditInfo = new CreditInfo(new LoanAmount(loanAmount), new CreditDurationInMonth(monthsDuration), new NominalRate(nominalRate));

            // Act
            var result = creditInfo.GetCumulativeMonthlyPrincipalPayment();

            // Assert
            Assert.Equal(expectedTotalCumulativePayment, result[monthsDuration - 1], 2);
        }
    }
}
