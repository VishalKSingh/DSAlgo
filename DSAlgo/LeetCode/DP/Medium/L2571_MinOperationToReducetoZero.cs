using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.DP.Medium
{
    internal class L2571_MinOperationToReducetoZero
    {
        // 2571. Minimum Operations to Reduce an Integer to 0
        // Use NAF-like greedy: when n is even shift right; when odd decide +/-1 using n % 4 (special-case n == 3).
        public int MinOperations(int n)
        {
            int operations = 0;
            while (n > 0)
            {
                // If n is even, divide by 2 (shift right).
                if ((n & 1) == 0)
                {
                    n >>= 1;
                }
                else
                {
                    if (n == 1)
                    {
                        operations++;
                        break;
                    }

                    // If n is odd, decide whether to add or subtract 1 based on n % 4.
                    int mod4 = n & 3;
                    // If n % 4 == 1, subtract 1; if n % 4 == 3, add 1 (except for n == 3).
                    if (mod4 == 1)
                    {
                        n -= 1;
                    }
                    else // mod4 == 3
                    {
                        if (n == 3)
                            n -= 1; // special-case to avoid extra steps
                        else
                            n += 1;
                    }

                    operations++;
                }
            }
            return operations;
        }
    }
}
