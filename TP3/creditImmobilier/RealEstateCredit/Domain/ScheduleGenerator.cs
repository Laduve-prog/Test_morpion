using RealEstateCredit.Interfaces;

namespace RealEstateCredit.Domain
{
    public class ScheduleGenerator
    {
        private IFileSystem _fileSystem { get; }
        private IClock _clock {get; }
        public ScheduleGenerator(IFileSystem fileSystem, IClock clock)
        {
            _fileSystem = fileSystem;
            _clock = clock;
        }

        public void GenerateCsvCreditReport(CreditInfo credit)
        {
            try
            {
                string fileName = "report_" + _clock.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                List<string[]> csvData = credit.createReceipt();
                _fileSystem.SaveResult(csvData, fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error generating report: ", e.Message);
            }
        }
    }
}
