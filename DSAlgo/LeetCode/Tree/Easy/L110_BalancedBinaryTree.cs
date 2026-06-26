using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class L110_BalancedBinaryTree
    {
        public bool IsBalanced(TreeNode root)
        {
            return CheckBalance(root) != -1;
        }

        private int CheckBalance(TreeNode node)
        {
            if (node == null)
                return 0;
            int leftHeight = CheckBalance(node.left);
            if (leftHeight == -1) return -1; // Left subtree is not balanced
            int rightHeight = CheckBalance(node.right);
            if (rightHeight == -1) return -1; // Right subtree is not balanced
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return -1; // Current node is not balanced
            return Math.Max(leftHeight, rightHeight) + 1; // Return height of the current node
        }
    }
}
