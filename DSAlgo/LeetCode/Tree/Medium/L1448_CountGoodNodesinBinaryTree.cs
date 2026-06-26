using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Medium
{
    internal class L1448_CountGoodNodesinBinaryTree
    {
        public int GoodNodes(TreeNode root)
        {
            if (root == null) return 0; // If the root is null, return 0
            return CountGoodNodes(root, root.val); // Start counting good nodes from the root
        }

        private int CountGoodNodes(TreeNode node, int maxSoFar)
        {
            if (node == null) return 0; // Base case: if the node is null, return 0
            int count = 0;
            // Check if the current node is a good node
            if (node.val >= maxSoFar)
            {
                count = 1; // Increment count for the current good node
                maxSoFar = node.val; // Update maxSoFar to the current node's value
            }
            // Recursively count good nodes in left and right subtrees
            count += CountGoodNodes(node.left, maxSoFar);
            count += CountGoodNodes(node.right, maxSoFar);
            return count; // Return the total count of good nodes
        }
    }
}
