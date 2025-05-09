using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.TeamBlind
{
    public class MaximumSubArray_L53
    {
        public int MaximumSubArray(int[] nums)
        {
            int N = nums.Length;
            int sum = 0;
            int maxSum = Int32.MinValue;

            for(int i = 0; i < N; i++)
            {
                sum += nums[i];
                if(sum > maxSum)
                {
                    maxSum = sum;
                }

                if(sum < 0)
                {
                    sum = 0;
                }
            }
            return maxSum;

        }
    }

}
