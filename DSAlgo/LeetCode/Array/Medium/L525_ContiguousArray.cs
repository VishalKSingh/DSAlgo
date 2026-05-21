using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L525_ContiguousArray
    {
        // This problem is to find the maximum length of a contiguous subarray with equal number of 0 and 1 in a binary array.
        // The approach is to use a hash map to store the cumulative sum and its first occurrence index.
        // We can treat 0 as -1 and 1 as +1, so we are looking for the longest subarray with cumulative sum of 0.
        // Time Complexity: O(n) where n is the number of elements in the input array
        // Space Complexity: O(n) for the hash map

        public int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map[0] = -1; // Initialize the map with cumulative sum 0 at index -1
            int maxLength = 0;
            int sum = 0; // Cumulative sum where we treat 0 as -1 and 1 as +1
            for (int i = 0; i < nums.Length; i++)
            {
                sum += (nums[i] == 0) ? -1 : 1; // Treat 0 as -1 and 1 as +1
                if (map.ContainsKey(sum))
                {
                    // If the cumulative sum has been seen before, calculate the length of the subarray
                    maxLength = Math.Max(maxLength, i - map[sum]);
                }
                else
                {
                    // Otherwise, store the index of the first occurrence of this cumulative sum
                    map[sum] = i;
                }
            }
            return maxLength;
        }
    }
}
