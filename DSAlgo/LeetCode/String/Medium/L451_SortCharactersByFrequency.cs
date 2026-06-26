using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L451_SortCharactersByFrequency
    {
        // Time Complexity: O(n log n) where n is the length of the input string
        // Space Complexity: O(n) for the frequency map and the result string
        public string FrequencySort(string s)
        {
            // Count the frequency of each character
            var frequencyMap = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!frequencyMap.ContainsKey(c))
                {
                    frequencyMap[c] = 0;
                }
                frequencyMap[c]++;
            }
            // Sort characters by frequency in descending order
            var sortedChars = frequencyMap.OrderByDescending(kv => kv.Value).Select(kv => kv.Key);
            // Build the result string based on sorted characters and their frequencies
            var result = new StringBuilder();
            foreach (var c in sortedChars)
            {
                result.Append(new string(c, frequencyMap[c]));
            }
            return result.ToString();
        }

        // The above solution uses a frequency map to count the occurrences of each character in the input string
        // Then it sorts the characters based on their frequencies in descending order
        // Finally, it builds the result string by appending each character the number of times it appears in the input string

        // using a priority queue (max-heap) to sort characters by frequency
        // Time Complexity: O(n log k) where n is the length of the input string and k is the number of unique characters
        // Space Complexity: O(n) for the frequency map and the result string

        public string FrequencySortUsingHeap(string s)
        {
            // Count the frequency of each character
            var frequencyMap = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!frequencyMap.ContainsKey(c))
                {
                    frequencyMap[c] = 0;
                }
                frequencyMap[c]++;
            }
            // Use a max-heap to sort characters by frequency
            var maxHeap = new PriorityQueue<char, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            foreach (var kvp in frequencyMap)
            {
                maxHeap.Enqueue(kvp.Key, kvp.Value);
            }
            // Build the result string based on sorted characters and their frequencies
            var result = new StringBuilder();
            while (maxHeap.Count > 0)
            {
                var c = maxHeap.Dequeue();
                result.Append(new string(c, frequencyMap[c]));
            }
            return result.ToString();
        }
    }
}
