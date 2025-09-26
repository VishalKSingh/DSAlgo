namespace DSAlgo.LeetCode.Array.Medium
{
    internal class L621_TaskScheduler
    {
        // This problem is to schedule tasks with a given cooldown period.
        // The approach is to use a priority queue (or max heap) to keep track of the tasks.
        // Create a max heap to store tasks based on their counts
        // We use a SortedSet to simulate a max heap, where we store tuples of (count, task).
        // The count is negated to simulate max heap behavior since SortedSet sorts in ascending order by default.
        // The tuple is sorted first by count (descending) and then by task (ascending) to break ties.
        // This ensures that when we pop from the heap, we always get the task with the highest count.
        // If two tasks have the same count, we choose the one that comes first alphabetically.
        // This is important to ensure that we can always select the task with the highest count first.

        // Time Complexity: O(n log n) where n is the number of tasks
        // Space Complexity: O(n) for the task count dictionary

        public int LeastInterval(char[] tasks, int n)
        {
            // Count the occurrences of each task
            var taskCount = new Dictionary<char, int>();
            foreach (var task in tasks)
            {
                if (!taskCount.ContainsKey(task))
                {
                    taskCount[task] = 0;
                }
                taskCount[task]++;
            }
            

            var maxHeap = new SortedSet<(int count, char task)>(Comparer<(int, char)>.Create((x, y) => y.Item1 == x.Item1 ? x.Item2.CompareTo(y.Item2) : y.Item1.CompareTo(x.Item1)));

            foreach (var kvp in taskCount)
            {
                maxHeap.Add((kvp.Value, kvp.Key));
            }

            int time = 0;
            while (maxHeap.Count > 0)
            {
                var tempList = new List<(int count, char task)>();
                for (int i = 0; i <= n; i++)
                {
                    if (maxHeap.Count > 0)
                    {
                        var current = maxHeap.Max;
                        maxHeap.Remove(current);
                        tempList.Add((current.count - 1, current.task));
                    }
                    time++;
                    if (maxHeap.Count == 0 && tempList.All(x => x.count == 0))
                    {
                        break;
                    }
                }

                foreach (var item in tempList)
                {
                    if (item.count > 0)
                    {
                        maxHeap.Add(item);
                    }
                }
            }

            return time;
        }


        // This method is an alternative approach that uses a greedy algorithm to solve the task scheduling problem.
        // Time Complexity: O(n) where n is the number of tasks
        // Space Complexity: O(1) since we are only using a few variables to store counts
        public int LeastIntervalGreedy(char[] tasks, int n)
        {
            // Count the occurrences of each task
            var taskCount = new Dictionary<char, int>();
            foreach (var task in tasks)
            {
                if (!taskCount.ContainsKey(task))
                {
                    taskCount[task] = 0;
                }
                taskCount[task]++;
            }

            // Find the maximum frequency of any task
            int maxFrequency = taskCount.Values.Max();
            // Count how many tasks have this maximum frequency
            int maxCount = taskCount.Values.Count(x => x == maxFrequency);

            // Calculate the minimum time required
            // The formula is:
            // max(tasks.Length, (maxFrequency - 1) * (n + 1) + maxCount)
            // This accounts for the maximum frequency of tasks, the cooldown period, and the number of tasks with that maximum frequency.
            return Math.Max(tasks.Length, (maxFrequency - 1) * (n + 1) + maxCount);
        }
    }
}
