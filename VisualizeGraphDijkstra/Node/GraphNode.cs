using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    public class GraphNode
    {
        public char Identifier { get; set; }
        public Dictionary<GraphNode, int> DirectedEdge { get; set; }
        public bool Visited { get; set; } = false;
        public double? BackTrackWeight { get; set; }
        public GraphNode NearestToStart { get; set; }

        public static List<string> test = new List<string>();


        public GraphNode()
        {
            if (DirectedEdge == null)
            {
                DirectedEdge = new Dictionary<GraphNode, int>();
            }
        }

        public void PrintAllEdgeds()
        {
            foreach (KeyValuePair<GraphNode, int> keyValuePair in DirectedEdge)
            {
                test.Add($"Connected from = {Identifier}, to = {keyValuePair.Key.Identifier}, weight = {keyValuePair.Value}");     

                Console.WriteLine($"Connected from = {Identifier}, to = {keyValuePair.Key.Identifier}, weight = {keyValuePair.Value}");
           
            }
        }      

    }

    /// <summary>
    /// Directed graph build from nodes and weighted edges
    /// </summary>
    public class DirectedGraph
    {
        public List<GraphNode> NodeList;

        public DirectedGraph()
        {   
            if (NodeList == null)
            {
                NodeList = new List<GraphNode>();
            }
        }
               
        public void AddNode(GraphNode newNode)
        {
            if (NodeList.Any())
            {
                int tempIdentifier = NodeList.Last().Identifier;

                tempIdentifier++;

                newNode.Identifier = (char)tempIdentifier;
            }
            else
            {
                newNode.Identifier = 'A';
            }

            NodeList.Add(newNode);
        }

        public void RemoveNode(char identifier)
        {
            if (!DRNE(new char[] { identifier }))
            {
                return;
            }

            NodeList.Remove(FindNode(identifier));
        }

        public void AddDirectedEdge(char from, char to, int weight)
        {
            if (!DRNE(new char[] { from, to }))
            {
                return;
            }

            // no dubble edges
            if (FindNode(from).DirectedEdge.ContainsKey(FindNode(to)))
            {
                return;
            }

            FindNode(from).DirectedEdge.Add(FindNode(to), weight);
        }
               
        public string PrintAllNodes()
        {
            string nodeRepresentation = "";

            foreach (GraphNode node in NodeList)
            {
                nodeRepresentation += node.Identifier.ToString();
            }

            return nodeRepresentation;
        }

        public void PrintAllNodeEdges()
        {
            foreach (GraphNode node in NodeList)
            {
                node.PrintAllEdgeds();
            }
        }
                
        /// <summary>
        /// Does Requested Nodes Exist
        /// </summary>
        /// <returns></returns>
        public bool DRNE(char[] identifiers)
        {
            foreach (var item in NodeList)
            {
                if (item.Identifier > NodeList.Last().Identifier || item.Identifier < 65)
                {
                    Debug.WriteLine($"The requested node {item.Identifier} does not exist");
                    return false;
                }
            }
            
            return true;
        }
        
        public void RemoveDirectedEdgeFunction(char from, char to, int weight)
        {
            if (!DRNE(new char[] { from, to }))
            {
                return;
            }

            if (FindNode(from).DirectedEdge[FindNode(to)].Equals(weight))
            {
                FindNode(from).DirectedEdge.Remove(FindNode(to));
            }
        }
                        
        public GraphNode FindNode(char NodeId)
        {
            return NodeList.Find(x => x.Identifier == NodeId);
        }
    }

    public class GetTestData
    {
        public static DirectedGraph GetTestGraph(int graphVersion)
        {
            if (graphVersion == 1) return TestGraph1();
            else if (graphVersion == 2) return TestGraph2();
            else if (graphVersion == 3) return TestGraph3();
            
            return null;
        }

        public static DirectedGraph TestGraph1()
        {
            DirectedGraph graph = new DirectedGraph();

            for (int i = 0; i < 6; i++)
            {
                graph.AddNode(new GraphNode());
            }

            graph.AddDirectedEdge('A', 'D', 6);
            graph.AddDirectedEdge('A', 'E', 2);
            graph.AddDirectedEdge('E', 'D', 3);
            graph.AddDirectedEdge('B', 'D', 1);
            graph.AddDirectedEdge('C', 'E', 4);
            graph.AddDirectedEdge('F', 'A', 3);
            graph.AddDirectedEdge('F', 'C', 2);
            graph.AddDirectedEdge('F', 'B', 6);

            return graph;
        }
        
        private static DirectedGraph TestGraph2()
        {
            DirectedGraph graph = new DirectedGraph();

            for (int i = 0; i < 9; i++)
            {
                graph.AddNode(new GraphNode());
            }

            graph.AddDirectedEdge('H', 'A', 1);
            graph.AddDirectedEdge('H', 'C', 5);
            graph.AddDirectedEdge('H', 'B', 4);
            graph.AddDirectedEdge('G', 'I', 1);
            graph.AddDirectedEdge('E', 'I', 8);
            graph.AddDirectedEdge('G', 'E', 3);
            graph.AddDirectedEdge('F', 'G', 2);
            graph.AddDirectedEdge('D', 'F', 3);
            graph.AddDirectedEdge('A', 'D', 7);
            graph.AddDirectedEdge('C', 'E', 4);
            graph.AddDirectedEdge('B', 'C', 2);
            graph.AddDirectedEdge('B', 'D', 5);

            return graph;
        }

        private static DirectedGraph TestGraph3()
        {
            DirectedGraph graph = new DirectedGraph();

            for (int i = 0; i < 9; i++)
            {
                graph.AddNode(new GraphNode());
            }

            graph.AddDirectedEdge('H', 'A', 3);
            graph.AddDirectedEdge('H', 'C', 2);
            graph.AddDirectedEdge('H', 'B', 6);
            graph.AddDirectedEdge('D', 'I', 12);
            graph.AddDirectedEdge('G', 'I', 5);
            graph.AddDirectedEdge('D', 'F', 4);
            graph.AddDirectedEdge('F', 'G', 4);
            graph.AddDirectedEdge('E', 'G', 9);
            graph.AddDirectedEdge('E', 'D', 2);
            graph.AddDirectedEdge('B', 'D', 1);
            graph.AddDirectedEdge('A', 'D', 3);
            graph.AddDirectedEdge('A', 'E', 4);
            graph.AddDirectedEdge('C', 'E', 6);
            graph.AddDirectedEdge('G', 'D', 4);

            return graph;
        }

        public static DirectedGraph GetRandomGraph(int amountOfNodes)
        {
            Random rng = new Random();

            DirectedGraph graph = new DirectedGraph();

            for (int i = 0; i < amountOfNodes; i++)
            {
                graph.AddNode(new GraphNode());
            }

            for (int i = 0; i < amountOfNodes * 3; i++)
            {
                graph.AddDirectedEdge((char)rng.Next(65, 90), (char)rng.Next(65, 90), rng.Next(1, 25));
            }

            return graph;
        }
    }

}
