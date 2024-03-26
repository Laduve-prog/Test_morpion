using RealEstateCredit.Models;

namespace RealEstateCredit.ReportsGenerator
{
    public static class CsvCreditReportGenerator
    {
        private const char DELIMITER = '|';

        public static void GenerateCsvCreditReport(CreditEstimation credit, string filePath)
        {
            try
            {
                List<string[]> csvData = credit.createReceipt();
                File.WriteAllLines(filePath, csvData.Select(row => FormatRow(row)));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error generating report: ", e.Message);
            }
        }

        public static string FormatRow(string[] row)
        {
            string[] formattedData = row.Select(value => value).ToArray();
            return string.Join(DELIMITER.ToString(), formattedData);
        }
    }
}
