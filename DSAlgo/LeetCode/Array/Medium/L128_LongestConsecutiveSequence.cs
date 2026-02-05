using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    using System;
    internal class L128_LongestConsecutiveSequence
    {
        // This problem is to find the length of the longest consecutive elements sequence in an unsorted array of integers.
        // The approach is to use a HashSet to store the unique elements and then iterate through the set to find the longest sequence.
        // Time Complexity: O(n) where n is the number of elements in the input array
        // Space Complexity: O(n) for storing the unique elements in the HashSet
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> numSet = new HashSet<int>(nums);
            int longestStreak = 0;
            foreach (int num in numSet)
            {
                // Check if it's the start of a sequence
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;
                    // Count the length of the sequence
                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum++;
                        currentStreak++;
                    }
                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }
            return longestStreak;
        }

        // Brute force approach is to sort the array and then iterate through it to find the longest consecutive sequence
        // Time Complexity: O(n log n) due to sorting
        // Space Complexity: O(1) if we sort in place, otherwise O(n) for the sorted array
        public int LongestConsecutiveBruteForce(int[] nums)
        {
            if (nums.Length == 0) return 0;
            Array.Sort(nums);
            int longestStreak = 1;
            int currentStreak = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                // Skip duplicates
                if (nums[i] == nums[i - 1]) continue;
                if (nums[i] == nums[i - 1] + 1)
                {
                    currentStreak++;
                }
                else
                {
                    longestStreak = Math.Max(longestStreak, currentStreak);
                    currentStreak = 1;
                }
            }
            return Math.Max(longestStreak, currentStreak);
        }
    }
}
