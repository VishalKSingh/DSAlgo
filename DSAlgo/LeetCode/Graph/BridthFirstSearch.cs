using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph
{
    internal class BridthFirstSearch
    {
       

        //  finding the shortest path in an unweighted graph or for traversing a tree structure.
        // finding connected components in a graph,"Word Ladder" or "Shortest Path in a Grid".
        
        // finding the shortest path in a maze, "Minimum Depth of Binary Tree" using BFS traversal.
        // You can also implement BFS for problems like "Level Order Traversal" in trees,
        // shortest path in a weighted graph using Dijkstra's algorithm.


        // Time complexity: O(V + E) where V is the number of vertices and E is the number of edges
        // Space complexity: O(V) for the queue and visited set
        public void BFSGraphTraversal(Dictionary<int, List<int>> graph, int startNode)
        {
            var visited = new HashSet<int>(); // To keep track of visited unique nodes
            var queue = new Queue<int>(); // Queue for BFS
            queue.Enqueue(startNode); // Start from the given start node
            visited.Add(startNode); // Mark the start node as visited

            // Perform BFSl
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
