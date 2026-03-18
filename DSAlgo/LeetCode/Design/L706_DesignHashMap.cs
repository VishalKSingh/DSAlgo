using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Design
{
    internal class L706_DesignHashMap
    {
        public L706_DesignHashMap() { }

        // This problem is about designing a hash map data structure that supports put, get, and remove operations
        // We can use an array of linked lists to handle collisions in the hash map
        // Time Complexity: O(1) for put, get, and remove operations on average, but O(n) in the worst case when all keys hash to the same index
        // Space Complexity: O(n) where n is the number of key-value pairs stored in the hash map

        private class Node
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node(int key, int value)
            {
                Key = key;
                Value = value;
                Next = null;
            }
        }

        private Dictionary<int, Node> map;

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                map[key].Value = value;
            }
            else
            {
                var node = new Node(key, value);
                map[key] = node;
            }
        }

        public int Get(int key)
        {
            if (map.ContainsKey(key))
            {
                return map[key].Value;
            }
            else
            {
                return -1;
            }
        }

        public void Remove(int key)
        {
            if (map.ContainsKey(key))
            {
                map.Remove(key);
            }
        }

        // optimized version using an array of linked lists to handle collisions

        // We can use a simple hash function to map keys to indices in the array. For example, we can use the modulo operator with a prime number as the size of the array to reduce collisions.
        // We can also implement the linked list to handle collisions by chaining nodes together at each index of the array. Each node will store a key-value pair and a reference to the next node in the chain.
        // This implementation will allow us to handle collisions effectively while maintaining average O(1) time complexity for put, get, and remove operations.




    }
}
