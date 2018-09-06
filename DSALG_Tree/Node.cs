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
    /// Upon creating a Node class we define int data for the Node and 
    /// giving it the position left or right of the Node.
    /// A node can be a Parent, Leaf, Child or a Sibling
    /// </summary>
    public class Node
    {
        //a Node has a integer.
        public int Data;
        //a Node can be placed on the Left or Right side. the left child should be lower than right child
        public Node Left;
        public Node Right;
    }

    /// <summary>
    /// This class will define the Tree saving the root node and 
    /// giving it the position either left or right.
    /// </summary>
    public class BinaryTree
    {
        //declaring the first Node and calling it Root
        public Node Root;

        //when a Node Root is created it will be null (no value added)
        public BinaryTree()
        {
            Root = null;           
        }


        /// <summary>
        /// Now we want to fill the Complete BinaryTree with an insert method
<<<<<<< HEAD
        /// for example i is 5
=======
        /// O(Log(n))
>>>>>>> c16afd72357db98d9acbdcbc0fb36a54d2c24d75
        /// </summary>
        /// <param name="i">int i is the value of the Node</param>
        public void Insert(int i)
        {
            //the new node has the Data of I in this case 5
            Node newNode = new Node
            {
                Data = i
            };

            //if Root is null we create a new Node with data.
            //This is used so our tree is always empty upon creating a new tree.
            //in this case the Root isn't defined yet so root is indeed null
            if (Root == null)
            {
                //our root will be a new Node and we go inside again but this time we skip the if
                Root = newNode;
            }
            //if we enter the insert method the second time we get by the else statement
            else
            {  
                //creating a new Node
                Node current = Root;

                //dangerous code is equal to microsoft I Like It.
                while (true)
                {       
                    //if int i is smaller / lower than the current Node int data.
                    if (i < current.Data)
                    {      
                        //and if the current node left side is empty
                        if (current.Left == null)
                        {
                            current.Left = newNode;
                            break;
                        }
                        //we assign the current Node to the left Side
                        current = current.Left;
                    }
                    else
                    {                      
                        if (current.Right == null)
                        {
                            current.Right = newNode;
                            break;
                        }
                        current = current.Right;
                    }

                }
            }
        }
        /// <summary>
        /// Defining the depth of the Tree
        /// O(N)
        /// </summary>
        /// <returns></returns>
        public int GetDepth()
        {
            return MaxDepth(Root);
        }

        private int MaxDepth(Node root)
        {
            int depth = -1;
            Queue queue = new Queue();
            if (root != null) queue.Enqueue(root);

            while (queue.Count != 0)
            {
                int size = queue.Count;
                depth++;
                for (int i = 0; i < size; i++)
                {
                    Node top = (Node)queue.Dequeue();

                    if (top.Left != null)
                    {
                        queue.Enqueue(top.Left);
                    }

                    if (top.Right != null)
                    {
                        queue.Enqueue(top.Right);
                    }
                }
            }

            return depth;
        }

        public void Print()
        {
            Print(Root, 4);
        }

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

        /// <summary>
        /// 
        /// O(Log(n))
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public Node FindNode(int d)
        {
            Node Nonode = new Node
            {
                Data = 0
            };

            Node current = Root;

            while (true)
            {
                
                if (d <= current.Data)
                {
                    current = current.Left;
                    if (current == null)
                    {
                        Console.WriteLine("No node found");
                        return Nonode;
                    }
                    else if (current.Data == d)
                    {
                        Console.WriteLine("Found it");
                        return current;
                    }                   
                }
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        Console.WriteLine("No node found");
                        return Nonode;
                    }
                    else if (current.Data == d)
                    {
                        Console.WriteLine("Found it");
                        return current;
                    }
                }


            }
            
        }
        
        public static BinaryTree GetTestTree(int AmountOfNodes)
        {
            BinaryTree tree = new BinaryTree();

            int[] testTree = {90, 50, 150, 95, 175, 75, 20, 92, 111, 166, 200, 5, 25, 66, 80,
                              4, 6, 20, 30, 60, 67, 79, 81, 90, 93, 110, 112, 165, 167, 200};

            for (int i = 0; i < AmountOfNodes; i++)
            {
                tree.Insert(testTree[i]);
            }

            return tree;
        }
    }
}
