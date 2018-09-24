using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Node;
using Dijkstra_JM;

namespace UnitTestVisualizeGraph
{
    [TestClass]
    public class DirectedGraphTests
    {
        [TestMethod]
        public void CreateGraphAddNodeCheckIfNodeExists()
        {
            //act
            DirectedGraph pedro = new DirectedGraph();

            //arrange
            pedro.AddNode(new GraphNode());

            string NodeID = pedro.PrintAllNodes();

            //assert
            Assert.AreEqual(NodeID, "A");
        }

        [TestMethod]
        public void CreateGraphTestInsertSize9GetABCDEFGHI()
        {
            //arrange
            DirectedGraph ferdinand = new DirectedGraph();
            
            //act
            for (int i = 0; i < 9; i++)
            {
                ferdinand.AddNode(new GraphNode());
            }

            string allGraph = ferdinand.PrintAllNodes();

            //assert
            Assert.AreEqual(allGraph, "ABCDEFGHI");

        }

        [TestMethod]
        public void GetShortestPathTestGraph1()
        {
            //arrange
            DirectedGraph richard = DirectedGraph.GetTestGraph(1);
            Dijkstra sigismund = new Dijkstra(richard);

            List<GraphNode> petra = new List<GraphNode>();

            GraphNode from = richard.FindNode('F');
            GraphNode to = richard.FindNode('D');

            petra = sigismund.GetShortestPathDijikstra(from, to);

            //act

            string path = "";

            foreach (GraphNode item in petra)
            {
                path += item.Identifier;
            }
            

            //assert
            Assert.AreEqual("FBD", path);

        }

        [TestMethod]
        public void GetShortestPathTestGraph2()
        {
            //arrange
            DirectedGraph angel = DirectedGraph.GetTestGraph(2);
            Dijkstra sigismund = new Dijkstra(angel);

            List<GraphNode> olga = new List<GraphNode>();

            GraphNode from = angel.FindNode('H');
            GraphNode to = angel.FindNode('I');

            olga = sigismund.GetShortestPathDijikstra(from, to);

            //act

            string path = "";

            foreach (GraphNode item in olga)
            {
                path += item.Identifier;
            }


            //assert
            Assert.AreEqual("HADFGI", path);

        }

        [TestMethod]
        public void GetShortestPathTestGraph3()
        {
            //arrange
            DirectedGraph frederique = DirectedGraph.GetTestGraph(3);
            Dijkstra sigismund = new Dijkstra(frederique);

            List<GraphNode> hilda = new List<GraphNode>();

            GraphNode from = frederique.FindNode('H');
            GraphNode to = frederique.FindNode('I');

            hilda = sigismund.GetShortestPathDijikstra(from, to);

            //act

            string path = "";

            foreach (GraphNode item in hilda)
            {
                path += item.Identifier;
            }


            //assert
            Assert.AreEqual("HADI", path);

        }
    }
}
