using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Chocola
{
    class AlgoritmeSpeler : ChocolaSpeler
    {
        public override void DoeChocolaZet(bool[,] bord, int sizeX, int sizeY)
        {
            //We need to change the outcome so that there's an L shaped form in the board
            //That way we can always predict how to win
            //If we know if it's an L shape, we gotta calculate how many TRUE blocks there are
            Point Move = new Point();

            int ChocolateAmount = AmountOfChocolate(bord);

            if (IsLShape(bord))
            {
                if(ChocolateAmount == 2)
                {
                    if (bord[0, 1])
                    {
                        Move = new Point(1, 0);
                    }
                    else
                    {
                        Move = new Point(0, 1);
                    }
                }
                else if(ChocolateAmount == 3)
                {
                    if (bord[0, 1])
                    {
                        Move = new Point(1, 0);
                    }
                    else
                    {
                        Move = new Point(0, 1);
                    }
                }
                else if(ChocolateAmount == 4)
                {
                    if(!bord[0,2] && bord[2, 0])
                    {
                        Move = new Point(0, 2);
                    }
                    else if(!bord[2,0] && bord[0, 2])
                    {
                        Move = new Point(2, 0);
                    }
                }
                else
                {
                    if (bord[0, 2])
                        Move = new Point(2, 0);
                    if (bord[2, 0])
                        Move = new Point(0, 2);
                }
            }
            else if (IsIShape(bord))
            {
                if (bord[0, 1])
                {
                    Move = new Point(1, 0);
                }
                else if (bord[1, 0])
                {
                    Move = new Point(0, 1);
                }
            }
            else
            {
                if (bord[1, 1])
                    Move = new Point(1, 1);
                else
                    Move = new Point(0, 0);
            }

            HandleZet(Move);
        }

        public AlgoritmeSpeler()
        {
            Naam = "Algoritme Speler";
        }


        private int LongestSide(bool[,] bord, int side)
        {
            int SideLength = 0;
            if (side == 0)
            {
                for (int i = 0; i < bord.GetLength(side); i++)
                {
                    if (bord[side, i])
                        SideLength++;
                }
            }
            else
            {
                for (int i = 0; i < bord.GetLength(0); i++)
                {
                    if (bord[i, 0])
                        SideLength++;
                }
            }
            return SideLength;
        }

        private int AmountOfChocolate(bool[,] bord)
        {
            int TrueAmount = 0;
            for (int i = 0; i < bord.GetLength(0); i++)
            {
                for (int j = 0; j < bord.GetLength(1); j++)
                {
                    if (bord[i, j])
                    {
                        TrueAmount++;
                    }
                }
            }
            return TrueAmount;
        }

        private bool IsLShape(bool[,] bord)
        {
            if (!bord[1, 1] && bord[0,1] && bord[1,0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsIShape(bool[,] bord)
        {
            if (bord[1, 1])
                return false;
            if (!bord[0, 1] && bord[1, 0])
                return true;
            if (!bord[1, 0] && bord[0, 1])
                return true;
            return false;
        }
    }
}