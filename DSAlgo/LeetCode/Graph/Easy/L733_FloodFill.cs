using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Graph.Easy
{
    internal class L733_FloodFill
    {
        // This problem is about performing a flood fill on a 2D grid
        // The approach is to use Depth-First Search (DFS) to change the color of the connected component
        // Time Complexity: O(M * N) where M is the number of rows and N is the number of columns in the image
        // Space Complexity: O(M * N) for the recursion stack in the worst case
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int originalColor = image[sr][sc];
            if (originalColor != newColor)
            {
                DFS(image, sr, sc, originalColor, newColor);
            }
            return image;
        }
        private void DFS(int[][] image, int row, int col, int originalColor, int newColor)
        {
            // Check for out of bounds and if the current pixel is not of the original color
            if (row < 0 || row >= image.Length || col < 0 || col >= image[0].Length || image[row][col] != originalColor)
                return;
            // Change the color of the current pixel
            image[row][col] = newColor;
            // Explore all four directions
            DFS(image, row - 1, col, originalColor, newColor); // Up
            DFS(image, row + 1, col, originalColor, newColor); // Down
            DFS(image, row, col - 1, originalColor, newColor); // Left
            DFS(image, row, col + 1, originalColor, newColor); // Right
        }
    }
}
