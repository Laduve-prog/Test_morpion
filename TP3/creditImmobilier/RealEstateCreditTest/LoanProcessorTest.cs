using RealEstateCredit.Interfaces;
using Moq;

namespace RealEstateCreditTest
{
    public class LoanProcessorTests
    {
        [Theory]
        [InlineData("100000", "108", "5")]
        [InlineData("50000", "109", "5")] 
        public void ProcessLoan_ValidInputs_ReturnsCreditEstimation(string loanAmountStr, string monthsDurationStr, string nominalRateStr)
        {
            var calculatorMock = new Mock<ICreditCalculator>();
            var loanProcessor = new LoanProcessor(calculatorMock.Object);

            var result = loanProcessor.ProcessLoan(loanAmountStr, monthsDurationStr, nominalRateStr);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("100000", "-12", "5")]
        [InlineData("100000", "12", "-5")]
        [InlineData("abc", "12", "5")]
        [InlineData("100000", "abc", "5")]
        public void ProcessLoan_InvalidInputs_ReturnsException(string loanAmountStr, string monthsDurationStr, string nominalRateStr)
        {
            var calculatorMock = new Mock<ICreditCalculator>();
            var loanProcessor = new LoanProcessor(calculatorMock.Object);

            Assert.Throws<ArgumentException>(() => loanProcessor.ProcessLoan(loanAmountStr, monthsDurationStr, nominalRateStr));
        }
    }
}
