using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Node;

namespace VisualizeGraphDijkstra
{
   

    public partial class Form1 : Form
    {
        Point lastPoint = Point.Empty;//Point.Empty represents null for a Point object
        Random rng = new Random();
        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("New Graph project");

            DirectedGraph graph = DirectedGraph.GetTestGraph(2);

            graph.PrintAllNodes();
            graph.PrintAllNodeEdges();

            Console.WriteLine(graph.DoesPathExist('E', 'F'));

         

            for (int i = 0; i < 9; i++)
            {
                DrawPictureBoxToForm(rng.Next(100,400), rng.Next(100,400), i);
            }

        }
      
        public void DrawPictureBoxToForm(int pointX, int pointY, int i)
        {           
                PictureBox Node = new PictureBox();
                Node.Tag = "Node_" + i;
                Node.Width = 10;
                Node.Height = 10;
                Node.Location = new Point(pointX, pointY);
                Node.BackColor = Color.Red;

                this.Controls.Add(Node);
        }

     

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
          
            //Create graphic object for the current form
            Graphics gs = this.CreateGraphics();

            //Create brush object   
            Brush br2 = new SolidBrush(Color.Black);

            //Create pen objects
            Pen p1 = new Pen(br2);
            Pen p2 = new Pen(br2);
            Pen p3 = new Pen(br2);
            Pen p4 = new Pen(br2);
            Pen p5 = new Pen(br2);
            Pen p6 = new Pen(br2);
            Pen p7 = new Pen(br2);
            Pen p8 = new Pen(br2);

            //Draw lines
            gs.DrawLine(p1, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p1, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p2, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p2, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p3, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p3, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p4, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p4, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p5, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p5, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p6, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
            gs.DrawLine(p6, new Point(rng.Next(100, 400), rng.Next(100, 400)), new Point(rng.Next(100, 400), rng.Next(100, 400)));
        }

   

    }
}

