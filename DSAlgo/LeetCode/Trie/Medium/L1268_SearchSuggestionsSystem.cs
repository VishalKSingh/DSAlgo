using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Trie.Medium
{
    using System;
    internal class L1268_SearchSuggestionsSystem
    {
        // Time Complexity: O(n * m * log(n)) where n is the number of products and m is the average length of the product names. The sorting step takes O(n * log(n)), and for each character in the searchWord, we may need to check all products.
        // Space Complexity: O(n) for storing the sorted products and the result list.
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            Array.Sort(products); // Sort products lexicographically
            var result = new List<IList<string>>();
            var prefix = new StringBuilder();
            foreach (char c in searchWord)
            {
                prefix.Append(c);
                var suggestions = new List<string>();
                foreach (var product in products)
                {
                    if (product.StartsWith(prefix.ToString()))
                    {
                        suggestions.Add(product);
                        if (suggestions.Count == 3) break; // Limit to 3 suggestions
                    }
                }
                result.Add(suggestions);
            }
            return result;
        }

        // Alternative implementation using Trie for better performance
        // Time Complexity: O(n * m + k * log(k)) where n is the number of products, m is the average length of the product names, and k is the number of suggestions for each prefix. Building the Trie takes O(n * m), and retrieving suggestions takes O(k * log(k)) due to sorting.
        // Space Complexity: O(n * m) for storing the Trie and the result list.
        public IList<IList<string>> SuggestedProductsTrie(string[] products, string searchWord)
        {
            Array.Sort(products); // Sort products lexicographically
            var trie = new TrieNode();
            foreach (var product in products)
            {
                Insert(trie, product);
            }
            var result = new List<IList<string>>();
            var prefix = new StringBuilder();
            foreach (char c in searchWord)
            {
                prefix.Append(c);
                var suggestions = Search(trie, prefix.ToString());
                result.Add(suggestions);
            }
            return result;
        } 
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; set; }
            public List<string> Suggestions { get; set; }
            public TrieNode()
            {
                Children = new Dictionary<char, TrieNode>();
                Suggestions = new List<string>();
            }
        }

        public void Insert(TrieNode root, string word)
        {
            var node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
                if (node.Suggestions.Count < 3)
                {
                    node.Suggestions.Add(word);
                }
            }
        }

        public IList<string> Search(TrieNode root, string prefix)
        {
            var node = root;
            foreach (char c in prefix)
            {
                if (!node.Children.ContainsKey(c))
                {
                    return new List<string>();
                }
                node = node.Children[c];
            }
            return node.Suggestions;
        }

    }
}
