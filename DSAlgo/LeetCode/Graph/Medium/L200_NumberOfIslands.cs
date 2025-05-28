using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L200_NumberOfIslands
    {
        // This problem is about counting the number of islands in a grid
        // An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically
        // The problem can be solved using Depth-First Search (DFS) or Breadth-First Search (BFS)
        // Time Complexity: O(M * N) where M is the number of rows and N is the number of columns in the grid
        // Space Complexity: O(M * N) for the visited set or stack/queue used in DFS/BFS

        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

            int numRows = grid.Length;
            int numCols = grid[0].Length;
            bool[,] visited = new bool[numRows, numCols];// Initialize a 2D array to keep track of visited cells
            int islandCount = 0;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    // If the cell is land ('1') and not visited, it is part of a new island
                    if (grid[i][j] == '1' && !visited[i, j])
                    {
                        islandCount++;
                        DFS(grid, visited, i, j);
                    }
                }
            }

            return islandCount;
        }

        private void DFS(char[][] grid, bool[,] visited, int row, int col)
        {
            if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length ||
                               visited[row, col] || grid[row][col] == '0')
                return;

            visited[row, col] = true;

            // Explore all four directions
            DFS(grid, visited, row - 1, col); // Up
            DFS(grid, visited, row + 1, col); // Down
            DFS(grid, visited, row, col - 1); // Left
            DFS(grid, visited, row, col + 1); // Right
        }

        // Alternative BFS solution
        public int NumIslandsBFS(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

            int numRows = grid.Length;
            int numCols = grid[0].Length;
            bool[,] visited = new bool[numRows, numCols];
            int islandCount = 0;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (grid[i][j] == '1' && !visited[i, j])
                    {
                        islandCount++;
                        BFS(grid, visited, i, j);
                    }
                }
            }

            return islandCount;
        }
        private void BFS(char[][] grid, bool[,] visited, int row, int col)
        {
            int numRows = grid.Length;
            int numCols = grid[0].Length;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((row, col));
            visited[row, col] = true;

            while (queue.Count > 0)
            {
                var (currentRow, currentCol) = queue.Dequeue();

                // Explore all four directions
                foreach (var (dr, dc) in new[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
                {
                    int newRow = currentRow + dr;
                    int newCol = currentCol + dc;

                    if (newRow >= 0 && newRow < numRows && newCol >= 0 && newCol < numCols &&
                                               !visited[newRow, newCol] && grid[newRow][newCol] == '1')
                    {
                        visited[newRow, newCol] = true;
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }
        }
    }
}
