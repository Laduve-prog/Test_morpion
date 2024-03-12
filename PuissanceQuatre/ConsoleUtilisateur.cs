using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    internal class ConsoleUtilisateur
    {
        public void afficherPlateau(char[,] grille)
        {
            int rows = grille.GetLength(0);
            int columns = grille.GetLength(1);
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                Console.Write(" ");
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(grille[i, j]);
                    if (j < columns - 1)
                    {
                        Console.Write("  |  ");
                    }
                }
                Console.WriteLine();
                if (i < rows - 1)
                {
                    Console.WriteLine("    |     |");
                    Console.WriteLine("----+-----+----");
                    Console.WriteLine("    |     |");
                }
            }   
        }

        internal void afficherFinPartie(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }

        public void displayInput(int column , int row)
        {
            Console.WriteLine();
            Console.WriteLine("Choisir une case valide est appuyer sur [Entrer]");
            Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);
        }

        public void afficherMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
