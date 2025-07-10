using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L74Search2DMatrix
    {
        public L74Search2DMatrix() { }
        // This problem is to search for a target value in a 2D matrix that is sorted in ascending order both row-wise and column-wise.
        // The approach is to treat the 2D matrix as a 1D sorted array and use binary search.
        // Time Complexity: O(log(m * n)) where m is the number of rows and n is the number of columns
        // Space Complexity: O(1) since we are using a constant amount of space
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return false;

            int m = matrix.Length;
            int n = matrix[0].Length;
            int left = 0, right = m * n - 1;

            // Treat the 2D matrix as a 1D array and perform binary search
            while (left <= right)
            {
                int mid = left + (right - left) / 2; // Calculate the middle index
                int midValue = matrix[mid / n][mid % n]; // Convert the 1D index back to 2D indices

                if (midValue == target)
                    return true;
                else if (midValue < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return false;
        }

        // This method is an alternative approach that uses a linear search.
        public bool SearchMatrixLinear(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return false;

            int m = matrix.Length;
            int n = matrix[0].Length;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == target)
                        return true;
                }
            }

            return false;
        }

        // The linear search approach has a time complexity of O(m * n) where m is the number of rows and n is the number of columns.
        // This is less efficient than the binary search approach, especially for larger matrices.
        // However, it is simpler and easier to understand for small matrices or when the matrix is not sorted.
    }
}
