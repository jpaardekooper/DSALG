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

        private void RemoveDirectedEdgeFunction(GraphNode from, GraphNode to, int weight)
        {
            if (from.DirectedEdge[to] == weight)
            {
                from.DirectedEdge.Remove(to);
            }          
        }

        private void AddDirectedEdgeFunction(GraphNode firstNode, GraphNode secondNode, int weight)
        {
            firstNode.DirectedEdge.Add(secondNode, weight);
        }

        private void RemoveNodeFunction(char identifier)
        {
            NodeList.Remove(FindNode(identifier));
        }

        private GraphNode FindNode(char NodeId)
        {
            return NodeList.Find(x => x.Identifier == NodeId);
        }

    }

}
