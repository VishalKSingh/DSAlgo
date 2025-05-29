using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L417_PacificAtlanticWaterFlow
    {
        // This problem is about finding cells in a grid that can flow to both the Pacific and Atlantic oceans
        // The grid represents heights of cells, and water can flow from a cell to its neighbors if the neighbor's height is less than or equal to the current cell's height
        // The problem can be solved using Depth-First Search (DFS) or Breadth-First Search (BFS)
        // Time Complexity: O(M * N) where M is the number of rows and N is the number of columns in the grid
        // Space Complexity: O(M * N) for the visited sets used in DFS/BFS

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            if (heights == null || heights.Length == 0 || heights[0].Length == 0) return new List<IList<int>>();

            int rows = heights.Length, cols = heights[0].Length;

            // Create two boolean arrays to keep track of cells that can reach Pacific and Atlantic oceans
            var pacific = new bool[rows, cols]; // Pacific Ocean
            var atlantic = new bool[rows, cols]; // Atlantic Ocean
            var result = new List<IList<int>>();

            // Perform DFS from the borders of the grid to mark reachable cells for both oceans
            for (int i = 0; i < rows; i++)
            {
                DFS(heights, pacific, i, 0); // Pacific Ocean
                DFS(heights, atlantic, i, cols - 1); // Atlantic Ocean
            }

            // Perform DFS from the borders of the grid to mark reachable cells for both oceans
            for (int j = 0; j < cols; j++)
            {
                DFS(heights, pacific, 0, j); // Pacific Ocean
                DFS(heights, atlantic, rows - 1, j); // Atlantic Ocean
            }

            // Collect the cells that can reach both oceans
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (pacific[i, j] && atlantic[i, j])
                    {
                        result.Add(new List<int> { i, j });
                    }
                }
            }

            return result;
        }

        private void DFS(int[][] heights, bool[,] visited, int row, int col)
        {
            int m = heights.Length, n = heights[0].Length;

            if (row < 0 || row >= m || col < 0 || col >= n || visited[row, col])
                return;

            visited[row, col] = true;

            // Explore all four directions
            foreach (var dir in new[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
            {
                // Calculate new row and column indices based on the current direction
                int newRow = row + dir.Item1; 
                int newCol = col + dir.Item2;

                if (newRow >= 0 && newRow < m && newCol >= 0 && newCol < n &&
                                       heights[newRow][newCol] >= heights[row][col])
                {
                    DFS(heights, visited, newRow, newCol);
                }
            }
        }
       
    }
}
