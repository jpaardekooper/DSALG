using DSALG_Tree;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        
        private void DepthTest(BinaryTree tree, int expected)
        {
            // Act
            int diepte = tree.GetDepth();

            // Assert
            Assert.AreEqual(expected, diepte);
        }

        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get2Depth()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(7);

            // call
            DepthTest(tree, 2);
        }

        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get3Depth()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(15);

            // call
            DepthTest(tree, 3);
        }

        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get4Depth()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(30);

            // call
            DepthTest(tree, 4);
        }

    }
}
