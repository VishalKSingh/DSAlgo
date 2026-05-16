using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Hard
{
    internal class L127_WordLadder
    {
        // This problem is about finding the shortest transformation sequence from a start word to an end word, where each transformation can only change one letter and must be a valid word in the given dictionary
        // The problem can be solved using Breadth-First Search (BFS) to explore all possible transformations level by level
        // Time Complexity: O(N * M^2) where N is the number of words in the dictionary and M is the length of each word (for generating transformations)
        // Space Complexity: O(N) for the queue and visited set

        public L127_WordLadder() { }

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var wordSet = new HashSet<string>(wordList); // Convert the word list to a hash set for O(1) lookups
            if (!wordSet.Contains(endWord)) return 0; // If the end word is not in the dictionary, return 0
            
            var queue = new Queue<string>();// Queue for BFS
            queue.Enqueue(beginWord);
            
            var visited = new HashSet<string> { beginWord }; // Set to keep track of visited words to avoid cycles
            int ladderLength = 1; // Start with length 1 for the beginWord
            
            while (queue.Count > 0)
            {
                int levelSize = queue.Count; // Number of elements at the current level
                for (int i = 0; i < levelSize; i++)
                {
                    var currentWord = queue.Dequeue();
                    if (currentWord == endWord) return ladderLength; // If we reached the end word, return the ladder length
                    // Generate all possible transformations of the current word
                    for (int j = 0; j < currentWord.Length; j++)
                    {
                        char[] charArray = currentWord.ToCharArray();
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            charArray[j] = c;
                            var nextWord = new string(charArray);
                            if (wordSet.Contains(nextWord) && !visited.Contains(nextWord))
                            {
                                visited.Add(nextWord); // Mark the next word as visited
                                queue.Enqueue(nextWord); // Add the next word to the queue for further exploration
                            }
                        }
                    }
                }
                ladderLength++; // Increment ladder length after exploring one level
            }
            return 0; // If we exhaust the queue without finding the end word, return 0
        }
    }
}
