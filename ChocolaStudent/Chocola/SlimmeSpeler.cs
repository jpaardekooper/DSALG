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
        private bool EvenBoard { get; set; } = false;
        private bool? IsFirstPlayer { get; set; } = null;
        private bool[,] Bord { get; set; }
        private int MaxY { get; set; }
        private int MaxX { get; set; }

        public SlimmeSpeler()
        {
            Naam = "slimme speler";
        }

        public override void DoeChocolaZet(bool[,] bord, int sizeX, int sizeY)
        {
            Random rand = new Random();           
            Bord = bord;

            // Checking if the baords lenghts are even or uneven
            if (bord.Length * bord.LongLength % 2 == 0)
            {
                EvenBoard = true;
            }

            MaxY = 0;
            MaxX = 0;

            for (MaxY = 0; MaxY < sizeY - 1; MaxY++)
            {
                if (!Bord[MaxY + 1, 0])
                {
                    break;
                }
            }

            for (MaxX = 0; MaxX < sizeX - 1; MaxX++)
            {
                if (!Bord[0, MaxX + 1])
                {
                    break;
                }
            }

            // Checking if it is first player
            if (IsFirstPlayer == null && !Bord[MaxY, MaxX])
            {
                IsFirstPlayer = false;
            }
            else if(IsFirstPlayer == null)
            {
                IsFirstPlayer = true;
            }

            if (EvenBoard && IsFirstPlayer == true)
            {
                HandleZet(SecondEvenZet());
            }
            else if (EvenBoard && IsFirstPlayer == false)
            {
                HandleZet(SecondEvenZet());
            }
            else if (!EvenBoard && IsFirstPlayer == true)
            {
                HandleZet(FirstUnevenZet());
            }
            else
            {
                HandleZet(SecondUnevenZet());
            }
           
        }

        /// <summary>
        /// Always a win
        /// </summary>
        /// <returns></returns>
        private Point SecondEvenZet()
        {
            Point zet = new Point();
            
            if (!Bord[1, 1])
            {              
                if (Bord[1, 0])
                {
                    if (MaxX % 2 == 0)
                    {
                        zet = new Point(MaxX - 1, 0);
                    }
                    else
                    {
                        zet = new Point(MaxX, 0);
                    }
                }
                else if (Bord[0, 1])
                {
                    if (MaxY % 2 == 0)
                    {
                        zet = new Point(0, MaxY - 1);
                    }
                    else
                    {
                        zet = new Point(0, MaxY);
                    }
                }
                if (MaxY == 2 && MaxX == 2 && Bord[2, 0] && Bord[0, 2])
                {
                    zet = new Point(0, 2);
                }
                if (MaxX == 2 && MaxY == 2 && Bord[0, 2] && Bord[2, 0])
                {
                    zet = new Point(2, 0);
                }
                if (MaxY == 2 && MaxY > 2)
                {
                    zet = new Point(0,3);
                }
                if (MaxY == 2 && MaxX > 2)
                {
                    zet = new Point(3, 0);
                }

                
            }

            if (Bord[1, 0] && Bord[0, 1] && Bord[0, 2] && MaxY == 1 && MaxX == 2)
            {
                zet = new Point(2, 0);
            }
            if (Bord[0, 1] && Bord[1, 0] && Bord[2, 0] && MaxX == 1 && MaxY == 2)
            {
                zet = new Point(0, 2);
            }

            if (MaxY == 1 && MaxX >= 2)
            {
                zet = new Point(2, 0);
            }
            else if (MaxX == 1 && MaxY >= 2)
            {
                zet = new Point(0, 2);
            }

            //If 1,1 is not taken on an even bord take 1,1 for a win
            if (Bord[1, 1])
            {
                zet = new Point(1, 1);
            }

            // Winning move vertical
            if (Bord[1, 0] && !Bord[0, 1])
            {
                zet = new Point(0, 1);
            }

            // Winning move horizontal
            else if (Bord[0, 1] && !Bord[1, 0])
            {
                zet = new Point(1, 0);
            }

            return zet;
        }

        private Point FirstEvenZet()
        {
            return new Point(0, 0);
        }

        private Point FirstUnevenZet()
        {
            return new Point(0, 0);
        }

        private Point SecondUnevenZet()
        {
            return new Point(0, 0);
        }

    }
}
