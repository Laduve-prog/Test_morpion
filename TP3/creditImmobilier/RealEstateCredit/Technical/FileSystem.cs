using RealEstateCredit.Interfaces;

namespace RealEstateCredit.Technical
{
    internal class FileSystem : IFileSystem
    {
        private const char DELIMITER = '|';

        public double GetInfoFromFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public void SaveResult(List<string[]> data, string fileName)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/../../../Reports/" + fileName;
            File.WriteAllLines(path,data.Select(row => FormatRow(row)));
        }

        public static string FormatRow(string[] row)
        {
            string[] formattedData = row.Select(value => value).ToArray();
            return string.Join(DELIMITER.ToString(), formattedData);
        }
    }
}
