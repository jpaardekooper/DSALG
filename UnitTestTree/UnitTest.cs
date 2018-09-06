using DSALG_Tree;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get3Depth()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree();

            // Act
            int diepte = tree.GetDepth();

            // Assert
            Assert.AreEqual(3, diepte);

        }

        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get2Depth()
        {
            // Arange
            BinaryTree tree = new BinaryTree();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(8);

            // Act
            int diepte = tree.GetDepth();

            // Assert
            Assert.AreEqual(2, diepte);
        }



    }
}
