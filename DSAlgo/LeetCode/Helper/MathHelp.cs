using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Helper
{
    internal class MathHelp
    {
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int remainder = a % b;
                a=b ;
                b = remainder;
            }
            return a;
        }
        public static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }

        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;
            // Check for factors from 5 to sqrt(n)
            // All primes are of the form 6k ± 1
            // Hence, we can skip even numbers and multiples of 3
            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }
            return true;
        }
        public static List<int> SieveOfEratosthenes(int n)
        {
            int[] nums = new int[n + 1];
            IList<int> list = new List<int>(nums);

            
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++) isPrime[i] = true;

            for (int p = 2; p * p <= n; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= n; i += p)
                        isPrime[i] = false;
                }
            }

            List<int> primes = new List<int>();
            for (int p = 2; p <= n; p++)
            {
                if (isPrime[p]) primes.Add(p);
            }
            return primes;
        }
    }
}
