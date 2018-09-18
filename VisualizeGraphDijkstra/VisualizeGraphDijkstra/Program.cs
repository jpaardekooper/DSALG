using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Node;

namespace VisualizeGraphDijkstra
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //arrange
            DirectedGraph Richard = DirectedGraph.GetTestGraph(3);

            //act


            //List<char> Path = Richard.GetShortestPath('H', 'I');

            //Path.ToString();

        }
    }
}
