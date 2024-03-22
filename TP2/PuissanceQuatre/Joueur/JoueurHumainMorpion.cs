using MorpionApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Joueur
{
    internal class JoueurHumainMorpion : JoueurHumain
    {
        public JoueurHumainMorpion(string nom, char symbole) : base(nom, symbole) { }

        public override void JouerTour(IGrille _grille , IVueJeu _vueJeu)
        {
            var (row, column) = (0, 0);
            bool moved = false;
            bool quitterJeu = false;

            while (!quitterJeu && !moved)
            {
                _vueJeu.afficherPlateau(_grille);
                _vueJeu.displayInput(column, row);

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
                        if (_grille.GetCellule(row, column).jeton.Symbole == ' ')
                        {
                            _grille.SetCellule(row, column, Jeton);
                            moved = true;
                            quitterJeu = false;
                        }
                        break;
                }
            }
        }
    }
}
