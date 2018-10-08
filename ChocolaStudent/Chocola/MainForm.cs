using Chocola.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chocola
{
   
    public partial class ChocolaMainForm : Form
    {
        ChocolaSpel chocola;
        Bitmap buffer;
        Graphics bufferGraphics;
        Image imgGiftig;
        Image imgChoco;
        Image imgOp;
        public ChocolaMainForm()
        {
            InitializeComponent();
            chocola = new ChocolaSpel(this);
            buffer = new Bitmap(spelBord.Width, spelBord.Height);
            bufferGraphics = Graphics.FromImage(buffer);

            imgGiftig = Resources.chocoGiftig;
            imgChoco = Resources.choco;
            imgOp = Resources.chocoOp;

            spelBord.MouseClick += SpelBord_MouseClick;

        }

        private void SpelBord_MouseClick(object sender, MouseEventArgs e)
        {
            Point zet = new Point(); ;
            zet.X = e.X / imgGiftig.Size.Width;
            zet.Y = e.Y / imgGiftig.Size.Height;
            chocola.ClickZet(zet);
        }

        public void updateScherm(Boolean[,] spelBord, int sizeX, int sizeY)
        {
            bufferGraphics.Clear(Color.Transparent);
            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        bufferGraphics.DrawImage(imgGiftig, 0, 0, imgGiftig.Size.Width, imgGiftig.Size.Height);
                    }
                    else {
                        if (spelBord[i, j])
                        {
                            bufferGraphics.DrawImage(imgChoco, (j * imgChoco.Size.Width), (i * imgChoco.Size.Height), imgChoco.Size.Width, imgChoco.Size.Height);
                        }
                        else
                        {
                            bufferGraphics.DrawImage(imgOp, (j * imgOp.Size.Width), (i * imgOp.Size.Height), imgOp.Size.Width, imgOp.Size.Height);
                        }
                    }
                }
            }
            this.spelBord.Image = buffer;
            this.Refresh();
        }

        private void VoegSpelerToe(ChocolaSpeler deze)
        {
            speler1.Items.Add(deze);
            speler2.Items.Add(deze);
        }

        private void ChocolaMainForm_Load(object sender, EventArgs e)
        {
            VoegSpelerToe(new MensSpeler());
            VoegSpelerToe(new RandomSpeler());
            VoegSpelerToe(new SlimmeSpeler());
            
            speler1.SelectedIndex = 0;
            speler2.SelectedIndex = 1;
        }

        private void startEnkel_Click(object sender, EventArgs e)
        {
            int sizeX;
            int sizeY;

            if (full.Checked)
            {
                sizeX = 20;
                sizeY = 5;
            }
            else if (square.Checked)
            {
                sizeX = 5;
                sizeY = 5;
            }
            else if (smal.Checked)
            {
                sizeX = 20;
                sizeY = 3;
            }
            else
            {
                sizeX = 20;
                sizeY = 2;
            }
            chocola.startNieuwSpel((ChocolaSpeler)speler1.SelectedItem, (ChocolaSpeler)speler2.SelectedItem, sizeX, sizeY);
        }

    }
}
