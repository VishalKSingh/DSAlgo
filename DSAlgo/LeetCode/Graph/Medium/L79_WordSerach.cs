using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L79_WordSerach
    {
        public L79_WordSerach()
        {
            char[][] board = new char[][]
            {
                new char[] { 'A', 'B', 'C', 'E' },
                new char[] { 'S', 'F', 'C', 'S' },
                new char[] { 'A', 'D', 'E', 'E' }
            };
            string word = "ABCCED";
            Console.WriteLine(Exist(board, word));
        }
        public bool Exist(char[][] board, string word)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (DFS(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool DFS(char[][] board, string word, int i, int j, int index)
        {
            // Base case: If we have found the entire word
            if (index == word.Length)
            {
                return true;
            }

            // Check boundaries and if the current cell matches the character in the word
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != word[index])
            {
                return false;
            }
            // Mark the cell as visited by replacing it with a special character (e.g., '#')
            char temp = board[i][j];
            board[i][j] = '#'; // Mark as visited
            bool found = DFS(board, word, i + 1, j, index + 1) ||
                         DFS(board, word, i - 1, j, index + 1) ||
                         DFS(board, word, i, j + 1, index + 1) ||
                         DFS(board, word, i, j - 1, index + 1);
            board[i][j] = temp; // Unmark
            return found;
        }
    }
}
