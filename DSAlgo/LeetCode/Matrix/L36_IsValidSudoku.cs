using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Matrix
{
    public static class L36_IsValidSudoku
    {
        // This problem is about validating a 9x9 Sudoku board
        // We need to check if each row, column, and 3x3 sub-box contains unique digits from 1 to 9
        // Time Complexity: O(1) since the board size is fixed (9x9)
        // Space Complexity: O(1) for the hash sets used to track seen numbers
        public static bool IsValidSudoku(char[][] board)
        {
            var rows = new HashSet<char>[9];
            var cols = new HashSet<char>[9];
            var boxes = new HashSet<char>[9];

            // Initialize hash sets for rows, columns, and boxes
            for (int i = 0; i < 9; i++)
            {
                rows[i] = new HashSet<char>();
                cols[i] = new HashSet<char>();
                boxes[i] = new HashSet<char>();
            }
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    char num = board[r][c];
                    // Skip empty cells
                    if (num == '.') continue;
                    int boxIndex = (r / 3) * 3 + (c / 3);
                    if (rows[r].Contains(num) || cols[c].Contains(num) || boxes[boxIndex].Contains(num))
                    {
                        return false; // Duplicate found in row, column, or box
                    }
                    rows[r].Add(num);
                    cols[c].Add(num);
                    boxes[boxIndex].Add(num);
                }
            }
            return true; // All checks passed, the board is valid
        }

        // This brute force method checks each row, column, and box separately for duplicates
        // It uses three hash sets to track seen numbers for rows, columns, and boxes
        // The method iterates through each cell in the board and checks for duplicates in the corresponding row, column, and box
        // If a duplicate is found, it returns false; otherwise, it continues checking until all cells are processed

        public static bool IsValidSudokuBruteForce(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                var rowSet = new HashSet<char>();
                var colSet = new HashSet<char>();
                var boxSet = new HashSet<char>();
                for (int j = 0; j < 9; j++)
                {
                    // Check row
                    if (board[i][j] != '.' && !rowSet.Add(board[i][j]))
                    {
                        return false; // Duplicate in row
                    }
                    // Check column
                    if (board[j][i] != '.' && !colSet.Add(board[j][i]))
                    {
                        return false; // Duplicate in column
                    }
                    // Check box (5,3)
                    int boxRow = 3 * (i / 3) + j / 3; // Calculate the row index for the 3x3 box
                    int boxCol = 3 * (i % 3) + j % 3; // Calculate the column index for the 3x3 box
                    if (board[boxRow][boxCol] != '.' && !boxSet.Add(board[boxRow][boxCol]))
                    {
                        return false; // Duplicate in box
                    }
                }
            }
            return true; // All checks passed, the board is valid

        }
    }
}
