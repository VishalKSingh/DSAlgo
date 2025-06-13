namespace DSAlgo.LeetCode.Array.Medium
{
    using System;
    public class L15_3Sum
    {
        // This problem is to find all unique triplets in an array that sum to zero.
        // The approach is to sort the array and use a two-pointer technique to find pairs that sum to the negative of the current element.
        // Time Complexity: O(n^2) where n is the number of elements in the array
        // Space Complexity: O(1) for the result list, but O(n) for the sorting step
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums); // Sort the array to use two-pointer technique
            int n = nums.Length;

            for (int i = 0; i < n - 2; i++) // Skip the last two elements
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // Skip duplicates

                int left = i + 1; // Start from the next element
                int right = n - 1; // Start from the last element

                // Use two pointers to find pairs that sum to the negative of nums[i]
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++; // Skip duplicates
                        while (left < right && nums[right] == nums[right - 1]) right--; // Skip duplicates
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }

        // Example usage
        //public static void Main(string[] args)
        //{
        //    L15_3Sum solution = new L15_3Sum();
        //    int[] nums = { -1, 0, 1, 2, -1, -4 };
        //    IList<IList<int>> result = solution.ThreeSum(nums);

        //    foreach (var triplet in result)
        //    {
        //        Console.WriteLine($"[{string.Join(", ", triplet)}]");
        //    }
        //}

        // Time Complexity: O(n^2)
        // Space Complexity: O(1) for the result list, but O(n) for the sorting step
        // The overall space complexity is O(n) due to the result list.
        // The algorithm uses a two-pointer technique to find triplets that sum to zero.
        // The outer loop iterates through the sorted array, and for each element,
        // it uses two pointers (left and right) to find pairs that sum to the negative of the current element.
        // The inner loop checks for duplicates to avoid adding the same triplet multiple times.
        // The result is a list of unique triplets that sum to zero.
        // The algorithm is efficient and works well for large input arrays.
        // The time complexity is O(n^2) because for each element, we are using a two-pointer approach,

        // which takes O(n) time, and we are iterating through the array once, leading to O(n^2) overall.
        // The space complexity is O(1) for the result list, but O(n) for the sorting step.
        // The overall space complexity is O(n) due to the result list.
        // The algorithm is efficient and works well for large input arrays.
        // The time complexity is O(n^2) because for each element, we are using a two-pointer approach,





    }
}
