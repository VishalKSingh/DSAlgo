using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Helper
{
    internal class MathHelp
    {
        public static int EculideanGCD(int a, int b)
        {
            //while (b != 0)
            //{
            //    int remainder = a % b;
            //    a=b ;
            //    b = remainder;
            //}
            //return a;
            // it states GCD(a , b) = GCD(a % b, b) while a > b 

            while (a > 0 && b > 0)
            {
                if (a > b)
                    a = a % b;
                else
                    b = b % a;
            }
            return a == 0 ? b : a;
        }
        public static int LCM(int a, int b)
        {
            return (a / EculideanGCD(a, b)) * b;
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

        public static bool IsPrimeBruteForce(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            int count = 0;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    count++;
                    if(n / i != i)
                    {
                        count++;
                    }
                }
            }

            return count == 2 ? true : false;
        }

        public static List<int> GetPrimesUpToN(int n)
        {
            List<int> primes = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
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

        public static int CountDigits(int num)
        {
            int count = 0;

            while(num > 0)
            {
                int remainder = num % 10;
                Console.WriteLine("remainder :" + remainder);
                num = num / 10;
                count++;
            }

            return count;
        }

        public static int ReverseNumber(int num)
        {
            int revNum = 0;

            while(num > 0)
            {
                int remainder = num % 10;
                num = num / 10;
                revNum = (revNum * 10) + remainder;
            }

            return revNum;
        }

        public static int Power(int baseNum, int exponent)
        {
            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= baseNum;
            }
            return result;
        }

        public static int Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            int fact = 1;
            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }

        public static bool checkPalindrom(int n)
        {
            int reverseNumber = 0;
            int num = n;
            while (num > 0)
            {
                int remainder = num % 10;
                num = num / 10;
                reverseNumber = (reverseNumber * 10) + remainder;
            }
            Console.WriteLine("reverseNumber: " + reverseNumber);
            return reverseNumber == n;
        }

    }
}
