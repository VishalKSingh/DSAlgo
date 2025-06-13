using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Hard
{
    internal class L42_TrappingRainWater
    {
        // This problem is to calculate the amount of water that can be trapped after raining
        // given an array of non-negative integers representing the height of bars.
        // The approach is to use two pointers to calculate the trapped water.
        // Time Complexity: O(n) where n is the number of elements in the array
        // Space Complexity: O(1) since we are using constant space

        public int Trap(int[] height)
        {
            if (height == null || height.Length == 0) return 0;

            // Two-pointer approach to calculate trapped water
            int left = 0, right = height.Length - 1;
            // Initialize left and right pointers
            int leftMax = 0, rightMax = 0;
            int waterTrapped = 0;

            while (left < right)
            {
                // Compare the heights at the left and right pointers
                //explanation: We will always move the pointer with the smaller height

                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        waterTrapped += leftMax - height[left]; // Calculate trapped water at the left pointer
                    }
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        waterTrapped += rightMax - height[right];
                    }
                    right--;
                }
            }

            return waterTrapped;
        }

        // explain above code in detail
        // The code uses a two-pointer approach to calculate the amount of water that can be trapped after raining.
        // It initializes two pointers, left and right, at the beginning and end of the height array, respectively.
        // It also initializes two variables, leftMax and rightMax, to keep track of the maximum heights encountered from the left and right sides.
        // The while loop continues until the left pointer is less than the right pointer.
        // Inside the loop, it compares the heights at the left and right pointers.
        // If the height at the left pointer is less than the height at the right pointer, it checks if the current height at the left pointer is greater than or equal to leftMax.
        // If it is, it updates leftMax to the current height.
                // Otherwise, it calculates the trapped water at the left pointer by subtracting the current height from leftMax and adds it to waterTrapped.
                // Then, it increments the left pointer.
                // If the height at the right pointer is less than or equal to the height at the left pointer, it performs similar checks for rightMax and calculates trapped water at the right pointer.
                // Finally, it returns the total amount of water trapped.
            // This approach ensures that we always move the pointer with the smaller height, which helps in calculating the trapped water efficiently.

        // brute force approach
        // This approach uses a nested loop to calculate the trapped water at each index.
        // Time Complexity: O(n^2) where n is the number of elements in the array
        // Space Complexity: O(1) since we are using constant space
        public int TrapBruteForce(int[] height)
        {
            if (height == null || height.Length == 0) return 0;

            int n = height.Length;
            int waterTrapped = 0;

            for (int i = 0; i < n; i++)
            {
                // Find the maximum height to the left of the current index
                int leftMax = 0;
                for (int j = 0; j < i; j++)
                {
                    leftMax = Math.Max(leftMax, height[j]);
                }

                // Find the maximum height to the right of the current index
                int rightMax = 0;
                for (int j = i + 1; j < n; j++)
                {
                    rightMax = Math.Max(rightMax, height[j]);
                }

                // Calculate trapped water at the current index
                waterTrapped += Math.Max(0, Math.Min(leftMax, rightMax) - height[i]);
            }

            return waterTrapped;
        }
    }
}
