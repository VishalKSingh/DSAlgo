using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L120_Triangle
    {
        public L120_Triangle() { }
        // Given a triangle array, return the minimum path sum from top to bottom.
        // For each step, you may move to an adjacent number of the row below.
        // More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.
        // Example 1:
        // Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
        // Output: 11
        // Explanation: The triangle looks like:
        // The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = triangle[n - 1][i];
            }
            for (int layer = n - 2; layer >= 0; layer--)
            {
                for (int i = 0; i <= layer; i++)
                {
                    dp[i] = Math.Min(dp[i], dp[i + 1]) + triangle[layer][i];
                }
            }
            return dp[0];
        }

        // Time Complexity: O(n^2), where n is the number of rows in the triangle. We process each element in the triangle once.
        // Space Complexity: O(n), where n is the number of rows in the triangle. We use an array of size n to store the minimum path sums for the current row.

        //dp[0] = 1 + 6
        //dp[1] = 1 + 5
        //dp[2] = 3 + 7
        // dp[3] = 3
        //1 + 6, 1 + 5,  

        // write Brute force approach

        // Time Complexity: O(2^n), where n is the number of rows in the triangle. In the worst case, we explore two paths at each step.
        // Space Complexity: O(n), where n is the number of rows in the triangle. This space is used by the recursion stack.
        public int MinimumTotal_BruteForce(IList<IList<int>> triangle)
        {
            return Helper(triangle, 0, 0);
        }
        private int Helper(IList<IList<int>> triangle, int row, int col)
        {
            if (row == triangle.Count - 1)
            {
                return triangle[row][col];
            }
            int down = Helper(triangle, row + 1, col);
            int diagonal = Helper(triangle, row + 1, col + 1);
            return Math.Min(down, diagonal) + triangle[row][col];


        }
    }
}
