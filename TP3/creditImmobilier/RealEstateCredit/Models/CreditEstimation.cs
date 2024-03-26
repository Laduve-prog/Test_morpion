using RealEstateCredit.Interfaces;

namespace RealEstateCredit.Models
{
    public class CreditEstimation
    {
        internal CreditInfo CreditData { get; }
        private readonly ICreditCalculator calculator;

        public CreditEstimation(double loanAmount, int monthsDuration, double nominalRate, ICreditCalculator calculator)
        {
            CreditData = new CreditInfo(loanAmount, monthsDuration, nominalRate);
            this.calculator = calculator;
            Calculate();
        }

        public void Calculate()
        {
            CreditData.CalculateDetails(calculator);
        }

        public List<string[]> createReceipt()
        {
            List<string[]> data = [["Total Payment", CreditData.TotalAmountWithInterest.ToString()]];

            for (int month = 1; month <= CreditData.MonthsDuration; month++)
            {
                double totalPaid = calculator.TotalPaid(CreditData.MonthlyPayment, month);
                double remainingBalance = calculator.CalculateTotalLeftToPay(CreditData.LoanAmount, CreditData.MonthsDuration, CreditData.NominalRate, month);
                data.Add([month.ToString(), CreditData.MonthlyPayment.ToString(), totalPaid.ToString(), remainingBalance.ToString()]);
            }

            return data;
        }
    }
}
