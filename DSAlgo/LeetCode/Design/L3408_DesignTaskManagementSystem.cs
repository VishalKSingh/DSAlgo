using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Design
{
    internal class L3408_DesignTaskManagementSystem
    {
        // This problem requires us to design a task management system that allows adding tasks, marking them as completed, and retrieving the next task to be completed based on priority and timestamp.
        // We can use a combination of dictionaries and priority queues (heaps) to efficiently manage the tasks.
        // Time Complexity: O(log n) for addTask and completeTask operations due to heap operations, O(1) for getNextTask
        // Space Complexity: O(n) for storing the tasks

        private class Task
        {
            public int TaskId { get; set; }
            public int Priority { get; set; }
            public int Timestamp { get; set; }

            public Task(int taskId, int priority, int timestamp)
            {
                TaskId = taskId;
                Priority = priority;
                Timestamp = timestamp;
            }
        }

        private class TaskComparer : IComparer<Task>
        {
            public int Compare(Task x, Task y)
            {
                if (x.Priority != y.Priority)
                    return y.Priority.CompareTo(x.Priority); // Higher priority first
                return x.Timestamp.CompareTo(y.Timestamp); // Earlier timestamp first
            }
        }

        private Dictionary<int, Task> taskMap; // Maps taskId to Task
        private SortedSet<Task> taskSet; // Sorted set of tasks based on priority and timestamp
        private int currentTime;

        public L3408_DesignTaskManagementSystem()
        {
            taskMap = new Dictionary<int, Task>();
            taskSet = new SortedSet<Task>(new TaskComparer());
            currentTime = 0;
        }

        public void AddTask(int taskId, int priority)
        {
            var task = new Task(taskId, priority, currentTime++);
            taskMap[taskId] = task;
            taskSet.Add(task);
        }

        public void CompleteTask(int taskId)
        {
            if (taskMap.ContainsKey(taskId))
            {
                var task = taskMap[taskId];
                taskSet.Remove(task);
                taskMap.Remove(taskId);
            }
        }

        public int GetNextTask()
        {
            if (taskSet.Count == 0) return -1;
            return taskSet.Min.TaskId; // Return the taskId of the highest priority and earliest timestamp task
        }
    }
}
