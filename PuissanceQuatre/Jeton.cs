using MorpionApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    internal class Jeton : IJeton
    {
        public char Symbole { get; private set; }

        public Jeton(char symbole)
        {
            Symbole = symbole;
        }
    }
}
