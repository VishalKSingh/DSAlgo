using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Design
{
    internal class L460_LFUCache
    {
        // This problem is about designing a data structure for a Least Frequently Used (LFU) cache. The LFU cache should support get and put operations in O(1) time complexity.
        // We can use a combination of a dictionary and a doubly linked list to achieve O(1) time complexity for both operations. The dictionary will store the key and the corresponding node in the linked list, while the linked list will maintain the order of usage based on frequency, with the least frequently used item at the head and the most frequently used item at the tail.
        // Time Complexity: O(1) for both get and put operations.
        // Space Complexity: O(capacity) for storing the cache items.

        private int _capacity;
        private Dictionary<int, LinkedListNode<(int key, int value, int frequency)>> _cache; // Dictionary to store key and corresponding node in the linked list
        private Dictionary<int, LinkedList<(int key, int value, int frequency)>> _frequencyList; // Dictionary to maintain linked lists for each frequency

        public L460_LFUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, LinkedListNode<(int key, int value, int frequency)>>();
            _frequencyList = new Dictionary<int, LinkedList<(int key, int value, int frequency)>>();
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
            {
                return -1; // Key not found
            }
            var node = _cache[key];
            int frequency = node.Value.frequency;
            // Remove the node from the current frequency list
            _frequencyList[frequency].Remove(node);
            // If the current frequency list is empty, remove it from the dictionary
            if (_frequencyList[frequency].Count == 0)
            {
                _frequencyList.Remove(frequency);
            }
            // Increment the frequency and add the node to the new frequency list
            frequency++;
            if (!_frequencyList.ContainsKey(frequency))
            {
                _frequencyList[frequency] = new LinkedList<(int key, int value, int frequency)>();
            }
            var newNode = new LinkedListNode<(int key, int value, int frequency)>((key, node.Value.value, frequency));
            _frequencyList[frequency].AddFirst(newNode);
            _cache[key] = newNode; // Update cache with the new node
            return node.Value.value; // Return the value associated with the key
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0)
            {
                return; // Cannot add items to a cache with zero capacity
            }
            if (_cache.ContainsKey(key))
            {
                // If the key already exists, update the value and frequency
                var node = _cache[key];
                int frequency = node.Value.frequency;
                // Remove the node from the current frequency list
                _frequencyList[frequency].Remove(node);
                // If the current frequency list is empty, remove it from the dictionary
                if (_frequencyList[frequency].Count == 0)
                {
                    _frequencyList.Remove(frequency);
                }
                // Increment the frequency and add the node to the new frequency list
                frequency++;
                if (!_frequencyList.ContainsKey(frequency))
                {
                    _frequencyList[frequency] = new LinkedList<(int key, int value, int frequency)>();
                }
                var newNode = new LinkedListNode<(int key, int value, int frequency)>((key, value, frequency));
                _frequencyList[frequency].AddFirst(newNode);
                _cache[key] = newNode; // Update cache with the new node
            }
            else
            {
                // If the key does not exist, add a new node to the cache
                if (_cache.Count >= _capacity)
                {
                    // If the cache exceeds capacity, remove the least frequently used item (head of the lowest frequency list)
                    int minFrequency = _frequencyList.Keys.Min(); // Get the minimum frequency
                    var lfuNode = _frequencyList[minFrequency].Last; // Get the least frequently used node
                    _frequencyList[minFrequency].RemoveLast(); // Remove it from the linked list
                    if (_frequencyList[minFrequency].Count == 0)
                    {
                        _frequencyList.Remove(minFrequency); // Remove the frequency list if it's empty
                    }
                    _cache.Remove(lfuNode.Value.key); // Remove it from the cache
                }
                var newNode = new LinkedListNode<(int key, int value, int frequency)>((key, value, 1));
                if (!_frequencyList.ContainsKey(1))
                {
                    _frequencyList[1] = new LinkedList<(int key, int value, int frequency)>();
                }
                _frequencyList[1].AddFirst(newNode); // Add to frequency list for frequency 1
            }
        }
    }
}
