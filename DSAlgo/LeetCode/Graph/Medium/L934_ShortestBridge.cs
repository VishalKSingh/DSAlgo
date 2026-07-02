using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L934_ShortestBridge
    {
        public int ShortestBridge(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            bool[,] visited = new bool[rows, cols];
            Queue<(int, int)> queue = new Queue<(int, int)>();
            // Step 1: Find the first island and mark it
            bool found = false;
            for (int i = 0; i < rows; i++)
            {
                if (found) break;
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        DFS(grid, visited, queue, i, j);
                        found = true;
                        break;
                    }
                }
            }
            // Step 2: Expand from the first island to find the shortest bridge
            int steps = 0;
            int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var (x, y) = queue.Dequeue();
                    foreach (var dir in directions)
                    {
                        int newX = x + dir[0];
                        int newY = y + dir[1];
                        if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && !visited[newX, newY])
                        {
                            if (grid[newX][newY] == 1)
                            {
                                return steps; // Found the second island
                            }
                            visited[newX, newY] = true;
                            queue.Enqueue((newX, newY));
                        }
                    }
                }
                steps++;
            }
            return -1; // Should never reach here
        }

        private void DFS(int[][] grid, bool[,] visited, Queue<(int, int)> queue, int x, int y)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            if (x < 0 || x >= rows || y < 0 || y >= cols || visited[x, y] || grid[x][y] == 0)
            {
                return;
            }
            visited[x, y] = true;
            queue.Enqueue((x, y));
            DFS(grid, visited, queue, x + 1, y);
            DFS(grid, visited, queue, x - 1, y);
            DFS(grid, visited, queue, x, y + 1);
            DFS(grid, visited, queue, x, y - 1);
        }
    }
}
