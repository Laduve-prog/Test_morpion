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

        [Fact]
        public void TestDurationValidation_ValidDuration_ReturnsDuration()
        {
            string validDuration = "120";
            int expected = 120;
            int actual = CreditInputValidator.durationValidation(validDuration);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestDurationValidation_InvalidFormat_ThrowsException()
        {
            string invalidFormat = "invalid";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.durationValidation(invalidFormat));
        }

        [Fact]
        public void TestDurationValidation_DurationLessThanMinimum_ThrowsException()
        {
            string lessThanMinimum = "100";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.durationValidation(lessThanMinimum));
        }

        [Fact]
        public void TestDurationValidation_DurationMoreThanMaximum_ThrowsException()
        {
            string moreThanMaximum = "400";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.durationValidation(moreThanMaximum));
        }

        [Fact]
        public void TestRateValidation_ValidRate_ReturnsRate()
        {
            string validRate = "5";
            decimal expected = 5;
            decimal actual = CreditInputValidator.rateValidation(validRate);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRateValidation_InvalidFormat_ThrowsException()
        {
            string invalidFormat = "invalid";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.rateValidation(invalidFormat));
        }

        [Fact]
        public void TestRateValidation_RateLessThanMinimum_ThrowsException()
        {
            string lessThanMinimum = "-1";
            Assert.Throws<ArgumentException>(() => CreditInputValidator.rateValidation(lessThanMinimum));
        }
    }
}
