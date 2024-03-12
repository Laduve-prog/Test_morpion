using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Interface
{
    public interface ICellule
    {
        IJeton jeton { get; set; }
    }
}
