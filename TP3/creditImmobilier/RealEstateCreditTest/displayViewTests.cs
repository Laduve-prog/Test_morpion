using RealEstateCredit.UI;

namespace RealEstateCreditTest
{
    public class displayViewTests
    {
        [Fact]
        public void TestPrintUsage()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            displayView.PrintUsage();

            var expectedOutput = "Usage: RealEstateCredit <amount> <duration in months> <nominal rate>" + Environment.NewLine;
            Assert.Equal(expectedOutput, output.ToString());
        }
    }
}