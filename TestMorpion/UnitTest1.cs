using MorpionApp;
namespace TestMorpion
{
    public class UnitTest1
    {
        Morpion game = new Morpion();

        [Fact]
        public void TestVerifVictoire()
        {
            game.grille = new char[3, 3]
            {
                    { 'X', 'X', 'X'},
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
            };
            Assert.True(game.verifVictoire('X'));
        }

        [Fact]
        public void TestVerifEgalite()
        {
            game.grille = new char[3, 3]
            {
                    { 'X', 'O', 'X'},
                    { 'X', 'O', 'O'},
                    { 'O', 'X', 'O'},
            };
            Assert.True(game.verifEgalite());
        }
    }
}