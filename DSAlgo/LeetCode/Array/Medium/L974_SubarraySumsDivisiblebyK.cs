using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L974_SubarraySumsDivisiblebyK
    {
        public L974_SubarraySumsDivisiblebyK() { }

        // This problem is about finding the number of subarrays whose sum is divisible by k
        // The idea is to use a frequency map to count the occurrences of cumulative sum remainders when divided by k
        // We iterate through the array and keep track of the cumulative sum. For each cumulative sum, we calculate its remainder when divided by k.
        // If the same remainder has been seen before, it means that the subarray between the previous occurrence and the current index has a sum that is divisible by k.
        // Time Complexity: O(n) where n is the length of the input array
        // Space Complexity: O(k) for the frequency map
        public int SubarraysDivByK(int[] nums, int k)
        {
            var frequencyMap = new Dictionary<int, int>();
            frequencyMap[0] = 1; // There is one way to have a sum of 0 (the empty subarray)
            int count = 0;
            int cumulativeSum = 0;
            foreach (var num in nums)
            {
                cumulativeSum += num;
                int remainder = ((cumulativeSum % k) + k) % k; // Handle negative remainders
                if (frequencyMap.ContainsKey(remainder))
                {
                    count += frequencyMap[remainder];
                    frequencyMap[remainder]++;
                }
                else
                {
                    frequencyMap[remainder] = 1;
                }
            }
            return count;
        }
    }
}
