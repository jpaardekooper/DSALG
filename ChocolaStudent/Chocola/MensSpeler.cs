using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocola
{
    class MensSpeler : ChocolaSpeler
    {
        public MensSpeler()
        {
            Naam = "Mens Speler";
        }
        public override void DoeChocolaZet(bool[,] bord, int sizeX, int sizeY)
        {
            //doe niks!
        }
    }
}
