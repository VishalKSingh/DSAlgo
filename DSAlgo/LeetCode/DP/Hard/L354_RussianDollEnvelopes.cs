namespace DSAlgo.LeetCode.DP.Hard
{
    using System;
    public class L354_RussianDollEnvelopes
    {
        // This problem is about finding the maximum number of envelopes you can Russian doll (put one inside the other)
        public int MaxEnvelopes(int[][] envelopes)
        {
            // Sort the envelopes by width in ascending order, and if widths are the same, sort by height in descending order
            Array.Sort(envelopes, (a, b) =>
            {
                if (a[0] == b[0])
                {
                    return b[1].CompareTo(a[1]); // Sort by height in descending order if widths are the same
                }
                return a[0].CompareTo(b[0]); // Sort by width in ascending order
            });
            // Extract the heights of the sorted envelopes
            int[] heights = new int[envelopes.Length];
            for (int i = 0; i < envelopes.Length; i++)
            {
                heights[i] = envelopes[i][1];
            }
            // Find the length of the longest increasing subsequence of heights
            return LengthOfLIS(heights);
        }

        private int LengthOfLIS(int[] nums)
        {
            List<int> lis = new List<int>();
            foreach (int num in nums)
            {
                int index = lis.BinarySearch(num);
                if (index < 0) index = ~index;
                if (index < lis.Count)
                {
                    lis[index] = num;
                }
                else
                {
                    lis.Add(num);
                }
            }
            return lis.Count;
        }
    }
}