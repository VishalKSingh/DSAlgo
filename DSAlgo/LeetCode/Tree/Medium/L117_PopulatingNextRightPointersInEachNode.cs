using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    internal static class L117_PopulatingNextRightPointersInEachNodeII
    {
        // This problem is a follow-up to the problem of populating next right pointers in each node in a perfect binary tree
        // In this problem, the binary tree can be any binary tree (not necessarily perfect), and we need to populate the next right pointers accordingly
        // The main idea is to use a level order traversal (BFS) to connect the nodes at each level
        // We can also solve this problem using constant space by using the next pointers to traverse the tree level by level
        // The iterative approach using a queue is straightforward and easy to understand, while the constant space approach is more efficient in terms of space complexity
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(n) in the worst case when the last level of the tree is full for the iterative approach, and O(1) for the constant space approach

        public static void Main(string[] args)
        {
            // Example usage:
            L117_Node root = new L117_Node(1);
            root.left = new L117_Node(2);
            root.right = new L117_Node(3);
            root.left.left = new L117_Node(4);
            root.left.right = new L117_Node(5);
            root.right.right = new L117_Node(7);
            Connect(root); // Populates the next right pointers
        }

        public static L117_Node Connect(L117_Node root)
        {
            if (root == null)
            {
                return null; // Base case: if the root is null, return null
            }
            Queue<L117_Node> queue = new Queue<L117_Node>();
            queue.Enqueue(root); // Start with the root node
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    L117_Node currentNode = queue.Dequeue(); // Dequeue the front node
                    if (i < levelSize - 1)
                    {
                        currentNode.next = queue.Peek(); // Connect to the next node in the same level
                    }
                    else
                    {
                        currentNode.next = null; // Last node in the level points to null
                    }
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
            }
            return root; // Return the modified tree with next right pointers populated
        }


        public static L117_Node ConnectConstantSpace(L117_Node root)
        {
            if (root == null)
            {
                return null; // Base case: if the root is null, return null
            }
            L117_Node leftmost = root; // Start with the leftmost node of the tree
            while (leftmost != null)
            {
                L117_Node head = leftmost; // Traverse the current level
                while (head != null)
                {
                    if (head.left != null)
                    {
                        head.left.next = head.right; // Connect left child to right child
                    }
                    if (head.right != null && head.next != null)
                    {
                        head.right.next = head.next.left; // Connect right child to next left child
                    }
                    head = head.next; // Move to the next node in the same level
                }
                leftmost = leftmost.left; // Move to the next level
            }
            return root; // Return the modified tree with next right pointers populated
        }

        public class L117_Node
        {
            public int val;
            public L117_Node left;
            public L117_Node right;
            public L117_Node next;
            public L117_Node() { }
            public L117_Node(int _val)
            {
                val = _val;
            }
            public L117_Node(int _val, L117_Node _left, L117_Node _right, L117_Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}
