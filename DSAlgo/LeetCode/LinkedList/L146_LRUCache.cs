using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList
{
    public class L146_LRUCache
    {
        // This problem is about designing a data structure that implements a Least Recently Used (LRU) cache
        // The LRU cache should support get and put operations in O(1) time complexity
        // We can use a combination of a doubly linked list and a hash map to achieve O(1) time complexity for both operations
        // The hash map will store the key and a reference to the corresponding node in the doubly linked list
        public class ListNode
        {
            public int key;
            public int value;
            public ListNode next;
            public ListNode prev;

            public ListNode(int key, int value)
            {
                this.key = key;
                this.value = value;
                this.next = null;
                this.prev = null;
            }
        }

        private Dictionary<int, ListNode> cache; // Hash map to store key and reference to the corresponding node in the doubly linked list
        private int capacity;
        private ListNode head;
        private ListNode tail;

        public L146_LRUCache(int capacity)
        {
            this.capacity = capacity;
            cache = new Dictionary<int, ListNode>();
            head = new ListNode(0, 0);
            tail = new ListNode(0, 0);
            head.next = tail;
            tail.prev = head;
        }

        // The get operation retrieves the value of the key if it exists in the cache, otherwise returns -1
        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                ListNode node = cache[key];
                Remove(node);// Remove the node from its current position
                AddToHead(node); // Move the node to the head of the list to mark it as recently used
                return node.value;
            }
            return -1; // Not found
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                ListNode node = cache[key];
                Remove(node); // Remove the node from its current position
                node.value = value; // Update the value of the node
                AddToHead(node); // Move the node to the head of the list to mark it as recently used
            }
            else
            {
                if (cache.Count >= capacity)
                {
                    cache.Remove(tail.prev.key);
                    Remove(tail.prev);
                }
                ListNode newNode = new ListNode(key, value);
                AddToHead(newNode);
                cache[key] = newNode;
            }
        }

        // The Remove method removes a node from the doubly linked list by bypassing it
        private void Remove(ListNode node)
        {
            node.prev.next = node.next;// Bypass the node to remove it from the list
            node.next.prev = node.prev;// Bypass the node to remove it from the list
        }

        private void AddToHead(ListNode node)
        {
            node.next = head.next; // Insert the node right after the head
            head.next.prev = node; // Update the previous pointer of the old first node to point to the new node
            head.next = node; // Update the next pointer of the head to point to the new node
            node.prev = head; // Update the previous pointer of the new node to point to the head
        } 
    }
}
