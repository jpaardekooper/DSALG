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

            Graph graph = new Graph();

            Node f1 = new Node();
            Node f2 = new Node();
            Node f3 = new Node();
            Node f4 = new Node();
            Node f5 = new Node();
            Node f6 = new Node();
            Node f7 = new Node();

            graph.AddNode(f1);
            graph.AddNode(f2);
            graph.AddNode(f3);
            graph.AddNode(f4);
            graph.AddNode(f5);
            graph.AddNode(f6);
            graph.AddNode(f7);

            graph.RemoveNode('A');
            graph.RemoveNode(f4);

            for (int i = 0; i < graph.NodeList.Count; i++)
            {
                Console.WriteLine(graph.NodeList[i].Identifier);
                
            }

            Console.ReadKey();
        }
    }
}
