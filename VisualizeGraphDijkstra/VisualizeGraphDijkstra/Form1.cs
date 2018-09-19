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

        Random rng = new Random();
        PictureBox Node;
        List<PictureBox> ListOfPB = new List<PictureBox>();

        List<Point> polyPoints = new List<Point>();
        List<Point> polyPoints2 = new List<Point>();



        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("New Graph project");

            DirectedGraph graph = DirectedGraph.GetTestGraph(2);

            graph.PrintAllNodes();
            graph.PrintAllNodeEdges();

            Console.WriteLine(graph.DoesPathExist('E', 'F'));

            //a
            polyPoints.Add(new Point(50, 50));
            //b
            polyPoints.Add(new Point(150, 70));
            //c
            polyPoints.Add(new Point(40, 170));
            //d
            polyPoints.Add(new Point(100, 280));
            //e
            polyPoints.Add(new Point(280, 110));
            //f
            polyPoints.Add(new Point(250, 210));
            //g
            polyPoints.Add(new Point(200, 300));
            //h
            polyPoints.Add(new Point(410, 290));
            //i
            polyPoints.Add(new Point(480, 175));

            //a
            polyPoints2.Add(new Point(50, 30));
            //b
            polyPoints2.Add(new Point(150, 50));
            //c
            polyPoints2.Add(new Point(20, 170));
            //d
            polyPoints2.Add(new Point(100, 290));
            //e
            polyPoints2.Add(new Point(280, 90));
            //f
            polyPoints2.Add(new Point(250, 180));
            //g
            polyPoints2.Add(new Point(200, 320));
            //h
            polyPoints2.Add(new Point(410, 270));
            //i
            polyPoints2.Add(new Point(480, 140));



            for (int i = 0; i < graph.NodeList.Count(); i++)
            {       
                DrawPictureBoxToForm(polyPoints[i], polyPoints2[i], 65 + i, i);

            }
            foreach (PictureBox p in ListOfPB)
            {
                Console.WriteLine(p.Tag + "een" + p.Location);
            }

        }

        public void DrawPictureBoxToForm(Point number, Point distance, int i, int x)
        {
            char c = Convert.ToChar(i);

            Node = new PictureBox();
            Label label = new Label();

            label.Text = "" + c;
            label.Location = distance;
            label.Width = 15;
            label.Height = 15;
            label.BringToFront();

            Node.Tag = c;
            Node.Width = 10;
            Node.Height = 10;
            Node.Location = number;
            
          
            Node.BackColor = Color.Red;

            ListOfPB.Add(Node);
          this.Controls.Add(Node);
            this.Controls.Add(label);

            Console.WriteLine(ListOfPB[x]);
        }



        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {

            //Create graphic object for the current form
            Graphics gs = this.CreateGraphics();

            //Create brush object   
            Brush br1 = new SolidBrush(Color.Black);
            Brush br2 = new SolidBrush(Color.Red);

            //Create pen objects
            Pen p1 = new Pen(br1);
            Pen p2 = new Pen(br2);


            //Draw lines

            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(0).Location.X, ListOfPB.ElementAt(0).Location.Y), new Point(ListOfPB.ElementAt(1).Location.X, ListOfPB.ElementAt(1).Location.Y));
            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(0).Location.X, ListOfPB.ElementAt(0).Location.Y), new Point(ListOfPB[2].Location.X, ListOfPB[2].Location.Y));

            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(1).Location.X, ListOfPB.ElementAt(1).Location.Y), new Point(ListOfPB.ElementAt(4).Location.X, ListOfPB.ElementAt(4).Location.Y));
         

            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(1).Location.X, ListOfPB.ElementAt(1).Location.Y), new Point(ListOfPB.ElementAt(3).Location.X, ListOfPB.ElementAt(3).Location.Y));
            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(2).Location.X, ListOfPB.ElementAt(2).Location.Y), new Point(ListOfPB[3].Location.X, ListOfPB[3].Location.Y));

            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(3).Location.X, ListOfPB.ElementAt(3).Location.Y), new Point(ListOfPB.ElementAt(4).Location.X, ListOfPB.ElementAt(4).Location.Y));
            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(3).Location.X, ListOfPB.ElementAt(3).Location.Y), new Point(ListOfPB[5].Location.X, ListOfPB[5].Location.Y));

            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(5).Location.X, ListOfPB.ElementAt(5).Location.Y), new Point(ListOfPB.ElementAt(6).Location.X, ListOfPB.ElementAt(6).Location.Y));
            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(6).Location.X, ListOfPB.ElementAt(6).Location.Y), new Point(ListOfPB[7].Location.X, ListOfPB[7].Location.Y));

            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(6).Location.X, ListOfPB.ElementAt(6).Location.Y), new Point(ListOfPB.ElementAt(8).Location.X, ListOfPB.ElementAt(8).Location.Y));
            gs.DrawLine(p1, new Point(ListOfPB.ElementAt(4).Location.X, ListOfPB.ElementAt(4).Location.Y), new Point(ListOfPB[8].Location.X, ListOfPB[8].Location.Y));

        }



    }
}

