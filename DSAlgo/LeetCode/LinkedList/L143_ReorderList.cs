using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList
{
    public class L143_ReorderList
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null) return;

            // Step 1: Find the middle of the list
            ListNode slow = head, fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // Step 2: Reverse the second half of the list
            ListNode prev = null, curr = slow.next;
            slow.next = null; // split the list into two halves
            while (curr != null)
            {
                ListNode nextTemp = curr.next; // store next node
                curr.next = prev; // reverse the link
                prev = curr; // move prev to current node
                curr = nextTemp; // move to the next node
            }

            // Step 3: Merge the two halves
            ListNode firstHalf = head;
            ListNode secondHalf = prev; // this is now the head of the reversed second half

            while (secondHalf != null)
            {
                ListNode temp1 = firstHalf.next;
                ListNode temp2 = secondHalf.next;

                firstHalf.next = secondHalf; // link first half to second half
                secondHalf.next = temp1; // link second half to first half

                firstHalf = temp1; // move to the next node in the first half
                secondHalf = temp2; // move to the next node in the second half
            }
        }
    }
}
