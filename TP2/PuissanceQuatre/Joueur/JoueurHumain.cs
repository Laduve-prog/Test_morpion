using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp.Interface;

namespace MorpionApp.Joueur
{
    public abstract class JoueurHumain : IJoueur
    {
        public char Symbole { get; private set; }
        public string Nom { get; private set; }

        public IJeton Jeton { get; private set; }

        public JoueurHumain(string nom , char symbole)
        {
            Nom = nom;
            Jeton = new Jeton(symbole);
        }

        public abstract void JouerTour(IGrille _grille, IVueJeu _vueJeu);
    }
}
