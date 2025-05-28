using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph
{
    internal class BridthFirstSearch
    {
        // This class is a placeholder for BFS-related methods
        // It can be extended to include BFS algorithms for various problems

        public void ExampleBFS()
        {
            // Example method to demonstrate BFS usage
            Console.WriteLine("This is an example of a BFS method.");
            // Implement BFS logic here
        }
        
        // Additional BFS methods can be added here
        public void AnotherBFSExample()
        {
            // Another example method to demonstrate BFS usage
            Console.WriteLine("This is another example of a BFS method.");
            // Implement additional BFS logic here
        }
        // You can add more BFS-related methods as needed
        // For example, you can implement BFS for graph traversal, shortest path finding, etc.
        // This class can be used as a base for implementing BFS algorithms in various graph-related problems
        // For example, you can implement BFS for finding the shortest path in an unweighted graph
        // or for traversing a tree structure.
        // Remember to include necessary using directives for collections and other required namespaces
        // You can also implement BFS for specific problems like finding connected components in a graph,
        // or for solving problems like "Word Ladder" or "Shortest Path in a Grid".
        // This class can be extended further based on specific BFS-related problems you want to solve
        // or algorithms you want to implement.
        // For example, you can implement BFS for finding the shortest path in a maze,
        // or for solving problems like "Minimum Depth of Binary Tree" using BFS traversal.
        // You can also implement BFS for problems like "Level Order Traversal" in trees,
        // or for finding the shortest path in a weighted graph using Dijkstra's algorithm.
        // This class serves as a starting point for implementing BFS algorithms
        // and can be extended with more specific methods as needed.

        // write a method to demonstrate BFS traversal on a graph
        public void BFSGraphTraversal(Dictionary<int, List<int>> graph, int startNode)
        {
            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                Console.WriteLine($"Visited node: {currentNode}");

                foreach (var neighbor in graph[currentNode])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        // Example usage of BFSGraphTraversal
        public void ExampleUsage()
        {
            var graph = new Dictionary<int, List<int>>
            {
                { 0, new List<int> { 1, 2 } },
                { 1, new List<int> { 0, 3 } },
                { 2, new List<int> { 0, 3 } },
                { 3, new List<int> { 1, 2 } }
            };

            Console.WriteLine("Starting BFS traversal from node 0:");
            BFSGraphTraversal(graph, 0);
        }
        // This method can be used to demonstrate BFS traversal on a graph
        // You can call ExampleUsage() to see the BFS traversal in action
        public void RunBFSExample()
        {
            ExampleUsage(); // Call the example usage method to demonstrate BFS traversal
        }
    }
}
