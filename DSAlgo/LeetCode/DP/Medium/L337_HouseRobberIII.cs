using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L337_HouseRobberIII
    {
        public L337_HouseRobberIII() { }
        // This problem is to find the maximum amount of money that can be robbed from a binary tree of houses,
        // where you cannot rob two directly connected houses.
        
        // The approach is to use a post-order traversal of the tree and calculate the maximum amount that can be robbed at each node.
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree (due to recursion stack)
        public int Rob(TreeNode root)
        {
            var result = RobHelper(root);
            return Math.Max(result.Item1, result.Item2); // Return the maximum of robbing or not robbing the root
        }
        private (int, int) RobHelper(TreeNode node)
        {
            if (node == null)
                return (0, 0); // Base case: no money can be robbed from a null node
            var left = RobHelper(node.left); // Recur for left subtree
            var right = RobHelper(node.right); // Recur for right subtree
            int robCurrent = node.val + left.Item2 + right.Item2; // If we rob current node, we cannot rob its children
            int notRobCurrent = Math.Max(left.Item1, left.Item2) + Math.Max(right.Item1, right.Item2); // If we do not rob current node, we can choose to rob or not rob its children
            return (robCurrent, notRobCurrent); // Return both scenarios for current node
        }

        // Definition for a binary tree node.

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
