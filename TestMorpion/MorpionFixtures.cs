using MorpionApp;

namespace TestMorpion 
{
    public class MorpionFixtures
    {
        public static TheoryData<char[]> GenerateVictoryData(char player, int[] winningCells)
        {
            var testData = new TheoryData<char[]>();
            char[] grid = new char[9];
            for (int i = 0; i < 9; i++)
            {
                grid[i] = ' ';
            }

            foreach (int cell in winningCells)
            {
                grid[cell] = player;
            }

            testData.Add(grid);
            return testData;
        }

        public char[] CreateFullGrid(char player1, char player2)
        {
            char[] grid = new char[9];
            for (int i = 0; i < 9; i++)
            {
                grid[i] = (i % 2 == 0) ? player1 : player2;
            }
            return grid;
        }
    }
}