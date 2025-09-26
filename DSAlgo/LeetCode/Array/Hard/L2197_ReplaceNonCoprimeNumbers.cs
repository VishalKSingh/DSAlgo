using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Array.Hard
{
    internal class L2197_ReplaceNonCoprimeNumbers
    {
        // This problem requires us to repeatedly replace adjacent non-coprime numbers in an array with their least common multiple (LCM) until all adjacent numbers are coprime.
        // We can use a stack to keep track of the numbers and perform the replacements as needed.
        // Time Complexity: O(n log m) where n is the number of elements in the array and m is the maximum value in the array (due to GCD calculations)
        // Space Complexity: O(n) for the stack
        public IList<int> ReplaceNonCoprimes(int[] nums)
        {
            Stack<int> stack = new Stack<int>();

            foreach (var num in nums)
            {
                int current = num;
                while (stack.Count > 0)
                {
                    int top = stack.Peek();
                    int gcd = GCD(top, current);
                    if (gcd == 1) break; // They are coprime
                    current = LCM(top, current);
                    stack.Pop(); // Remove the top element as we are replacing it
                }
                stack.Push(current);
            }

            return stack.Reverse().ToList(); // Reverse to maintain original order
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }

        // another approach
        // using List instead of Stack
        // Time Complexity: O(n log m) where n is the number of elements in the array and m is the maximum value in the array (due to GCD calculations)
        // Space Complexity: O(n) for the list

        public IList<int> ReplaceNonCoprimes2(int[] nums)
        {
            List<int> result = new List<int>();

            foreach (var num in nums)
            {
                int current = num;
                while (result.Count > 0)
                {
                    int last = result[result.Count - 1];
                    int gcd = GCD(last, current);
                    if (gcd == 1) break; // They are coprime
                    current = LCM(last, current);
                    result.RemoveAt(result.Count - 1); // Remove the last element as we are replacing it
                }
                result.Add(current);
            }

            return result;
        }

        // test for nums =
        // [287,41,49,287,899,23,23,20677,5,825]
        // Result [2009,20677,825]
        
        public IList<int> ReplaceNonCoprimes3(int[] nums)
        {
            IList<int> list = new List<int>(nums);

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (GCD(list[i], list[i + 1]) > 1)
                {
                    int a = list[i];
                    int b = list[i + 1];
                    list.RemoveAt(i);
                    list.RemoveAt(i);

                    list.Insert(i, LCM(a, b));
                    i--;
                }
            }
            return list;

        }
    }
}
