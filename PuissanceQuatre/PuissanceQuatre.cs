using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp.Interface;

namespace MorpionApp
{
    public class PuissanceQuatre : Jeu
    {
        public bool quitterJeu = false;
        public bool tourDuJoueur1 = true;

        protected override int NB_LIGNES { get; } = 4;
        protected override int NB_COLONNES { get; } = 7;
        protected override int CONDITION_VICTOIRE { get; } = 4;

        public PuissanceQuatre(IVueJeu vueJeu, IJoueur joueur1, IJoueur joueur2) : base(vueJeu, joueur1, joueur2)
        {
            _grille = new Grille(NB_LIGNES, NB_COLONNES);
        }
    }
}
