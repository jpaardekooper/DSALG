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
        public List<Node> Neighbors;
        public Dictionary<Node, int> DirectedEdge;
    }


    public class Graph
    {
        public List<Node> NodeList;

        public Graph()
        {
            if (NodeList == null)
            {
                NodeList = new List<Node>();
            }
        }

        public void AddNode(Node newNode)
        {           
            if (!NodeList.Any())
            {
                newNode.Identifier = 'A';
            }
            else
            {
                int tempIdentifier = NodeList.Last().Identifier;

                tempIdentifier++;

                newNode.Identifier = (char)tempIdentifier;               
            }

            NodeList.Add(newNode);
        }

        public void RemoveNode(char NodeIdentifier)
        {
            RemoveNodeFunction(NodeIdentifier);
        }

        public void RemoveNode(Node node)
        {
            RemoveNodeFunction(node.Identifier);
        }

        private void RemoveNodeFunction(char identifier)
        {
            NodeList.Remove(NodeList.Find(x => x.Identifier == identifier));
        }



    }

}
