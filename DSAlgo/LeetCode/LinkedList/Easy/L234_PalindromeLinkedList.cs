using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList.Easy
{
    internal class L234_PalindromeLinkedList
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null) return true;
            // Step 1: Find the middle of the linked list using the fast and slow pointer technique.
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next; // Move slow by 1
                fast = fast.next.next; // Move fast by 2
            }
            // Step 2: Reverse the second half of the linked list.
            ListNode prev = ReverseLinkedList(slow);
            // Step 3: Compare the first half and the reversed second half of the linked list.
            ListNode firstHalfPointer = head;
            ListNode secondHalfPointer = prev; // This is now the head of the reversed second half
            while (secondHalfPointer != null)
            {
                if (firstHalfPointer.val != secondHalfPointer.val)
                {
                    return false; // Not a palindrome
                }
                firstHalfPointer = firstHalfPointer.next; // Move to next node in first half
                secondHalfPointer = secondHalfPointer.next; // Move to next node in second half
            }
            return true; // The linked list is a palindrome
        }

        public ListNode ReverseLinkedList(ListNode head)
        {
            ListNode curr = head; ;
            ListNode prev = null;

            while(curr != null)
            {
                ListNode temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }
            return prev;
        }

        // Optimized version that combines finding the middle and reversing the second half in one pass.
        // Time Complexity: O(n), where n is the number of nodes in the linked list.
        // Space Complexity: O(1), as we are using only a constant amount of space.
    }
}
