using RealEstateCredit.Interfaces;

namespace RealEstateCredit.Calculations
{
    public class Calculator : ICreditCalculator
    {
        private const int MONTHS_IN_YEAR = 12;

        public double CalculateMonthlyInterestRate(double interestRate)
        {
            return interestRate / MONTHS_IN_YEAR;
        }

        public double CalculateMonthlyPayment(double loanAmount, int monthsDuration, double nominalRate)
        {
            double monthlyPayment;
            double monthlyInterestRate = CalculateMonthlyInterestRate(nominalRate);

            monthlyPayment = loanAmount * monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -monthsDuration));

            return Math.Round(monthlyPayment, 2, MidpointRounding.AwayFromZero);
        }

        public double CalculateTotalAmountWithInterest(double loanAmount, int monthsDuration, double nominalRate)
        {
            double totalAmount;
            double monthlyPayment = CalculateMonthlyPayment(loanAmount, monthsDuration, nominalRate);
            totalAmount = monthlyPayment * monthsDuration;
            return Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero);
        }

        public double CalculateTotalLeftToPay(double loanAmount, int monthsDuration, double nominalRate, double paidMonths)
        {
            double totalLeftToPay;
            double monthlyPayment = CalculateMonthlyPayment(loanAmount, monthsDuration, nominalRate);
            totalLeftToPay = monthlyPayment * (monthsDuration - paidMonths);
            return Math.Round(totalLeftToPay, 2, MidpointRounding.AwayFromZero);
        }

        public double TotalPaid(double monthlyPayment, double month)
        {
            return Math.Round(monthlyPayment * month, 2, MidpointRounding.AwayFromZero);
        }
    }
}
