using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAlgo.LeetCode.Design
{
    internal class L355_DesignTwitter
    {
        // Time Complexity: O(1) for postTweet, follow, and unfollow operations. O(n log k) for getNewsFeed where n is the number of tweets and k is the number of tweets to retrieve.
        // Space Complexity: O(u + t) where u is the number of users and t is the total number of tweets.
        private readonly Dictionary<int, HashSet<int>> _follows; // Maps userId to a set of userIds they follow
        private readonly Dictionary<int, List<(int TweetId, int Time)>> _tweets; // Maps userId to a list of their tweets (TweetId, Time)
        private int _timestamp;

        public L355_DesignTwitter()
        {
            _follows = new Dictionary<int, HashSet<int>>();
            _tweets = new Dictionary<int, List<(int, int)>>();
            _timestamp = 0;
        }

        // Post a new tweet
        public void PostTweet(int userId, int tweetId)
        {
            if (!_tweets.ContainsKey(userId))
            {
                _tweets[userId] = new List<(int, int)>();
            }

            // Ensure the user follows themself so their tweets appear in their feed
            if (!_follows.ContainsKey(userId))
            {
                _follows[userId] = new HashSet<int> { userId };
            }
            else
            {
                _follows[userId].Add(userId);
            }
            // Add the new tweet with the current timestamp
            _tweets[userId].Add((tweetId, ++_timestamp));
        }

        public IList<int> GetNewsFeed(int userId)
        {
            var result = new List<int>();

            // If user has no follow list, still include themselves
            if (!_follows.ContainsKey(userId))
            {
                _follows[userId] = new HashSet<int> { userId };
            }

            var followees = _follows[userId];

            var candidates = new List<(int TweetId, int Time)>();

            foreach (var fid in followees)
            {
                if (!_tweets.TryGetValue(fid, out var list)) continue;
                // take up to last 10 tweets from this followee (they are appended in time order)
                int take = Math.Min(10, list.Count);
                for (int i = list.Count - take; i < list.Count; i++)
                {
                    candidates.Add(list[i]);
                }
            }

            // get top 10 by timestamp
            foreach (var t in candidates.OrderByDescending(x => x.Time).Take(10))
            {
                result.Add(t.TweetId);
            }

            return result;
        }

        public void Follow(int followerId, int followeeId)
        {
            if (!_follows.ContainsKey(followerId))
            {
                _follows[followerId] = new HashSet<int> { followerId };
            }

            // create entry for followee to avoid missing user later (optional)
            if (!_follows.ContainsKey(followeeId))
            {
                _follows[followeeId] = new HashSet<int> { followeeId };
            }

            _follows[followerId].Add(followeeId);
        }

        public void Unfollow(int followerId, int followeeId)
        {
            // cannot unfollow self
            if (followerId == followeeId) return;

            if (!_follows.ContainsKey(followerId)) return;

            _follows[followerId].Remove(followeeId);
        }


    }
}
