using RealEstateCredit.Interfaces;

namespace RealEstateCreditTest.Fixtures
{
    internal class FakeFileSystem : IFileSystem
    {
        public Dictionary<string, double> keyValuePairs { get; private set; } = new();

        public double GetInfoFromFile(string fileName)
        {
            return keyValuePairs[fileName];
        }

        public void SaveResult(List<string[]> data, string fileName)
        {
            //keyValuePairs[fileName] = ;
        }
    }
}
