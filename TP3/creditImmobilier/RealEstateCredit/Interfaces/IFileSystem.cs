namespace RealEstateCredit.Interfaces
{
    public interface IFileSystem
    {
        public void SaveResult(List<string[]> data, string fileName);
        public double GetInfoFromFile(string fileName);
    }
}
