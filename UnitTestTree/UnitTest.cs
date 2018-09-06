using DSALG_Tree;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

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

        public static BinaryTree GetTestTree2()
        {
            BinaryTree tree = new BinaryTree();

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(8);

            return tree;
        }

        public static BinaryTree GetTestTree3()
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


        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get3Depth()
        {
            // Arange
            BinaryTree tree = GetTestTree();

            // Act
            int diepte = tree.GetDepth();

            // Assert
            Assert.AreEqual(3, diepte);

        }

        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get2Depth()
        {
            // Arange
            BinaryTree tree = GetTestTree2();
            

            // Act
            int diepte = tree.GetDepth();

            // Assert
            Assert.AreEqual(2, diepte);
        }



    }
}
