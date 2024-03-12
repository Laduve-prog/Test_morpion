using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public abstract class Jeu : IJeu
    {
        public char[,] grille;

        public void InitialiserPlateau(int NB_LIGNES , int NB_COLONNES)
        {
            for (int i = 0; i < NB_LIGNES; i++)
            {
                for (int j = 0; j < NB_COLONNES; j++)
                {
                    grille[i, j] = ' ';
                }
            }
        }

        public abstract void JouerTour(int joueur);

        public bool VerifierVictoire(char symboleJoueur, char[,] grille, int nombreJetonsPourGagner)
        {
            return VerifierLigne(symboleJoueur, grille, nombreJetonsPourGagner) ||
                   VerifierColonne(symboleJoueur, grille, nombreJetonsPourGagner) ||
                   VerifierDiagonales(symboleJoueur, grille, nombreJetonsPourGagner);
        }

        private bool VerifierLigne(char symboleJoueur, char[,] grille, int nombreJetonsPourGagner)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == symboleJoueur)
                    {
                        if (EstSerieGagnante(symboleJoueur, grille, i, j, nombreJetonsPourGagner, 0, 1))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool VerifierColonne(char symboleJoueur, char[,] grille, int nombreJetonsPourGagner)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == symboleJoueur)
                    {
                        if (EstSerieGagnante(symboleJoueur, grille, i, j, nombreJetonsPourGagner, 1, 0))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool VerifierDiagonales(char symboleJoueur, char[,] grille, int nombreJetonsPourGagner)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == symboleJoueur)
                    {
                        if (EstSerieGagnante(symboleJoueur, grille, i, j, nombreJetonsPourGagner, 1, 1) ||
                            EstSerieGagnante(symboleJoueur, grille, i, j, nombreJetonsPourGagner, 1, -1))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool EstSerieGagnante(char symboleJoueur, char[,] grille, int ligne, int colonne, int longueurSerie, int deltaLigne, int deltaColonne)
        {
            for (int k = 0; k < longueurSerie; k++)
            {
                int nouvelleLigne = ligne + k * deltaLigne;
                int nouvelleColonne = colonne + k * deltaColonne;

                if (nouvelleLigne >= grille.GetLength(0) || nouvelleLigne < 0 ||
                    nouvelleColonne >= grille.GetLength(1) || nouvelleColonne < 0 ||
                    grille[nouvelleLigne, nouvelleColonne] != symboleJoueur)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool VerifierEgalite(char[,] grille)
        {
            for (int i = 0; i < grille.GetLength(0); i++)
            {
                for (int j = 0; j < grille.GetLength(1); j++)
                {
                    if (grille[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public abstract void BoucleJeu();
    }
}
