using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L57_InsertInterval
    {
        public L57_InsertInterval() { }

        // Time complexity
        public static int[][] InsertInterval(int[][] intervals, int[] newInterval)
        {
            var result = new List<int[]>();
            int i = 0, n = intervals.Length;

            // Add all intervals ending before newInterval starts
            while (i < n && intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i]);
                i++;
            }

            // Merge all overlapping intervals to one considering newInterval
            while (i < n && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            result.Add(newInterval);

            // Add all the rest
            while (i < n)
            {
                result.Add(intervals[i]);
                i++;
            }

            return result.ToArray();
        }
    }
}
