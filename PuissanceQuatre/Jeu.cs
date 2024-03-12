using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp.Interface;
using MorpionApp.Joueur;

namespace MorpionApp
{
    public abstract class Jeu : IJeu
    {
        public IGrille _grille;
        public readonly IVueJeu _vueJeu;

        protected abstract int NB_LIGNES { get; }
        protected abstract int NB_COLONNES { get; }
        protected abstract int CONDITION_VICTOIRE { get; }

        protected readonly IJoueur _joueur1;
        protected readonly IJoueur _joueur2;

        public bool quitterJeu = false;
        public bool tourDuJoueur1 = true;

        IJoueur joueurCourant;

        public Jeu(IVueJeu vueJeu , IJoueur joueur1 , IJoueur joueur2)
        {
            _vueJeu = vueJeu;

            _joueur1 = joueur1;
            _joueur2 = joueur2;
        }

        public bool VerifierVictoire(char symboleJoueur, int nombreJetonsPourGagner)
        {
            return VerifierLigne(symboleJoueur, nombreJetonsPourGagner) ||
                   VerifierColonne(symboleJoueur, nombreJetonsPourGagner) ||
                   VerifierDiagonales(symboleJoueur, nombreJetonsPourGagner);
        }

        private bool VerifierLigne(char symboleJoueur, int nombreJetonsPourGagner)
        {
            for (int i = 0; i < _grille.ligne; i++)
            {
                for (int j = 0; j < _grille.colonne; j++)
                {
                    if (_grille.GetCellule(i, j).jeton.Symbole == symboleJoueur)
                    {
                        if (EstSerieGagnante(symboleJoueur, i, j, nombreJetonsPourGagner, 0, 1))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool VerifierColonne(char symboleJoueur, int nombreJetonsPourGagner)
        {
            for (int i = 0; i < _grille.ligne; i++)
            {
                for (int j = 0; j < _grille.colonne; j++)
                {
                    if (_grille.GetCellule(i,j).jeton.Symbole == symboleJoueur)
                    {
                        if (EstSerieGagnante(symboleJoueur, i, j, nombreJetonsPourGagner, 1, 0))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool VerifierDiagonales(char symboleJoueur, int nombreJetonsPourGagner)
        {
            for (int i = 0; i < _grille.ligne; i++)
            {
                for (int j = 0; j < _grille.colonne; j++)
                {
                    if (_grille.GetCellule(i,j).jeton.Symbole == symboleJoueur)
                    {
                        if (EstSerieGagnante(symboleJoueur, i, j, nombreJetonsPourGagner, 1, 1) ||
                            EstSerieGagnante(symboleJoueur, i, j, nombreJetonsPourGagner, 1, -1))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool EstSerieGagnante(char symboleJoueur, int ligne, int colonne, int longueurSerie, int deltaLigne, int deltaColonne)
        {
            for (int k = 0; k < longueurSerie; k++)
            {
                int nouvelleLigne = ligne + k * deltaLigne;
                int nouvelleColonne = colonne + k * deltaColonne;

                if (nouvelleLigne >= _grille.ligne || nouvelleLigne < 0 ||
                    nouvelleColonne >= _grille.colonne || nouvelleColonne < 0 ||
                    _grille.GetCellule(nouvelleLigne, nouvelleColonne).jeton.Symbole != symboleJoueur)
                {
                    return false;
                }
            }

            return true;
        }

        public  bool VerifierEgalite()
        {
            for (int i = 0; i < _grille.ligne; i++)
            {
                for (int j = 0; j < _grille.colonne; j++)
                {
                    if (_grille.GetCellule(i, j).jeton.Symbole == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void BoucleJeu()
        {
            while (!quitterJeu)
            {
                joueurCourant = tourDuJoueur1 ? _joueur1 : _joueur2;
                joueurCourant.JouerTour(_grille,_vueJeu);

                if (VerifierVictoire(joueurCourant.Jeton.Symbole, CONDITION_VICTOIRE))
                {
                    _vueJeu.afficherPlateau(_grille);
                    _vueJeu.afficherFinPartie(joueurCourant.Nom + " à gagné !", _grille);
                    break;
                }

                tourDuJoueur1 = !tourDuJoueur1;

                if (VerifierEgalite())
                {
                    _vueJeu.afficherPlateau(_grille);
                    _vueJeu.afficherFinPartie("Aucun vainqueur, la partie se termine sur une égalité.", _grille);
                    break;
                }
            }
            if (!quitterJeu)
            {
                _vueJeu.afficherMessage("Appuyer sur [Echap] pour quitter, [Entrer] pour rejouer.");
            GetKey:
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Escape:
                        quitterJeu = true;
                        Console.Clear();
                        break;
                    default:
                        goto GetKey;
                }
            }
        }
    }
}
