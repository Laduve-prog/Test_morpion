using realEstateCredit;

namespace testCreditImmobilier
{
    public class displayViewTests
    {
        [Fact]
        public void TestPrintUsage()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            displayView.PrintUsage();

            var expectedOutput = "Usage: creditImmobilier <montant> <duree> <taux>" + Environment.NewLine;
            Assert.Equal(expectedOutput, output.ToString());
        }
    }
}