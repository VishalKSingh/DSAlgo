using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L763_Partition_Labels
    {
        // This problem is about partitioning a string into as many parts as possible so that each letter appears in at most one part,
        // and returning a list of the sizes of these parts.
        // We can use a dictionary to store the last occurrence of each character in the string,
        // and then iterate through the string to determine the partitions based on these last occurrences.
        // Time Complexity: O(n) where n is the length of the string, because we are traversing the string twice (once to build the last occurrence dictionary and once to determine the partitions).
        // Space Complexity: O(1) because we are using a fixed-size dictionary to store the last occurrence of characters (assuming only lowercase letters).

        public L763_Partition_Labels() { }

        public IList<int> PartitionLabels(string s)
        {
            Dictionary<char, int> lastOccurrence = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                lastOccurrence[s[i]] = i; // Update the last occurrence of each character
            }
            List<int> partitions = new List<int>();
            // We will keep track of the start and end indices of the current partition.
            // The end index will be updated to the farthest last occurrence of any character we encounter in the current partition.
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                end = Math.Max(end, lastOccurrence[s[i]]); // Update the end index to the farthest last occurrence of the current character
                if (i == end) // If we have reached the end of a partition
                {
                    partitions.Add(end - start + 1); // Add the size of the partition to the result list
                    start = i + 1; // Move the start index to the next character
                }
            }
            return partitions;
        }

        // Optimized version using an array instead of a dictionary to store the last occurrence of characters, since we are only dealing with lowercase letters.

        public IList<int> PartitionLabelsOptimized(string s)
        {
            int[] lastOccurrence = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                lastOccurrence[s[i] - 'a'] = i; // Update the last occurrence of each character
            }
            List<int> partitions = new List<int>();
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                end = Math.Max(end, lastOccurrence[s[i] - 'a']); // Update the end index to the farthest last occurrence of the current character
                if (i == end) // If we have reached the end of a partition
                {
                    partitions.Add(end - start + 1); // Add the size of the partition to the result list
                    start = i + 1; // Move the start index to the next character
                }
            }
            return partitions;
        }

    }
}
