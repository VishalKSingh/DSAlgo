using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    public class PreOrderBinaryTree
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
    }
}
