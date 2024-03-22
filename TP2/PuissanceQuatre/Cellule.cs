using MorpionApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp
{
    public class Cellule : ICellule
    {
        public char Symbole { get; set; }
        public IJeton jeton { get; set; }

        public void SetSymbole(char symbole)
        {
            Symbole = symbole;
        }
    }
}
