namespace DSAlgo.LeetCode.String.Medium
{
    using System;
    using System.Text;
    internal class L151_ReverseWordsInString
    {
        // This problem is to reverse the words in a given string.
        // The approach is to split the string by spaces, reverse the list of words, and then join them back with a single space.
        // Time Complexity: O(n) where n is the length of the input string
        // Space Complexity: O(n) for storing the words

        public string ReverseWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";

            var words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }

        // Brute force solution
        // This approach iterates through the string in reverse order, building words and appending them to the result.
        // Time Complexity: O(n) where n is the length of the input string
        // Space Complexity: O(n) for the result string
        public string ReverseWordsBruteForce(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";

            var result = string.Empty;
            var word = string.Empty;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                // Check if the character is a space
                if (s[i] == ' ')
                {
                    // If we encounter a space and we have a word, append it to the result
                    if (!string.IsNullOrEmpty(word))
                    {
                        result += word + " ";
                        word = string.Empty;
                    }
                }
                else
                {
                    word = s[i] + word;
                }
            }

            if (!string.IsNullOrEmpty(word))
            {
                result += word;
            }

            return result.Trim();
        }

        // Optimized solution using StringBuilder
        public string ReverseWordsOptimized(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";

            var result = new StringBuilder();
            var word = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                // Check if the character is a space
                if (s[i] == ' ')
                {
                    // If we encounter a space and we have a word, append it to the result
                    if (word.Length > 0)
                    {
                        if (result.Length > 0)
                        {
                            result.Append(" ");
                        }
                        result.Append(word.ToString());
                        word.Clear();
                    }
                }
                else
                {
                    word.Insert(0, s[i]);
                }
            }

            // Append the last word if exists
            if (word.Length > 0)
            {
                if (result.Length > 0)
                {
                    result.Append(" ");
                }
                result.Append(word.ToString());
            }

            return result.ToString();
        }
    }
}
