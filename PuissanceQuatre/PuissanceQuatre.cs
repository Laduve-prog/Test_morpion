using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class PuissanceQuatre : Jeu
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;

        const int NB_LIGNES = 4;
        const int NB_COLONNES = 7;
        const int CONDITION_VICTOIRE = 4;

        public PuissanceQuatre()
        {
            grille = new char[NB_LIGNES, NB_COLONNES];
        }

        public override void BoucleJeu()
        {
            while (!quiterJeu)
            {
                InitialiserPlateau(NB_LIGNES, NB_COLONNES);
                while (!quiterJeu)
                {
                    if (tourDuJoueur)
                    {
                        JouerTour(1);
                        if (VerifierVictoire('X',grille,CONDITION_VICTOIRE))
                        {
                            finPartie("Le joueur 1 à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        JouerTour(2);
                        if (VerifierVictoire('O',grille,CONDITION_VICTOIRE))
                        {
                            finPartie("Le joueur 2 à gagné !");
                            break;
                        }
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (VerifierEgalite(grille))
                    {
                        finPartie("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }
                if (!quiterJeu)
                {
                    Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
                GetKey:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:
                            quiterJeu = true;
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
            char joueurSymbole = joueur == 1 ? 'X' : 'O';

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                affichePlateau();
                Console.WriteLine();
                Console.WriteLine($"Choisir une case valide pour joueur {joueur} (appuyer sur [Entrer])");
                Console.SetCursorPosition(column * 6 + 1, row * NB_LIGNES + 1);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quiterJeu = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (column >= 6)
                        {
                            column = 0;
                        }
                        else
                        {
                            column++;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = 6;
                        }
                        else
                        {
                            column--;
                        }
                        break;

                    case ConsoleKey.Enter:
                        while (row <= NB_LIGNES - 1) 
                        {
                            row++;
                            if (row >= NB_LIGNES) 
                            {
                                break;
                            }
                        }
                        while (grille[row - 1, column] == 'X' || grille[row - 1, column] == 'O')
                        {
                            if (row == 1)
                            {
                                break;
                            }
                            row--;
                        }

                        if (grille[row - 1, column] == ' ')
                        {
                            grille[row - 1, column] = joueurSymbole;
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }
            }
        }

        public void affichePlateau()
        {
            Console.WriteLine();
            Console.WriteLine($" {grille[0, 0]}  |  {grille[0, 1]}  |  {grille[0, 2]}  |  {grille[0, 3]}  |  {grille[0, 4]}  |  {grille[0, 5]}  |  {grille[0, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine($" {grille[1, 0]}  |  {grille[1, 1]}  |  {grille[1, 2]}  |  {grille[1, 3]}  |  {grille[1, 4]}  |  {grille[1, 5]}  |  {grille[1, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine($" {grille[2, 0]}  |  {grille[2, 1]}  |  {grille[2, 2]}  |  {grille[2, 3]}  |  {grille[2, 4]}  |  {grille[2, 5]}  |  {grille[1, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine($" {grille[3, 0]}  |  {grille[3, 1]}  |  {grille[3, 2]}  |  {grille[3, 3]}  |  {grille[3, 4]}  |  {grille[3, 5]}  |  {grille[1, 6]}");
            Console.WriteLine("    |     |     |     |     |     |");
            Console.WriteLine("----+-----+-----+-----+-----+-----+----");
        }

        public void finPartie(string msg)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine(msg);
        }
    }
}
