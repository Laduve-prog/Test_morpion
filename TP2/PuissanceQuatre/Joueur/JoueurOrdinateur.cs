using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp.Interface;

namespace MorpionApp.Joueur
{
    internal abstract class JoueurOrdinateur : IJoueur
    {
        public string Nom { get; private set; }
        public IJeton Jeton { get; private set; }
        public JoueurOrdinateur(string nom , char symbole)
        {
            Nom = nom;
            Jeton = new Jeton('O');
        }
        public abstract void JouerTour(IGrille grille, IVueJeu vueJeu);
    }
}
