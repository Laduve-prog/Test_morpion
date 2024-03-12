using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Interface
{
    public interface IGrille
    {
        int ligne { get; }
        int colonne { get; }
        ICellule GetCellule(int ligne, int colonne);
        void SetCellule(int ligne, int colonne, IJeton jeton);
        void RemplirGrille();
    }
}
