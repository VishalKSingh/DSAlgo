using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Backtracking
{
    internal class L51_NQueens
    {
        public L51_NQueens()
        {
            int n = 4;
            var result = SolveNQueens(n);
            foreach (var solution in result)
            {
                foreach (var row in solution)
                {
                    Console.WriteLine(row);
                }
                Console.WriteLine();
            }
        }
        // Backtracking approach to solve the N-Queens problem
        // Time Complexity: O(N!), Space Complexity: O(N^2) for the board
        // The idea is to place queens one by one in different columns, starting from the leftmost column.
        // For every placed queen, we check for clashes with already placed queens. If there is no clash, we move on to place the next queen.
        // If placing the queen in the current column leads to a solution then we return true. If placing the queen doesn't lead to a solution
        // then we remove the queen from that position (backtrack) and try other columns.
        // The process is repeated until all queens are placed on the board.
        // The IsSafe function checks if it's safe to place a queen at the given position by checking the column and both diagonals.
        
        public IList<IList<string>> SolveNQueens(int n)
        {
            var result = new List<IList<string>>();
            var board = new char[n][];
            // Initialize the board with '.'
            for (int i = 0; i < n; i++)
            {
                board[i] = new string('.', n).ToCharArray();
            }
            Backtrack(board, 0, result);
            return result;
        }
        private void Backtrack(char[][] board, int row, IList<IList<string>> result)
        {
            // Base case: If we have placed queens in all rows, add the current board configuration to the result
            if (row == board.Length)
            {
                result.Add(board.Select(r => new string(r)).ToList());
                return;
            }
            // Try placing a queen in each column of the current row and check if it's safe
            for (int col = 0; col < board.Length; col++)
            {
                if (IsSafe(board, row, col))
                {
                    board[row][col] = 'Q';
                    Backtrack(board, row + 1, result);
                    board[row][col] = '.';
                }
            }
        }
        private bool IsSafe(char[][] board, int row, int col)
        {
            // Check column
            for (int i = 0; i < row; i++)
            {
                if (board[i][col] == 'Q')
                {
                    return false;
                }
            }
            // Check upper left diagonal
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i][j] == 'Q')
                {
                    return false;
                }
            }
            // Check upper right diagonal
            for (int i = row - 1, j = col + 1; i >= 0 && j < board.Length; i--, j++)
            {
                if (board[i][j] == 'Q')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
