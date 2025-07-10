using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Hard
{
    internal class L68_TextJustification
    {
        public L68_TextJustification() { }
        // This problem is to justify text in a given width.
        // The approach is to group words into lines that fit within the specified width and then justify each line.
        // Time Complexity: O(n) where n is the total number of characters in the input words
        // Space Complexity: O(n) for storing the result lines
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var result = new List<string>();
            var currentLine = new List<string>();
            int currentLength = 0;

            // Iterate through each word and build lines
            foreach (var word in words)
            {
                // currentLength is the total length of words in the current line
                // currentLength + word.Length is the length of the current line if we add the next word
                // currentLine.Count is the number of spaces that will be added between words in the current line
                // maxWidth is the maximum allowed width for the line
                // If adding the next word exceeds maxWidth, we need to justify the current line



                if (currentLength + word.Length + currentLine.Count > maxWidth)
                {
                    // Justify the current line and add it to the result
                    result.Add(JustifyLine(currentLine, currentLength, maxWidth));
                    currentLine.Clear();
                    currentLength = 0;
                }
                currentLine.Add(word);
                currentLength += word.Length;
            }

            // Handle the last line
            if (currentLine.Count > 0)
            {
                var lastLine = string.Join(" ", currentLine);
                result.Add(lastLine + new string(' ', maxWidth - lastLine.Length));
            }

            return result;
        }
        private string JustifyLine(List<string> words, int currentLength, int maxWidth)
        {
            // If there is only one word in the line, we simply pad it with spaces to the right
            if (words.Count == 1)
            {
                return words[0] + new string(' ', maxWidth - words[0].Length);
            }

            // Calculate the total spaces needed and distribute them evenly between words
            // The number of spaces between words is the total spaces divided by (number of words - 1)
            // If there are extra spaces, distribute them from left to right

            int totalSpaces = maxWidth - currentLength; // total spaces needed to fill the line
            int spaceBetweenWords = totalSpaces / (words.Count - 1); // spaces between each word
            int extraSpaces = totalSpaces % (words.Count - 1); // extra spaces to distribute

            // Build the justified line
            var sb = new StringBuilder();
            // Append each word and the appropriate number of spaces

            for (int i = 0; i < words.Count; i++)
            {
                sb.Append(words[i]);
                // If it's not the last word, append spaces
                // If there are extra spaces, we add one more space to the leftmost words

                if (i < words.Count - 1)
                {
                    sb.Append(new string(' ', spaceBetweenWords + (i < extraSpaces ? 1 : 0))); // add spaces between words
                }
            }

            return sb.ToString();
        }
    }
}
