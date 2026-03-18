using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L347_TopKFrequentElement
    {
        public L347_TopKFrequentElement() { }

        // Use a min-heap to keep track of the top k elements
        // The heap will store pairs of (number, frequency) and will be ordered by frequency
        // Time Complexity: O(n log k) where n is the number of elements in the input array and k is the number of top frequent elements to return
        // Space Complexity: O(n) for the frequency map and O(k) for the heap
        public L347_TopKFrequentElement(int[] nums, int k)
        {
            var frequencyMap = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (!frequencyMap.ContainsKey(num))
                    frequencyMap[num] = 0;
                frequencyMap[num]++;
            }

            // PriorityQueue is a min-heap by default, so we will store the frequency as the priority and the number as the value
            var minHeap = new PriorityQueue<int, int>();
            foreach (var kvp in frequencyMap)
            {
                minHeap.Enqueue(kvp.Key, kvp.Value);
                if (minHeap.Count > k)
                    minHeap.Dequeue();
            }
            var result = new List<int>();
            while (minHeap.Count > 0)
                result.Add(minHeap.Dequeue());
            result.Reverse(); // Reverse to get the correct order
        }

        // optimized approach using bucket sort




    }
}
