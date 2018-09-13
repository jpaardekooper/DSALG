using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DSALG_Tree
{  
    public class GraphNode
    {
        public char Identifier;      
        public Dictionary<GraphNode, int> DirectedEdge;

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
                Console.WriteLine("Connected from = {0}, to = {1}, weight = {2}", Identifier, keyValuePair.Key.Identifier, keyValuePair.Value);
            }
        }

    }
    
    public class DirectedGraph
    {
        private List<GraphNode> NodeList;

        public DirectedGraph()
        {
            if (NodeList == null)
            {
                NodeList = new List<GraphNode>();
            }
        }

        public static DirectedGraph GetTestGraph(int verion)
        {
            if (verion == 1) return TestGraph1();
            else if (verion == 2) return TestGraph2();
            else if (verion == 3) return TestGraph3();


            return null;
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

        public void RemoveNode(char NodeIdentifier) => RemoveNodeFunction(NodeIdentifier);

        public void RemoveNode(GraphNode node) => RemoveNodeFunction(node.Identifier);

        public void AddDirectedEdge(GraphNode firstNode, GraphNode secondNode, int weight) => AddDirectedEdgeFunction(firstNode, secondNode, weight);

        public void AddDirectedEdge(char firstNodeId, char secondNodeId, int weight)
        {
            AddDirectedEdgeFunction(FindNode(firstNodeId), FindNode(secondNodeId), weight);
        }

        public void RemoveDirectedEdge(GraphNode from, GraphNode to, int weight) => RemoveDirectedEdgeFunction(from, to, weight);

        public void RemoveDirectedEdge(char from, char to, int weight) => RemoveDirectedEdgeFunction(FindNode(from), FindNode(to), weight);
        
        public void PrintAllNodes()
        {
            foreach (GraphNode node in NodeList)
            {
                Console.WriteLine(node.Identifier);
            }
        }

        public void PrintAllNodeEdges()
        {
            foreach (GraphNode node in NodeList)
            {
                node.PrintAllEdgeds();
            }
        }

        public bool DoesPathExist(GraphNode from, GraphNode to) => DoesPathExistFunction(from, to);

        public bool DoesPathExist(char from, char to) => DoesPathExistFunction(FindNode(from), FindNode(to));
        
        private bool DoesPathExistFunction(GraphNode from, GraphNode to)
        {
            List<GraphNode> visited = new List<GraphNode>();

            if (from.DirectedEdge.ContainsKey(to))
            {
                return true;
            }


            Queue<GraphNode> queue = new Queue<GraphNode>();
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                GraphNode Current = queue.Dequeue();

                if (visited.Contains(Current))
                    continue;

                visited.Add(Current);

                foreach (GraphNode neighbor in Current.DirectedEdge.Keys)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                    if (neighbor.Equals(to))
                    {
                        return true;
                    }
                }
                
            }
            
            return false;
        }

        private void RemoveDirectedEdgeFunction(GraphNode from, GraphNode to, int weight)
        {
            if (from.DirectedEdge[to].Equals(weight))
            {
                from.DirectedEdge.Remove(to);
            }          
        }

        private void AddDirectedEdgeFunction(GraphNode from, GraphNode to, int weight)
        {
            // no dubble edges
            if (from.DirectedEdge.ContainsKey(to) && from.DirectedEdge[to].Equals(weight))
            {
                return;
            }

            from.DirectedEdge.Add(to, weight);
        }

        private void RemoveNodeFunction(char identifier)
        {
            NodeList.Remove(FindNode(identifier));
        }

        private GraphNode FindNode(char NodeId)
        {
            return NodeList.Find(x => x.Identifier == NodeId);
        }

        private static DirectedGraph TestGraph1()
        {
            DirectedGraph graph = new DirectedGraph();

            for (int i = 0; i < 6; i++)
            {
                graph.AddNode(new GraphNode());
            }

            graph.AddDirectedEdge('A', 'D', 6);
            graph.AddDirectedEdge('A', 'E', 2);
            graph.AddDirectedEdge('E', 'D', 2);
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
            //graph.AddDirectedEdge('E', 'I', 8);
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

    }

}
