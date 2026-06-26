using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L443_StringCompression
    {
        public int Compress(char[] chars)
        {
            int writeIndex = 0; // Index to write the compressed characters
            int readIndex = 0;  // Index to read the original characters
            while (readIndex < chars.Length)
            {
                char currentChar = chars[readIndex];
                int count = 0;
                // Count the number of occurrences of the current character
                while (readIndex < chars.Length && chars[readIndex] == currentChar)
                {
                    readIndex++;
                    count++;
                }
                // Write the character to the compressed array
                chars[writeIndex++] = currentChar;
                // If the count is greater than 1, write the count as well
                if (count > 1)
                {
                    foreach (char c in count.ToString())
                    {
                        chars[writeIndex++] = c;
                    }
                }
            }
            return writeIndex; // Return the length of the compressed array
        }
    }
}
