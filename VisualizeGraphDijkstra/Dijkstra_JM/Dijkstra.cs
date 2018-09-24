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

        public Dijkstra(DirectedGraph graph)
        {
            Graph = graph;
        }

        public List<GraphNode> GetShortestPathDijikstra(GraphNode from, GraphNode to)
        {

            SetDijkstraSearchValues(from, to);

            var shortestPath = new List<GraphNode>
            {
                to
            };

            BuildShortestPath(shortestPath, to);
            shortestPath.Reverse();

            return shortestPath;
        }
        
        private void BuildShortestPath(List<GraphNode> list, GraphNode node)
        {
            if (node.NearestToStart == null)
            {
                return;
            }
               
            list.Add(node.NearestToStart);
            BuildShortestPath(list, node.NearestToStart);
        }
        
        private void SetDijkstraSearchValues(GraphNode from, GraphNode to)
        {
            from.BackTrackWeight = 0;

            List<GraphNode> toVisit = new List<GraphNode>
            {
                from
            };

            do
            {
                toVisit = toVisit.OrderBy(x => x.BackTrackWeight.Value).ToList();

                GraphNode current = toVisit.First();

                toVisit.Remove(current);

                foreach (var edge in current.DirectedEdge.OrderBy(x => x.Value))
                {
                    GraphNode childNode = edge.Key;

                    if (childNode.Visited)
                    {
                        continue;
                    }
                    if (childNode.BackTrackWeight == null ||
                        current.BackTrackWeight + edge.Value < childNode.BackTrackWeight)
                    {
                        childNode.BackTrackWeight = current.BackTrackWeight + edge.Value;
                        childNode.NearestToStart = current;
                        if (!toVisit.Contains(childNode))
                        {
                            toVisit.Add(childNode);
                        }

                    }
                }

                current.Visited = true;

                if (current == to)
                {
                    break;
                }

            } while (toVisit.Any());
        }
        
        public bool DoesPathExistFunction(GraphNode from, GraphNode to)
        {
            if (!Graph.DRNE(new char[] { from.Identifier, to.Identifier }))
            {
                return false;
            }


            List<GraphNode> visited = new List<GraphNode>();

            if (from.DirectedEdge.ContainsKey(to))
            {
                return true;
            }


            Queue<GraphNode> queue = new Queue<GraphNode>();
            queue.Enqueue(from);

            while (queue.Count > 0)
            {
                GraphNode Current = queue.Dequeue();

                if (visited.Contains(Current))
                    continue;

                visited.Add(Current);

                foreach (GraphNode neighbor in Current.DirectedEdge.Keys)
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                    if (neighbor.Equals(to))
                    {
                        return true;
                    }
                }

            }

            return false;
        }

    }

    
}
