using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Node;
using Dijkstra_JM;

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

            DirectedGraph Richard = DirectedGraph.GetTestGraph(1);
            Dijkstra d = new Dijkstra(Richard);

            List<GraphNode> t = new List<GraphNode>();

            GraphNode from = Richard.FindNode('H');
            GraphNode to = Richard.FindNode('I');

            t = d.GetShortestPathDijikstra(from, to);

            //act

            string path = "";

            foreach (var item in t)
            {
                path += item.Identifier;
            }






            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

           

        }
    }
}
