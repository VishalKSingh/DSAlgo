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
            Dictionary<int, int> map = new Dictionary<int, int>(); // Key: cumulative sum, Value: frequency of that cumulative sum
            map[0] = 1; // Initialize with sum 0
            int count = 0;
            int sum = 0;

            foreach (int num in nums)
            {
                sum += num; // Update the cumulative sum

                // Check if there is a subarray with sum equal to k
                // in order to get sum of a subarray to be equal to k, the cumulative sum at the end of that subarray should be equal to (current cumulative sum - k)
                if (map.ContainsKey(sum - k))
                {
                    count += map[sum - k]; // Increment count by the frequency of the cumulative sum that equals (current sum - k)
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


        //Optimized version
        // using two pointers to find the subarrays with sum equal to k
        // This approach is not efficient for all cases, but it can be used when the array contains only positive numbers


        public int SubarraySumTwoPointers(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;
            int left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right]; // Update the cumulative sum
                // Move the left pointer to maintain the sum less than or equal to k
                while (sum > k && left <= right)
                {
                    sum -= nums[left]; // Remove the leftmost element from the sum
                    left++; // Move the left pointer to the right
                }
                // If the current sum is equal to k, increment the count
                if (sum == k)
                {
                    count++;
                }
            }
            return count;

        }
    }
}
