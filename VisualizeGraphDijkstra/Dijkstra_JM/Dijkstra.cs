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

        /// <summary>
        /// Creates a list of nodes that is the shortest path it could find
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<GraphNode> GetShortestPathDijikstra(GraphNode from, GraphNode to)
        {
            // setting the dijkstra variables
            SetDijkstraSearchValues(from, to);

            // building the path
            var shortestPath = new List<GraphNode>
            {
                to
            };

            BuildShortestPath(shortestPath, to);
            shortestPath.Reverse();

            return shortestPath;
        }

        /// <summary>
        /// Builds the shortest path based on the node that is neaest to start
        /// this is a recursive method that keeps buidling till its done and returns the list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="node"></param>
        private void BuildShortestPath(List<GraphNode> list, GraphNode node)
        {
            if (node.NearestToStart == null)
            {
                return;
            }
               
            list.Add(node.NearestToStart);
            BuildShortestPath(list, node.NearestToStart);
        }

        /// <summary>
        /// Searching for the shortest path
        /// Big O natation: O(n)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        private void SetDijkstraSearchValues(GraphNode from, GraphNode to)
        {
            from.BackTrackWeight = 0;

            List<GraphNode> toVisit = new List<GraphNode>
            {
                from
            };

            // looping till it finds its destatnation
            // and looked trugh the paths if a shorter one is achavible
            do
            {
                toVisit = toVisit.OrderBy(x => x.BackTrackWeight.Value).ToList();

                GraphNode current = toVisit.First();

                toVisit.Remove(current);

                // Trying all the edges to find the shortest one
                foreach (var edge in current.DirectedEdge.OrderBy(x => x.Value))
                {
                    GraphNode childNode = edge.Key;

                    // Skip viseted nodes
                    if (childNode.Visited)
                    {
                        continue;
                    }
                    if (childNode.BackTrackWeight == null ||
                        current.BackTrackWeight + edge.Value < childNode.BackTrackWeight) // checking if the edge is backtrackcost is less then it was
                    {
                        // setting the new closests node
                        childNode.BackTrackWeight = current.BackTrackWeight + edge.Value;
                        childNode.NearestToStart = current;
                        // looking for a shorter path back
                        if (!toVisit.Contains(childNode))
                        {
                            // adding a new to visit node
                            toVisit.Add(childNode);
                        }

                    }
                }

                // setting the current node as visited
                current.Visited = true;

                // if the current no is the destination it will end
                if (current == to)
                {
                    break;
                }

            } while (toVisit.Any());
        }
                
    }

    
}
