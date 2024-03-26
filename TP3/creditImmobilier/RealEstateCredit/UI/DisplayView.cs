namespace RealEstateCredit.UI
{
    public static class displayView
    {
        public static void PrintUsage()
        {
            Console.WriteLine("Usage: RealEstateCredit <amount> <duration in months> <nominal rate>");
        }

        public static void PrintError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
