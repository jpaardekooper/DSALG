using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSALG_Tree;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("New Graph project");

            DirectedGraph graph = DirectedGraph.GetTestGraph(2);

            graph.PrintAllNodes();
            graph.PrintAllNodeEdges();

            Console.WriteLine(graph.DoesPathExist('E', 'F'));

            

            Console.ReadKey();
        }
    }
}
