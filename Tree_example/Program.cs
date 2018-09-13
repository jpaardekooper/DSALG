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

            DirectedGraph graph = new DirectedGraph();

            GraphNode f1 = new GraphNode();
            GraphNode f2 = new GraphNode();
            GraphNode f3 = new GraphNode();
            GraphNode f4 = new GraphNode();
            GraphNode f5 = new GraphNode();
            GraphNode f6 = new GraphNode();
            GraphNode f7 = new GraphNode();

            graph.AddNode(f1);
            graph.AddNode(f2);
            graph.AddNode(f3);
            graph.AddNode(f4);
            graph.AddNode(f5);
            graph.AddNode(f6);
            graph.AddNode(f7);
            
            graph.AddDirectedEdge(f1, f2, 5);
            graph.AddDirectedEdge('A', 'C', 10);
            graph.AddDirectedEdge('A', 'D', 20);

            graph.RemoveDirectedEdge(f1, f2, 5);
            graph.RemoveDirectedEdge('A', 'C', 10);
            graph.RemoveDirectedEdge('A', 'D', 30);


            graph.PrintAllNodes();
            f1.PrintAllEdgeds();

            Console.ReadKey();
        }
    }
}
