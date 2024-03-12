using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class SelecteurJeu
    {
        ConsoleUtilisateur consoleUtilisateur = new ConsoleUtilisateur();

        public Jeu ChoisirJeu()
        {
            consoleUtilisateur.afficherMessage("Choisissez un jeu : [X] Morpion, [P] Puissance 4");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.X:
                        return new Morpion();
                    case ConsoleKey.P:
                        return new PuissanceQuatre();
                    default:
                        consoleUtilisateur.afficherMessage("Choix invalide. Veuillez choisir [X] ou [P].");
                        continue;
                }
            }
        }
    }
}
