using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L6_ZigZagConversion
    {
        // This problem is to convert a string into a zigzag pattern on a given number of rows.
        // The approach is to simulate the zigzag pattern by iterating through the characters and placing them in the correct row.
        // Time Complexity: O(n) where n is the length of the input string
        // Space Complexity: O(n) for storing the result

        public string Convert(string s, int numRows)
        {
            // If numRows is 1 or greater than or equal to the length of the string, we cannot form a zigzag pattern, so return the original string

            if (numRows == 1 || numRows >= s.Length) return s;

            // Create an array of StringBuilder to hold each row
            var rows = new StringBuilder[numRows];
            for (int i = 0; i < numRows; i++)
            {
                rows[i] = new StringBuilder();
            }

            int currentRow = 0; // Current row index
            bool goingDown = false; // Direction of movement in the zigzag pattern

            // Iterate through each character in the string
            foreach (char c in s)
            {
                rows[currentRow].Append(c); // Append the character to the current row
                // Change direction if we reach the top or bottom row
                if (currentRow == 0)
                    goingDown = true;
                else if (currentRow == numRows - 1)
                    goingDown = false;
                // Move to the next row based on the direction 
                currentRow += goingDown ? 1 : -1;
            }

            return string.Join("", rows.Select(r => r.ToString()));
        }
    }
}
