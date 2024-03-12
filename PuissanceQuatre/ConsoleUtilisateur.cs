using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp.Interface;

namespace MorpionApp
{
    internal class ConsoleUtilisateur : IVueJeu
    {
        public void afficherPlateau(IGrille grille)
        {
            int rows = grille.ligne;
            int columns = grille.colonne;

            Console.Clear();
            Console.WriteLine();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(" ");
                    if (j < columns)
                    {
                        Console.Write("  |  ");
                    }
                }
                Console.WriteLine();
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(grille.GetCellule(i, j).jeton.Symbole);
                    if (j < columns)
                    {
                        Console.Write("  |  ");
                    }
                }
                Console.WriteLine();
                if (i < rows - 1)
                {
                    for(int j = 0 ; j < columns; j++)
                    {
                        if (j == columns - 1)
                        {
                            Console.Write("---+");
                        }
                        else
                        {
                            Console.Write("---+--");
                        }
                    }
                    Console.WriteLine();
                }
            }  
        }

        public void afficherFinPartie(string message , IGrille grille)
        {
            Console.Clear();
            afficherPlateau(grille);
            Console.WriteLine(message);
        }

        public void displayInput(int column , int row)
        {
            Console.WriteLine();
            Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
            Console.SetCursorPosition(column * 6 + 1 , row * 3 + 1 );
        }

        public void afficherMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
