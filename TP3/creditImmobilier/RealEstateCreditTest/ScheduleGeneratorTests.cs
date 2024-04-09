using RealEstateCredit.Domain;
using RealEstateCredit.Domain.ValueObjects;
using RealEstateCreditTest.Fixtures;

namespace RealEstateCreditTest
{
    public class ScheduleGeneratorTests
    {
        [Theory]
        [InlineData(50000, 108, 0.01)]
        public void ShouldGenerateCsvReportWithData(double amount, int duration, double rate)
        {
            var fakeFileSystem = new FakeFileSystem();
            var fakeClock = new FakeClock(DateTime.Now);
            var scheduleGenerator = new ScheduleGenerator(fakeFileSystem, fakeClock);

            var credit = new CreditInfo(new LoanAmount(amount), new CreditDurationInMonth(duration), new NominalRate(rate));

            scheduleGenerator.GenerateCsvCreditReport(credit);

            var csvData = credit.createReceipt();
            Assert.NotNull(csvData);
            Assert.NotEmpty(csvData);
            Assert.Equal(duration+6, csvData.Count);
            Assert.Equal("Loan Summary", csvData[0][0]);
            Assert.Equal("Total Cost:", csvData[1][0]);
            Assert.Equal("Loan Amount:", csvData[2][0]);
            Assert.Equal("Duration (Months):", csvData[3][0]);
            Assert.Equal("Nominal Rate (%):", csvData[4][0]);
            Assert.Equal("Month", csvData[5][0]);
            Assert.Equal("Principal Repaid", csvData[5][1]);
            Assert.Equal("Remaining Principal", csvData[5][2]);
            Assert.Equal("Monthly Payment", csvData[5][3]);
            Assert.Equal("Insurance", csvData[5][4]);
            Assert.Equal("Interest", csvData[5][5]);
        }
    }
}
