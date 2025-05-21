using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class L104_MaximumDepthOFBinaryTree
    {
        // This problem is about finding the maximum depth of a binary tree
        // The maximum depth of a binary tree is the number of nodes along the longest path from the root node down to the farthest leaf node
        // The recursive approach is used to find the maximum depth
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0; // Base case: if the node is null, return 0
            }

            // Recursively find the maximum depth of left and right subtrees and add 1 for the current node
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

    }
}
