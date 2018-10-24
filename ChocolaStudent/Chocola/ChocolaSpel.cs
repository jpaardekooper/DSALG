using Chocola.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chocola
{
    class ChocolaSpel
    {
        private const int DELAY = 500;
        private int sizeX;
        private int sizeY;

        private ChocolaSpeler spelerEen;
        private ChocolaSpeler spelerTwee;
        private ChocolaSpeler beurt;
        private bool bezig;

        private bool[,] spelBord;
        private ChocolaMainForm ChocolaScherm;


        public ChocolaSpel(ChocolaMainForm ChocolaScherm)
        {
            this.ChocolaScherm = ChocolaScherm;
            bezig = false;
        }

        private void InitBord()
        {
            spelBord = new bool[sizeY, sizeX];
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    spelBord[i, j] = true;
                }
            }
        }

        private void PrintBord()
        {
            ChocolaScherm.updateScherm(spelBord, sizeX, sizeY);
        }

        public bool VerliesZet(Point zet)
        {
            return (zet.X == 0 && zet.Y == 0);
        }

        public bool MagZet(Point zet)
        {
            return spelBord[zet.Y, zet.X];
        }

        public void DoeZet(Point zet)
        {
            for (int i = zet.Y; i < sizeY; i++)
            {
                for (int j = zet.X; j < sizeX; j++)
                {
                    spelBord[i, j] = false;
                }
            }
        }

        private void Afgelopen()
        {
            bezig = false;
            MessageBox.Show(beurt + " (speler " + (beurt == spelerEen ? "1" : "2") + ") heeft verloren!");
        }

        public void startNieuwSpel(ChocolaSpeler een, ChocolaSpeler twee, int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            InitBord();
            PrintBord();
            spelerEen = een;
            spelerTwee = twee;
            een.OnZetGedaan += Een_OnZetGedaan;
            twee.OnZetGedaan += Twee_OnZetGedaan;
            bezig = true;
            beurt = een;
            beurt.DoeChocolaZet(spelBord, sizeX, sizeY);
        }

        private void Twee_OnZetGedaan(Point zet)
        {
            if (bezig)
            {
                if (MagZet(zet))
                {
                    if (VerliesZet(zet))
                    {
                        Afgelopen();
                    }
                    else
                    {
                        DoeZet(zet);
                        PrintBord();
                        Thread.Sleep(DELAY);
                        beurt = spelerEen;
                        beurt.DoeChocolaZet(spelBord, sizeX, sizeY);
                    }
                }
                else
                {
                    Console.WriteLine("Ongeldige zet");
                    beurt.DoeChocolaZet(spelBord, sizeX, sizeY);
                }
            }
        }

        private void Een_OnZetGedaan(Point zet)
        {
            if (bezig)
            {
                if (MagZet(zet))
                {
                    if (VerliesZet(zet))
                    {
                        Afgelopen();
                    }
                    else
                    {
                        DoeZet(zet);
                        PrintBord();
                        Thread.Sleep(DELAY);
                        beurt = spelerTwee;
                        beurt.DoeChocolaZet(spelBord, sizeX, sizeY);
                    }
                }
                else
                {
                    Console.WriteLine("Ongeldige zet");
                    beurt.DoeChocolaZet(spelBord, sizeX, sizeY);
                }
            }
        }

        public void ClickZet(Point zet)
        {
            if (bezig && zet.X < sizeX && zet.Y < sizeY)
            {
                if (MagZet(zet))
                {
                    if (VerliesZet(zet))
                    {
                        Afgelopen();
                    }
                    else
                    {
                        DoeZet(zet);
                        PrintBord();
                        Thread.Sleep(DELAY);
                        if (beurt == spelerTwee)
                        {
                            beurt = spelerEen;
                        }
                        else
                        {
                            beurt = spelerTwee;
                        }
                        beurt.DoeChocolaZet(spelBord, sizeX, sizeY);
                    }
                }
            }
        }

    }
}
