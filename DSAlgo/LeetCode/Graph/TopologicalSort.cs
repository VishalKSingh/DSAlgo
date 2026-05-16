using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph
{
    internal class TopologicalSort
    {
        // This problem is about performing a topological sort on a directed acyclic graph (DAG)
        // The approach is to use Depth-First Search (DFS) to visit nodes and add them to a stack

        public TopologicalSort() { }

        public IList<int> TopologicalSortDFS(int numCourses, int[][] prerequisites)
        {
            // Initialize the graph as an adjacency list
            var graph = new List<int>[numCourses];
            
            // Initialize the graph with empty lists for each course
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }
            // Build the graph from the prerequisites
            foreach (var prereq in prerequisites)
            {
                graph[prereq[1]].Add(prereq[0]);
            }

            // Perform DFS and populate the stack with the topological order
            var visited = new HashSet<int>();
            var stack = new Stack<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (!visited.Contains(i))
                {
                    DFS(graph, i, visited, stack);
                }
            }
            return stack.ToList();
        }


        private void DFS(List<int>[] graph, int node, HashSet<int> visited, Stack<int> stack)
        {
            // Iterative DFS using an explicit stack to simulate recursion.
            // We keep a local processed set so we only push a node to the output
            // stack after all its neighbors have been visited.
            var work = new Stack<int>();
            var processed = new HashSet<int>();

            work.Push(node);
            while (work.Count > 0)
            {
                var curr = work.Peek();

                if (!visited.Contains(curr))
                {
                    visited.Add(curr);

                    // Push unvisited neighbors onto the work stack.
                    // Note: pushing in iteration order means the last neighbor
                    // will be processed first (LIFO), which is acceptable for
                    // topological ordering.
                    foreach (var neighbor in graph[curr])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            work.Push(neighbor);
                        }
                    }
                }
                else
                {
                    // If we've returned to this node and haven't processed it yet,
                    // all its neighbors have been processed, so add it to result.
                    if (!processed.Contains(curr))
                    {
                        processed.Add(curr);
                        stack.Push(curr);
                    }

                    work.Pop();
                }
            }
        }
    }
}
