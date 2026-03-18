using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    public class DFS_PreOrderBinaryTree
    {
        // This problem is about traversing a binary tree in pre-order
        // Pre-order traversal means visiting the root node first, then the left subtree, and finally the right subtree
        // The recursive approach is used to traverse the tree
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            PreorderHelper(root, result);
            return result;
        }

        private void PreorderHelper(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            result.Add(node.val); // Visit the root node
            PreorderHelper(node.left, result); // Traverse the left subtree
            PreorderHelper(node.right, result); // Traverse the right subtree
        }

        // Iterative approach using a stack can also be used to perform pre-order traversal

        private void PreorderIterative(TreeNode root, List<int> result)
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
                result.Add(currentNode.val); // Visit the root node
                // Push right child first so that left child is processed first
                if (currentNode.right != null)
                {
                    stack.Push(currentNode.right);
                }
                if (currentNode.left != null)
                {
                    stack.Push(currentNode.left);
                }
            }
        }
    }
}
