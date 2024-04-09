using RealEstateCredit.Domain.ValueObjects;
using RealEstateCredit.UI;

namespace RealEstateCredit
{
    public class UserInputs
    {
        public readonly CreditDurationInMonth durationInMonths;
        public readonly LoanAmount amount;
        public readonly NominalRate nomimalRate;

        public UserInputs(string[] args) : this(args[0], args[1], args[2])
        {
        }

        public UserInputs(string amount, string durationInMonths, string nomimalRate)
        {
            this.durationInMonths = new CreditDurationInMonth(durationInMonths);
            this.amount = new LoanAmount(amount);
            this.nomimalRate = new NominalRate(nomimalRate);
        }

    }
}
