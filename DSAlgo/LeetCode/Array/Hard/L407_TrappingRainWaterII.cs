namespace DSAlgo.LeetCode.Array.Hard
{
    using System;
    using System.Collections.Generic;
    internal class L407_TrappingRainWaterII
    {
        // This problem is to calculate the amount of water that can be trapped after raining
        // given a 2D grid representing the height of each cell.
        // The approach is to use a priority queue (min-heap) to simulate the water trapping process.
        // Time Complexity: O(m * n * log(m * n)) where m and n are the dimensions of the grid
        // Space Complexity: O(m * n) for the priority queue

        public int TrapRainWater(int[][] heightMap)
        {
            if (heightMap == null || heightMap.Length == 0 || heightMap[0].Length == 0) return 0;

            int m = heightMap.Length, n = heightMap[0].Length; // Number of rows and columns
            bool[,] visited = new bool[m, n]; // Visited array to keep track of cells that have been processed
            PriorityQueue<(int, int)> pq = new PriorityQueue<(int, int)>();
            // Using a priority queue to store the heights of the cells
            // The priority queue will store tuples of (height, index) where index is calculated as i * n + j
            // This allows us to efficiently get the cell with the minimum height
            // PriorityQueue is a custom implementation or can be replaced with a suitable library
            // Note: In C#, you can use SortedSet or a custom priority queue implementation
            // to achieve similar functionality as a min-heap.
            // The priority queue will help us process the cells in order of their heights
            // Directions array to move in the four possible directions (up, right, down, left)

            int[] directions = { 0, 1, 0, -1, 0 }; // Directions for up, right, down, left
            int waterTrapped = 0;

            // Initialize the priority queue with the boundary cells
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Add boundary cells to the priority queue
                    if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                    {
                        pq.Enqueue((heightMap[i][j], i * n + j)); // Store height and index in the queue
                        visited[i, j] = true;
                    }
                }
            }

            while (pq.Count > 0)
            {
                var (height, index) = pq.Dequeue(); // Get the cell with the minimum height from the priority queue
                int x = index / n, y = index % n;// Calculate the coordinates of the cell from the index

                // Check all four directions
                for (int d = 0; d < 4; d++)
                {
                    // Calculate the next cell coordinates based on the current direction
                    int nx = x + directions[d], ny = y + directions[d + 1];
                    // Check if the next cell is within bounds and not visited
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && !visited[nx, ny])
                    {
                        visited[nx, ny] = true;
                        waterTrapped += Math.Max(0, height - heightMap[nx][ny]);
                        pq.Enqueue((Math.Max(height, heightMap[nx][ny]), nx * n + ny));
                    }
                }
            }

            return waterTrapped;
        }
    }
}
