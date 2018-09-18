using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Node;

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
            DirectedGraph Richard = DirectedGraph.GetTestGraph(3);

            //act


            List<char> Path = Richard.GetShortestPath('H', 'I');

            Path.ToString();

            //assert
            Assert.AreEqual(Path, "HADGI");

        }

        [TestMethod]
        public void SendMailData()
        {
            //arrange
          
            //act

            //assert     

        }

        public interface ImailSender
        {
            bool SendMail(string to, string from, string body);
        }


    }
}
