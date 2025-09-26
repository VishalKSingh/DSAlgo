using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L994_RottingOranges
    {
        // This problem is to find the minimum time required for all oranges to become rotten.
        // We can use a breadth-first search (BFS) approach to solve this problem.
        // Time Complexity: O(m * n) where m is the number of rows and n is the number of columns in the grid
        // Space Complexity: O(m * n) for the queue used in BFS

        public int OrangesRotting(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            // Create a queue to perform BFS and a counter for fresh oranges
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int freshCount = 0;

            // Initialize the queue with all rotten oranges and count fresh oranges
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                    }
                    else if (grid[i][j] == 1)
                    {
                        freshCount++;
                    }
                }
            }

            if (freshCount == 0) return 0; // No fresh oranges

            int minutes = 0;
            // Define the directions for adjacent cells (down, up, right, left)
            int[][] directions = { [ 1, 0 ], [ -1, 0 ], [ 0, 1 ], [ 0, -1 ] };

            // Perform BFS to rot oranges
            while (queue.Count > 0 && freshCount > 0)
            {
                int size = queue.Count;// Get the number of rotten oranges at this level
                // Iterate through all rotten oranges at this level
                for (int i = 0; i < size; i++)
                {
                    var (x, y) = queue.Dequeue();// Get the current rotten orange's position
                    // Check all four directions to rot adjacent fresh oranges
                    foreach (var dir in directions)
                    {
                        int newX = x + dir[0];
                        int newY = y + dir[1];
                        if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && grid[newX][newY] == 1)
                        {
                            grid[newX][newY] = 2; // Mark as rotten
                            freshCount--;
                            queue.Enqueue((newX, newY)); // Add the newly rotten orange to the queue
                        }
                    }
                }
                minutes++;
            }

            return freshCount == 0 ? minutes : -1; // If there are still fresh oranges left
        }

        // This method is an alternative approach that uses DFS to solve the problem.
        // Time Complexity: O(m * n) where m is the number of rows and n is the number of columns in the grid
        // Space Complexity: O(m * n) for the recursive stack used in DFS
        public int OrangesRottingDFS(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            int freshCount = 0;
            int minutes = 0;

            // Count fresh oranges and mark rotten oranges
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        freshCount++;
                    }
                }
            }

            if (freshCount == 0) return 0; // No fresh oranges

            // Perform DFS to rot oranges
            while (freshCount > 0)
            {
                bool rotted = false;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (grid[i][j] == 2)
                        {
                            // Check all four directions
                            rotted |= TryRot(grid, i + 1, j);
                            rotted |= TryRot(grid, i - 1, j);
                            rotted |= TryRot(grid, i, j + 1);
                            rotted |= TryRot(grid, i, j - 1);
                        }
                    }
                }
                if (!rotted) break; // No more oranges can rot
                minutes++;
            }

            return freshCount == 0 ? minutes : -1; // If there are still fresh oranges left
        }

        private bool TryRot(int[][] grid, int x, int y)
        {
            if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || grid[x][y] != 1)
            {
                return false; // Out of bounds or not a fresh orange
            }
            grid[x][y] = 2; // Mark as rotten
            return true; // Successfully rotted an orange
        }
    }
}
