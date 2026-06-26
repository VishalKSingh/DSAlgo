namespace DSAlgo.LeetCode.Tree.Medium
{
    internal class L236_LowesttCommonAncestorOfBinaryTree
    {
        // The return type is TreeNode, which is a reference type.
        // To fix CS8603, you can annotate the return type as nullable (TreeNode?).
        public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // Base case: if the current node is null, return null
            // If the current node is either p or q, return the current node
            if (root == null || root == p || root == q)
            {
                return root;
            }

            // Recur for left and right subtrees
            TreeNode? left = LowestCommonAncestor(root.left, p, q);
            TreeNode? right = LowestCommonAncestor(root.right, p, q);

            // If both left and right are non-null, it means p and q are found in different subtrees
            if (left != null && right != null)
            {
                return root;
            }

            return left ?? right;
        }
    }
}
