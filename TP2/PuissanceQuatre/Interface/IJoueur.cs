using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Interface
{
    public interface IJoueur
    {
        IJeton Jeton { get; }
        string Nom { get; }

        public void JouerTour(IGrille _grille , IVueJeu _vueJeu);
    }
}
