namespace RealEstateCredit.Domain.ValueObjects
{
    public record LoanAmount
    {
        private const double MINIMUM_AMOUNT = 50000;
        public double value { get; init; }

        public LoanAmount(double input)
        {
            if (input < MINIMUM_AMOUNT)
            {
                throw new ArgumentOutOfRangeException("Loan amount should be superior to " + MINIMUM_AMOUNT);
            }
            value = input;
        }

        public LoanAmount(string input)
        {
            try
            {
                value = Convert.ToInt32(input);

                if (value < MINIMUM_AMOUNT)
                {
                    throw new ArgumentOutOfRangeException("Loan amount should be superior to " + MINIMUM_AMOUNT);
                }
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(ArgumentOutOfRangeException))
                {
                    throw new ArgumentException("Loan amount must be strictly positive integer and superior to " + MINIMUM_AMOUNT);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
