using DSALG_Tree;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class DepthUnitTests
    {
        /// <summary>
        /// Small tree test
        /// </summary>
        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get2Depth()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(7);

            // call
            DepthTest(tree, 2);
        }

        /// <summary>
        /// mid tree test
        /// </summary>
        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get3Depth()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(15);

            // call
            DepthTest(tree, 3);
        }

        /// <summary>
        /// Big tree test
        /// </summary>
        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get4Depth()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(30);

            // call
            DepthTest(tree, 4);
        }
        
        /// <summary>
        /// Long tree test
        /// </summary>
        [TestMethod]
        public void BinaryTree_DepthTest_GiveTestThree_Get10Depth()
        {
            // Arange
            BinaryTree tree = new BinaryTree();

            for (int i = 0; i < 10; i++)
            {
                tree.Insert(i);
            }

            // call
            DepthTest(tree, 9);
            
        }

        /// <summary>
        /// Act and asert test for BinaryTree depth tests
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="expected"></param>
        private void DepthTest(BinaryTree tree, int expected)
        {
            // Act
            int diepte = tree.GetDepth();

            // Assert
            Assert.AreEqual(expected, diepte);
        }

    }

    [TestClass]
    public class FindNodeTests
    {
        [TestMethod]
        public void BinaryTree_FindNode_GiveTestThree_Get20()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(7);

            // call
            FindNodeTestAreEqual(tree, 20, 20);
        }

        [TestMethod]
        public void BinaryTree_FindNode_GiveTestThree_DontGet20()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(7);

            // call
            FindNodeTestAreNotEqual(tree, 40, 20);
        }









        private void FindNodeTestAreNotEqual(BinaryTree tree, int expected, int given)
        {
            // act
            Node gotten = tree.FindNode(given);

            // assert
            Assert.AreNotEqual(expected, gotten.Data);

        }

        private void FindNodeTestAreEqual(BinaryTree tree, int expected, int given)
        {
            // act
            Node gotten = tree.FindNode(given);

            // assert
            Assert.AreEqual(expected, gotten.Data);
            
        }



    }




}
