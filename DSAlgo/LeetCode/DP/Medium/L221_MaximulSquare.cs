using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L221_MaximulSquare
    {
        public L221_MaximulSquare() { }
        // This problem is about finding the largest square of 1's in a binary matrix
        // We can solve this problem using dynamic programming by creating a dp array where dp[i][j] represents the size of the largest square
        // that can be formed with (i, j) as the bottom-right corner
        // The value of dp[i][j] can be calculated as the minimum of dp[i-1][j], dp[i][j-1], and dp[i-1][j-1] plus 1 if the current cell is '1'
        // Time Complexity: O(m*n) where m is the number of rows and n is the number of columns in the matrix
        // Space Complexity: O(m*n) for the dp array
        public L221_MaximulSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return;
            }
            int maxSide = 0;
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[,] dp = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i, j] = 1; // First row or first column can only form a square of size 1
                        }
                        else
                        {
                            dp[i, j] = Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1])) + 1;
                        }
                        maxSide = Math.Max(maxSide, dp[i, j]);
                    }
                }
            }
            int maxArea = maxSide * maxSide; // The area of the largest square
        }
    }
}
