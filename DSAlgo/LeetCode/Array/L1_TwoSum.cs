using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L1_TwoSum
    {
            // Time Complexity: O(n)
            // Space Complexity: O(n)
            public int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }
                    map[nums[i]] = i;
                }
                throw new ArgumentException("No two sum solution");
            }

        // The above solution uses a hash map to store the indices of the numbers
        // This allows us to find the complement in O(1) time
        // The overall time complexity is O(n) and space complexity is O(n)
        // The brute force solution is to use two nested loops to check all pairs of numbers
        // This is a simple solution but it is not efficient for large arrays

        // This is a brute force solution
        // Time Complexity: O(n^2)
        // Space Complexity: O(1)
        // public int[] TwoSum(int[] nums, int target)
        // {
        //     for (int i = 0; i < nums.Length; i++)
        //     {
        //         for (int j = i + 1; j < nums.Length; j++)
        //         {
        //             if (nums[i] + nums[j] == target)
        //             {
        //                 return new int[] { i, j };
        //             }
        //         }
        //     }
        //     throw new ArgumentException("No two sum solution");

        // }

        /// <summary>   
        /// 
    }
}
