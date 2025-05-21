using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    internal class L98_ValidateBinarySearchTree
    {
        // This problem is about validating if a binary tree is a binary search tree (BST)
        // A BST is a binary tree in which all the left descendants of a node are less than the node and all the right descendants are greater than the node
        // The recursive approach is used to validate the BST
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBSTHelper(root, null, null);
        }

        private bool IsValidBSTHelper(TreeNode node, int? lower, int? upper)
        {
            if (node == null)
            {
                return true; // Base case: if the node is null, it's a valid BST
            }

            if ((lower.HasValue && node.val <= lower.Value) || (upper.HasValue && node.val >= upper.Value))
            {
                return false; // If the current node's value violates the BST property, return false
            }

            // Recursively check left and right subtrees with updated bounds
            return IsValidBSTHelper(node.left, lower, node.val) && IsValidBSTHelper(node.right, node.val, upper);
        }
    }
}
