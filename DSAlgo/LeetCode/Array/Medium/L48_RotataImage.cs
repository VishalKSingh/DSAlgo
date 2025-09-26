using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    using System;
    internal class L48_RotataImage
    {
        // This problem is to rotate a given n x n 2D matrix by 90 degrees (clockwise).
        // The rotation should be done in-place, meaning we should not use any additional space for another matrix.
        // Time Complexity: O(n^2) where n is the number of rows/columns in the matrix
        // Space Complexity: O(1) since we are modifying the matrix in place

        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;

            // First, transpose the matrix
            for (int i = 0; i < n; i++)
            {
                // Transpose the matrix by swapping elements across the diagonal
                for (int j = i + 1; j < n; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            // Then, reverse each row
            for (int i = 0; i < n; i++)
            {
                Array.Reverse(matrix[i]);
            }
        }

        // This method is an alternative approach that uses a layer-by-layer rotation.
        public void RotateLayerByLayer(int[][] matrix)
        {
            int n = matrix.Length;
            int layers = n / 2;

            for (int layer = 0; layer < layers; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    // Save the top element
                    int top = matrix[first][i];

                    // Move left to top
                    matrix[first][i] = matrix[last - offset][first];

                    // Move bottom to left
                    matrix[last - offset][first] = matrix[last][last - offset];

                    // Move right to bottom
                    matrix[last][last - offset] = matrix[i][last];

                    // Move top to right
                    matrix[i][last] = top;
                }
            }
        }

        // This method is a brute force approach that creates a new matrix and fills it with the rotated values.
        public int[][] RotateBruteForce(int[][] matrix)
        {
            int n = matrix.Length;
            int[][] rotatedMatrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                rotatedMatrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    rotatedMatrix[j][n - 1 - i] = matrix[i][j];
                }
            }

            return rotatedMatrix;
        }
        // This method uses a mathematical approach to calculate the new positions of the elements.
        public void RotateMath(int[][] matrix)
        {
            int n = matrix.Length;

            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;

                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int top = matrix[first][i];

                    // Rotate elements
                    matrix[first][i] = matrix[last - offset][first];
                    matrix[last - offset][first] = matrix[last][last - offset];
                    matrix[last][last - offset] = matrix[i][last];
                    matrix[i][last] = top;
                }
            }
        }
        // This method uses a single loop to rotate the matrix in place.
        public void RotateSingleLoop(int[][] matrix)
        {
            int n = matrix.Length;

            for (int i = 0; i < n / 2; i++)
            {
                for (int j = i; j < n - i - 1; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[n - j - 1][i];
                    matrix[n - j - 1][i] = matrix[n - i - 1][n - j - 1];
                    matrix[n - i - 1][n - j - 1] = matrix[j][n - i - 1];
                    matrix[j][n - i - 1] = temp;
                }
            }
        }
        // This method uses a recursive approach to rotate the matrix.
        public void RotateRecursive(int[][] matrix, int layer = 0)
        {
            int n = matrix.Length;
            if (layer >= n / 2) return;

            int first = layer;
            int last = n - 1 - layer;

            for (int i = first; i < last; i++)
            {
                int offset = i - first;
                int top = matrix[first][i];

                // Rotate elements
                matrix[first][i] = matrix[last - offset][first];
                matrix[last - offset][first] = matrix[last][last - offset];
                matrix[last][last - offset] = matrix[i][last];
                matrix[i][last] = top;
            }

            RotateRecursive(matrix, layer + 1);
        }
        // This method uses a stack to rotate the matrix.
        public void RotateStack(int[][] matrix)
        {
            int n = matrix.Length;
            Stack<int> stack = new Stack<int>();

            // Push all elements into the stack
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    stack.Push(matrix[i][j]);
                }
            }

            // Pop elements back into the matrix in rotated order
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[j][n - 1 - i] = stack.Pop();
                }
            }
        }

    }
}
