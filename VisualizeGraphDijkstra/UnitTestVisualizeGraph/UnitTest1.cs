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
        public void createGraphAddNodeCheckIfNodeExists()
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
        public void GetShortestPath()
        {
            //arrange
            DirectedGraph Richard = DirectedGraph.GetTestGraph(1);
            Dijkstra d = new Dijkstra(Richard);

            List<GraphNode> t = new List<GraphNode>();

            GraphNode from = Richard.FindNode('F');
            GraphNode to = Richard.FindNode('D');

            t = d.GetShortestPathDijikstra(from, to);

            //act

            string path = "";

            foreach (var item in t)
            {
                path += item.Identifier;
            }
            

            //assert
            Assert.AreEqual("FBD", path);

        }

        

    }
}
