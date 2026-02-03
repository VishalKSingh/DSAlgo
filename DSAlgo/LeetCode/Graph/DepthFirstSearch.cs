using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph
{
    internal class DepthFirstSearch
    {
        // This class is a placeholder for DFS-related methods
        // It can be extended to include DFS algorithms for various problems

        public void ExampleDFS()
        {
            var graph = new Dictionary<int, List<int>>
            {
                { 0, new List<int> { 1, 2 } },
                { 1, new List<int> { 0, 3, 4 } },
                { 2, new List<int> { 0 } },
                { 3, new List<int> { 1 } },
                { 4, new List<int> { 1, 5 } },
                { 5, new List<int> { 4 } }
            };

            DFSGraphTraversal(graph, 0);

            // Example method to demonstrate DFS usage
            Console.WriteLine("This is an example of a DFS method.");
            // Implement DFS logic here
            Console.WriteLine(
                "DFS (Depth-First Search) is an algorithm for traversing or searching tree or graph data structures. " +
                "The algorithm starts at the root (or an arbitrary node in the case of a graph) and explores as far as possible along each branch before backtracking."
            );

        }

        // You can add more DFS-related methods as needed
        // For example, you can implement DFS for graph traversal, path finding,finding paths in a maze, Maximum Depth of Binary Tree etc.
        // This class can be used as a base for implementing DFS algorithms in various graph-related problems
        // For example, you can implement DFS for finding connected components in a graph,
        // or for solving problems like "Word Search" or "Number of Islands".

        // finding the longest path in a directed acyclic graph (DAG),
        // "Binary Tree Paths" using DFS traversal.

        // write a method to demonstrate DFS traversal on a graph
        // Time complexity: O(V + E) where V is the number of vertices and E is the number of edges
        // Space complexity: O(V) for the recursion stack and visited set
        public void DFSGraphTraversal(Dictionary<int, List<int>> graph, int startNode)
        {
            var visited = new HashSet<int>();
            DFSUtil(graph, startNode, visited);
        }
        private void DFSUtil(Dictionary<int, List<int>> graph, int node, HashSet<int> visited)
        {
            visited.Add(node);
            Console.WriteLine($"Visited node: {node}");

            foreach (var neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    DFSUtil(graph, neighbor, visited);
                }
            }
        }

        private void DFSUtilIterative(Dictionary<int, List<int>> graph, int startNode)
        {
            var visited = new HashSet<int>();
            var stack = new Stack<int>();
            stack.Push(startNode);
            while (stack.Count > 0)
            {
                int node = stack.Pop();
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    Console.WriteLine($"Visited node: {node}");
                    foreach (var neighbor in graph[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            stack.Push(neighbor);
                        }
                    }
                }
            }
        }
    }
}
