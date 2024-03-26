using RealEstateCredit.Interfaces;
using RealEstateCredit.Models;
using RealEstateCredit.Validators;

public class LoanProcessor
{
    private readonly ICreditCalculator calculator;

    public LoanProcessor(ICreditCalculator calculator)
    {
        this.calculator = calculator;
    }

    public CreditEstimation ProcessLoan(string loanAmountStr, string monthsDurationStr, string nominalRateStr)
    {
        int loanAmount = CreditInputValidator.ValidateAmount(loanAmountStr);
        int monthsDuration = CreditInputValidator.ValidateDuration(monthsDurationStr);
        double nominalRate = CreditInputValidator.ValidateRate(nominalRateStr);

        return new CreditEstimation(loanAmount, monthsDuration, nominalRate, calculator);
    }
}