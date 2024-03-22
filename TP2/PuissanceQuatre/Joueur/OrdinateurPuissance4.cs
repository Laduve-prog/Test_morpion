using MorpionApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Joueur
{
    internal class OrdinateurPuissance4 : JoueurOrdinateur
    {
        public OrdinateurPuissance4(string nom, char symbole) : base(nom, symbole)
        {
        }

        public override void JouerTour(IGrille grille, IVueJeu vueJeu)
        {
            Random random = new Random();
            int ligne = TrouverDerniereLigneVide(grille);

            if (ligne == -1)
            {
                ligne = random.Next(grille.ligne);
            }

            int colonne = random.Next(grille.colonne);
            grille.SetCellule(ligne, colonne, Jeton);
        }

        private int TrouverDerniereLigneVide(IGrille grille)
        {
            for (int ligne = grille.ligne - 1; ligne >= 0; ligne--)
            {
                for (int colonne = 0; colonne < grille.colonne; colonne++)
                {
                    if (grille.GetCellule(ligne, colonne).jeton.Symbole == ' ')
                    {
                        return ligne;
                    }
                }
            }

            return -1;
        }
    }
}
