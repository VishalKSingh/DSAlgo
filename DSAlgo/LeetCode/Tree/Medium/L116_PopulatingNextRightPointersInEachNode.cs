using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    public class L116_PopulatingNextRightPointersInEachNode
    {
        // This problem is about populating each node's next right pointer in a perfect binary tree
        // A perfect binary tree is a binary tree in which all interior nodes have two children and all leaves are at the same level
        // The iterative approach is used to populate the next right pointers
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(1) as we are using only a few variables
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return null; // Base case: if the root is null, return null
            }

            Node leftmost = root;

            while (leftmost.left != null)
            {
                Node head = leftmost;

                while (head != null)
                {
                    head.left.next = head.right; // Connect left child to right child
                    if (head.next != null)
                    {
                        head.right.next = head.next.left; // Connect right child to next left child
                    }
                    head = head.next; // Move to the next node in the same level
                }

                leftmost = leftmost.left; // Move to the next level
            }

            return root; // Return the modified tree with next right pointers populated
        }

        // Above problem can also be solved using Queue
        public Node ConnectQueue(Node root)
        {
            if (root == null)
            {

                return null; // Base case: if the root is null, return null
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root); // Start with the root node
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                Node prev = null; // Previous node in the same level
                for (int i = 0; i < levelSize; i++)
                {
                    Node currentNode = queue.Dequeue(); // Dequeue the front node
                    if (prev != null)
                    {
                        prev.next = currentNode; // Connect the previous node to the current node
                    }
                    prev = currentNode; // Update the previous node
                    // Enqueue the left and right children of the current node
                    if (currentNode.left != null)
                    {
                        queue.Enqueue(currentNode.left);
                    }
                    if (currentNode.right != null)
                    {
                        queue.Enqueue(currentNode.right);
                    }
                }
                prev.next = null; // Set the next pointer of the last node in the level to null
            }
            return root; // Return the modified tree with next right pointers populated
        }


        // Definition for a binary tree node with next pointer.
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node(int val = 0, Node left = null, Node right = null, Node next = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                this.next = next;
            }
        }
    }
}
