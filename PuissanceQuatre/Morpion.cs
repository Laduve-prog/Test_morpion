using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Morpion : Jeu
    {
        public bool quitterJeu = false;
        public bool tourDuJoueur = true;

        internal ConsoleUtilisateur consoleUtilisateur = new ConsoleUtilisateur();

        const int NB_LIGNES = 3;
        const int NB_COLONNES = 3;
        const int CONDITION_VICTOIRE = 3;

        public Morpion()
        {
            grille = new char[NB_LIGNES, NB_COLONNES];
        }

        public override void BoucleJeu()
        {
            while (!quitterJeu)
            {
                InitialiserPlateau(NB_LIGNES, NB_COLONNES);
                while (!quitterJeu)
                {
                    if (tourDuJoueur)
                    {
                        JouerTour(1);
                        if (VerifierVictoire('X',grille, CONDITION_VICTOIRE))
                        {
                            consoleUtilisateur.afficherFinPartie("Le joueur 1 à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        JouerTour(2);
                        if (VerifierVictoire('O',grille, CONDITION_VICTOIRE))
                        {
                            consoleUtilisateur.afficherFinPartie("Le joueur 2 à gagné !");
                            break;
                        }
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (VerifierEgalite(grille))
                    {
                        consoleUtilisateur.afficherFinPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }
                if (!quitterJeu)
                {
                    consoleUtilisateur.afficherMessage("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                    GetKey:
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.Enter:
                                break;
                            case ConsoleKey.Escape:
                                quitterJeu = true;
                                Console.Clear();
                                break;
                            default:
                                goto GetKey;
                        }
                }

            }
        }

        public override void JouerTour(int joueur)
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quitterJeu && !moved)
            {
                consoleUtilisateur.afficherPlateau(grille);
                consoleUtilisateur.displayInput(column, row);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quitterJeu = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (column >= 2)
                        {
                            column = 0;
                        }
                        else
                        {
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = 2;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = 2;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= 2)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (grille[row, column] == ' ')
                        {
                            grille[row, column] = joueur == 1 ? 'X' : 'O';
                            moved = true;
                            quitterJeu = false;
                        }
                        break;
                }
            }      
        }
    }
}
