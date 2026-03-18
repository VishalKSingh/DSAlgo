using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    internal class L977_SquaresofaSortedArray
    {
        public L977_SquaresofaSortedArray() { }
        public int[] SortedSquares(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            int left = 0, right = n - 1;
            for (int i = n - 1; i >= 0; i--)
            {
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    result[i] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    result[i] = nums[right] * nums[right];
                    right--;
                }
            }
            return result;
        }
    }
}
