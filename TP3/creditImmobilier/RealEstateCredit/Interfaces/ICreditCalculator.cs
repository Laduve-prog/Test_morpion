
namespace RealEstateCredit.Interfaces
{
    public interface ICreditCalculator
    {
        double CalculateMonthlyPayment(double loanAmount, int monthsDuration, double nominalRate);
        double CalculateTotalAmountWithInterest(double loanAmount, int monthsDuration, double nominalRate);
        public double CalculateTotalLeftToPay(double loanAmount, int monthsDuration, double nominalRate, double paidMonths);
        public double TotalPaid(double monthlyPayment, double month);
    }
}
