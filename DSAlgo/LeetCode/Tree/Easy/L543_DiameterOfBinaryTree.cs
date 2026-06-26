using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class L543_DiameterOfBinaryTree
    {
        // The diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.
        // The length of a path between two nodes is represented by the number of edges between them.
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree (due to recursion stack)
        public int DiameterOfBinaryTree(TreeNode root)
        {
            int diameter = 0;
            Depth(root, ref diameter);
            return diameter;
        }

        public int Depth(TreeNode node, ref int diameter)
        {
            if (node == null)
                return 0;
            int leftDepth = Depth(node.left, ref diameter);
            int rightDepth = Depth(node.right, ref diameter);
            // Update the diameter if the path through the current node is larger
            diameter = Math.Max(diameter, leftDepth + rightDepth);
            // Return the depth of the current node
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
