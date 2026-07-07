using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L73_SetMatrixZeroes
    {
        public L73_SetMatrixZeroes() { }

        public void SetZeroes(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            HashSet<int> zeroRows = new HashSet<int>();
            HashSet<int> zeroCols = new HashSet<int>();
            // First pass: Identify all rows and columns that need to be zeroed
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        zeroRows.Add(i); // Mark row to be Zero
                        zeroCols.Add(j); // Mark column to be Zero
                    }
                }
            }
            // Second pass: Set the identified rows and columns to zero
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // mark the cell as zero if its row or column is marked
                    if (zeroRows.Contains(i) || zeroCols.Contains(j))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        // Brute force approach using additional space
        // Time complexity: O(m * n)
        // Space complexity: O(m + n)
        public void SetZeroesBruteForce(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            
            // First pass: Mark the positions to be zeroed
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        // Mark the entire row and column for zeroing
                        for (int k = 0; k < cols; k++)
                        {
                            if (matrix[i][k] != 0) // Only mark if it's not already zero
                                matrix[i][k] = -1;
                           
                        }
                        for (int k = 0; k < rows; k++)
                        {
                            if(matrix[k][j] != 0) // Only mark if it's not already zero
                                matrix[k][j] = -1;
                        }
                    }
                }
            }
            // Second pass: Set the marked positions to zero
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == - 1)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }


        // Another approach using the first row and column as markers
        // Time complexity: O(m * n)
        // Space complexity: O(1)
        public void SetZeroesptimized(int[][] matrix)
        {
            //Brute force approach is O(N)+O(N) space for storing marking
            //OPTIMAL=>In-place marking
            //Problem figured :)
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int col0 = 1;// to keep track of whether the first column should be zeroed

            // First pass: Use the first row and first column as markers
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i][0] == 0) col0 = 0; //Mark whether the first column should be zeroed
                for (int j = 1; j < cols; j++)
                { //MISTAKE-:You started qwith 0 distrupting markers
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0; // Mark the first cell of the row
                        matrix[0][j] = 0; // Mark the first cell of the column
                    }
                }
            }
            //Markings done start conversion
            //Mark rows mark columns
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            // First row
            if (matrix[0][0] == 0)
            {
                for (int j = 0; j < cols; j++)
                    matrix[0][j] = 0;
            }

            // First column
            if (col0 == 0)
            {
                for (int i = 0; i < rows; i++)
                    matrix[i][0] = 0;
            }
        }
        
    }
}
