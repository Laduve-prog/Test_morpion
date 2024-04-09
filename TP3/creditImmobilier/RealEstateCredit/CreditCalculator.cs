using RealEstateCredit.UI;
using RealEstateCredit.Domain;
using RealEstateCredit.Domain.ValueObjects;
using RealEstateCredit.Technical;
using RealEstateCredit;


public class CreditCalculator
{
    public static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            displayView.PrintUsage();
            return;
        }

        var inputs = new UserInputs(args);

        CreditInfo credit = new CreditInfo(inputs.amount, inputs.durationInMonths, inputs.nomimalRate );

        Clock clock = new Clock();
        FileSystem fileSystem = new FileSystem();

        ScheduleGenerator scheduleGenerator = new ScheduleGenerator(fileSystem, clock);
        scheduleGenerator.GenerateCsvCreditReport(credit);
    }
}

