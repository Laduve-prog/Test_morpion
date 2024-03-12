using MorpionApp.Interface;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Joueur
{
    internal class JoueurHumainPuissance4 : JoueurHumain
    {
        public JoueurHumainPuissance4(string nom, char symbole) : base(nom, symbole)
        {
         
        }

        public override void JouerTour(IGrille _grille, IVueJeu _vueJeu)
        {
            var (row, column) = (0, 0);
            bool moved = false;
            bool quitterJeu = false;

            while (!quitterJeu && !moved)
            {
                _vueJeu.afficherPlateau(_grille);
                _vueJeu.afficherMessage($"Choisir une case valide pour {Nom} (appuyer sur [Entrer])");
                _vueJeu.displayInput(column,row);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        quitterJeu = true;
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
                        while (row <= _grille.ligne - 1)
                        {
                            row++;
                            if (row >= _grille.colonne)
                            {
                                break;
                            }
                        }
                        while (_grille.GetCellule(row - 1, column).jeton.Symbole == 'X' || _grille.GetCellule(row - 1, column).jeton.Symbole == 'O')
                        {
                            if (row == 1)
                            {
                                break;
                            }
                            row--;
                        }

                        if (_grille.GetCellule(row - 1, column).jeton.Symbole == ' ')
                        {
                            _grille.SetCellule(row - 1, column, Jeton);
                            moved = true;
                            quitterJeu = false;
                        }
                        break;
                }
            }
        }
    }
}
