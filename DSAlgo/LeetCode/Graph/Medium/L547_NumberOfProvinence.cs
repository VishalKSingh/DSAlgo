using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L547_NumberOfProvinence
    {
        // This problem is to find the number of provinces (connected components) in an undirected graph.
        // The approach is to use Depth-First Search (DFS) to explore the graph and count the number of connected components.
        // Time Complexity: O(n^2) where n is the number of cities (nodes) since we are using an adjacency matrix
        // Space Complexity: O(n) for the visited array
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            bool[] visited = new bool[n];
            int provinceCount = 0;

            // Iterate through each city
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    DFS(isConnected, visited, i);
                    provinceCount++;
                }
            }
            return provinceCount;
        }
        private void DFS(int[][] isConnected, bool[] visited, int city)
        {
            visited[city] = true;
            // Explore all neighbors of the current city
            for (int neighbor = 0; neighbor < isConnected.Length; neighbor++)
            {
                // If there is a connection and the neighbor hasn't been visited, continue the DFS
                if (isConnected[city][neighbor] == 1 && !visited[neighbor])
                {
                    DFS(isConnected, visited, neighbor);
                }
            }
        }
    }
}
