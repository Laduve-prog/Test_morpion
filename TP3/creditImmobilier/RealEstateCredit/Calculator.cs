
namespace RealEstateCredit
{
    public class Calculator
    {
        private const int MONTHS_IN_YEAR = 12;

        public double CalculateMonthlyInterestRate(double interestRate)
        {
            return interestRate / MONTHS_IN_YEAR;
        }

        public double CalculateMonthlyPayment(double loanAmount, double monthsDuration, double nominalRate)
        {
            double monthlyPayment;
            double monthlyInterestRate = CalculateMonthlyInterestRate(nominalRate);

            monthlyPayment = (loanAmount * monthlyInterestRate) / (1 - (Math.Pow(1 + monthlyInterestRate,-monthsDuration)));
            
            return monthlyPayment;
        }

        public double CalculateTotalAmount(double loanAmount, double monthsDuration, double nominalRate)
        {
           double totalAmount;
           double monthlyPayment = CalculateMonthlyPayment(loanAmount, monthsDuration, nominalRate);
           totalAmount = monthlyPayment * monthsDuration;
           return totalAmount;
        }
    }
}
