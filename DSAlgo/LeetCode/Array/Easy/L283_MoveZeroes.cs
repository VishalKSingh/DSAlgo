using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L283_MoveZeroes
    {
        // This problem is to move all zeroes in an array to the end while maintaining the order of non-zero elements.
        // The approach is to use a two-pointer technique to swap non-zero elements with zeroes.
        // Time Complexity: O(n) where n is the length of the input array
        // Space Complexity: O(1) since we are modifying the array in place

        public void MoveZeroes(int[] nums)
        {
            int lastNonZeroIndex = 0; // Pointer for the position of the last non-zero element

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[lastNonZeroIndex] = nums[i]; // Move non-zero element to the last non-zero position
                    lastNonZeroIndex++;
                }
            }

            // Fill the remaining positions with zeroes
            for (int i = lastNonZeroIndex; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}
