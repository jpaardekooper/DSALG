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
        public int Data;
        public Node Left;
        public Node Right;
    }

    /// <summary>
    /// 
    /// </summary>
    public class BinaryTree
    {
        public Node Root;

        public BinaryTree()
        {
            Root = null;
            Console.WriteLine("root = null");
        }

        public void Insert(int i)
        {
            Node newNode = new Node
            {
                Data = i
            };

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                Node current = Root;
                Node parent;

                while (true)
                {
                    parent = current;
                    if (i < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }

                }
            }
        }

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

        public Node FindNode(int d)
        {
            Node Nonode = new Node
            {
                Data = 0
            };

            Node current = Root;
            Node parent;

            while (true)
            {
                parent = current;
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
