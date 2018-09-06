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
                    Debug.Write(" ".PadLeft(padding));
                }
                if (p.Right != null)
                {
                    Debug.Write("/\n");
                    Debug.Write(" ".PadLeft(padding));
                }
                Debug.Write(p.Data.ToString() + "\n ");
                if (p.Left != null)
                {
                    Debug.Write(" ".PadLeft(padding) + "\\\n");
                    Print(p.Left, padding + 4);
                }
            }
        }

        public Node FindNode(int d)
        {
            Queue queue = new Queue();
            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    Node current = (Node)queue.Dequeue();

                    if (current.Data == d)
                    {
                        return current;
                    }
                    if (current.Left != null)
                    {
                        queue.Enqueue(current.Left);
                    }

                    if (current.Data == d)
                    {
                        return current;
                    }
                    if (current.Right != null)
                    {
                        queue.Enqueue(current.Right);
                    }

                }

            }

            Node Nonode = new Node();
            Nonode.Data = 0;
            Debug.WriteLine("There is no root node present");
            return Nonode;

        }

        public static BinaryTree GetTestTree()
        {
            BinaryTree tree = new BinaryTree();

            tree.Insert(90);
            tree.Insert(50);
            tree.Insert(150);
            tree.Insert(95);
            tree.Insert(175);
            tree.Insert(92);
            tree.Insert(111);
            tree.Insert(166);
            tree.Insert(200);
            tree.Insert(20);
            tree.Insert(75);
            tree.Insert(5);
            tree.Insert(25);
            tree.Insert(66);
            tree.Insert(80);

            return tree;
        }

    }
}
