namespace DSAlgo.LeetCode.Tree.Medium
{
    internal class L236_LowesttCommonAncestorOfBinaryTree
    {
        // The return type is TreeNode, which is a reference type.
        // To fix CS8603, you can annotate the return type as nullable (TreeNode?).
        public TreeNode? LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
            {
                return root;
            }

            TreeNode? left = LowestCommonAncestor(root.left, p, q);
            TreeNode? right = LowestCommonAncestor(root.right, p, q);

            if (left != null && right != null)
            {
                return root;
            }

            return left ?? right;
        }
    }
}
