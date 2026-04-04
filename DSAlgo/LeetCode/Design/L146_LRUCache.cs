namespace DSAlgo.LeetCode.Design
{
    internal class L146_LRUCache
    {
        // This problem is about designing a data structure for a Least Recently Used (LRU) cache. The LRU cache should support get and put operations in O(1) time complexity.
        // We can use a combination of a dictionary and a doubly linked list to achieve O(1) time complexity for both operations. The dictionary will store the key and the corresponding node in the linked list, while the linked list will maintain the order of usage, with the most recently used item at the head and the least recently used item at the tail.
        // Time Complexity: O(1) for both get and put operations.
        // Space Complexity: O(capacity) for storing the cache items.
        private int _capacity;
        private Dictionary<int, LinkedListNode<(int key, int value)>> _cache; // Dictionary to store key and corresponding node in the linked list
        private LinkedList<(int key, int value)> _lruList; // Doubly linked list to maintain the order of usage
        public L146_LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, LinkedListNode<(int key, int value)>>();
            _lruList = new LinkedList<(int key, int value)>();

        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
            {
                return -1; // Key not found
            }
            var node = _cache[key];
            // Move the accessed node to the head of the linked list to mark it as most recently used
            _lruList.Remove(node);
            _lruList.AddFirst(node);
            return node.Value.value; // Return the value associated with the key
        }

        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key))
            {
                // If the key already exists, update the value and move it to the head of the linked list
                var node = _cache[key];
                node.Value = (key, value); // Update the value
                _lruList.Remove(node);
                _lruList.AddFirst(node);
            }
            else
            {
                // If the key does not exist, add a new node to the head of the linked list
                var newNode = new LinkedListNode<(int key, int value)>((key, value));
                _lruList.AddFirst(newNode);
                _cache[key] = newNode; // Add to cache
                // If the cache exceeds capacity, remove the least recently used item (tail of the linked list)
                if (_cache.Count > _capacity)
                {
                    var lruNode = _lruList.Last; // Get the least recently used node
                    _lruList.RemoveLast(); // Remove it from the linked list
                    _cache.Remove(lruNode.Value.key); // Remove it from the cache
                }
            }

        }


    }
}
