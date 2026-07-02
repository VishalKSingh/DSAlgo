using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Trie.Medium
{
    internal class L208_ImplementTrie_PrefixTree
    {
        // Implement a trie with insert, search, and startsWith methods.
        // A trie (pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. There are various applications of this data structure, such as autocomplete and spellchecker.
        // Implement the Trie class:
        // Trie trie = new Trie();
        // void insert(String word) Inserts the string word into the trie.
        // boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
        // boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.

        private class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; }
            public bool IsEndOfWord { get; set; }

            public TrieNode()
            {
                Children = new Dictionary<char, TrieNode>();
                IsEndOfWord = false;
            }
        }

        private TrieNode root;

        public L208_ImplementTrie_PrefixTree()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];// Move to the child node
            }
            node.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return false;
                }
                node = node.Children[c];
            }
            return node.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode node = root;
            foreach (char c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return false;
                }
                node = node.Children[c];
            }
            return true;
        }
    }
}
