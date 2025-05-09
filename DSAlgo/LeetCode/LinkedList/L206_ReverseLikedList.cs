using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList
{
    public class L206_ReverseLikedList
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

        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode prev = null;
            ListNode curr = head;

            while (curr != null)
            {
                ListNode nextTemp = curr.next; // store next node
                curr.next = prev; // reverse the link
                prev = curr; // move prev to current node
                curr = nextTemp; // move to the next node
            }

            return prev; // new head of the reversed list
        }
    }
}
