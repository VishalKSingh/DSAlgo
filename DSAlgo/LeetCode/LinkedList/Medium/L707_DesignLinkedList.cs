using DSAlgo.LeetCode.LinkedList.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList.Medium
{
    internal class L707_DesignLinkedList
    {
        // 707. Design Linked List
        // Implement a singly linked list with the following methods:
        // - get(index): Get the value of the index-th node in the linked list. If the index is invalid, return -1.
        // - addAtHead(val): Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list.
        // - addAtTail(val): Append a node of value val to the last element of the linked list.
        // - addAtIndex(index, val): Add a node o f value val before the index-th node in the linked list. If index equals the length of the linked list, the node will be appended to the end of the linked list. If index is greater than the length, the node will not be inserted.
        // - deleteAtIndex(index): Delete the index-th node in the linked list, if the index is valid.
        private ListNode head;
        private ListNode tail;

        public L707_DesignLinkedList() {
            head = null;
            tail = null;
        }

        public int get(int index)
        {
            // Implement the get method to return the value of the node at the specified index.
            // If the index is invalid, return -1.
            ListNode current = head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.val;
                }
                current = current.next;
                currentIndex++;
            }
            return -1; // Index is out of bounds
        }

        public void addAtHead(int val)
        {
            // Implement the addAtHead method to add a node of value val before the first element of the linked list.
            // After the insertion, the new node will be the first node of the linked list.
            ListNode newNode = new ListNode(val);
            newNode.next = head;
            head = newNode;
        }

        public void removeAtHead(int val)
        {
            // Implement the removeAtHead method to remove the first occurrence of a node with value val from the linked list.
            // If such a node does not exist, do nothing.
            if (head == null) return;
            if (head.val == val)
            {
                head = head.next; // Remove the head node
                return;
            }
            ListNode current = head;
            while (current.next != null)
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next; // Remove the node
                    return;
                }
                current = current.next;
            }
        }

        public void AddatTail(int val)
        {
            // Implement the addAtTail method to append a node of value val to the last element of the linked list.
            ListNode newNode = new ListNode(val);
            if (head == null)
            {
                head = newNode; // If the list is empty, set head to the new node
                return;
            }
            ListNode current = head;
            while (current.next != null)
            {
                current = current.next; // Traverse to the end of the list
            }
            current.next = newNode; // Append the new node at the end
        }

        public void RemoveAtTail(int val)
        {
            // Implement the removeAtTail method to remove the last occurrence of a node with value val from the linked list.
            // If such a node does not exist, do nothing.
            if (head == null) return;
            if (head.val == val && head.next == null)
            {
                head = null; // If the list has only one node and it matches val, remove it
                return;
            }
            ListNode current = head;
            ListNode prev = null;
            ListNode lastOccurrence = null;
            ListNode lastOccurrencePrev = null;
            while (current != null)
            {
                if (current.val == val)
                {
                    lastOccurrencePrev = prev; // Update the previous node of the last occurrence
                    lastOccurrence = current; // Update the last occurrence
                }
                prev = current;
                current = current.next;
            }
            if (lastOccurrence != null)
            {
                if (lastOccurrencePrev != null)
                {
                    lastOccurrencePrev.next = lastOccurrence.next; // Remove the last occurrence
                }
                else
                {
                    head = head.next; // If the last occurrence is the head, update head
                }
            }
        }

        public void AddAtIndex(int index, int val)
        {
            // Implement the addAtIndex method to add a node of value val before the index-th node in the linked list.
            // If index equals the length of the linked list, the node will be appended to the end of the linked list.
            // If index is greater than the length, the node will not be inserted.
            if (index < 0) return; // Invalid index
            if (index == 0)
            {
                addAtHead(val); // Add at head if index is 0
                return;
            }
            ListNode newNode = new ListNode(val);
            ListNode current = head;
            int currentIndex = 0;
            while (current != null && currentIndex < index - 1)
            {
                current = current.next;
                currentIndex++;
            }
            if (current == null) return; // Index is greater than the length of the list
            newNode.next = current.next; // Insert the new node
            current.next = newNode;
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || head == null) return; // Invalid index or empty list
            if (index == 0)
            {
                head = head.next; // Remove the head node
                return;
            }
            ListNode current = head;
            int currentIndex = 0;
            while (current != null && currentIndex < index - 1)
            {
                current = current.next;
                currentIndex++;
            }
            if (current == null || current.next == null) return; // Index is out of bounds
            current.next = current.next.next; // Remove the node at the specified index
        }
    }
}
