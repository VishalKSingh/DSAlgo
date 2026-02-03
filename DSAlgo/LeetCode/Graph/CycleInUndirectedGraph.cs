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
            public bool HasCycle(Dictionary<int, List<int>> graph)
            {
                var visited = new HashSet<int>();
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
        }
    }
}
