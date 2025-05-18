using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L238_ProductOfArrayExceptSelf
    {
        // This problem is to find the product of all elements in an array except the current element at each index.
        // Given an array nums of n integers where n > 1, return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
        // Example:
        // Input:  [1,2,3,4]
        // Output: [24,12,8,6]
        // Note: Please solve it without division and in O(n).
        // You must do it in O(n) time complexity and O(1) space complexity (excluding the output array).
        
        // The approach is to use two passes:
        // 1. First pass: Calculate the left product for each index and store it in the result array.
        // 2. Second pass: Calculate the right product for each index and multiply it with the left product stored in the result array.
        // The final result will be the product of left and right products for each index.
        // Time Complexity: O(n)
        // Space Complexity: O(1) for the result array, but O(n) for the left and right product arrays.
        // The overall space complexity is O(n) due to the result array.
        // The result array is initialized with 1s to handle the case when there are zeros in the input array.
        // The left product is calculated by multiplying the previous left product with the current element.
        // The right product is calculated by multiplying the previous right product with the current element.
        // The final result is obtained by multiplying the left and right products for each index.

        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            int[] leftProducts = new int[n];
            int[] rightProducts = new int[n];

            leftProducts[0] = 1;
            for (int i = 1; i < n; i++)
            {
                leftProducts[i] = leftProducts[i - 1] * nums[i - 1];
            }

            rightProducts[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                rightProducts[i] = rightProducts[i + 1] * nums[i + 1];
            }

            for (int i = 0; i < n; i++)
            {
                result[i] = leftProducts[i] * rightProducts[i];
            }

            return result;
        }

        // Optimized version without using extra space for left and right products
        // This version uses the result array to store the left products and then calculates the right products in a single pass.
        // The time complexity is still O(n) and the space complexity is O(1) for the left and right product arrays.
        // The result array is used to store the left products in the first pass.
        // In the second pass, we calculate the right products and multiply them with the left products stored in the result array.

        public int[] ProductExceptSelfOptimized(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];

            result[0] = 1;
            for (int i = 1; i < n; i++)
            {
                result[i] = result[i - 1] * nums[i - 1];
            }

            int rightProduct = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] *= rightProduct; // Multiply the left product with the right product
                rightProduct *= nums[i]; // Update the right product for the next iteration 
            }

            return result;
        }
    }
}
