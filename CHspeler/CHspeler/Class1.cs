using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Chocola;

namespace CHSPEL
{
    public class SlimmeSpeler : ChocolaSpeler
    {
        private bool? IsFirstPlayer { get; set; } = null;
        private int MaxY { get; set; }
        private int MaxX { get; set; }
        private bool[,] Bord { get; set; }

        public SlimmeSpeler()
        {
            Naam = "slimme speler";
        }

        public override void DoeChocolaZet(bool[,] bord, int sizeX, int sizeY)
        {
            Random rand = new Random();

            MaxY = 0;
            MaxX = 0;
            Bord = bord;


            for (MaxY = 0; MaxY < sizeY - 1; MaxY++)
            {
                if (!bord[MaxY + 1, 0])
                {
                    break;
                }
            }

            for (MaxX = 0; MaxX < sizeX - 1; MaxX++)
            {
                if (!bord[0, MaxX + 1])
                {
                    break;
                }
            }

            if (IsFirstPlayer == null && bord[MaxY, MaxX])
            {
                IsFirstPlayer = true;
            }
            else if (IsFirstPlayer == null)
            {
                IsFirstPlayer = false;
            }

            if (IsFirstPlayer == true)
            {
                HandleZet(FirstPlayer());
            }
            else
            {
                HandleZet(SecondPlayer());
            }

        }

        public Point FirstPlayer()
        {
            Point zet = new Point(0, 0);

            #region CHE01
            if (Bord[1, 1])
            {
                if (MaxX % 2 == 0 && MaxY % 2 == 0)
                {
                    if (MaxX > MaxY)
                    {
                        if ((MaxX + MaxY) % 2 == 0)
                        {
                            zet = new Point(MaxX, 0);
                        }
                        else
                        {
                            zet = new Point(MaxX - 1, 0);
                        }
                    }
                    else
                    {
                        if ((MaxX + MaxY) % 2 == 0)
                        {
                            zet = new Point(0, MaxY);
                        }
                        else
                        {
                            zet = new Point(0, MaxY - 1);
                        }
                    }
                }
                else
                {
                    zet = new Point(1, 1);
                }
            }
            else
            {
                if (MaxX > MaxY)
                {
                    if ((MaxX + MaxY) % 2 == 0)
                    {
                        zet = new Point(MaxX - 1, 0);
                    }
                    else
                    {
                        zet = new Point(MaxX, 0);
                    }
                }
                else
                {
                    if ((MaxX + MaxY) % 2 == 0)
                    {
                        zet = new Point(0, MaxY - 1);
                    }
                    else
                    {
                        zet = new Point(0, MaxY);
                    }
                }
            }
            #endregion

            #region CHE02
            if (MaxX == 2 && MaxY == 4)
            {
                if (Bord[2, 2])
                {
                    zet = new Point(2, 2);
                }
                else if (Bord[1, 1])
                {
                    if (Bord[2, 1])
                    {
                        zet = new Point(1, 2);
                    }
                    if (Bord[3, 1])
                    {
                        zet = new Point(1, 3);
                    }
                    else if (Bord[4, 1])
                    {
                        zet = new Point(1, 4);
                    }
                    else if (Bord[1, 2])
                    {
                        zet = new Point(2, 1);
                    }
                    else
                    {
                        zet = new Point(1, 1);
                    }
                }

            }
            if (MaxX > 2)
            {
                zet = new Point(3, 0);
            }
            #endregion

            if (!Bord[0, 1] && !Bord[1, 0])
            {
                zet = new Point(0, 0);
            }

            return zet;
        }

        public Point SecondPlayer()
        {
            Point zet = new Point(0, 0);

            #region CHE01
            if (Bord[1, 1])
            {
                if (MaxX % 2 == 0 && MaxY % 2 == 0)
                {
                    if (MaxX > MaxY)
                    {
                        if ((MaxX + MaxY) % 2 == 0)
                        {
                            zet = new Point(MaxX, 0);
                        }
                        else
                        {
                            zet = new Point(MaxX - 1, 0);

                        }
                    }
                    else
                    {
                        if ((MaxX + MaxY) % 2 == 0)
                        {
                            zet = new Point(0, MaxY);
                        }
                        else
                        {
                            zet = new Point(0, MaxY - 1);

                        }
                    }
                }
                else
                {
                    zet = new Point(1, 1);
                }
            }
            else
            {
                if (MaxX > MaxY)
                {
                    if ((MaxX + MaxY) % 2 == 0)
                    {
                        zet = new Point(MaxX - 1, 0);
                    }
                    else
                    {
                        zet = new Point(MaxX, 0);
                    }
                }
                else
                {
                    if ((MaxX + MaxY) % 2 == 0)
                    {
                        zet = new Point(0, MaxY - 1);
                    }
                    else
                    {
                        zet = new Point(0, MaxY);
                    }
                }
            }
            #endregion

            #region CHE02
            if (MaxX == 2 && MaxY == 4)
            {
                if (Bord[2, 2])
                {
                    zet = new Point(2, 2);
                }
                else if (Bord[1, 1])
                {
                    if (Bord[3, 1])
                    {
                        zet = new Point(1, 3);
                    }
                    else if (Bord[2, 1])
                    {
                        zet = new Point(1, 2);
                    }
                    else if (Bord[4, 1])
                    {
                        zet = new Point(1, 4);
                    }
                    else if (Bord[1, 2])
                    {
                        zet = new Point(2, 1);
                    }
                    else
                    {
                        zet = new Point(1, 1);
                    }
                }
            }
            #endregion

            #region CHE03
            if (MaxY == 3 && MaxX == 2 && Bord[3, 0])
            {
                zet = new Point(0, 3);
            }
            else if (MaxX == 3 && MaxY == 2 && Bord[0, 3])
            {
                zet = new Point(3, 0);
            }
            #endregion

            #region CHE04
            if (MaxX == 4 && MaxY == 4)
            {
                if (Bord[1, 1])
                {
                    zet = new Point(1, 1);
                }
                else
                {
                    zet = new Point(0, 4);
                }
            }
            #endregion

            #region CHE05
            if (Bord[1, 0] && MaxY > 1 && MaxX == 1)
            {
                zet = new Point(0, 2);
            }
            else if (Bord[0, 1] && MaxX > 1 && MaxY == 1)
            {
                zet = new Point(2, 0);
            }
            #endregion

            #region CHE06
            // Winning move vertical
            if (Bord[1, 0] && !Bord[0, 1])
            {
                zet = new Point(0, 1);
            }
            // Winning move horizontal
            if (Bord[0, 1] && !Bord[1, 0])
            {
                zet = new Point(1, 0);
            }
            #endregion

            if (!Bord[0,1] && !Bord[1,0])
            {
                zet = new Point(0, 0);
            }

            return zet;
        }

    }
}
