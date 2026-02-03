using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Sorting
{
    internal class MergeSort
    {
        public static void Sort(int[] array)
        {
            if (array == null || array.Length <= 1)
                return;

            int[] temp = new int[array.Length];
            DivideRecursive(array, temp, 0, array.Length - 1);
        }

        private static void DivideRecursive(int[] array, int[] temp, int left, int right)
        {
            // Base case: If the array has one or no elements, it's already sorted
            if (left >= right)
                return;

            int mid = left + (right - left) / 2; // To avoid potential overflow

            DivideRecursive(array, temp, left, mid);
            DivideRecursive(array, temp, mid + 1, right);
            Merge(array, temp, left, mid, right);
        }

        private static void Merge(int[] array, int[] temp, int left, int mid, int right)
        {
            int i = left;      // pointer for left subarray
            int j = mid + 1;   // pointer for right subarray
            int k = left;      // pointer for temp array

            while (i <= mid && j <= right)
            {
                if (array[i] <= array[j])
                    temp[k++] = array[i++];
                else
                    temp[k++] = array[j++];
            }

            while (i <= mid)
                temp[k++] = array[i++];

            while (j <= right)
                temp[k++] = array[j++];

            for (int index = left; index <= right; index++)
                array[index] = temp[index];
        }

        // Example usage
        //static void Main()
        //{
        //    int[] nums = { 38, 27, 43, 3, 9, 82, 10 };

        //    Sort(nums);

        //    Console.WriteLine(string.Join(", ", nums));
        //}
    }
}
