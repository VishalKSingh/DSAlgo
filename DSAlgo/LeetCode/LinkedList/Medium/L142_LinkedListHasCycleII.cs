using DSAlgo.LeetCode.Recursion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList.Medium
{
    internal class L142_LinkedListHasCycleII
    {
        // 142. Linked List Cycle II
        // Use Floyd's Tortoise and Hare algorithm to detect the cycle and find the entry point of the cycle.
        // Time Complexity: O(n), where n is the number of nodes in the linked list.
        // Space Complexity: O(1), as we are using only a constant amount of space.
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null) return null;
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next; // Move slow by 1
                fast = fast.next.next; // Move fast by 2
                if (slow == fast) // A cycle is detected
                {
                    // To find the entry point of the cycle, reset one pointer to the head and move both pointers at the same speed.
                    ListNode entry = head;
                    while (entry != slow)
                    {
                        entry = entry.next;
                        slow = slow.next;
                    }
                    return entry; // The node where the cycle begins
                }
            }
            return null; // No cycle found
        }
    }
}
