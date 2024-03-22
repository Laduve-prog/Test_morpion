using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp.Interface;

namespace MorpionApp.Joueur
{
    public static class UsineJoueur
    {
        public static IJoueur CréerJoueur(TypeJoueur typejoueur, string nom , char symbole)
        {
            if (typejoueur == TypeJoueur.HumainPuissance4)
            {
                return new JoueurHumainPuissance4(nom , symbole);
            }
            else if (typejoueur == TypeJoueur.HumainMorpion)
            {
                return new JoueurHumainMorpion(nom , symbole);
            }
            else if (typejoueur == TypeJoueur.OrdinateurMorpion)
            {
                return new OrdinateurMorpion(nom , symbole);
            }
            else if (typejoueur == TypeJoueur.OrdinateurPuissance4)
            {
                return new OrdinateurPuissance4(nom, symbole);
            }
            else
            {
                throw new ArgumentException("Type de joueur invalide");
            }
        }
    }
}
