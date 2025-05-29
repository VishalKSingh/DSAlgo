using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList.Medium
{
    internal class L61_RotateList
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

        // This problem is about rotating a linked list to the right by k places
        // The function should return the new head of the rotated list
        // Time Complexity: O(n) where n is the length of the linked list
        // Space Complexity: O(1) since we are modifying the list in place

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0) return head;

            // Find the length of the list
            int length = 1;
            ListNode tail = head;
            while (tail.next != null)
            {
                tail = tail.next;
                length++;
            }

            // Make the list circular
            tail.next = head;

            // Find the new tail: (length - k % length - 1)th node
            k = k % length;
            int newTailIndex = length - k - 1;
            ListNode newTail = head;

            for (int i = 0; i < newTailIndex; i++)
            {
                newTail = newTail.next;
            }

            // Set the new head and break the circular link
            ListNode newHead = newTail.next;
            newTail.next = null;

            return newHead;
        }

        // approach of the above solution
         //1. Check if the list is empty or has only one node, or if k is 0. If so, return the head as no rotation is needed.
         //2. Calculate the length of the linked list by traversing it and counting the nodes.
         //3. Make the linked list circular by connecting the tail's next pointer to the head.
         //4. Calculate the effective rotation by taking k modulo the length of the list.
         //5. Determine the new tail of the list by finding the(length - k - 1)th node.
         //6. Set the new head to the next node of the new tail.
         //7. Break the circular link by setting the new tail's next pointer to null.
         //8. Return the new head of the rotated list.


        // Example usage:
        // public static void Main(string[] args)
        // {
        //     ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        //     L61_RotateList solution = new L61_RotateList();
        //     ListNode rotatedList = solution.RotateRight(head, 2);
        //     while (rotatedList != null)
        //     {

        //         Console.Write(rotatedList.val + " ");
        //         rotatedList = rotatedList.next;

        //     }
        //     // Output: 4 5 1 2 3

    }
}
