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

        public Form1()
        {
            InitializeComponent();

            Console.WriteLine("New Graph project");

            DirectedGraph graph = DirectedGraph.GetTestGraph(2);

            graph.PrintAllNodes();
            graph.PrintAllNodeEdges();

            Console.WriteLine(graph.DoesPathExist('E', 'F'));

            DrawPictureBoxToForm(10,10);
            
        }
      
        public void DrawPictureBoxToForm(int pointX, int pointY)
        {      
            PictureBox Node = new PictureBox();
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
            Pen p2 = new Pen(br2);

            //Draw lines
            gs.DrawLine(p2, new Point(10, 10), new Point(50, 70));
            gs.DrawLine(p2, new Point(30, 30), new Point(50, 70));
        }

    }
}

