using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Design
{
    internal class L2353_DesignFoodRatingSystem
    {
        // This problem requires us to design a food rating system that allows updating food ratings and retrieving the highest-rated food for a given cuisine.
        // We can use a combination of dictionaries and sorted data structures to efficiently manage the food ratings and cuisines.
        // Time Complexity: O(log n) for update and retrieval operations due to the use of sorted data structures
        // Space Complexity: O(n) for storing the food items and their ratings

        private class FoodItem
        {
            public string Name { get; set; }
            public string Cuisine { get; set; }
            public int Rating { get; set; }

            public FoodItem(string name, string cuisine, int rating)
            {
                Name = name;
                Cuisine = cuisine;
                Rating = rating;
            }
        }

        private Dictionary<string, FoodItem> foodMap; // Maps food name to FoodItem
        private Dictionary<string, SortedSet<FoodItem>> cuisineSortedFoodMap; // Maps cuisine to a sorted set of FoodItems

        public L2353_DesignFoodRatingSystem(string[] foods, string[] cuisines, int[] ratings)
        {
            foodMap = new Dictionary<string, FoodItem>();
            cuisineSortedFoodMap = new Dictionary<string, SortedSet<FoodItem>>();

            for (int i = 0; i < foods.Length; i++)
            {
                var foodItem = new FoodItem(foods[i], cuisines[i], ratings[i]);
                foodMap[foods[i]] = foodItem;

                if (!cuisineSortedFoodMap.ContainsKey(cuisines[i]))
                {
                    cuisineSortedFoodMap[cuisines[i]] = new SortedSet<FoodItem>(new FoodItemComparer());  // Custom comparer to sort by rating and name
                }
                cuisineSortedFoodMap[cuisines[i]].Add(foodItem);
            }
        } 

        public void ChangeRating(string food, int newRating)
        {
            if (foodMap.ContainsKey(food))
            {
                var foodItem = foodMap[food];
                var cuisine = foodItem.Cuisine;

                // Remove the old item from the sorted set
                cuisineSortedFoodMap[cuisine].Remove(foodItem);

                // Update the rating
                foodItem.Rating = newRating;

                // Re-add the updated item to the sorted set
                cuisineSortedFoodMap[cuisine].Add(foodItem);
            }
        }

        public string HighestRated(string cuisine)
        {
            return cuisineSortedFoodMap[cuisine].Min.Name;
        }

        private class FoodItemComparer : IComparer<FoodItem>
        {
            public int Compare(FoodItem a, FoodItem b)
            {
                if (a.Rating != b.Rating)
                {
                    return b.Rating.CompareTo(a.Rating);
                }
                return a.Name.CompareTo(b.Name);
            }
        }
    }
} 
