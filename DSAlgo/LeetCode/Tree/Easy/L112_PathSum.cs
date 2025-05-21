using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Tree.Easy
{
    public class L112_PathSum
    {
        // This problem is about checking if a binary tree has a root-to-leaf path such that the sum of the values along the path equals a given target sum
        // The recursive approach is used to traverse the tree and check the sum
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return false; // Base case: if the node is null, return false
            }

            // Check if we are at a leaf node and if the remaining target sum equals the node's value
            if (root.left == null && root.right == null)
            {
                return targetSum == root.val;
            }

            // Recursively check the left and right subtrees with the updated target sum
            return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
        }

        // The iterative approach is used to traverse the tree using a stack
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(n) where n is the number of nodes in the tree due to the stack
        public bool HasPathSumIterative(TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return false; // Base case: if the node is null, return false
            }

            Stack<(TreeNode node, int sum)> stack = new Stack<(TreeNode node, int sum)>();
            stack.Push((root, targetSum - root.val));

            while (stack.Count > 0)
            {
                var (node, sum) = stack.Pop();

                // Check if we are at a leaf node and if the remaining target sum equals zero
                if (node.left == null && node.right == null && sum == 0)
                {
                    return true;
                }

                // Push the left and right children onto the stack with the updated sum
                if (node.left != null)
                {
                    stack.Push((node.left, sum - node.left.val));
                }
                if (node.right != null)
                {
                    stack.Push((node.right, sum - node.right.val));
                }
            }

            return false; // No path found that meets the target sum
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
