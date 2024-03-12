using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Interface
{
    public interface IVueJeu
    {
        public void displayInput(int column, int row);
        public void afficherPlateau(IGrille grille);
        public void afficherMessage(string message);
        public void afficherFinPartie(string message, IGrille grille);
    }
}
