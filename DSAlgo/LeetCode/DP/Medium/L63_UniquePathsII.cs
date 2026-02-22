using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L63_UniquePathsII
    {
        // This problem is to find the number of unique paths from the top-left corner to the bottom-right corner of a grid,
        // where some cells are blocked (denoted by 1) and others are free (denoted by 0).
        // You can only move either down or right at any point in time.

        // The approach is to use dynamic programming to count the number of unique paths to each cell.
        // Time Complexity: O(m * n) where m is the number of rows and n is the number of columns
        // Space Complexity: O(m * n) for the dp array

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0)
                return 0;

            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            if (obstacleGrid[0][0] == 1 || obstacleGrid[m - 1][n - 1] == 1)
                return 0; // If start or end is blocked, return 0

            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
                dp[i] = new int[n];

            dp[0][0] = 1; // Start point

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[i][j] = 0; // Blocked cell
                    }
                    else
                    {
                        if (i > 0)
                            dp[i][j] += dp[i - 1][j]; // From top
                        if (j > 0)
                            dp[i][j] += dp[i][j - 1]; // From left
                    }
                }
            }

            return dp[m - 1][n - 1]; // Return the number of unique paths to the bottom-right corner
        }

        // This method uses a space-optimized approach to reduce the space complexity to O(n).
        // Instead of using a 2D array, we can use a 1D array to store the number of unique paths to each cell in the current row.
        // Time Complexity: O(m * n) where m is the number of rows and n is the number of columns
        // Space Complexity: O(n) since we are using a 1D array to store the results for the current row
        public int UniquePathsWithObstaclesOptimized(int[][] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0)
                return 0;

            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            if (obstacleGrid[0][0] == 1 || obstacleGrid[m - 1][n - 1] == 1)
                return 0; // If start or end is blocked, return 0

            int[] dp = new int[n];
            dp[0] = 1; // Start point

            // Initialize the first row

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[j] = 0; // Blocked cell
                    }
                    else
                    {
                        if (j > 0)
                            dp[j] +=  dp[j - 1]; // From left
                    }
                }
            }

            return dp[n - 1]; // Return the number of unique paths to the bottom-right corner
        }

        //Brute Force Approach
        // This method uses a brute force approach to count the number of unique paths from the top-left corner to the bottom-right corner of a grid 
        // with obstacles.
        // The approach is to recursively explore all possible paths and count the valid ones.
        // Time Complexity: O(2^(m+n)) in the worst case, where m is the number of rows and n is the number of columns
        // Space Complexity: O(m+n) for the recursion stack
        public int UniquePathsWithObstaclesBruteForce(int[][] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0)
                return 0;

            return CountPaths(obstacleGrid, 0, 0);
        }
        private int CountPaths(int[][] obstacleGrid, int row, int col)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            // If out of bounds or cell is blocked, return 0
            if (row >= m || col >= n || obstacleGrid[row][col] == 1)
                return 0;

            // If reached the bottom-right corner, return 1
            if (row == m - 1 && col == n - 1)
                return 1;

            // Move down and right
            return CountPaths(obstacleGrid, row + 1, col) + CountPaths(obstacleGrid, row, col + 1);
        }

        // Using memoization approach
        // This method uses a recursive approach with memoization to count the number of unique paths from the top-left corner to the bottom-right corner of a grid with obstacles.
        // The approach is to recursively explore all possible paths while storing the results of previously computed paths in a memoization array to avoid redundant calculations.
        // Time Complexity: O(m * n) due to memoization
        // Space Complexity: O(m * n) for the memoization array
        public int UniquePathsWithObstaclesMemoization(int[][] obstacleGrid)
        {
            if (obstacleGrid == null || obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0)
                return 0;
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            if (obstacleGrid[0][0] == 1 || obstacleGrid[m - 1][n - 1] == 1)
                return 0; // If start or end is blocked, return 0
            int[][] memo = new int[m][];
            for (int i = 0; i < m; i++)
                memo[i] = Enumerable.Repeat(-1, n).ToArray(); // Initialize memoization array with -1
            return UniquePathsWithObstaclesMemoization(obstacleGrid, 0, 0, memo);
        }

        private int UniquePathsWithObstaclesMemoization(int[][] obstacleGrid, int row, int col, int[][] memo)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            // If out of bounds or cell is blocked, return 0
            if (row >= m || col >= n || obstacleGrid[row][col] == 1)
                return 0;

            // If reached the bottom-right corner, return 1
            if (row == m - 1 && col == n - 1)
                return 1;

            // If already computed, return the stored value
            if (memo[row][col] != -1)
                return memo[row][col];

            // Move down and right
            memo[row][col] = UniquePathsWithObstaclesMemoization(obstacleGrid, row + 1, col, memo) +
                             UniquePathsWithObstaclesMemoization(obstacleGrid, row, col + 1, memo);

            return memo[row][col];
        }
        
      

    }
}
