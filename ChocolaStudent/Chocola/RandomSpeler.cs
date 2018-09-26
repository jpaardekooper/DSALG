using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocola
{
    class RandomSpeler : ChocolaSpeler
    {
        Random rand = new Random();
        public RandomSpeler()
        {
            Naam = "Random Speler";
        }
        public override void DoeChocolaZet(bool[,] bord, int sizeX, int sizeY)
        {
            Point zet = new Point();
            int maxY;
            int maxX;

            for (maxY = 0; maxY < sizeY - 1; maxY++)
            {
                if (!bord[maxY + 1,0])
                {
                    break;
                }
            }

            for (maxX = 0; maxX < sizeX - 1; maxX++)
            {
                if (!bord[0,maxX + 1])
                {
                    break;
                }
            }

            do
            {
                zet.X = rand.Next(maxX + 1);
                zet.Y = rand.Next(maxY + 1);
            } while (!bord[zet.Y,zet.X]);
            //Console.WriteLine("Ik zet: (" + zet.X + ", " + zet.Y + ")");

            HandleZet(zet);

        }
    }
}
