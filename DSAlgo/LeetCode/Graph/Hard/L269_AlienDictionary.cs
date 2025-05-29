using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Hard
{
    internal class L269_AlienDictionary
    {
        // This problem is about finding the order of characters in an alien language based on given words
        // The problem can be solved using Topological Sorting on a directed graph
        // Time Complexity: O(V + E) where V is the number of vertices (characters) and E is the number of edges (comparisons)
        // Space Complexity: O(V + E) for the graph representation and in-degree array

        public string AlienOrder(string[] words)
        {
            // Check for edge cases
            // If the input is null or empty, return an empty string
            if (words == null || words.Length == 0)
            {
                return "";
            }
            // Initialize the graph and in-degree dictionary
            var graph = new Dictionary<char, HashSet<char>>();// Graph to store the directed edges between characters
            var inDegree = new Dictionary<char, int>(); // In-degree dictionary to keep track of the number of incoming edges for each character
            BuildGraph(words, graph, inDegree);

            return TopologicalSort(graph, inDegree);
        }

        private void BuildGraph(string[] words, Dictionary<char, HashSet<char>> graph, Dictionary<char, int> inDegree)
        {
            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    if (!graph.ContainsKey(c))
                    {
                        graph[c] = new HashSet<char>();
                        inDegree[c] = 0;
                    }
                }
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                var word1 = words[i];
                var word2 = words[i + 1];
                int minLength = Math.Min(word1.Length, word2.Length);

                for (int j = 0; j < minLength; j++)
                {
                    if (word1[j] != word2[j])
                    {
                        if (!graph[word1[j]].Contains(word2[j]))
                        {
                            graph[word1[j]].Add(word2[j]);
                            inDegree[word2[j]]++;
                        }
                        break;
                    }
                }
            }
        }

        private string TopologicalSort(Dictionary<char, HashSet<char>> graph, Dictionary<char, int> inDegree)
        {
            var queue = new Queue<char>();
            foreach (var kvp in inDegree)
            {
                if (kvp.Value == 0)
                {
                    queue.Enqueue(kvp.Key);
                }
            }

            var result = new StringBuilder();
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Append(current);

                foreach (var neighbor in graph[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result.Length == inDegree.Count ? result.ToString() : ""; // If not all characters are included, return empty string
        } 

        
    }
}
