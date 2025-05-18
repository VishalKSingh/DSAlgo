using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L11_ContainerWithMostWater
    {
        // This problem is about finding the maximum area of water that can be contained between two lines
        // The two lines are represented by the heights of the bars in the array
        // The area is calculated as the minimum height of the two lines multiplied by the distance between them
        // The two-pointer approach is used to find the maximum area in linear time
        // Time Complexity: O(n) where n is the number of elements in the array
        // Space Complexity: O(1) as we are using only a few variables
        public int MaxArea(int[] height)
        {
            int maxArea = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                // Calculate the area between the two lines
                int area = Math.Min(height[left], height[right]) * (right - left);
                maxArea = Math.Max(maxArea, area);

                // Move the pointer pointing to the shorter line towards the other pointer
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }
    }
}
