using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    using System;
    internal class L56_MergeIntervals
    {
        // This problem is to merge overlapping intervals in a list of intervals.
        // The approach is to first sort the intervals based on their start time, and then iterate through the sorted intervals to merge them if they overlap.

        // Time Complexity: O(n log n) due to sorting, where n is the number of intervals
        // Space Complexity: O(n) in the worst case if all intervals are merged into one, otherwise O(1) for in-place merging
        public L56_MergeIntervals() { }
        public int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return new int[0][];
            // Sort intervals based on the start time
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            List<int[]> merged = new List<int[]>();

            int[] currentInterval = intervals[0]; // 
            merged.Add(currentInterval);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (currentInterval[1] >= intervals[i][0]) // Check for overlap
                {
                    currentInterval[1] = Math.Max(currentInterval[1], intervals[i][1]); // Merge intervals
                }
                else
                {
                    currentInterval = intervals[i]; // Move to the next interval
                    merged.Add(currentInterval);
                }
            }
            return merged.ToArray();
        }

        // Brute Force Approach (not recommended due to higher time complexity)
        public int[][] MergeBruteForce(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return new int[0][];
            List<int[]> merged = new List<int[]>();
            foreach (var interval in intervals)
            {
                bool mergedFlag = false;
                for (int i = 0; i < merged.Count; i++)
                {
                    if (merged[i][1] >= interval[0] && merged[i][0] <= interval[1]) // Check for overlap
                    {
                        merged[i][0] = Math.Min(merged[i][0], interval[0]);
                        merged[i][1] = Math.Max(merged[i][1], interval[1]);
                        mergedFlag = true;
                        break;
                    }
                }
                if (!mergedFlag)
                {
                    merged.Add(interval);
                }
            }
            return merged.ToArray();
        }
    }
}
