using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        DirectedGraph graph = DirectedGraph.GetTestGraph(2);


        Random rndLocGen = new Random();

        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("New Graph project");
       

            graph.PrintAllNodes();
            graph.PrintAllNodeEdges();

            Console.WriteLine(graph.DoesPathExist('E', 'F'));


            for (int row = 0; row < graph.NodeList.Count(); row++)
            {
                int PositionX = rndLocGen.Next(1, 35) * 10;
                int PositionY = rndLocGen.Next(1, 35) * 10;

                polyPoints.Add(new Point(PositionX, PositionY));
                polyPoints2.Add(new Point(PositionX, PositionY));
            }


            //for (int z = 0; z < graph.NodeList.Count(); z++)
            //{
            //    DrawPictureBoxToForm(polyPoints[z], polyPoints2[z], 65 + z, z);
            //}


            var points = new Point[300];
            int i = 0;
            for (int y = -15; y <= 15; y++)
            {
                for (int x = -15; x <= 15 && i < 300; x++)
                {

                    var c = Math.Sqrt(x * x + y * y);
                    if (10 <= c && c <= 15)
                    {
                        points[i++] = new Point(x, y);
                    }

                }
            }
                

            //ar bm = new Bitmap(600, 600);
            //var g = Graphics.FromImage(bm);
            //var brush = new SolidBrush(Color.Magenta);

            var r = new System.Random();
            for (int count = 0; count < graph.NodeList.Count(); count++)
            {
                var p = points[r.Next(299)];
               // g.FillEllipse(brush, new Rectangle(290 + 19 * p.X, 290 + 19 * p.Y, 10, 10));
                DrawPictureBoxToForm(290 + 19 * p.X, 290 + 19 * p.Y, 65 + count, count);
            }
            //const string filename = "Constrained Random Circle.png";
            //bm.Save(filename);
            //Process.Start(filename);
        }

        public void DrawPictureBoxToForm(int number, int distance, int i, int x)
        {
            char c = Convert.ToChar(i);

            Node = new PictureBox();
            Label label = new Label();

            label.Text = "" + c;
            label.Left = number;
            label.Top = distance;
            label.Width = 15;
            label.Height = 15;
            label.BringToFront();

            Node.Tag = c;
            Node.Width = 10;
            Node.Height = 10;

            Node.Left = number;
            Node.Top = distance;


            Node.BackColor = Color.Red;

            ListOfPB.Add(Node);
            //  this.Controls.Add(Node);
            this.Controls.Add(label);
        }



        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {

            //Create graphic object for the current form
            Graphics gs = this.CreateGraphics();

            int i = 0;

            //Create brush object   
            Brush br1 = new SolidBrush(Color.Black);
            Brush br2 = new SolidBrush(Color.Red);
            Brush br3 = new SolidBrush(Color.Pink);
            Brush br4 = new SolidBrush(Color.Yellow);
            Brush br5 = new SolidBrush(Color.Purple);
            Brush br6 = new SolidBrush(Color.Orange);
            Brush br7 = new SolidBrush(Color.Green);
            Brush br8 = new SolidBrush(Color.Green);

            //Create pen objects
            Pen p1 = new Pen(br1);
            Pen p2 = new Pen(br2);


            //Draw lines
            List<Vertex> allShit = new List<Vertex>();
       
            
            foreach (var item in graph.NodeList)
            { 
                foreach (var h in item.DirectedEdge)
                {
                    // a -> b lengte 8
                    allShit.Add(new Vertex(graph.FindNode(item.Identifier), h.Key, h.Value));
                   
                    if (item.Identifier.ToString() == ListOfPB[i].Tag.ToString() )
                    {
                        for (int x = 0; x < ListOfPB.Count(); x++)
                        {
                            if (ListOfPB[x].Tag.ToString() == h.Key.Identifier.ToString())
                            {
                                gs.DrawLine(p1, new Point(ListOfPB[i].Location.X, ListOfPB[i].Location.Y), new Point(ListOfPB[x].Location.X, ListOfPB[x].Location.Y));

                                Debug.WriteLine($"{item.Identifier}{h.Key.Identifier}{h.Value}" + " " + ListOfPB[i].Tag + " " + ListOfPB[x].Tag);
                            }
                        }
                    }  
                }
                i++;
            }
           
        }
       

        class Vertex
        {
            public GraphNode From { get; set; }
            public GraphNode To { get; set; }
            public int Distance { get; set; }

            public Vertex(GraphNode from, GraphNode to, int distance)
            {
                From = from;
                To = to;
                Distance = distance;
            }
        }

            
    }
}

