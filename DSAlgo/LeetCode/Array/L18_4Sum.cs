using System;

namespace DSAlgo.LeetCode.Array
{
    using System;
    public class L18_4Sum
    {
        // This problem is to find all unique quadruplets in an array that sum to a given target.
        // The approach is to sort the array and use a two-pointer technique to find pairs that sum to the negative of the current two elements.
        // Time Complexity: O(n^3) where n is the number of elements in the array
        // Space Complexity: O(1) for the result list, but O(n) for the sorting step
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            int n = nums.Length;

            for (int i = 0; i < n - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                for (int j = i + 1; j < n - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                    int left = j + 1;
                    int right = n - 1;

                    while (left < right)
                    {
                        long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum == target)
                        {
                            result.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });

                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;

                            left++;
                            right--;
                        }
                        else if (sum < target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }

            return result;
        }
    }
}
