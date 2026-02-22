using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L62UniquePaths
    {
        // This problem is to find the number of unique paths from the top-left corner to the bottom-right corner of a grid.
        // You can only move either down or right at any point in time.

        // Brute force recursive approach
        // Time Complexity: O(2^(m+n)) in the worst case, which is exponential
        // Space Complexity: O(m+n) for the recursion stack
        public int UniquePathsBruteForce(int m, int n)
        {
            return UniquePathsBruteForceHelper(m - 1, n - 1);
        }
        private int UniquePathsBruteForceHelper(int m, int n)
        {
            if (m == 0 || n == 0) return 1; // Base case: only one way to reach the first row or column
            return UniquePathsBruteForceHelper(m - 1, n) + UniquePathsBruteForceHelper(m, n - 1); // Recursive case
        }

        // ##### Recursive approach with memoization  ####
        // Time Complexity: O(m * n) due to memoization
        // Space Complexity: O(m * n) for the memoization dictionary
        public int UniquePathsRecursiveMemo(int m, int n)
        {
            var memo = new Dictionary<(int, int), int>();
            return UniquePathsHelper(m - 1, n - 1, memo);
        }
        
        private int UniquePathsHelper(int m, int n, Dictionary<(int, int), int> memo)
        {
            if (m == 0 || n == 0) return 1; // Base case: only one way to reach the first row or column
            if (memo.ContainsKey((m, n))) return memo[(m, n)]; // Check if already computed

            // Recursive case: sum of paths from the cell above and the cell to the left
            memo[(m, n)] = UniquePathsHelper(m - 1, n, memo) + UniquePathsHelper(m, n - 1, memo);
            return memo[(m, n)];
        }

        // ##### Tabulation approach with 2D array  ####
        // The approach is to use dynamic programming to build a 2D array where each cell represents the number of unique paths to that cell.
        // Time Complexity: O(m * n) where m is the number of rows and n is the number of columns
        // Space Complexity: O(m * n) for the DP table

        public int UniquePathsTwoDArray(int m, int n)
        {
            int[,] dp = new int[m, n];

            // Fill the DP table
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i == 0 || j == 0)
                        dp[i, j] = 1; // Base case: only one way to reach the first row or column
                    else
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1]; // Return the value in the bottom-right corner
        }


        // Instead of using a 2D array, we can use a 1D array to store the number of unique paths to each cell in the current row.
        // Time Complexity: O(m * n)
        // Space Complexity: O(n) since we are using a 1D array to store the results for the current row
        public int UniquePathsOneDArray(int m, int n)
        {
            int[] dp = new int[n];
            dp[0] = 1; // There's one way to reach the first cell

            // Initialize the first row
            for (int i = 0; i < m; i++)
            {
                // Update the first cell of the current row
                for (int j = 1; j < n; j++)
                {
                    dp[j] += dp[j - 1]; // Update the current cell based on the cell abovedp[j] and to the left dp[j-1
                }
            }

            return dp[n - 1]; // Return the value in the last cell
        }

        // Combinatorial approach to calculate the number of unique paths.
        // The number of unique paths is given by the binomial coefficient C(m+n-2, m-1) or C(m+n-2, n-1).
        // Time Complexity: O(min(m, n)) for calculating the binomial coefficient
        // Space Complexity: O(1) since we are using a constant amount of space
        public int UniquePathsCombinatorial(int m, int n)
        {
            // The number of unique paths is given by the binomial coefficient C(m+n-2, m-1) or C(m+n-2, n-1)
            long result = 1;
            int N = m + n - 2; // Total steps(m-1 down + n-1 right)
            int K = Math.Min(m - 1, n - 1); // Choose the smaller of m-1 or n-1

            // Calculate the binomial coefficient C(N, K)
            for (int i = 0; i < K; i++)
            {
                result *= (N - i); // Multiply by (N - i)
                result /= (i + 1); // Divide by (i + 1)
            }

            return (int)result; // Return the result as an integer
        }
    }
}
