using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Medium
{
    internal class L212_WordSearchII
    {
        public L212_WordSearchII()
        {
            char[][] board = new char[][]
            {
                new char[] { 'o', 'a', 'a', 'n' },
                new char[] { 'e', 't', 'a', 'e' },
                new char[] { 'i', 'h', 'k', 'r' },
                new char[] { 'i', 'f', 'l', 'v' }
            };
            string[] words = new string[] { "oath", "pea", "eat", "rain" };
            var result = FindWords(board, words);
            Console.WriteLine(string.Join(", ", result));
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            var result = new List<string>();
            var trie = new Trie();
            foreach (var word in words)
            {
                trie.Insert(word);
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    DFS(board, trie.Root, i, j, result);
                }
            }
            return result;
        }

        private void DFS(char[][] board, TrieNode node, int i, int j, List<string> result)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] == '#' || !node.Children.ContainsKey(board[i][j]))
            {
                return;
            }
            char temp = board[i][j];
            node = node.Children[temp];
            if (node.IsEndOfWord)
            {
                result.Add(node.Word);
                node.IsEndOfWord = false; // Avoid duplicate entries
            }
            board[i][j] = '#'; // Mark as visited
            DFS(board, node, i + 1, j, result);
            DFS(board, node, i - 1, j, result);
            DFS(board, node, i, j + 1, result);
            DFS(board, node, i, j - 1, result);
            board[i][j] = temp; // Unmark
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; }
            public bool IsEndOfWord { get; set; }
            public string Word { get; set; }
            public TrieNode()
            {
                Children = new Dictionary<char, TrieNode>();
                IsEndOfWord = false;
                Word = null;
            }
        }

        public class Trie
        {
            public TrieNode Root { get; set; }
            public Trie()
            {
                Root = new TrieNode();
            }
            public void Insert(string word)
            {
                var current = Root;
                foreach (var ch in word)
                {
                    if (!current.Children.ContainsKey(ch))
                    {
                        current.Children[ch] = new TrieNode();
                    }
                    current = current.Children[ch];
                }
                current.IsEndOfWord = true;
                current.Word = word; // Store the complete word at the end node
            }
        }
    }
}
