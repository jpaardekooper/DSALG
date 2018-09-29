using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ChocolaJ;

namespace Chocola
{
    class SlimmeSpeler : ChocolaSpeler
    {
        public SlimmeSpeler()
        {
            Naam = "slimme speler";
        }

        public override void DoeChocolaZet(bool[,] bord, int sizeX, int sizeY)
        {
            Point zet = ChocolaJMSpeler.Zet(bord, sizeX, sizeY);


            HandleZet(zet);
        }

    }
}
