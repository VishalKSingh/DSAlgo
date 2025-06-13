using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Hard
{
    internal class L239_SlidingWindowMaximum
    {
        // This problem is to find the maximum value in each sliding window of size k in an array.
        // The approach is to use a deque (double-ended queue) to keep track of the indices of the maximum elements.
        // Time Complexity: O(n) where n is the number of elements in the array
        // Space Complexity: O(k) for the deque

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 0) return new int[0];

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            Deque<int> deque = new Deque<int>();

            for (int i = 0; i < n; i++)
            {
                // Remove indices that are out of the current window
                if (deque.Count > 0 && deque.Peek() < i - k + 1)
                {
                    deque.Dequeue(); // Remove the front element if it is out of the window
                }

                // Remove indices of elements that are less than the current element
                while (deque.Count > 0 && nums[deque.PeekLast()] < nums[i])
                {
                    deque.DequeueLast(); // Remove elements from the back that are less than the current element
                }

                // Add the current index to the deque
                deque.Enqueue(i);

                // If we have filled the first window, add the maximum to the result
                if (i >= k - 1)
                {
                    result[i - k + 1] = nums[deque.Peek()]; // The front of the deque is the index of the maximum element in the current window
                }
            }

            return result;
        }

        // Deque implementation to support the sliding window maximum
        public class Deque<T>
        {
            private LinkedList<T> list = new LinkedList<T>();

            // Adds an element to the end of the deque
            public void Enqueue(T value)
            {
                list.AddLast(value);
            }

            // Removes the first element from the deque
            public void Dequeue()
            {
                if (list.Count > 0)
                {
                    list.RemoveFirst();
                }
            }

            // Removes the last element from the deque
            public void DequeueLast()
            {
                if (list.Count > 0)
                {
                    list.RemoveLast();
                }
            }
            // Gets the first element of the deque without removing it
            public T Peek()
            {
                return list.First.Value;
            }
            // Gets the last element of the deque without removing it
            public T PeekLast()
            {
                return list.Last.Value;
            }

            public int Count => list.Count;
        }

        // Time Complexity: O(n * k) for the brute force approach
        // Space Complexity: O(1) for the brute force approach, but O(n) for the result array
        public int[] MaxSlidingWindowBruteForce(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 0) return new int[0];
            int n = nums.Length;
            int[] result = new int[n - k + 1]; // Initialize the result array to hold the maximums
            if (k == 1) return nums; // If k is 1, the maximums are the elements themselves
            // Iterate through the array and find the maximum for each sliding window
            for (int i = 0; i <= n - k; i++)
            {
                int max = nums[i];
                for (int j = i + 1; j < i + k; j++)
                {
                    max = Math.Max(max, nums[j]);
                }
                result[i] = max;
            }
            return result;
        }
    }
}
