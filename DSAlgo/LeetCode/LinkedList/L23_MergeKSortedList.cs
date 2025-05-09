using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.LinkedList
{
    public class L23_MergeKSortedList
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;

            while (lists.Length > 1)
            {
                List<ListNode> mergedLists = new List<ListNode>();
                for (int i = 0; i < lists.Length; i += 2)
                {
                    if (i + 1 < lists.Length)
                    {
                        mergedLists.Add(MergeTwoLists(lists[i], lists[i + 1]));
                    }
                    else
                    {
                        mergedLists.Add(lists[i]);
                    }
                }
                lists = mergedLists.ToArray();
            }

            return lists[0];
        }

        private ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }
    }
}
