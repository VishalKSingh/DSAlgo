using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L692_TopKFrequentwords
    {
        public L692_TopKFrequentwords() { }

        // This problem is about finding the top k frequent words from a list of words
        // We can solve this problem by counting the frequency of each word and then using a min-heap (priority queue) to keep track of the top k frequent words
        // Time Complexity: O(N log k) where N is the number of words and k is the number of top frequent words we want to return
        // Space Complexity: O(N) for the frequency map and the min-heap
        public L692_TopKFrequentwords(string[] words, int k)
        {
            var frequencyMap = new Dictionary<string, int>();
            // Count the frequency of each word
            foreach (var word in words)
            {
                if (!frequencyMap.ContainsKey(word))
                {
                    frequencyMap[word] = 0;
                }
                frequencyMap[word]++;
            }
            // Use a min-heap (priority queue) to keep track of the top k frequent words
            var minHeap = new SortedSet<(int Frequency, string Word)>();
            foreach (var entry in frequencyMap)
            {
                minHeap.Add((entry.Value, entry.Key));
                if (minHeap.Count > k)
                {
                    minHeap.Remove(minHeap.Min); // Remove the least frequent word
                }
            }
            // Extract the top k frequent words from the min-heap
            var result = new List<string>();
            while (minHeap.Count > 0)
            {
                result.Add(minHeap.Min.Word);
                minHeap.Remove(minHeap.Min);
            }
            result.Reverse(); // Reverse to get the correct order
        }
    }
}
