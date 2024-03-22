using System;
namespace RealEstateCredit
{
    public class CreditInputValidator
    {
        private const int MINIMUM_AMOUNT = 50000;
        private const int MINIMUM_DURATION = 108;
        private const int MAXIMUM_DURATION = 300;
        private const int MINIMUM_RATE = 0;

        public static int ValidateAmount(string value)
        {
            int loanAmount;

            if (!int.TryParse(value, out loanAmount))
            {
                throw new ArgumentException("Invalid format for loanAmount");
            }
            else
            {
                if(loanAmount < MINIMUM_AMOUNT)
                {
                    throw new ArgumentException("loanAmount should be superior to 50k");
                }
            }

            return loanAmount;
        }

        public static int ValidateDuration(string value)
        {
            int monthsDuration;

            if (!int.TryParse(value, out monthsDuration))
            {
                throw new ArgumentException("Invalid format for monthsDuration");
            }
            else
            {
                if(monthsDuration <= MINIMUM_DURATION)
                {
                    throw new ArgumentException("monthsDuration should be superior or equal to " + MINIMUM_DURATION);
                }
                else if(monthsDuration > MAXIMUM_DURATION)
                {
                    throw new ArgumentException("monthsDuration should be inferior or equal to " + MAXIMUM_DURATION);
                }
            }

            return monthsDuration;
        }

        public static double ValidateRate(string value)
        {
            double nominalRate;

            if (!double.TryParse(value, out nominalRate))
            {
                throw new ArgumentException("Invalid format for nominalRate");
            }
            else
            {
                if(nominalRate < MINIMUM_RATE)
                {
                    throw new ArgumentException("nominalRate should be superior to 0");
                }
            }

            return nominalRate/100;
        }   
    }
}
