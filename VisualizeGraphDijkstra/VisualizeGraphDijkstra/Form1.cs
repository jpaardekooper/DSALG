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
        List<PictureBox> ListForStartAndEndNodes = new List<PictureBox>();

        //dynamically points for the graph
        List<Point> polyPoints = new List<Point>();
        List<Point> polyPoints2 = new List<Point>();
        bool graph_random = false;

        /// <summary>
        /// Points and Labels for graph 1
        /// </summary>
        List<Point> graph1 = new List<Point>();
        List<Point> label1 = new List<Point>();
        //only show graph one if its true
        bool graph_one = false;

        /// <summary>
        /// Points and Labels for graph 2
        /// </summary>
        List<Point> graph2 = new List<Point>();
        List<Point> label2 = new List<Point>();
        //only show graph one if its true
        bool graph_two = false;

        /// <summary>
        /// Points and Labels for graph 3
        /// </summary>
        List<Point> graph3 = new List<Point>();
        List<Point> label3 = new List<Point>();
        //only show graph one if its true
        bool graph_three = false;

        DirectedGraph Datagraph1;
        DirectedGraph Datagraph2;
        DirectedGraph Datagraph3;
        DirectedGraph DataRandom;

        GraphNode information = new GraphNode();

        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("New Graph project created by Marnix and Jasper");
        }

        /// <summary>
        /// creaating points for graph1
        /// </summary>
        private void CreatePointAndLabelForGraphOne()
        {
            //graph1
            graph1.Add(new Point(320, 50)); //a
            graph1.Add(new Point(130, 250)); //b
            graph1.Add(new Point(180, 160)); //c
            graph1.Add(new Point(360, 270)); //d

            //end node
            graph1.Add(new Point(240, 190)); // e
            //start node
            graph1.Add(new Point(50, 100)); // f

            for (int i = 0; i < graph1.Count(); i++)
            {
                label1.Add(graph1[i]);
                DrawPictureBoxToForm(graph1[i].X, graph1[i].Y, 65 + i);
            }
        }

        /// <summary>
        /// creating points for graph2
        /// </summary>
        private void CreatePointAndLabelForGraphTwo()
        {
            //graph 2
            graph2.Add(new Point(250, 25)); //a
            graph2.Add(new Point(85, 250)); //b
            graph2.Add(new Point(150, 125)); //c
            graph2.Add(new Point(170, 260)); //d
            graph2.Add(new Point(360, 150)); //e
            graph2.Add(new Point(180, 340)); //f
            graph2.Add(new Point(260, 280)); //g

            //start node
            graph2.Add(new Point(50, 100)); //h
            //end node
            graph2.Add(new Point(380, 240)); //i
    

            for (int i = 0; i < graph2.Count(); i++)
            {
                label2.Add(graph2[i]);
                DrawPictureBoxToForm(graph2[i].X, graph2[i].Y, 65 + i);

            }
        }
        /// <summary>
        /// creating points for graph 3
        /// </summary>
        private void CreatePointAndLabelForGraphThree()
        {
            //graph 3
            graph3.Add(new Point(250, 25)); //a
            graph3.Add(new Point(85, 250)); //b
            graph3.Add(new Point(150, 125)); //c
            graph3.Add(new Point(170, 260)); //d
            graph3.Add(new Point(360, 150)); //e
            graph3.Add(new Point(180, 310)); //f
            graph3.Add(new Point(260, 280)); //g

            //start node
            graph3.Add(new Point(50, 100)); //h
            //end node
            graph3.Add(new Point(130, 365)); //i
            
            for (int i = 0; i < graph3.Count(); i++)
            {
                label3.Add(graph3[i]);
                DrawPictureBoxToForm(graph3[i].X, graph3[i].Y, 65 + i);
            }

        }

        /// <summary>
        /// Creating the labels and pictureboxes to the form
        /// </summary>
        /// <param name="x">for position x</param>
        /// <param name="y">for the position y</param>
        /// <param name="i">for the character in the alfabet starting with a</param>
        private void DrawPictureBoxToForm(int x, int y, int i)
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

            ListForStartAndEndNodes.Add(Node);
         
            if(graph_two)
            {
                //start Node is color green with the Tag of H
                if (Node.Tag.Equals('H'))
                {
                    Node.BackColor = Color.Black;
                    // label.Left = x + 15; 
                    Node.Size = new Size(20, 20);
                    this.Controls.Add(Node);
                }
                //end Node is color red with the Tag of I
                if (Node.Tag.Equals('I'))
                {
                    Node.BackColor = Color.Red;
                    Node.Size = new Size(20, 20);
                    // label.Top = y - 15;
                    this.Controls.Add(Node);
                }
            }
            else if (graph_three)
            {
                //start Node is color green with the Tag of H
                if (Node.Tag.Equals('H'))
                {
                    Node.BackColor = Color.Black;
              //      label.Left = x + 15; 
                    Node.Size = new Size(20, 20);
                    this.Controls.Add(Node);
                }
                //end Node is color red with the Tag of I
                if (Node.Tag.Equals('I'))
                {
                    Node.BackColor = Color.Red;
                    Node.Size = new Size(20, 20);
               //    label.Top = y - 15;
                    this.Controls.Add(Node);
                }
            }
            else
            {
                //start Node is color green with the Tag of H
                if (Node.Tag.Equals('F'))
                {
                    Node.BackColor = Color.Black;
                  //  label.Left = x + 25; 
                    Node.Size = new Size(20, 20);
                    this.Controls.Add(Node);
                }
                //end Node is color red with the Tag of I
                if (Node.Tag.Equals('D'))
                {
                    Node.BackColor = Color.Red;
                    Node.Size = new Size(20, 20);
              //      label.Top = y - 25;
                    this.Controls.Add(Node);
                }
            }          

            this.Controls.Add(label);
        }


        /// <summary>
        /// painting the graph to the form 
        /// with Labels for the Nodes and Weight
        /// Picturebox for start node and end node
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (graph_one)
            {
                foreach (var item in Datagraph1.NodeList)
                {
                    foreach (var h in item.DirectedEdge)
                    {

                        if (item.Identifier.ToString() == ListForStartAndEndNodes[i].Tag.ToString())
                        {
                            for (int x = 0; x < ListForStartAndEndNodes.Count(); x++)
                            {
                                if (ListForStartAndEndNodes[x].Tag.ToString() == h.Key.Identifier.ToString())
                                {
                                    gs.DrawLine(p1, new Point(ListForStartAndEndNodes[i].Location.X, ListForStartAndEndNodes[i].Location.Y), new Point(ListForStartAndEndNodes[x].Location.X, ListForStartAndEndNodes[x].Location.Y));

                                    AddDistanceLabels(ListForStartAndEndNodes[x].Location.X / 2 + (ListForStartAndEndNodes[i].Location.X / 2), ListForStartAndEndNodes[x].Location.Y / 2 + (ListForStartAndEndNodes[i].Location.Y / 2), $"{h.Value}");

                                    // Debug.WriteLine($"{item.Identifier}{h.Key.Identifier}{h.Value}" + " " + ListForStartAndEndNodes[i].Tag + " " + ListForStartAndEndNodes[x].Tag);

                                }
                            }
                        }
                    }
                    i++;
                }
            }

            //Draw lines 
            if (graph_two)
            {
                foreach (var item in Datagraph2.NodeList)
                {
                    foreach (var h in item.DirectedEdge)
                    {

                        if (item.Identifier.ToString() == ListForStartAndEndNodes[i].Tag.ToString())
                        {
                            for (int x = 0; x < ListForStartAndEndNodes.Count(); x++)
                            {
                                if (ListForStartAndEndNodes[x].Tag.ToString() == h.Key.Identifier.ToString())
                                {
                                    gs.DrawLine(p1, new Point(ListForStartAndEndNodes[i].Location.X, ListForStartAndEndNodes[i].Location.Y), new Point(ListForStartAndEndNodes[x].Location.X, ListForStartAndEndNodes[x].Location.Y));

                                    AddDistanceLabels(ListForStartAndEndNodes[x].Location.X / 2 + (ListForStartAndEndNodes[i].Location.X / 2), ListForStartAndEndNodes[x].Location.Y / 2 + (ListForStartAndEndNodes[i].Location.Y / 2), $"{h.Value}");

                                    // Debug.WriteLine($"{item.Identifier}{h.Key.Identifier}{h.Value}" + " " + ListForStartAndEndNodes[i].Tag + " " + ListForStartAndEndNodes[x].Tag);

                                }
                            }
                        }
                    }
                    i++;
                }
            }


            if (graph_three)
            {
                foreach (var item in Datagraph3.NodeList)
                {
                    foreach (var h in item.DirectedEdge)
                    {

                        if (item.Identifier.ToString() == ListForStartAndEndNodes[i].Tag.ToString())
                        {
                            for (int x = 0; x < ListForStartAndEndNodes.Count(); x++)
                            {
                                if (ListForStartAndEndNodes[x].Tag.ToString() == h.Key.Identifier.ToString())
                                {
                                    gs.DrawLine(p1, new Point(ListForStartAndEndNodes[i].Location.X, ListForStartAndEndNodes[i].Location.Y), new Point(ListForStartAndEndNodes[x].Location.X, ListForStartAndEndNodes[x].Location.Y));

                                    AddDistanceLabels(ListForStartAndEndNodes[x].Location.X / 2 + (ListForStartAndEndNodes[i].Location.X / 2), ListForStartAndEndNodes[x].Location.Y / 2 + (ListForStartAndEndNodes[i].Location.Y / 2), $"{h.Value}");

                                    // Debug.WriteLine($"{item.Identifier}{h.Key.Identifier}{h.Value}" + " " + ListForStartAndEndNodes[i].Tag + " " + ListForStartAndEndNodes[x].Tag);

                                }
                            }
                        }
                    }
                    i++;
                }
            }

            if (graph_random)
            {
                foreach (var item in DataRandom.NodeList)
                {
                    foreach (var h in item.DirectedEdge)
                    {

                        if (item.Identifier.ToString() == ListForStartAndEndNodes[i].Tag.ToString())
                        {
                            for (int x = 0; x < ListForStartAndEndNodes.Count(); x++)
                            {
                                if (ListForStartAndEndNodes[x].Tag.ToString() == h.Key.Identifier.ToString())
                                {
                                    gs.DrawLine(p1, new Point(ListForStartAndEndNodes[i].Location.X, ListForStartAndEndNodes[i].Location.Y), new Point(ListForStartAndEndNodes[x].Location.X, ListForStartAndEndNodes[x].Location.Y));

                                    AddDistanceLabels(ListForStartAndEndNodes[x].Location.X / 2 + (ListForStartAndEndNodes[i].Location.X / 2), ListForStartAndEndNodes[x].Location.Y / 2 + (ListForStartAndEndNodes[i].Location.Y / 2), $"{h.Value}");

                                    // Debug.WriteLine($"{item.Identifier}{h.Key.Identifier}{h.Value}" + " " + ListForStartAndEndNodes[i].Tag + " " + ListForStartAndEndNodes[x].Tag);

                                }
                            }
                        }
                    }
                    i++;
                }
            }


        }

        private void AddDistanceLabels(int x, int y, string value)
        {
            Label distance = new Label();

            distance.Left = x;
            distance.Top = y - 8;

            distance.Width = 20;
            distance.Height = 12;

            distance.Text = value;
            this.Controls.Add(distance);
        }

        /// <summary>
        /// on click will show the data of graph 1
        /// and removes all data on the current screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            GraphNode.NodesConnectedTo.Clear();
            Datagraph1 = GetTestData.GetTestGraph(1);
            Datagraph1.PrintAllNodes();
            Datagraph1.PrintAllNodeEdges();
      
            graph_one = true;
            graph_two = false;
            graph_three = false;
            graph_random = false;

            ListForStartAndEndNodes.Clear();

            _removeLabelsFromScreen();

            CreatePointAndLabelForGraphOne();
            getTextBoxData();
            this.Invalidate();

        }

        /// <summary>
        /// on click will show the data of graph 2
        /// and removes all data on the current screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphtwo_Click(object sender, EventArgs e)
        {
            GraphNode.NodesConnectedTo.Clear();
            Datagraph2 = GetTestData.GetTestGraph(2);
            Datagraph2.PrintAllNodes();
            Datagraph2.PrintAllNodeEdges();
           
            graph_one = false;
            graph_two = true;
            graph_three = false;
            graph_random = false;

            ListForStartAndEndNodes.Clear();

            _removeLabelsFromScreen();         

            CreatePointAndLabelForGraphTwo();
            getTextBoxData();
            this.Invalidate();
        }

        /// <summary>
        /// on click will show the data for graph 3
        /// and removes all data on the current screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphthree_Click(object sender, EventArgs e)
        {
            GraphNode.NodesConnectedTo.Clear();
            Datagraph3 = GetTestData.GetTestGraph(3);
            Datagraph3.PrintAllNodes();
            Datagraph3.PrintAllNodeEdges();
            graph_one = false;
            graph_two = false;
            graph_three = true;
            graph_random = false;

            ListForStartAndEndNodes.Clear();

            _removeLabelsFromScreen();
         
            CreatePointAndLabelForGraphThree();
            getTextBoxData();
            this.Invalidate();
        }

        /// <summary>
        /// Really sneaky way to remove the labels and pictureboxes that are still on the screen
        /// </summary>
        private void _removeLabelsFromScreen()
        {
            for (int i = 0; i < 300; i++)
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Label)
                    {
                        c.Dispose();
                    }
                    if (c is PictureBox)
                    {
                        c.Dispose();
                    }
                }
            }
         
        }
        /// <summary>
        /// getting the data from the Graphnode List to put it on the screen
        /// </summary>
        private void getTextBoxData()
        {
            textBox1.Clear();
            foreach (string a in GraphNode.NodesConnectedTo)
            {
                textBox1.Text += a + Environment.NewLine;
            }
        }

        /// <summary>
        /// Creating a random graph up to 26 characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void randomData_Click(object sender, EventArgs e)
        {           
           
            GraphNode.NodesConnectedTo.Clear();
            DataRandom = GetTestData.GetRandomGraph(27);
            DataRandom.PrintAllNodes();
            DataRandom.PrintAllNodeEdges();
            graph_one = false;
            graph_two = false;
            graph_three = false;
            graph_random = true;

            ListForStartAndEndNodes.Clear();

            _removeLabelsFromScreen();


            CreateNodesMap(27);

            getTextBoxData();
            this.Invalidate();
        }

        /// <summary>
        /// Creating a dynamically Poligon that will create points for the nodes
        /// problem is that the nodes can overlap and it will not be visible for the user
        /// fun way to test the node class to test 26 nodes
        /// </summary>
        #region
        public void CreateNodesMap(int data)
        {

            for (int row = 0; row < data; row++)
            {
                int PositionX = rng.Next(1, 35) * 15;
                int PositionY = rng.Next(1, 35) * 15;

                polyPoints.Add(new Point(PositionX, PositionY));
                polyPoints2.Add(new Point(PositionX, PositionY));
            }

            var points = new Point[250];

            int i = 0;
            for (int y = -15; y <= 15; y++)
            {
                for (int x = -15; x <= 15 && i < 250; x++)
                {

                    var c = Math.Sqrt(x * x + y * y);
                    if (10 <= c && c <= 15)
                    {
                        points[i++] = new Point(x, y);
                    }
                }
            }

            for (int count = 0; count < data; count++)
            {
                var p = points[rng.Next(250)];
                DrawPictureBoxToForm(290 + 19 * p.X, 290 + 19 * p.Y, 65 + count);
            }
        }
        #endregion
    }
}

