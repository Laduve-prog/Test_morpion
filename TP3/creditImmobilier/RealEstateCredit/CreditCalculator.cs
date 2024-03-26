using RealEstateCredit.Models;
using RealEstateCredit.ReportsGenerator;
using RealEstateCredit.UI;
using RealEstateCredit.Calculations;
using RealEstateCredit.Interfaces;


public class CreditCalculator
{
    public static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            displayView.PrintUsage();
            return;
        }
        else
        {
            try
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory + "/../../../Reports/";
                string fileName = "report_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                ICreditCalculator calculator = new Calculator();

                LoanProcessor processor = new LoanProcessor(calculator);
                CreditEstimation creditEstimation = processor.ProcessLoan(args[0], args[1], args[2]);

                CsvCreditReportGenerator.GenerateCsvCreditReport(creditEstimation, projectPath+fileName);
            }
            catch ( Exception e)
            {
                displayView.PrintError(e.Message);
            }
        }
    }
}

