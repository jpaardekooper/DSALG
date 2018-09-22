using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node;

namespace Dijkstra_JM
{
    public class Dijkstra
    {
        public DirectedGraph Graph { get; set; }
        public GraphNode From { get; set; }
        public GraphNode To { get; set; }
        public int NodeVisits { get; private set; }
        public double ShortestPathLength { get; set; }
        public double ShortestPathCost { get; private set; }

        public Dijkstra(DirectedGraph graph)
        {
            Graph = graph;
        }

        public List<GraphNode> GetShortestPathDijikstra(GraphNode from, GraphNode to)
        {
            From = from;
            To = to;

            NodeVisits = 0;
            From.MinCostToStart = 0;
            var prioQueue = new List<GraphNode>();
            prioQueue.Add(From);
            do
            {
                NodeVisits++;
                prioQueue = prioQueue.OrderBy(x => x.MinCostToStart.Value).ToList();
                var node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (var cnn in node.DirectedEdge.OrderBy(x => x.Value))
                {
                    var childNode = cnn.Key;
                    if (childNode.Visited)
                        continue;
                    if (childNode.MinCostToStart == null ||
                        node.MinCostToStart + cnn.Value < childNode.MinCostToStart)
                    {
                        childNode.MinCostToStart = node.MinCostToStart + cnn.Value;
                        childNode.NearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                            prioQueue.Add(childNode);
                    }
                }
                node.Visited = true;
                if (node == To)
                    break;
            } while (prioQueue.Any());


            var shortestPath = new List<GraphNode>();
            shortestPath.Add(To);
            BuildShortestPath(shortestPath, To);
            shortestPath.Reverse();
            return shortestPath;
        }

        private GraphNode GetClosestNode(GraphNode node)
        {
            KeyValuePair<GraphNode, int> currentClossestNode = new KeyValuePair<GraphNode, int>(new GraphNode(), int.MaxValue);
            GraphNode g = null;

            foreach (var item in node.DirectedEdge)
            {
                if (item.Value < currentClossestNode.Value)
                {
                    currentClossestNode = item;
                    g = item.Key;
                }
            }

            return g;

        }

        private void BuildShortestPath(List<GraphNode> list, GraphNode node)
        {
            if (node.NearestToStart == null)
                return;
            list.Add(node.NearestToStart);
            BuildShortestPath(list, node.NearestToStart);
        }
        
    }
}
