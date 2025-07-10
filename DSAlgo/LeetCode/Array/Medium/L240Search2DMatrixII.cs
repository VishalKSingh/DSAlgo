using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L240Search2DMatrixII
    {
        // This problem is to search for a target value in a 2D matrix where each row and column is sorted in ascending order.
        // The approach is to start from the top-right corner and move left or down based on the comparison with the target.
        // Time Complexity: O(m + n) where m is the number of rows and n is the number of columns
        // Space Complexity: O(1) since we are using a constant amount of space

        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return false;

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int row = 0;
            int col = cols - 1;

            while (row < rows && col >= 0)
            {
                if (matrix[row][col] == target)
                    return true;
                else if (matrix[row][col] > target)
                    col--; // Move left
                else
                    row++; // Move down
            }

            return false; // Target not found
        }
    }
}
