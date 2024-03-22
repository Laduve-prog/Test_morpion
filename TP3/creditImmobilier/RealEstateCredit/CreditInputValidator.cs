using System;
namespace RealEstateCredit
{
    public class CreditInputValidator
    {
        private const int MINIMUM_AMOUNT = 50000;

        public static int amountValidation(string value)
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
    }
}
