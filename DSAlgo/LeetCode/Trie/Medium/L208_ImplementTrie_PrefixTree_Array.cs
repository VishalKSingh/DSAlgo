using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Trie.Medium
{
    internal class L208_ImplementTrie_PrefixTree_Array
    {
        // Alternative implementation using array[26] instead of Dictionary
        // More memory efficient for lowercase letters a-z

        private class TrieNode
        {
            public TrieNode[] Children { get; set; }
            public bool IsEndOfWord { get; set; }

            public TrieNode()
            {
                Children = new TrieNode[26]; // Array for 'a' to 'z'
                IsEndOfWord = false;
            }
        }

        private TrieNode root;

        public L208_ImplementTrie_PrefixTree_Array()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                int index = c - 'a'; // Convert character to index (0-25)
                if (node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }
                node = node.Children[index];
            }
            node.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                if (node.Children[index] == null)
                {
                    return false;
                }
                node = node.Children[index];
            }
            return node.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode node = root;
            foreach (char c in prefix)
            {
                int index = c - 'a';
                if (node.Children[index] == null)
                {
                    return false;
                }
                node = node.Children[index];
            }
            return true;
        }
    }
}
