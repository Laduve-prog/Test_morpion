
using RealEstateCredit.ReportsGenerator;

namespace RealEstateCreditTest
{
    public class CsvCreditReportGeneratorTest
    {
        [Theory]
        [InlineData(new string[] { "1", "2", "3" }, "1|2|3")]
        [InlineData(new string[] { }, "")] 
        public void FormatRow_ValidInput_FormatsCorrectly(string[] input, string expectedOutput)
        {
            string result = CsvCreditReportGenerator.FormatRow(input);

            Assert.Equal(expectedOutput, result);
        }
    }
}
