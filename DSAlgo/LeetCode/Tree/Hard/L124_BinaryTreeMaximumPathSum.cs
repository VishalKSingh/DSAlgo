namespace DSAlgo.LeetCode.Tree.Hard
{
    internal class L124_BinaryTreeMaximumPathSum
    {
        // This problem is about finding the maximum path sum in a binary tree
        // A path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections
        // The path must contain at least one node and does not need to go through the root
        // The recursive approach is used to find the maximum path sum
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        private int maxSum = int.MinValue;

        public int MaxPathSum(TreeNode root)
        {
            MaxPathSumHelper(root);
            return maxSum;
        }

        private int MaxPathSumHelper(TreeNode node)
        {
            if (node == null)
            {
                return 0; // Base case: if the node is null, return 0
            }

            // Calculate maximum path sum for left and right subtrees
            int leftMax = Math.Max(0, MaxPathSumHelper(node.left));
            int rightMax = Math.Max(0, MaxPathSumHelper(node.right));

            // Update maximum path sum considering the current node as a root of the path
            maxSum = Math.Max(maxSum, node.val + leftMax + rightMax);

            // Return maximum path sum including the current node and one of its subtrees
            return node.val + Math.Max(leftMax, rightMax);
        }
    }
}
