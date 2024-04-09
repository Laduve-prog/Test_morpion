using RealEstateCredit.Domain.ValueObjects;

namespace RealEstateCredit.Domain
{
    public class CreditInfo
    {
        public LoanAmount LoanAmount { get; }
        public CreditDurationInMonth MonthsDuration { get; }
        public NominalRate NominalRate { get; }

        private readonly double TotalAmountWithInterest; 
        private readonly double MonthlyPayment;
        private readonly double NominalRateInPercentagePerMonth;
        private readonly double[] Interests;
        private readonly double[] Amortization;
        private readonly double[] RemainingPrincipal;
        private readonly double[] CumulativeMonthlyPrincipalPayment;


        public CreditInfo(LoanAmount loanAmount, CreditDurationInMonth monthsDuration, NominalRate nominalRate)
        {
            LoanAmount = loanAmount;
            MonthsDuration = monthsDuration;
            NominalRate = nominalRate;
            NominalRateInPercentagePerMonth = nominalRate.value / 100 / 12;

            TotalAmountWithInterest = GetTotalAmountWithInterest();
            MonthlyPayment = GetMonthlyPayment();
            Amortization = GetAmortization();
            Interests = GetInterests();
            RemainingPrincipal = GetRemainingPrincipalDue();
            CumulativeMonthlyPrincipalPayment = GetCumulativeMonthlyPrincipalPayment();
        }

        public double GetMonthlyPayment()
        {
            double monthlyPayment = LoanAmount.value * NominalRateInPercentagePerMonth / (1 - Math.Pow(1 + NominalRateInPercentagePerMonth, -MonthsDuration.value));
            return monthlyPayment;
        }

        public double GetTotalAmountWithInterest()
        {
            double totalAmount;
            totalAmount = GetMonthlyPayment() * this.MonthsDuration.value;
            return totalAmount;
        }

        public double[] GetAmortization()
        {
            double[] amortization = new double[MonthsDuration.value];
            double monthlyPayment = GetMonthlyPayment();
            double remainingBalance = LoanAmount.value;

            for (int i = 0; i < MonthsDuration.value + 0; i++)
            {
                double interest = remainingBalance * NominalRateInPercentagePerMonth;
                double principal = monthlyPayment - interest;
                remainingBalance -= principal;
                amortization[i] = principal;
            }

           return amortization;
        }

        public double[] GetInterests()
        {
            double[] interests = new double[MonthsDuration.value];

            double monthlyPayment = GetMonthlyPayment();
            double remainingBalance = LoanAmount.value;

            for (int i = 0; i < MonthsDuration.value; i++)
            {
                double interest = remainingBalance * NominalRateInPercentagePerMonth;
                interests[i] = interest;
                remainingBalance -= monthlyPayment - interest;
            }

            return interests;
        }

        public double[] GetRemainingPrincipalDue()
        {
            double[] remainingPrincipal = new double[MonthsDuration.value];
            double remainingBalance = LoanAmount.value;

            for (int i = 0; i < MonthsDuration.value; i++)
            {
                remainingBalance -= Amortization[i];
                remainingPrincipal[i] = remainingBalance;
            }

            return remainingPrincipal;
        }

        public double[] GetCumulativeMonthlyPrincipalPayment()
        {
            double[] cumulativeCapitalPayment = new double[MonthsDuration.value];
            double cumulativePayment = 0;

            for (int i = 0; i < MonthsDuration.value; i++)
            {
                cumulativePayment += GetAmortization()[i];
                cumulativeCapitalPayment[i] = cumulativePayment;
            }

            return cumulativeCapitalPayment;
        }

        public List<string[]> createReceipt()
        {
            List<string[]> data =
            [
                new string[] { "Loan Summary" },
                new string[] { "Total Cost:", this.TotalAmountWithInterest.ToString("0.00") },
                new string[] { "Loan Amount:", this.LoanAmount.value.ToString("0.00") },
                new string[] { "Duration (Months):", this.MonthsDuration.value.ToString() },
                new string[] { "Nominal Rate (%):", this.NominalRate.value.ToString("0.00") },
                new string[] { "Month", "Principal Repaid", "Remaining Principal", "Monthly Payment", "Insurance", "Interest" },
            ];

            for (int month = 1; month <= MonthsDuration.value; month++)
            {
                double principalRepaid = CumulativeMonthlyPrincipalPayment[month -1];
                double amortization = Amortization[month -1];
                double interest = Interests[month -1];
                double monthlyPayment = MonthlyPayment;
                double remainingPrincipal = RemainingPrincipal[month -1];


                data.Add(new string[] {
                    month.ToString(),
                    Math.Round(principalRepaid, 2).ToString("0.00"),
                    Math.Round(remainingPrincipal, 2).ToString("0.00"),
                    Math.Round(monthlyPayment, 2).ToString("0.00"),
                    Math.Round(amortization, 2).ToString("0.00"),
                    Math.Round(interest, 2).ToString("0.00")
                });
            }

            return data;
        }
    }
}
