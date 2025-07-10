using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L54SpiralMatrix
    {
        // This problem is to return all elements of a matrix in spiral order.
        // The approach is to use four pointers to keep track of the boundaries of the matrix and iterate through the layers.
        // Time Complexity: O(m * n) where m is the number of rows and n is the number of columns
        // Space Complexity: O(1) since we are using a constant amount of space for the result list

        public IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> result = new List<int>();
            if (matrix.Length == 0 || matrix[0].Length == 0) return result;

            int top = 0, bottom = matrix.Length - 1;
            int left = 0, right = matrix[0].Length - 1;

            while (top <= bottom && left <= right)
            {
                // Traverse from left to right
                for (int i = left; i <= right; i++)
                {
                    result.Add(matrix[top][i]);
                }
                top++;

                // Traverse from top to bottom
                for (int i = top; i <= bottom; i++)
                {
                    result.Add(matrix[i][right]);
                }
                right--;

                // Check if we still have rows to traverse
                if (top <= bottom)
                {
                    // Traverse from right to left
                    for (int i = right; i >= left; i--)
                    {
                        result.Add(matrix[bottom][i]);
                    }
                    bottom--;
                }
                // Check if we still have columns to traverse
                if (left <= right)
                {
                    // Traverse from bottom to top
                    for (int i = bottom; i >= top; i--)
                    {
                        result.Add(matrix[i][left]);
                    }
                    left++;
                }
            }

            return result;
        }
    }
}
