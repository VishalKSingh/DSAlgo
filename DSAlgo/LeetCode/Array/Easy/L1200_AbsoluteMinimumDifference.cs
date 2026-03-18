using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Easy
{
    using System;
    internal class L1200_AbsoluteMinimumDifference
    {
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            if (arr == null)
            {
                return new List<IList<int>>();
            }

            Array.Sort(arr); // Sort the array to ensure adjacent elements are compared for minimum difference
            List<IList<int>> result = new List<IList<int>>();
            int minDiff = int.MaxValue;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int diff = arr[i + 1] - arr[i]; // Calculate the absolute difference between adjacent elements
                // Update the minimum difference and reset the result list if a smaller difference is found
                if (diff < minDiff)
                {
                    minDiff = diff;
                    result.Clear();
                }
                // If the current difference is equal to the minimum difference, add the pair to the result list
                if (diff == minDiff)
                {
                    result.Add(new List<int> { arr[i], arr[i + 1] });
                }
            }
            return result;
        }
    }
}
