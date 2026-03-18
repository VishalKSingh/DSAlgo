using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class DFS_PostOrderTraversalBinaryTree
    {
        // This problem is about traversing a binary tree in post-order
        // Post-order traversal means visiting the left subtree first, then the right subtree, and finally the root node
        // The recursive approach is used to traverse the tree
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            PostorderHelper(root, result);
            return result;
        }
        private void PostorderHelper(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }
            PostorderHelper(node.left, result); // Traverse the left subtree
            PostorderHelper(node.right, result); // Traverse the right subtree
            result.Add(node.val); // Visit the root node
        }
        // Iterative approach using a stack can also be used to perform post-order traversal
        private void PostorderIterative(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root); // Start with the root node
            while (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop(); // Pop the top node
                result.Insert(0, currentNode.val); // Visit the root node (insert at the beginning)
                // Push left child first so that right child is processed first
                if (currentNode.left != null)
                {
                    stack.Push(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    stack.Push(currentNode.right);
                }
            }
        }
    }
}
