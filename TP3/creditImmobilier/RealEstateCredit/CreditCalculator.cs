using RealEstateCredit;

public class CreditCalculator
{
    public static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            displayView.PrintUsage();
        }
        else
        {
            try
            {
                int loanAmount = CreditInputValidator.ValidateAmount(args[0]);
                int monthsDuration = CreditInputValidator.ValidateDuration(args[1]);
                double nominalRate = CreditInputValidator.ValidateRate(args[2]);

                Calculator calculator = new Calculator();
                calculator.CalculateTotalAmountWithInterest(loanAmount, monthsDuration, nominalRate);

            }
            catch
            {

            }
        }
    }
}

