using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L152_MaximumProductSubArray
    {
        // This method calculates the maximum product of a contiguous subarray in an array of integers.
        // It uses a dynamic programming approach to keep track of the maximum and minimum products
        // at each position in the array. The maximum product is updated at each step,
        // and the result is returned at the end.
        // The algorithm handles negative numbers by swapping the maximum and minimum products
        // when a negative number is encountered, as it can turn a large negative product into a large positive product.
        // The final result is the maximum product found during the iteration.
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        public int MaxProduct(int[] nums)
        {
            int maxProduct = nums[0];
            int minProduct = nums[0];
            int result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    // Swap max and min when a negative number is encountered
                    int temp = maxProduct;
                    maxProduct = minProduct;
                    minProduct = temp;
                }

                maxProduct = Math.Max(nums[i], maxProduct * nums[i]);
                minProduct = Math.Min(nums[i], minProduct * nums[i]);

                result = Math.Max(result, maxProduct);
            }

            return result;
        }

        // The algorithm runs in linear time and uses constant space, making it efficient for large arrays.
        // Example:
        // Input: nums = [2,3,-2,4]
        // Output: 6
        // Explanation: The subarray [2,3] has the largest product 6.
        // Example:
        // Input: nums = [-2,0,-1]
        // Output: 0
    }
}
