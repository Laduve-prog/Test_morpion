using Xunit;
using System;
using RealEstateCredit.Validators;

namespace RealEstateCreditTest
{
    public class CreditInputValidatorTests
    {
        [Fact]
        public void TestAmountValidation_ValidAmount_ReturnsAmount()
        {
            string validAmount = "60000";
            int expected = 60000;
            int actual = CreditInputValidator.ValidateAmount(validAmount);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAmountValidation_InvalidFormat_ThrowsException()
        {
            string invalidFormat = "invalid";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.ValidateAmount(invalidFormat));
        }

        [Fact]
        public void TestAmountValidation_AmountLessThanMinimum_ThrowsException()
        {
            string lessThanMinimum = "40000";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.ValidateAmount(lessThanMinimum));
        }

        [Fact]
        public void TestDurationValidation_ValidDuration_ReturnsDuration()
        {
            string validDuration = "120";
            int expected = 120;
            int actual = CreditInputValidator.ValidateDuration(validDuration);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDurationValidation_InvalidFormat_ThrowsException()
        {
            string invalidFormat = "invalid";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.ValidateDuration(invalidFormat));
        }

        [Fact]
        public void TestDurationValidation_DurationLessThanMinimum_ThrowsException()
        {
            string lessThanMinimum = "100";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.ValidateDuration(lessThanMinimum));
        }

        [Fact]
        public void TestDurationValidation_DurationMoreThanMaximum_ThrowsException()
        {
            string moreThanMaximum = "400";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.ValidateDuration(moreThanMaximum));
        }

        [Fact]
        public void TestRateValidation_ValidRate_ReturnsRate()
        {
            string validRate = "5";
            double expected = 0.05;
            double actual = CreditInputValidator.ValidateRate(validRate);
            Assert.Equal(expected, actual , 2);
        }

        [Fact]
        public void TestRateValidation_InvalidFormat_ThrowsException()
        {
            string invalidFormat = "invalid";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.ValidateRate(invalidFormat));
        }

        [Fact]
        public void TestRateValidation_RateLessThanMinimum_ThrowsException()
        {
            string lessThanMinimum = "-1";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.ValidateRate(lessThanMinimum));
        }
    }
}
