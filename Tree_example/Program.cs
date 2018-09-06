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
            BinaryTree tree = BinaryTree.GetTestTree();

            tree.Print();

            Console.WriteLine(tree.GetDepth());

            Console.WriteLine(tree.FindNode(4).Data);

            Console.ReadKey();
        }
    }


}
