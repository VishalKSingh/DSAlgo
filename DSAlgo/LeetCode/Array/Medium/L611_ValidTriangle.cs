using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    using System;
    internal class L611_ValidTriangleNumber
    {
        // This problem is to find the number of triplets in an array that can form a valid triangle.
        // The approach is to sort the array and use a two-pointer technique to find pairs that can form a triangle with the current element.
        // Time Complexity: O(n^2) where n is the number of elements in the array
        // Space Complexity: O(1) for the result count, but O(n) for the sorting step

        public int TriangleNumber(int[] nums)
        {
            if (nums == null || nums.Length < 3)
                return 0;

            Array.Sort(nums);
            int n = nums.Length;
            int count = 0;
            for (int k = n - 1; k >= 2; k--)
            {
                int left = 0, right = k - 1;
                while (left < right)
                {
                    if (nums[left] + nums[right] > nums[k])
                    {
                        count += (right - left);
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }
            return count;
        }

        // Helper method to check if three sides can form a valid triangle
        public bool IsValidTriangle(int a, int b, int c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                return true;
            }
            return false;
        }

        // Brute-force O(n^3) solution using the IsValidTriangle helper
        public int TriangleNumberBruteForce(int[] nums)
        {
            if (nums == null || nums.Length < 3)
                return 0;
            int n = nums.Length;
            int count = 0;
            // Check all combinations of triplets

            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (IsValidTriangle(nums[i], nums[j], nums[k]))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }



    }
}
