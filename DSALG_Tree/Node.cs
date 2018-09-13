using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DSALG_Tree
{  
    public class Node
    {
        public char Identifier;      
        public Dictionary<Node, int> DirectedEdge;

        public Node()
        {
            if (DirectedEdge == null)
            {
                DirectedEdge = new Dictionary<Node, int>();
            }           
        }

        public void PrintAllEdgeds()
        {
            foreach (KeyValuePair<Node, int> keyValuePair in DirectedEdge)
            {
                Console.WriteLine("Connected from = {0}, Conectednode = {1}, weight = {2}", Identifier, keyValuePair.Key.Identifier, keyValuePair.Value);
            }
        }

    }


    public class Graph
    {
        private List<Node> NodeList;

        public Graph()
        {
            if (NodeList == null)
            {
                NodeList = new List<Node>();
            }
        }

        public void AddNode(Node newNode)
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

        public void RemoveNode(Node node) => RemoveNodeFunction(node.Identifier);

        public void AddDirectedEdge(Node firstNode, Node secondNode, int weight) => AddDirectedEdgeFunction(firstNode, secondNode, weight);

        public void AddDirectedEdge(char firstNodeId, char secondNodeId, int weight)
        {
            AddDirectedEdgeFunction(NodeList.Find(x => x.Identifier == firstNodeId), NodeList.Find(x => x.Identifier == secondNodeId), weight);
        }

        




        public void PrintAllNodes()
        {
            foreach (Node node in NodeList)
            {
                Console.WriteLine(node.Identifier);
            }
        }


        private void AddDirectedEdgeFunction(Node firstNode, Node secondNode, int weight)
        {
            firstNode.DirectedEdge.Add(secondNode, weight);
        }

        private void RemoveNodeFunction(char identifier)
        {
            NodeList.Remove(NodeList.Find(x => x.Identifier == identifier));
        }



    }

}
