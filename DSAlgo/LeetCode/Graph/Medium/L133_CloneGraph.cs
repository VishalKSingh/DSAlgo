using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L133_CloneGraph
    {
        // This problem is about cloning an undirected graph
        // Each node in the graph contains a value and a list of its neighbors
        // The problem can be solved using Depth-First Search (DFS) or Breadth-First Search (BFS)
        // Time Complexity: O(V + E) where V is the number of vertices (nodes) and E is the number of edges (connections)
        // Space Complexity: O(V) for the visited dictionary to keep track of cloned nodes

        public Node CloneGraph(Node node)
        {
            if (node == null) return null;

            var visited = new Dictionary<Node, Node>();
            return Clone(node, visited);
        }

        private Node Clone(Node node, Dictionary<Node, Node> visited)
        {
            // If the node has already been cloned, return the cloned node
            if (visited.ContainsKey(node)) return visited[node];

            var cloneNode = new Node(node.val);
            visited[node] = cloneNode; // Mark the node as visited and store its clone

            // Clone all neighbors of the current node
            foreach (var neighbor in node.neighbors)
            {
                cloneNode.neighbors.Add(Clone(neighbor, visited));
            }

            return cloneNode;
        }

        // Definition for a Node in the graph
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node(int val)
            {
                this.val = val;
                this.neighbors = new List<Node>();
            }
        }

        // can you optimize this code further?
        // The current implementation is already efficient with a time complexity of O(V + E) and space complexity of O(V).

    }
}
