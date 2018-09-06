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
            int[] testTree = { 90, 50, 150, 95, 175, 92, 111, 166, 200, 20, 75, 5, 25, 66, 80 };

            for (int i = 0; i < testTree.Length; i++)
            {
                tree.Insert(testTree[i]);
            }

            return tree;
        }

        public static BinaryTree GetTestTree2()
        {
            BinaryTree tree = new BinaryTree();
            int[] testTree = { 5, 3, 7, 4, 2, 6, 8 };

            for (int i = 0; i < testTree.Length; i++)
            {
                tree.Insert(testTree[i]);
            }

            return tree;
        }

        public static BinaryTree GetTestTree3()
        {
            BinaryTree tree = new BinaryTree();

            int[] testTree = {90, 50, 150, 95, 175, 92, 111, 166, 200, 20, 75, 5, 25, 66, 80,
                              4, 6, 20, 30, 60, 67, 79, 81, 90, 93, 110, 112, 165, 167, 200};

            for (int i = 0; i < testTree.Length; i++)
            {
                tree.Insert(testTree[i]);
            }
            
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

        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get4Depth()
        {
            // Arange
            BinaryTree tree = GetTestTree3();
            
            // Act
            int diepte = tree.GetDepth();

            // Assert
            Assert.AreEqual(4, diepte);
        }

    }
}
