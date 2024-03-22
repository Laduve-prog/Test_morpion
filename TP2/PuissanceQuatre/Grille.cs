using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MorpionApp.Interface;

namespace MorpionApp
{
    public class Grille : IGrille
    {
        private readonly ICellule[,] _cellules;
        private int _ligne;
        private int _colonne;

        public Grille(int ligne, int colonne)
        {
            _ligne = ligne;
            _colonne = colonne;
            _cellules = new Cellule[ligne, colonne];
            RemplirGrille();
        }

        public int ligne
        {
            get { return _ligne; }
        }

        public int colonne
        {
            get { return _colonne; }
        }

        public ICellule GetCellule(int ligne, int colonne)
        {
            return _cellules[ligne, colonne];
        }

        public void SetCellule(int ligne, int colonne, IJeton jeton)
        {
            _cellules[ligne, colonne].jeton = jeton;
        }

        public void RemplirGrille()
        {
            for (int i = 0; i < _ligne; i++)
            {
                for( int j = 0; j < _colonne; j++)
                {
                    _cellules[i, j] = new Cellule();
                    _cellules[i, j].jeton = new Jeton(' ') ;
                }
            }
        }
    }
}
