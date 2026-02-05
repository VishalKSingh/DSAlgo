using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class LongestSubarrayWithSumK
    {
        public static int GetLongestSubarray(int[] nums, int k)
        {
            // Dictionary stores <PrefixSum, FirstOccurringIndex>
            var map = new Dictionary<long, int>();
            long prefixSum = 0;
            int maxLength = 0;

            // Base case: prefix sum of 0 at index -1
            map.Add(0, -1);

            for (int i = 0; i < nums.Length; i++)
            {
                prefixSum += nums[i];

                // Target sum to find: Sj = Si - k
                long target = prefixSum - k;

                // If target exists in the map, we found a subarray with sum k.
                if (map.ContainsKey(target))
                {
                    int length = i - map[target];
                    maxLength = Math.Max(maxLength, length);
                }

                // Only add the prefix sum if it doesn't already exist.
                // We want to keep the EARLIEST index to maximize (i - map[target]).
                if (!map.ContainsKey(prefixSum))
                {
                    map.Add(prefixSum, i);
                }
            }

            return maxLength;
        }
    }
}
