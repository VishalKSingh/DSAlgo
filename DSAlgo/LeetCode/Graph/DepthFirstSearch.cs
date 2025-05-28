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
            // Example method to demonstrate DFS usage
            Console.WriteLine("This is an example of a DFS method.");
            // Implement DFS logic here
        }

        // Additional DFS methods can be added here
        public void AnotherDFSExample()
        {
            // Another example method to demonstrate DFS usage
            Console.WriteLine("This is another example of a DFS method.");
            // Implement additional DFS logic here
        }

        // You can add more DFS-related methods as needed
        // For example, you can implement DFS for graph traversal, path finding, etc.
        // This class can be used as a base for implementing DFS algorithms in various graph-related problems
        // For example, you can implement DFS for finding connected components in a graph,
        // or for solving problems like "Word Search" or "Number of Islands".
        // Remember to include necessary using directives for collections and other required namespaces
        // You can also implement DFS for specific problems like finding paths in a maze,
        // or for solving problems like "Maximum Depth of Binary Tree" using DFS traversal.
        // This class can be extended further based on specific DFS-related problems you want to solve
        // or algorithms you want to implement.
        // For example, you can implement DFS for finding the longest path in a directed acyclic graph (DAG),
        // or for solving problems like "Binary Tree Paths" using DFS traversal.
        // This class serves as a starting point for implementing DFS algorithms
        // and can be extended with more specific methods as needed.
        // write a method to demonstrate DFS traversal on a graph
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
    }
}
