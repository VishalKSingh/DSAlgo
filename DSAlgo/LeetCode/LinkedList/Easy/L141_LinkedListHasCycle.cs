using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList.Easy
{
    internal class L141_LinkedListHasCycle
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next; // Move slow by 1
                fast = fast.next.next; // Move fast by 2
                if (slow == fast) // A cycle is detected
                {
                    return true;
                }
            }
            return false; // No cycle found
        }

       
    }
}
