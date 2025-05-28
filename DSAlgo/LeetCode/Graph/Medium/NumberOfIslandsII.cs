using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class NumberOfIslandsII
    {
        // This problem is about counting the number of islands in a grid with dynamic updates
        // An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically
        // The problem can be solved using Union-Find (Disjoint Set Union) data structure
        // Time Complexity: O(M * N + K * α(M * N)) where M is the number of rows, N is the number of columns,
        // K is the number of positions to add, and α is the inverse Ackermann function
        // Space Complexity: O(M * N) for the parent array and rank array

        public IList<int> NumIslands2(int m, int n, int[][] positions)
        {
            var result = new List<int>();
            var parent = new int[m * n];
            var rank = new int[m * n];
            var count = 0;

            for (int i = 0; i < m * n; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }

            foreach (var pos in positions)
            {
                int x = pos[0], y = pos[1];
                int index = x * n + y;

                if (parent[index] != index) continue; // Already land

                parent[index] = index; // Mark as land
                count++;

                // Check all four directions
                foreach (var dir in new[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
                {
                    int nx = x + dir.Item1, ny = y + dir.Item2;
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n)
                    {
                        int neighborIndex = nx * n + ny;
                        if (parent[neighborIndex] != neighborIndex) // If neighbor is land
                        {
                            if (Union(parent, rank, index, neighborIndex))
                            {
                                count--; // Merge islands
                            }
                        }
                    }
                }

                result.Add(count);
            }

            return result;
        }
        private bool Union(int[] parent, int[] rank, int x, int y)
        {
            int rootX = Find(parent, x);
            int rootY = Find(parent, y);

            if (rootX == rootY) return false; // Already in the same set

            if (rank[rootX] > rank[rootY])
            {
                parent[rootY] = rootX;
            }
            else if (rank[rootX] < rank[rootY])
            {
                parent[rootX] = rootY;
            }
            else
            {
                parent[rootY] = rootX;
                rank[rootX]++;
            }

            return true;
        }
        private int Find(int[] parent, int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent, parent[x]); // Path compression
            }
            return parent[x];
        }

        
    }
}
