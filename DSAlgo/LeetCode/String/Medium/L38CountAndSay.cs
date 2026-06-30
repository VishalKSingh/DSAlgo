using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.String.Medium
{
    internal class L38CountAndSay
    {
        public string CountAndSay(int n)
        {
            if (n <= 0)
                return string.Empty;
            string result = "1";
            
            for (int i = 1; i < n; i++)
            {
                StringBuilder sb = new StringBuilder();
                int count = 1;
                // Loop through the current result string to count consecutive digits
                for (int j = 1; j < result.Length; j++)
                {
                    if (result[j] == result[j - 1])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(result[j - 1]); // Append the count and the digit to the StringBuilder
                        count = 1;
                    }
                }
                sb.Append(count);
                sb.Append(result[result.Length - 1]); // Append the count and the last digit to the StringBuilder
                result = sb.ToString();
            }
            return result;
        }
    }
}
