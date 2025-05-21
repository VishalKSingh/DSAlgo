using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    internal class L230_KthSmallestElementinBST
    {
        // This problem is about finding the kth smallest element in a binary search tree (BST)
        // The BST property ensures that the left subtree contains only nodes with values less than the node's value
        // and the right subtree contains only nodes with values greater than the node's value
        // The iterative approach is used to find the kth smallest element
        // Time Complexity: O(h + k) where h is the height of the tree and k is the kth smallest element
        // Space Complexity: O(h) for the stack used to store nodes
        public int KthSmallest(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            // In-order traversal of the BST is used to find the kth smallest element
            // In-order traversal visits nodes in ascending order
            // Push all left children of the root onto the stack
            while (true)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop(); // Pop the top node from the stack
                if (--k == 0) // Decrement k and check if it is zero
                {
                    return root.val; // Return the kth smallest element
                }
                root = root.right; // Move to the right child
            }
        }

        // Other approaches can be used to solve this problem, such as using recursion or Morris traversal
        // The recursive approach is used to find the kth smallest element
        // Time Complexity: O(h + k) where h is the height of the tree and k is the kth smallest element
        // Space Complexity: O(h) for the recursion stack
        public int KthSmallestRecursive(TreeNode root, int k)
        {
            List<int> result = new List<int>();
            InOrderTraversal(root, result);
            return result[k - 1]; // Return the kth smallest element
        }
        private void InOrderTraversal(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return; // Base case: if the node is null, return
            }

            InOrderTraversal(node.left, result); // Traverse the left subtree
            result.Add(node.val); // Visit the root node
            InOrderTraversal(node.right, result); // Traverse the right subtree
        }
    }
}
