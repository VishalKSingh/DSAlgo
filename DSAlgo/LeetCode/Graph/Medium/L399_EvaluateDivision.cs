using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L399_EvaluateDivision
    {
        // This problem is about evaluating division equations represented as a graph
        // Each equation is represented as a pair of variables and a value
        // The problem can be solved using Depth-First Search (DFS) or Breadth-First Search (BFS)
        // Time Complexity: O(V + E) where V is the number of variables and E is the number of equations
        // Space Complexity: O(V + E) for the graph representation and visited set

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            // Initialize the graph as a dictionary where each key is a variable and the value is a list of tuples (neighbor, value)
            var graph = new Dictionary<string, List<(string, double)>>();

            // Build the graph from the equations and values
            for (int i = 0; i < equations.Count; i++)
            {
                // Each equation is a pair of variables (a, b) with a value
                var (a, b) = (equations[i][0], equations[i][1]);

                // If the variables are not already in the graph, initialize their lists
                if (!graph.ContainsKey(a)) graph[a] = new List<(string, double)>();
                if (!graph.ContainsKey(b)) graph[b] = new List<(string, double)>();

                // Add the directed edges with the corresponding values
                graph[a].Add((b, values[i])); // Add edge from a to b with value
                graph[b].Add((a, 1 / values[i])); // Add edge from b to a with the reciprocal value
            }

            var results = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                var (start, end) = (queries[i][0], queries[i][1]);
                results[i] = DFS(graph, start, end, new HashSet<string>(), 1.0);
            }

            return results;
        }

        private double DFS(Dictionary<string, List<(string, double)>> graph, string start, string end,
                                     HashSet<string> visited, double product)
        {
            // Check if the start or end variable is not in the graph or if the start variable has already been visited
            if (!graph.ContainsKey(start) || visited.Contains(start) || !graph.ContainsKey(end)) return -1.0;

            // If we reach the end variable, return the accumulated product
            if (start == end) return product;

            visited.Add(start); // Mark the current variable as visited
            // Traverse all neighbors of the current variable
            // For each neighbor, if it has not been visited, perform DFS recursively
            // If a valid path is found, return the result
            // If no valid path is found, backtrack by removing the current variable from visited set
            foreach (var (neighbor, value) in graph[start])
            {
                if (!visited.Contains(neighbor))
                {
                    var result = DFS(graph, neighbor, end, visited, product * value);
                    if (result != -1.0) return result;
                }
            }
            visited.Remove(start);
            return -1.0;
        }

        // Note: The graph is undirected, so we add edges in both directions with the corresponding values.
    }
}
