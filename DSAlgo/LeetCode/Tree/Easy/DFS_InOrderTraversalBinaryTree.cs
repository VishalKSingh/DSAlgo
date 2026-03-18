using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class DFS_InOrderTraversalBinaryTree
    {
        // This problem is about traversing a binary tree in in-order
        // In-order traversal means visiting the left subtree first, then the root node, and finally the right subtree
        // The recursive approach is used to traverse the tree
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            InorderHelper(root, result);
            return result;
        }

        private void InorderHelper(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            InorderHelper(node.left, result); // Traverse the left subtree
            result.Add(node.val); // Visit the root node
            InorderHelper(node.right, result); // Traverse the right subtree
        }

        // Iterative approach using a stack can also be used to perform in-order traversal

        private void InorderIterative(TreeNode root, List<int> result)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
            while (current != null || stack.Count > 0)
            {
                // Reach the left most Node of the current Node
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }
                // Current must be null at this point
                current = stack.Pop();
                result.Add(current.val); // Visit the root node
                // We have visited the node and its left subtree. Now, it's right subtree's turn
                current = current.right;
            }
        }
    }
}
