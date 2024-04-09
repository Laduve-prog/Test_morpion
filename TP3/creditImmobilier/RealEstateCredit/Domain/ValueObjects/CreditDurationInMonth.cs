
namespace RealEstateCredit.Domain.ValueObjects
{
    public record CreditDurationInMonth
    {

        private const int MINIMUM_DURATION = 108;
        private const int MAXIMUM_DURATION = 300;

        public int value { get; init; }

        public CreditDurationInMonth(int input)
        {
            if (input < MINIMUM_DURATION || input > MAXIMUM_DURATION)
            {
                throw new ArgumentOutOfRangeException("Credit duration in months must be between" + MINIMUM_DURATION + " and " + MAXIMUM_DURATION);
            }
            value = input;
        }

        public CreditDurationInMonth(string input)
        {
            try
            {
                value = Convert.ToInt32(input);

                if (value < MINIMUM_DURATION || value > MAXIMUM_DURATION)
                {
                    throw new ArgumentOutOfRangeException("Credit duration in months must be between" + MINIMUM_DURATION + " and " + MAXIMUM_DURATION);
                }
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(ArgumentOutOfRangeException))
                {
                    throw new ArgumentException("Credit duration in months must be between" + MINIMUM_DURATION + " and " + MAXIMUM_DURATION);
                }
                else
                {
                    throw;
                }
            }

        }
    }
}
