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

        DirectedGraph graph = GetTestData.GetTestGraph(2);


        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("New Graph project");


            graph.PrintAllNodes();
            graph.PrintAllNodeEdges();
            CreateNodesMap();

<<<<<<< HEAD
            Console.WriteLine(graph.DoesPathExist('E', 'F'));     
        }
=======
            
>>>>>>> 0ff103f7bb283a6d39cff4864d65aca816bb125e

        /// <summary>
        /// Creating the map of the Nodes we define a circle and all nodes need to be outside of the circle
        /// </summary>
        public void CreateNodesMap()
        {

            for (int row = 0; row < graph.NodeList.Count(); row++)
            {
                int PositionX = rng.Next(1, 35) * 15;
                int PositionY = rng.Next(1, 35) * 15;

                polyPoints.Add(new Point(PositionX, PositionY));
                polyPoints2.Add(new Point(PositionX, PositionY));
            }

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

           
            for (int count = 0; count < graph.NodeList.Count(); count++)
            {
                var p = points[rng.Next(299)];              
                DrawPictureBoxToForm(290 + 19 * p.X, 290 + 19 * p.Y, 65 + count);
            }
        }

        public void DrawPictureBoxToForm(int x, int y, int i)
        {
            char c = Convert.ToChar(i);

            //creating labels
            Label label = new Label();
            label.Text = "" + c;
            label.Left = x;
            label.Top = y;
            label.Width = 15;
            label.Height = 15;
            label.BringToFront();

            //creating picturebox
            Node = new PictureBox();
            Node.Tag = c;
            Node.Width = 10;
            Node.Height = 10;
            Node.Left = x;
            Node.Top = y;
          

            ListOfPB.Add(Node);
     
            //start Node is color green with the Tag of H
            if (Node.Tag.Equals('H'))
            {
                Node.BackColor = Color.Green;
                this.Controls.Add(Node);
            }
            //start Node is color red with the Tag of I
            if (Node.Tag.Equals('I'))
            {
                Node.BackColor = Color.Red;
                this.Controls.Add(Node);
            }

            this.Controls.Add(label);
        }



        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            int i = 0;

            //Create graphic object for the current form
            Graphics gs = this.CreateGraphics();            

            //Create brush object   
            Brush br1 = new SolidBrush(Color.Black);      

            //Create pen objects
            Pen p1 = new Pen(br1); 


            //Draw lines 
            foreach (var item in graph.NodeList)
            {
                foreach (var h in item.DirectedEdge)
                {
                  
                    if (item.Identifier.ToString() == ListOfPB[i].Tag.ToString())
                    {
                        for (int x = 0; x < ListOfPB.Count(); x++)
                        {
                            if (ListOfPB[x].Tag.ToString() == h.Key.Identifier.ToString())
                            {
                                gs.DrawLine(p1, new Point(ListOfPB[i].Location.X, ListOfPB[i].Location.Y), new Point(ListOfPB[x].Location.X, ListOfPB[x].Location.Y));

                                AddDistanceLabels(ListOfPB[x].Location.X / 2 + (ListOfPB[i].Location.X / 2), ListOfPB[x].Location.Y / 2 + (ListOfPB[i].Location.Y / 2), $"{h.Value}");

                                Debug.WriteLine($"{item.Identifier}{h.Key.Identifier}{h.Value}" + " " + ListOfPB[i].Tag + " " + ListOfPB[x].Tag);
                                
                            }
                        }
                    }
                }
                i++;
            }

        }

        public void AddDistanceLabels(int x, int y, string value)
        {
            Label distance = new Label();

            distance.Left = x;
            distance.Top = y - 16;

            distance.Width = 12;
            distance.Height = 12;

            distance.Text = value;
            this.Controls.Add(distance);
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

