using RealEstateCredit.Interfaces;

namespace RealEstateCredit.Models
{
    public class CreditInfo
    {
        public double LoanAmount { get; }
        public int MonthsDuration { get; }
        public double NominalRate { get; }
        public double MonthlyPayment { get; private set; }
        public double TotalAmountWithInterest { get; private set; }

        public CreditInfo(double loanAmount, int monthsDuration, double nominalRate)
        {
            LoanAmount = loanAmount;
            MonthsDuration = monthsDuration;
            NominalRate = nominalRate;
        }

        public void CalculateDetails(ICreditCalculator calculator)
        {
            MonthlyPayment = calculator.CalculateMonthlyPayment(LoanAmount, MonthsDuration, NominalRate);
            TotalAmountWithInterest = calculator.CalculateTotalAmountWithInterest(LoanAmount, MonthsDuration, NominalRate);
        }
    }
}
