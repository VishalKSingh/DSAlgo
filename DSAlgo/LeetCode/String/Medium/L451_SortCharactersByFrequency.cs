using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L451_SortCharactersByFrequency
    {
        public L451_SortCharactersByFrequency() { }
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
    }
}
