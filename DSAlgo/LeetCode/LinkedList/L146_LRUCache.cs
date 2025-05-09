using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList
{
    public class L146_LRUCache
    {
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

        private Dictionary<int, ListNode> cache;
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

        public int Get(int key)
        {
            if (cache.ContainsKey(key))
            {
                ListNode node = cache[key];
                Remove(node);
                AddToHead(node);
                return node.value;
            }
            return -1; // Not found
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                ListNode node = cache[key];
                Remove(node);
                node.value = value;
                AddToHead(node);
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

        private void Remove(ListNode node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        private void AddToHead(ListNode node)
        {
            node.next = head.next;
            head.next.prev = node;
            head.next = node;
            node.prev = head;
        } 
    }
}
