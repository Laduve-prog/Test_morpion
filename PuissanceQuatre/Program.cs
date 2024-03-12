using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Program
    {

        static void Main(string[] args)
        {

            SelecteurJeu selecteurJeu = new SelecteurJeu();
            ConsoleUtilisateur console = new ConsoleUtilisateur();

            while (true)
            {
                Jeu jeu = selecteurJeu.ChoisirJeu();
                jeu.BoucleJeu();

                console.afficherMessage("Jouer à un autre jeu ? Taper [R] pour changer de jeu. Taper [Echap] pour quitter.");

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    break;
                }
                if (key == ConsoleKey.R)
                {
                    jeu = selecteurJeu.ChoisirJeu();
                    jeu.BoucleJeu();
                }
            }
        }
    }
}
