namespace DSAlgo.LeetCode.Tree.Easy
{
    internal class L94_BinaryTreeInorderTraversal
    {
        // This problem is about traversing a binary tree in in-order
        // In-order traversal means visiting the left subtree first, then the root node, and finally the right subtree
        // The recursive approach is used to traverse the tree
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            InorderHelper(root, result);
            return result;
        }

        private void InorderHelper(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            InorderHelper(node.left, result); // Traverse the left subtree
            result.Add(node.val); // Visit the root node
            InorderHelper(node.right, result); // Traverse the right subtree
        }
    }
}
