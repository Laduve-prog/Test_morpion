
namespace realEstateCredit
{
    public class MonthlyPaymentsCalculator
    {
        decimal loanAmount;
        int monthsDuration;
        decimal nominalRate;

        public MonthlyPaymentsCalculator(decimal _loanAmount, int _monthsDuration, decimal _nominalRate)
        {
            loanAmount = _loanAmount;
            monthsDuration = _monthsDuration;
            nominalRate = _nominalRate;
        }

        public decimal CalculateTotalAmount()
        {
            return 0;
        }
    }
}
