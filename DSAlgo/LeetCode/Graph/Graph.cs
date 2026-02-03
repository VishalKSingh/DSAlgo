using System.Collections.Generic;

namespace DSAlgo.LeetCode.Graph
{
    internal class Graph
    {
        private readonly Dictionary<int, List<int>> adjList = new();

        // Add a node to the graph
        public void AddNode(int node)
        {
            if (!adjList.ContainsKey(node))
                adjList[node] = new List<int>();
        }

        // Add an edge from 'from' to 'to'
        public void AddEdge(int from, int to)
        {
            AddNode(from);
            AddNode(to);
            adjList[from].Add(to);
        }

        // Get neighbors of a node
        public IEnumerable<int> GetNeighbors(int node)
        {
            if (adjList.TryGetValue(node, out var neighbors))
                return neighbors;
            return new List<int>();
        }

        // Get all nodes in the graph
        public IEnumerable<int> GetNodes()
        {
            return adjList.Keys;
        }
    }
}
