using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolaJ
{
    public static class ChocolaJMSpeler
    {
        public static Point Zet(bool[,] bord, int sizeX, int sizeY)
        {

            Random rand = new Random();

            Point zet = new Point();
            
            int maxY;
            int maxX;

            for (maxY = 0; maxY < sizeY - 1; maxY++)
            {
                if (!bord[maxY + 1, 0])
                {
                    break;
                }
            }

            for (maxX = 0; maxX < sizeX - 1; maxX++)
            {
                if (!bord[0, maxX + 1])
                {
                    break;
                }
            }
            
            if (bord[1,0] && !bord[0, 1])
            {
                zet = new Point(1, 0);
            }
            else if (bord[0,1] && !bord[1, 0])
            {
                zet = new Point(0, 1);
            }

            





            return zet;
        }
    }
}
