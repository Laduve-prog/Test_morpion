using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RealEstateCredit.Domain.ValueObjects
{
    public record NominalRate
    {
        private const int MINIMUM_RATE = 0;

        public double value { get; init; }

        public NominalRate(double input)
        {
            if (input < MINIMUM_RATE)
            {
                throw new ArgumentOutOfRangeException("Nominal rate must be positive.");
            }
            value = input;
        }

        public NominalRate(string input)
        {
            try
            {
                value = Convert.ToDouble(input);

                if (value < MINIMUM_RATE)
                {
                    throw new ArgumentOutOfRangeException("Nominal rate must be positive.");
                }
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(ArgumentOutOfRangeException))
                {
                    throw new ArgumentException("Nominal rate must be a strictly positive integer");
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
