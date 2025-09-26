using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Hard
{
    using System;
    internal class L493_ReversePairs
    {
        // This problem is to count the number of reverse pairs in an array.
        // A reverse pair (i, j) is defined as a pair where i < j and nums[i] > 2 * nums[j].
        // We can solve this problem using a modified merge sort algorithm.

        // Time Complexity: O(n log n) where n is the length of the array
        // Space Complexity: O(n) for the temporary array used in merge sort

        public int ReversePairs(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            return MergeSort(nums, 0, nums.Length - 1);
        }

        private int MergeSort(int[] nums, int left, int right)
        {
            if (left >= right)
                return 0;

            int mid = left + (right - left) / 2;
            int count = MergeSort(nums, left, mid) + MergeSort(nums, mid + 1, right);

            // Count reverse pairs
            int j = mid + 1;
            for (int i = left; i <= mid; i++)
            {
                while (j <= right && nums[i] > 2L * nums[j])
                    j++;
                count += j - (mid + 1);
            }

            // Merge step
            Array.Sort(nums, left, right - left + 1);
            return count;
        }

        // This method is an alternative approach that uses a brute force method.
        // It checks every pair (i, j) where i < j and counts if nums[i] > 2 * nums[j].
        // Time Complexity: O(n^2) where n is the length of the array
        // Space Complexity: O(1) since we are not using any additional space for another array
        public int ReversePairsBruteForce(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > 2L * nums[j])
                        count++;
                }
            }
            return count;
        }

        // This method is an alternative approach that uses a binary search tree to count reverse pairs.
        // It uses a sorted list to keep track of the elements seen so far and counts how many elements are less than or equal to the target.
        // Time Complexity: O(n log n) where n is the length of the array
        // Space Complexity: O(n) for the sorted list used to keep track of elements
        public int ReversePairsBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int count = 0;
            SortedList<long, int> sortedList = new SortedList<long, int>();

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                long target = (long)nums[i] * 2;
                // Count how many elements are less than or equal to target
                count += sortedList.TakeWhile(x => x.Key < target).Sum(x => x.Value);

                // Insert the current number into the sorted list
                if (sortedList.ContainsKey(nums[i]))
                    sortedList[nums[i]]++;
                else
                    sortedList.Add(nums[i], 1);
            }

            return count;
        }

        // This method is an alternative approach that uses a segment tree to count reverse pairs.
        // It builds a segment tree and counts how many elements are in the range that satisfies the reverse pair condition.
        // Time Complexity: O(n log n) where n is the length of the array
        // Space Complexity: O(n) for the segment tree
        public int ReversePairsSegmentTree(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int n = nums.Length;
            int[] sorted = new int[n];
            Array.Copy(nums, sorted, n);
            Array.Sort(sorted);

            // Create a segment tree
            SegmentTree segmentTree = new SegmentTree(sorted);

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                // Count how many elements are less than or equal to nums[i] / 2
                int target = Array.BinarySearch(sorted, nums[i] / 2);
                if (target < 0) target = ~target; // If not found, get the insertion point
                count += segmentTree.Query(0, target - 1);
                segmentTree.Update(nums[i], 1);
            }

            return count;
        }

        // Segment Tree class to support range queries and updates
        // This class is used to maintain the counts of elements in a sorted array.

        private class SegmentTree
        {
            private int[] tree;
            private int[] sorted;

            public SegmentTree(int[] sorted)
            {
                this.sorted = sorted;
                int n = sorted.Length;
                tree = new int[n * 4];
                Build(0, 0, n - 1);
            }

            private void Build(int node, int start, int end)
            {
                if (start == end)
                {
                    tree[node] = 0; // Leaf node
                }
                else
                {
                    int mid = (start + end) / 2;
                    Build(node * 2 + 1, start, mid);
                    Build(node * 2 + 2, mid + 1, end);
                    tree[node] = tree[node * 2 + 1] + tree[node * 2 + 2];
                }
            }

            public void Update(int value, int delta)
            {
                Update(0, 0, sorted.Length - 1, value, delta);
            }

            private void Update(int node, int start, int end, int value, int delta)
            {
                if (start == end)
                {
                    tree[node] += delta; // Update leaf node
                }
                else
                {
                    int mid = (start + end) / 2;
                    if (value <= sorted[mid])
                        Update(node * 2 + 1, start, mid, value, delta);
                    else
                        Update(node * 2 + 2, mid + 1, end, value, delta);
                    tree[node] = tree[node * 2 + 1] + tree[node * 2 + 2];
                }
            }

            public int Query(int left, int right)
            {
                return Query(0, 0, sorted.Length - 1, left, right);
            }
            private int Query(int node, int start, int end, int left, int right)
            {
                if (right < start || end < left)
                    return 0; // No overlap
                if (left <= start && end <= right)
                    return tree[node]; // Total overlap

                // Partial overlap
                int mid = (start + end) / 2;
                int leftSum = Query(node * 2 + 1, start, mid, left, right);
                int rightSum = Query(node * 2 + 2, mid + 1, end, left, right);
                return leftSum + rightSum;
            }

            
        }
    }
}
