using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L130_SurroundedRegions
    {
        // This problem is about capturing surrounded regions in a grid
        // A region is surrounded if it is completely surrounded by 'X's and not connected to the border
        // The problem can be solved using Depth-First Search (DFS) or Breadth-First Search (BFS)
        // Time Complexity: O(M * N) where M is the number of rows and N is the number of columns in the grid
        // Space Complexity: O(M * N) for the visited set or stack/queue used in DFS/BFS

        // which big tech company asked this question in their interview?
        // This problem is commonly asked by companies like Google, Facebook, and Amazon in their coding interviews.
        
        public void Solve(char[][] board)
        {
            if (board == null || board.Length == 0 || board[0].Length == 0) return;

            int numRows = board.Length;
            int numCols = board[0].Length;

            // Mark all 'O's connected to the border as 'E' (escaped)
            for (int i = 0; i < numRows; i++)
            {
                if (board[i][0] == 'O') DFS(board, i, 0);
                if (board[i][numCols - 1] == 'O') DFS(board, i, numCols - 1);
            }
            for (int j = 0; j < numCols; j++)
            {
                if (board[0][j] == 'O') DFS(board, 0, j);
                if (board[numRows - 1][j] == 'O') DFS(board, numRows - 1, j);
            }

            // Flip all remaining 'O's to 'X's and all 'E's back to 'O's
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
                    else if (board[i][j] == 'E')
                        board[i][j] = 'O';
                }
            }
        }

        private void DFS(char[][] board, int row, int col)
        {
            // Check if the current cell is out of bounds or not an 'O'
            if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length ||
                               board[row][col] != 'O')
                return;

            // Mark the cell as escaped
            board[row][col] = 'E';

            // Explore all four directions
            DFS(board, row - 1, col); // Up
            DFS(board, row + 1, col); // Down
            DFS(board, row, col - 1); // Left
            DFS(board, row, col + 1); // Right
        }


        // Alternative BFS solution
        public void SolveBFS(char[][] board)
        {
            if (board == null || board.Length == 0 || board[0].Length == 0) return;

            int numRows = board.Length;
            int numCols = board[0].Length;
            Queue<(int, int)> queue = new Queue<(int, int)>();

            // Enqueue all 'O's connected to the border
            for (int i = 0; i < numRows; i++)
            {
                if (board[i][0] == 'O') queue.Enqueue((i, 0));
                if (board[i][numCols - 1] == 'O') queue.Enqueue((i, numCols - 1));
            }
            for (int j = 0; j < numCols; j++)
            {
                if (board[0][j] == 'O') queue.Enqueue((0, j));
                if (board[numRows - 1][j] == 'O') queue.Enqueue((numRows - 1, j));
            }

            // Process the queue
            while (queue.Count > 0)
            {
                var (row, col) = queue.Dequeue();
                if (row < 0 || row >= numRows || col < 0 || col >= numCols ||
                                                  board[row][col] != 'O')
                    continue;

                // Mark the cell as escaped
                board[row][col] = 'E';

                // Enqueue all four directions
                queue.Enqueue((row - 1, col)); // Up
                queue.Enqueue((row + 1, col)); // Down
                queue.Enqueue((row, col - 1)); // Left
                queue.Enqueue((row, col + 1)); // Right
            }

            // Flip all remaining 'O's to 'X's and all 'E's back to 'O's
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
                    else if (board[i][j] == 'E')
                        board[i][j] = 'O';
                }
            }
        }
       
    }
}
