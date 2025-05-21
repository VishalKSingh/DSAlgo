namespace DSAlgo.LeetCode.Tree.Medium
{
    internal class L236_LowesttCommonAncestorOfBinaryTree
    {

        // This problem is about finding the lowest common ancestor (LCA) of two nodes in a binary tree
        // The LCA of two nodes p and q in a binary tree is defined as the lowest node that has both p and q as descendants
        // A node can be a descendant of itself, so if p is an ancestor of q, then p is the LCA
        // The recursive approach is used to find the LCA
        // Time Complexity: O(n) where n is the number of nodes in the tree
        // Space Complexity: O(h) where h is the height of the tree due to recursion stack
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // Base case: if the root is null or if the root is one of the nodes p or q
            if (root == null || root == p || root == q)
            {
                return root;
            }

            // Recursively find LCA in the left and right subtrees
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            // If both left and right are not null, then root is the LCA
            if (left != null && right != null)
            {
                return root;
            }

            // If one of them is null, return the other one
            return left ?? right;
        }

    }
}
