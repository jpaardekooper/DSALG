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
        public void BinaryTree_DepthTest_Get2Depth()
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
        public void BinaryTree_DepthTest_Get3Depth()
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
        public void BinaryTree_DepthTest_Get4Depth()
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
        public void BinaryTree_DepthTest_Get9Depth()
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
        public void BinaryTree_FindNode_Get20()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(7);

            // call
            FindNodeTestAreEqual(tree, 20, 20);
        }

        [TestMethod]
        public void BinaryTree_FindNode_DontGet3000()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(7);

            // act
            Node gotten = tree.FindNode(3000);

            // assert
            Assert.AreEqual(null, gotten);
        }

        [TestMethod]
        public void BinaryTree_FindNode_Get150()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(31);

            // call
            FindNodeTestAreEqual(tree, 150, 150);
        }

        [TestMethod]
        public void BinaryTree_FindNode_Get3000()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(31);

            // call
            FindNodeTestAreEqual(tree, 3000, 3000);
        }
        
        private void FindNodeTestAreEqual(BinaryTree tree, int expected, int given)
        {
            // act
            Node gotten = tree.FindNode(given);

            // assert
            Assert.AreEqual(expected, gotten.Data);
            
        }



    }

    [TestClass]
    public class InsertNodeTest
    {
        [TestMethod]
        public void BinaryTree_InserNode_CheckTheRootNodeData10()
        {
            // Arange
            BinaryTree tree = new BinaryTree();

            Node node = new Node
            {
                Data = 10
            };

            // act
            tree.Insert(node.Data);

            // assert
            Assert.AreEqual(node.Data, tree.Root.Data);

        }

        [TestMethod]
        public void BinaryTree_InserNode_CheckTheRootNodeData25()
        {
            // Arange
            BinaryTree tree = new BinaryTree();

            Node node = new Node
            {
                Data = 25
            };

            // act
            tree.Insert(node.Data);

            // assert
            Assert.AreEqual(node.Data, tree.Root.Data);

        }

        [TestMethod]
        public void BinaryTree_InserNode_CheckNodeByFindNode95()
        {           
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(7);

            // Act
            Node node2 = tree.FindNode(95);

            // assert
            Assert.AreEqual(95, node2.Data);

        }

        [TestMethod]
        public void BinaryTree_InserNode_CheckNodeByFindNode3000()
        {
            // Arange
            BinaryTree tree = BinaryTree.GetTestTree(31);
            

            // Act
            Node node2 = tree.FindNode(3000);

            // assert
            Assert.AreEqual(3000, node2.Data);

        }
        
    }
    
}
