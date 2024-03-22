using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MorpionApp.Interface;

namespace MorpionApp
{
    public class Morpion : Jeu
    {
        protected override int NB_LIGNES { get; } = 3;
        protected override int NB_COLONNES { get; } = 3;

        protected override int CONDITION_VICTOIRE { get; } = 3;

        public Morpion(IVueJeu vueJeu , IJoueur joueur1 , IJoueur joueur2) : base(vueJeu , joueur1 , joueur2)
        {
            _grille = new Grille(NB_LIGNES, NB_COLONNES);
        }
    }
}
