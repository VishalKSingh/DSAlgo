using DSAlgo.LeetCode.LinkedList.Easy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Medium.Matrix
{
    internal class L2326_SpiralMatrixIV
    {
        public int[][] SpiralMatrix(int m, int n, ListNode head)
        {
            int[][] result = new int[m][];
            for (int i = 0; i < m; i++)
            {
                result[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    result[i][j] = -1; // Initialize with -1
                }
            }

            int top = 0, bottom = m - 1, left = 0, right = n - 1;
            while (top <= bottom && left <= right)
            {
                // Traverse from left to right
                for (int j = left; j <= right && head != null; j++)
                {
                    result[top][j] = head.val;
                    head = head.next;
                }
                top++;
                // Traverse from top to bottom
                for (int i = top; i <= bottom && head != null; i++)
                {
                    result[i][right] = head.val;
                    head = head.next;
                }
                right--;
                // Traverse from right to left
                if (top <= bottom)
                {
                    for (int j = right; j >= left && head != null; j--)
                    {
                        result[bottom][j] = head.val;
                        head = head.next;
                    }
                    bottom--;
                }
                // Traverse from bottom to top
                if (left <= right)
                {
                    for (int i = bottom; i >= top && head != null; i--)
                    {
                        result[i][left] = head.val;
                        head = head.next;
                    }
                    left++;
                }
            }
            return result;
        }
    }
}
