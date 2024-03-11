using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class PuissanceQuatre
    {
        public bool quiterJeu = false;
        public bool tourDuJoueur = true;
        public char[,] grille;

        const int NB_LIGNES = 4;
        const int NB_COLONNES = 7;

        public PuissanceQuatre()
        {
            grille = new char[NB_LIGNES, NB_COLONNES];
        }

        public void BoucleJeu()
        {
            while (!quiterJeu)
            {
                grille = new char[NB_LIGNES, NB_COLONNES]
                {
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                };
                while (!quiterJeu)
                {
                    if (tourDuJoueur)
                    {
                        tourJoueur();
                        if (verifVictoire('X'))
                        {
                            finPartie("Le joueur 1 à gagné !");
                            break;
                        }
                    }
                    else
                    {
                        tourJoueur2();
                        if (verifVictoire('O'))
                        {
                            finPartie("Le joueur 2 à gagné !");
                            break;
                        }
                    }
                    tourDuJoueur = !tourDuJoueur;
                    if (verifEgalite())
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

        public void tourJoueur()
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                affichePlateau();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
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
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = 6;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        while (row <= 3)
                        {
                            row = row + 1;
                            if (row >= 3)
                            {
                                break;
                            }
                        }
                        while (grille[row, column] is 'X' or 'O')
                        {
                            if (row == 0)
                            {
                                break;
                            }

                            row = row - 1;
                        }
                        if(grille[row, column] is ' ')
                        {
                            grille[row, column] = 'X';
                            moved = true;
                            quiterJeu = false;
                        }
                        break;
                }

            }
        }

        public void tourJoueur2()
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!quiterJeu && !moved)
            {
                Console.Clear();
                affichePlateau();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
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
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = 6;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        while (row <= 3)
                        {
                            row = row + 1;
                            if (row >= 3)
                            {
                                break;
                            }
                        }
                        while (grille[row, column] is 'X' or 'O')
                        {
                            if(row == 0)
                            {
                                break;
                            }

                            row = row - 1;
                        }
                        if (grille[row, column] is ' ')
                        {
                            grille[row, column] = 'O';
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

        public bool verifVictoire(char symboleJoueur) =>
             grille[0, 0] == symboleJoueur && grille[1, 0] == symboleJoueur && grille[2, 0] == symboleJoueur && grille[3, 0] == symboleJoueur ||
             grille[0, 1] == symboleJoueur && grille[1, 1] == symboleJoueur && grille[2, 1] == symboleJoueur && grille[3, 1] == symboleJoueur ||
             grille[0, 2] == symboleJoueur && grille[1, 2] == symboleJoueur && grille[2, 2] == symboleJoueur && grille[3, 2] == symboleJoueur ||
             grille[0, 3] == symboleJoueur && grille[1, 3] == symboleJoueur && grille[2, 3] == symboleJoueur && grille[3, 3] == symboleJoueur ||
             grille[0, 4] == symboleJoueur && grille[1, 4] == symboleJoueur && grille[2, 4] == symboleJoueur && grille[3, 4] == symboleJoueur ||
             grille[0, 5] == symboleJoueur && grille[1, 5] == symboleJoueur && grille[2, 5] == symboleJoueur && grille[3, 5] == symboleJoueur ||
             grille[0, 6] == symboleJoueur && grille[1, 6] == symboleJoueur && grille[2, 6] == symboleJoueur && grille[3, 6] == symboleJoueur ||
             grille[0, 0] == symboleJoueur && grille[0, 1] == symboleJoueur && grille[0, 2] == symboleJoueur && grille[0, 3] == symboleJoueur ||
             grille[0, 1] == symboleJoueur && grille[0, 2] == symboleJoueur && grille[0, 3] == symboleJoueur && grille[0, 4] == symboleJoueur ||
             grille[0, 2] == symboleJoueur && grille[0, 3] == symboleJoueur && grille[0, 3] == symboleJoueur && grille[0, 5] == symboleJoueur ||
             grille[0, 3] == symboleJoueur && grille[0, 4] == symboleJoueur && grille[0, 5] == symboleJoueur && grille[0, 6] == symboleJoueur ||
             grille[1, 0] == symboleJoueur && grille[1, 1] == symboleJoueur && grille[1, 2] == symboleJoueur && grille[1, 3] == symboleJoueur ||
             grille[1, 1] == symboleJoueur && grille[1, 2] == symboleJoueur && grille[1, 3] == symboleJoueur && grille[1, 4] == symboleJoueur ||
             grille[1, 2] == symboleJoueur && grille[1, 3] == symboleJoueur && grille[1, 4] == symboleJoueur && grille[1, 5] == symboleJoueur ||
             grille[1, 4] == symboleJoueur && grille[1, 4] == symboleJoueur && grille[1, 5] == symboleJoueur && grille[1, 6] == symboleJoueur ||
             grille[2, 0] == symboleJoueur && grille[2, 1] == symboleJoueur && grille[2, 2] == symboleJoueur && grille[2, 3] == symboleJoueur ||
             grille[2, 1] == symboleJoueur && grille[2, 2] == symboleJoueur && grille[2, 3] == symboleJoueur && grille[2, 4] == symboleJoueur ||
             grille[2, 2] == symboleJoueur && grille[2, 3] == symboleJoueur && grille[2, 3] == symboleJoueur && grille[2, 5] == symboleJoueur ||
             grille[2, 3] == symboleJoueur && grille[2, 4] == symboleJoueur && grille[2, 5] == symboleJoueur && grille[2, 6] == symboleJoueur ||
             grille[3, 0] == symboleJoueur && grille[3, 1] == symboleJoueur && grille[3, 2] == symboleJoueur && grille[3, 3] == symboleJoueur ||
             grille[3, 1] == symboleJoueur && grille[3, 2] == symboleJoueur && grille[3, 3] == symboleJoueur && grille[3, 4] == symboleJoueur ||
             grille[3, 2] == symboleJoueur && grille[3, 3] == symboleJoueur && grille[3, 4] == symboleJoueur && grille[3, 5] == symboleJoueur ||
             grille[3, 3] == symboleJoueur && grille[3, 4] == symboleJoueur && grille[3, 5] == symboleJoueur && grille[3, 6] == symboleJoueur ||
             grille[0, 0] == symboleJoueur && grille[1, 1] == symboleJoueur && grille[2, 2] == symboleJoueur && grille[3, 3] == symboleJoueur ||
             grille[0, 1] == symboleJoueur && grille[1, 2] == symboleJoueur && grille[2, 3] == symboleJoueur && grille[3, 4] == symboleJoueur ||
             grille[0, 2] == symboleJoueur && grille[1, 3] == symboleJoueur && grille[2, 4] == symboleJoueur && grille[3, 5] == symboleJoueur ||
             grille[0, 3] == symboleJoueur && grille[1, 4] == symboleJoueur && grille[2, 5] == symboleJoueur && grille[3, 6] == symboleJoueur ||
             grille[0, 3] == symboleJoueur && grille[1, 2] == symboleJoueur && grille[2, 1] == symboleJoueur && grille[3, 0] == symboleJoueur ||
             grille[0, 4] == symboleJoueur && grille[1, 4] == symboleJoueur && grille[2, 2] == symboleJoueur && grille[3, 1] == symboleJoueur ||
             grille[0, 5] == symboleJoueur && grille[1, 3] == symboleJoueur && grille[2, 3] == symboleJoueur && grille[3, 2] == symboleJoueur ||
             grille[0, 6] == symboleJoueur && grille[1, 5] == symboleJoueur && grille[2, 4] == symboleJoueur && grille[3, 3] == symboleJoueur;

        public bool verifEgalite() =>
            grille[0, 0] != ' ' && grille[0, 1] != ' ' && grille[0, 2] != ' ' && grille[0, 3] != ' ' && grille[0, 4] != ' ' && grille[0, 5] != ' ' && grille[0, 6] != ' ' &&
            grille[1, 0] != ' ' && grille[1, 1] != ' ' && grille[1, 2] != ' ' && grille[1, 3] != ' ' && grille[1, 4] != ' ' && grille[1, 5] != ' ' && grille[1, 6] != ' ' &&
            grille[2, 0] != ' ' && grille[2, 1] != ' ' && grille[1, 2] != ' ' && grille[2, 3] != ' ' && grille[2, 4] != ' ' && grille[2, 5] != ' ' && grille[2, 6] != ' ' &&
            grille[3, 0] != ' ' && grille[3, 1] != ' ' && grille[3, 2] != ' ' && grille[3, 3] != ' ' && grille[3, 4] != ' ' && grille[3, 5] != ' ' && grille[3, 5] != ' ';


        public void finPartie(string msg)
        {
            Console.Clear();
            affichePlateau();
            Console.WriteLine(msg);
        }
    }
}
