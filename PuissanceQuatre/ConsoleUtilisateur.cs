using System;
using System.Collections.Generic;
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
        
        void afficherVictoire(string message)
        {
            
        }

        void afficherEgalite(string message)
        {
            
        }

        internal void afficherFinPartie(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }

        void afficherQuitterJeu()
        {
            
        }
    }
}
