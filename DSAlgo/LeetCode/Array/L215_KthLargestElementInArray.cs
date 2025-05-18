using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array
{
    public class L215_KthLargestElementInArray
    {
        // This problem is about finding the kth largest element in an unsorted array
        // The Quickselect algorithm is used to find the kth largest element in linear time on average
        // Time Complexity: O(n) on average, O(n^2) in the worst case
        // Space Complexity: O(1)
        public int FindKthLargest(int[] nums, int k)
        {
            // Check if k is valid
            if (k < 1 || k > nums.Length)
                throw new ArgumentException("k is out of bounds");
            // Call the QuickSelect function to find the kth largest element
            // The kth largest element is the (n-k)th smallest element
            // where n is the length of the array
            // So we call QuickSelect with k = n - k
            // This is because QuickSelect finds the kth smallest element

            return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
        }

        private int QuickSelect(int[] nums, int left, int right, int k)
        {
            if (left == right)
                return nums[left];

            Random random = new Random();
            int pivotIndex = left + random.Next(right - left);

            pivotIndex = Partition(nums, left, right, pivotIndex);

            if (k == pivotIndex)
                return nums[k];
            else if (k < pivotIndex)
                return QuickSelect(nums, left, pivotIndex - 1, k);
            else
                return QuickSelect(nums, pivotIndex + 1, right, k);
        }

        private int Partition(int[] nums, int left, int right, int pivotIndex)
        {
            int pivotValue = nums[pivotIndex];
            Swap(nums, pivotIndex, right);
            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (nums[i] < pivotValue)
                {
                    Swap(nums, storeIndex, i);
                    storeIndex++;
                }
            }
            Swap(nums, storeIndex, right);
            return storeIndex;
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        // The above solution uses the Quickselect algorithm to find the kth largest element
        // The Quickselect algorithm is a selection algorithm to find the kth smallest or largest element in an unordered list  
        // It is related to the quicksort sorting algorithm
        // The Quickselect algorithm works by selecting a pivot element and partitioning the array into two parts
        // The elements less than the pivot and the elements greater than the pivot
        // The pivot is then in its final position
        // If the pivot index is equal to k, we have found the kth largest element
        // If the pivot index is greater than k, we search in the left part of the array
        // If the pivot index is less than k, we search in the right part of the array
        // The average time complexity of the Quickselect algorithm is O(n)
        // The worst-case time complexity is O(n^2) but this is rare
        // The space complexity is O(1) as we are using only a few variables
        
       
        public int FindKthLargestUsingPriorityQueue(int[] nums, int k)
        {
            // Check if k is valid
            if (k < 1 || k > nums.Length)
                throw new ArgumentException("k is out of bounds");

            // Create a min-heap (priority queue) to store the k largest elements
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

            // Iterate through the array
            foreach (int num in nums)
            {
                // Add the current number to the min-heap
                minHeap.Enqueue(num, num);

                // If the size of the min-heap exceeds k, remove the smallest element
                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            // The root of the min-heap is the kth largest element
            return minHeap.Peek();
        }
    
    }
}
