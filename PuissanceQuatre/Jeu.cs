using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    internal abstract class Jeu
    {
        public abstract void InitialiserPlateau();

        public abstract void JouerTour();

        public abstract bool VerifierVictoire(char symboleJoueur);

        public abstract bool VerifierEgalite();

        public abstract void BoucleJeu();
    }
}
