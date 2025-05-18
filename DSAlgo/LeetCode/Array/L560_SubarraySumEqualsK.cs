using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L560_SubarraySumEqualsK
    {
        public L560_SubarraySumEqualsK()
        {
            // This problem is about finding the number of continuous subarrays that sum to a given value k
            // The solution uses a hash map to store the cumulative sum and its frequency
            // Time Complexity: O(n)
            // Space Complexity: O(n)

            int[] nums = { 1, 1, 1 };
            int k = 2;
            int result = SubarraySum(nums, k);
            Console.WriteLine($"Number of subarrays with sum {k}: {result}");
            Console.WriteLine(result);

        }

        public int SubarraySum(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            map[0] = 1; // Initialize with sum 0
            int count = 0;
            int sum = 0;

            foreach (int num in nums)
            {
                sum += num; // Update the cumulative sum

                // Check if there is a subarray with sum equal to k
                if (map.ContainsKey(sum - k))
                {
                    count += map[sum - k];
                }

                // Update the frequency of the cumulative sum
                if (map.ContainsKey(sum))
                {
                    map[sum]++;
                }
                else
                {
                    map[sum] = 1;
                }
            }

            return count;
        }

        // The above solution uses a hash map to store the cumulative sum and its frequency
        // This allows us to find the number of subarrays with sum equal to k in O(1) time
        // The overall time complexity is O(n) and space complexity is O(n)
        // The brute force solution is to use two nested loops to check all subarrays
        // This is a simple solution but it is not efficient for large arrays
        // This is a brute force solution
        // Time Complexity: O(n^2)
        // Space Complexity: O(1)
        // public int SubarraySum(int[] nums, int k)
        // {
        //     int count = 0;
        //     for (int i = 0; i < nums.Length; i++)
        //     {
        //         int sum = 0;
        //         for (int j = i; j < nums.Length; j++)
        //         {
        //             sum += nums[j];
            
        //             if (sum == k)
        //             {
        //                 count++;
        //             }
        //         }
        //     }
        //     return count;
        // }
        // The brute force solution uses two nested loops to check all subarrays
        // This is a simple solution but it is not efficient for large arrays
        // The time complexity is O(n^2) and space complexity is O(1)
        // The above solution uses a hash map to store the cumulative sum and its frequency
        // This allows us to find the number of subarrays with sum equal to k in O(1) time
        // The overall time complexity is O(n) and space complexity is O(n)
        // The hash map stores the cumulative sum and its frequency
        // The cumulative sum is the sum of all elements from the start of the array to the current index
        // The frequency is the number of times the cumulative sum has occurred
        // The hash map is used to check if there is a subarray with sum equal to k
        // The cumulative sum is updated as we iterate through the array
        // The frequency of the cumulative sum is updated in the hash map
        // The count is incremented if there is a subarray with sum equal to k
        // The final count is returned as the result



    }
}
