using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L64_MinPathSum
    {
        public L64_MinPathSum() { }
        // This problem is to find the minimum path sum from the top-left corner to the bottom-right corner of a grid,
        // where you can only move either down or right at any point in time.
        // The approach is to use dynamic programming to calculate the minimum path sum to each cell.
        // Time Complexity: O(m * n) where m is the number of rows and n is the number of columns
        // Space Complexity: O(m * n) for the dp array

        public int MinPathSum(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
                return 0;
            int m = grid.Length;
            int n = grid[0].Length;
            int[,] dp = new int[m, n];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i == 0 && j == 0)
                        dp[i,j] = grid[i][j]; // Start point
                    
                    else
                    {
                        int left = j > 0 ? dp[i,j - 1] : int.MaxValue;
                        int up = i > 0 ? dp[i - 1,j] : int.MaxValue;
                        // Minimum path sum from the left cell

                        dp[i,j] = Math.Min(up, left) + grid[i][j]; // Minimum path sum to reach (i, j)
                    }
                       
                }
            }
            return dp[m - 1, n - 1]; // Return the minimum path sum to reach the bottom-right corner
        }

        // memoization approach
        public int MinPathSumMemo(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
                return 0;
            int m = grid.Length;
            int n = grid[0].Length;
            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
            return MinPathSumHelper(grid, m - 1, n - 1, memo);
        }

        private int MinPathSumHelper(int[][] grid, int i, int j, Dictionary<(int, int), int> memo)
        {
            if (i < 0 || j < 0)
                return int.MaxValue; // Out of bounds
            if (i == 0 && j == 0)
                return grid[0][0]; // Start point
            if (memo.ContainsKey((i, j)))
                return memo[(i, j)]; // Return cached result
            int minPathSum = Math.Min(MinPathSumHelper(grid, i - 1, j, memo), MinPathSumHelper(grid, i, j - 1, memo)) + grid[i][j];
            memo[(i, j)] = minPathSum; // Cache the result
            return minPathSum;
        }

        // space optimized approach
        // This method uses a space-optimized approach to reduce the space complexity to O(n).
        // Instead of using a 2D array, we can use a 1D array to store the minimum path sum to each cell in the current row.
        // Time Complexity: O(m * n) where m is the number of rows and n is the number of columns
        // Space Complexity: O(n) since we are using a 1D array to store the results for the current row
        public int MinPathSumOptimized(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
                return 0;
            int m = grid.Length;
            int n = grid[0].Length;
            int[] dp = new int[n];

            dp[0] = grid[0][0]; // Start point

            //for (int j = 1; j < n; j++)
            //    dp[j] = dp[j - 1] + grid[0][j]; // First row

            //for (int i = 1; i < m; i++)
            //{
            //    dp[0] += grid[i][0]; // First column
            //    for (int j = 1; j < n; j++)
            //    {
            //        dp[j] = Math.Min(dp[j], dp[j - 1]) + grid[i][j]; // Minimum path sum to reach (i, j)
            //    }
            //}

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                        dp[j] = grid[i][j]; // Start point

                    else
                    {
                        int left = j > 0 ? dp[j - 1] : int.MaxValue;
                        int up = i > 0 ? dp[j] : int.MaxValue;
                        // Minimum path sum from the left cell

                        dp[j] = Math.Min(up, left) + grid[i][j]; // Minimum path sum to reach (i, j)
                    }

                }
            }
            return dp[n - 1]; // Return the minimum path sum to reach the bottom-right corner
        }
    }
}
