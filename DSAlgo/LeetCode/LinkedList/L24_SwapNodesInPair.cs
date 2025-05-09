using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Recursion
{
     public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }
 
        public class SwapNodesInPair
        {
            public ListNode SwapPairs(ListNode head)
            {
                if (head == null || head.next == null) return head;

                // create dummy node to handle head
                ListNode dummy = new ListNode(0);
                dummy.next = head;
                ListNode prev = dummy;

                while (prev != null && prev.next != null && prev.next.next != null)
                {

                    // nodes to swap and next pairs of node
                    ListNode first = prev.next;
                    ListNode second = first.next;
                    ListNode next_pair = second.next;

                    // swap node
                    prev.next = second;
                    second.next = first;
                    first.next = next_pair;

                    prev = first;
                }

                return dummy.next;
            }
        }
    }
}
