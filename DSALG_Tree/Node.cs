using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALG_Tree
{
    /// <summary>
    /// A node contains a piece of data (int)
    /// A node alsso stores its left and right niegbor
    /// </summary>
    public class Node
    {      
        public int Data;   
        public Node Left;
        public Node Right;
    }

    /// <summary>
    /// a data structure in which a record is linked to two successor records, 
    /// usually referred to as the left branch when greater 
    /// and the right when less than the previous record.
    /// </summary>
    public class BinaryTree
    {
        /// <summary>
        /// the Root note of the tree
        /// </summary>
        public Node Root;

        /// <summary>
        /// Creates a binay tree and declares Root Node to null
        /// </summary>
        public BinaryTree()
        {
            Root = null;           
        }

        /// <summary>
        /// Creates a binary tree and creates a root node 
        /// </summary>
        /// <param name="x"></param>
        public BinaryTree(int RootNodeData)
        {
            Root = new Node
            {
                Data = RootNodeData
            };
        }

        /// <summary>      
        /// Binary insert method for finding the right place for the data
        /// in the tree
        /// O(Log(n))
        /// </summary>
        /// <param name="i">int i is the value of the Node</param>
        public void Insert(int NodeData)
        {
            // Creates the New node to insert
            Node newNode = new Node
            {
                Data = NodeData
            };

            // Check if a Root Node exists, if not it wel assign the newNode as Root
            if (Root == null)
            {
                Root = newNode;
            }
            // If a Root Node exists it will search for a spot in the tree
            else
            {  
                // Create a temporary Node for the loop
                Node parrent = Root;

                // The binary search method
                // Using a while(true) loop is dangerous
                while (true)
                {       
                    // If the data is smaller than the parrent's data it wil go left
                    if (NodeData < parrent.Data)
                    {      
                        // Checking if There is Node present in that spot
                        if (parrent.Left == null)
                        {
                            // Setting the new node as the parrent's left neighbor
                            // and breaking the loop
                            parrent.Left = newNode;
                            break;
                        }
                        
                        // Setting the parrent to it's left neighbor and redo the loop
                        parrent = parrent.Left;
                    }
                    // Else the new node will go right doing the same as left 
                    else
                    {                      
                        if (parrent.Right == null)
                        {
                            parrent.Right = newNode;
                            break;
                        }
                        parrent = parrent.Right;
                    }

                }
            }
        }

        /// <summary>
        /// Linaire search for finding the depth of a tree?
        /// O(N)?
        /// </summary>
        /// <returns></returns>
        public int GetDepth()
        {
            // setting
            int depth = -1;

            // Making a queue for storing temp
            Queue queue = new Queue();

            // Checking if the tree has root
            // if not it will return the set depth of -1
            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            // Linaire search method for finding the depht
            // it checks if there is a child underneth the parrent Node
            // and adds them to the Queue to be searched
            while (queue.Count != 0)
            {      
                // If there are children in the queue
                // it means there is a +1 in depth
                depth++;

                //the for loop to empty the queue and all new children
                for (int i = 0; i < queue.Count; i++)
                {
                    Node parrent = (Node)queue.Dequeue();

                    if (parrent.Left != null)
                    {
                        queue.Enqueue(parrent.Left);
                    }

                    if (parrent.Right != null)
                    {
                        queue.Enqueue(parrent.Right);
                    }
                }
            }

            return depth;
            
        }

        /// <summary>
        /// Printing method for the console window
        /// for vizulization of the whole tree
        /// Read from left to right
        /// </summary>
        public void Print()
        {           
            Print(Root, 4);
        }

        /// <summary>
        /// Printing method for the console window
        /// for vizulization of a sub tree
        /// </summary>
        /// <param name="NodeData"></param>
        public void PrintFromNode(int NodeData)
        {
            Print(FindNode(NodeData), 4);
        }
        
        /// <summary>
        /// Binary search method for finding a givin data in the tree
        /// O(Log(n))
        /// </summary>
        /// <param name="NodeData"></param>
        /// <returns></returns>
        public Node FindNode(int NodeData)
        {
            // Crating Node to use in the loop
            Node Parrent = Root;

            // The binary search method
            // Using a while(true) loop is dangerous
            while (true)
            {
              
                // Cheking if data <= to the parrant data
                // if that is true it will go and look left
                if (NodeData <= Parrent.Data)
                {
                    // checking if the node exists
                    if (Parrent.Left == null)
                    {
                        
                        // Geving a no Node found message
                        Console.WriteLine("No node found");
                        return null;

                        // Possible to throw Application error
                        // throw new ApplicationException("The Requested Node does not excists");
                    }
                    else if (Parrent.Left.Data == NodeData)
                    {
                        // Found the requested node
                        Console.WriteLine("Found it");
                        return Parrent.Left;
                    }

                    // The Node has not been found yet and the loop will continue
                    Parrent = Parrent.Left;
                }
                else
                {
                    
                    if (Parrent.Right == null)
                    {
                        Console.WriteLine("No node found");
                        return null;
                    }
                    else if (Parrent.Right.Data == NodeData)
                    {
                        Console.WriteLine("Found it");
                        return Parrent.Right;
                    }
                    Parrent = Parrent.Right;
                }


            }
            
        }

        /// <summary>
        /// Debuging and unit testing method.
        /// for getting a pre generated tree with a varible in size.
        /// Ballenced when AmountOfNodes  is 7, 15 or 31.
        /// </summary>
        /// <param name="AmountOfNodes"></param>
        /// <returns></returns>
        public static BinaryTree GetTestTree(int AmountOfNodes)
        {
            BinaryTree tree = new BinaryTree();

            // self made data set that will genrate a tree
            int[] testTree = {90, 50, 150, 95, 175, 75, 20, 92, 111, 166, 200, 5, 25, 66, 80,
                              4, 6, 20, 30, 60, 67, 79, 81, 90, 93, 110, 112, 165, 167, 199, 3000};

            // filing the tree
            for (int i = 0; i < AmountOfNodes; i++)
            {
                tree.Insert(testTree[i]);
            }

            return tree;
        }

        /// <summary>
        /// Recursive method for printing a tree in the console
        /// source: https://stackoverflow.com/questions/36311991/c-sharp-display-a-binary-search-tree-in-console/36313190
        /// </summary>
        /// <param name="p"></param>
        /// <param name="padding"></param>
        private void Print(Node p, int padding)
        {
            if (p != null)
            {
                if (p.Right != null)
                {
                    Print(p.Right, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (p.Right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(p.Data.ToString() + "\n ");
                if (p.Left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Print(p.Left, padding + 4);
                }
            }
        }

    }
}
