using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.StackAndQueue.Hard
{
    internal class L726_NumerOfAtoms
    {
        public L726_NumerOfAtoms() { }
        // This problem is about parsing a chemical formula and counting the number of atoms of each element in the formula. The approach is to use a stack to keep track of the current context of the formula, and a dictionary to count the number of atoms for each element. We can iterate through the formula character by character, handling different cases for uppercase letters (indicating the start of an element), digits (indicating the count of the previous element), and parentheses (indicating a new context).
        // Time Complexity: O(n) where n is the length of the formula, as we need to parse each character once.
        // Space Complexity: O(n) in the worst case for the stack and dictionary if there are many nested contexts and unique elements.
        public string CountOfAtoms(string formula)
        {
            Stack<Dictionary<string, int>> stack = new Stack<Dictionary<string, int>>();
            stack.Push(new Dictionary<string, int>()); // Start with an empty context
            int i = 0;
            while (i < formula.Length)
            {
                char c = formula[i];
                if (c == '(')
                {
                    stack.Push(new Dictionary<string, int>()); // Start a new context
                    i++;
                }
                else if (c == ')')
                {
                    var top = stack.Pop(); // End the current context
                    i++;
                    int count = 0;
                    while (i < formula.Length && char.IsDigit(formula[i]))
                    {
                        count = count * 10 + (formula[i] - '0'); // Parse the count after the parenthesis
                        i++;
                    }
                    count = count == 0 ? 1 : count; // If no count is specified, it defaults to 1
                    foreach (var kvp in top)
                    {
                        if (!stack.Peek().ContainsKey(kvp.Key))
                        {
                            stack.Peek()[kvp.Key] = 0;
                        }
                        stack.Peek()[kvp.Key] += kvp.Value * count; // Multiply the counts by the number after the parenthesis
                    }
                }
                else if (char.IsUpper(c))
                {
                    StringBuilder element = new StringBuilder();
                    element.Append(c); // Start of an element
                    i++;
                    while (i < formula.Length && char.IsLower(formula[i]))
                    {
                        element.Append(formula[i]); // Continue parsing the element name
                        i++;
                    }
                    int count = 0;
                    while (i < formula.Length && char.IsDigit(formula[i]))
                    {
                        count = count * 10 + (formula[i] - '0'); // Parse the count for the element
                        i++;
                    }
                    count = count == 0 ? 1 : count; // If no count is specified, it defaults to 1
                    string elementName = element.ToString();
                    if (!stack.Peek().ContainsKey(elementName))
                    {
                        stack.Peek()[elementName] = 0;
                    }
                    stack.Peek()[elementName] += count; // Add the count of the element to the current context
                }
            }
            var resultDict = stack.Pop(); // Get the final counts from the stack
            var sortedElements = resultDict.Keys.OrderBy(e => e).ToList(); // Sort the elements alphabetically
            foreach (var kvp in sortedElements)
            {
                if (resultDict[kvp] == 1)
                {
                    sortedElements[sortedElements.IndexOf(kvp)] = kvp; // If count is 1, just use the element name
                }
                else
                {
                    sortedElements[sortedElements.IndexOf(kvp)] = kvp + resultDict[kvp].ToString(); // Append the count to the element name
                }
            }
            return string.Join("", sortedElements); // Join the sorted elements into the final result string
        }
    }
}
