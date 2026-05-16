using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph
{
    internal class CycleInUndirectedGraph
    {
        public class CycleDetection
        {
            // Time complexity: O(V + E) where V is the number of vertices and E is the number of edges
            // Space complexity: O(V) for the visited set and recursion stack
            public bool HasCycle(Dictionary<int, List<int>> graph)
            {
                var visited = new HashSet<int>();
                // Check for cycles in each component of the graph
                foreach (var node in graph.Keys)
                {
                    if (!visited.Contains(node))
                    {
                        if (DFS(node, -1, visited, graph))
                            return true;
                    }
                }
                return false;
            }

            private bool DFS(int current, int parent, HashSet<int> visited, Dictionary<int, List<int>> graph)
            {
                visited.Add(current);
                foreach (var neighbor in graph[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        if (DFS(neighbor, current, visited, graph))
                            return true;
                    }
                    else if (neighbor != parent)
                    {
                        return true;
                    }
                }
                return false;
            }

            // Using BFS for cycle detection in an undirected graph

            public bool HasCycleBFS(Dictionary<int, List<int>> graph)
            {
                var visited = new HashSet<int>();
                foreach (var node in graph.Keys)
                {
                    // If the node has not been visited, perform BFS to check for cycles
                    if (!visited.Contains(node))
                    {
                        // If BFS returns true, it means a cycle is detected
                        if (BFS(node, visited, graph))
                            return true;
                    }
                }
                return false;
            }

            public bool BFS(int start, HashSet<int> visited, Dictionary<int, List<int>> graph)
            {
                var queue = new Queue<(int node, int parent)>();
                queue.Enqueue((start, -1));
                visited.Add(start);
                while (queue.Count > 0)
                {
                    var (current, parent) = queue.Dequeue();
                    foreach (var neighbor in graph[current])
                    {
                        // If the neighbor has not been visited, add it to the queue and mark it as visited
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue((neighbor, current));
                        }
                        else if (neighbor != parent) // If the neighbor is visited and is not the parent of the current node, then a cycle is detected
                        {
                            return true;
                        }
                    }
                }
                return false;


            }
        }
    }
}
