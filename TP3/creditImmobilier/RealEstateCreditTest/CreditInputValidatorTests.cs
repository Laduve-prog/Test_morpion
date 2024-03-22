using Xunit;
using RealEstateCredit;
using System;

namespace RealEstateCreditTest
{
    public class CreditInputValidatorTests
    {
        [Fact]
        public void TestAmountValidation_ValidAmount_ReturnsAmount()
        {
            string validAmount = "60000";
            int expected = 60000;
            int actual = CreditInputValidator.amountValidation(validAmount);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAmountValidation_InvalidFormat_ThrowsException()
        {
            string invalidFormat = "invalid";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.amountValidation(invalidFormat));
        }

        [Fact]
        public void TestAmountValidation_AmountLessThanMinimum_ThrowsException()
        {
            string lessThanMinimum = "40000";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.amountValidation(lessThanMinimum));
        }
    }
}
