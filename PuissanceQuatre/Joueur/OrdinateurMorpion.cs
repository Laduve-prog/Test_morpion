using MorpionApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Joueur
{
    internal class OrdinateurMorpion : JoueurOrdinateur
    {
        public OrdinateurMorpion(string nom, char symbole) : base(nom, symbole)
        {
        }

        public override void JouerTour(IGrille grille, IVueJeu vueJeu)
        {
            Random random = new Random();
            int ligne = random.Next(grille.ligne);
            int colonne = random.Next(grille.colonne);
            while (grille.GetCellule(ligne, colonne).jeton.Symbole != ' ')
            {
                ligne = random.Next(grille.ligne);
                colonne = random.Next(grille.colonne);
            }
            grille.SetCellule(ligne, colonne, Jeton);
        }
    }
}
