using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Helpers;
using matcher.Models;

namespace matcher
{
    public class Matcha
    {

        public void UsersPrevPosts(int id)
        {
            List<string> Tweets = GetUserTweets(id);
            List<Tweet> othersTweets = GetTweetsByNotId(id);
            SaveMatches(id, Tweets, othersTweets);
        }

        private List<string> GetUserTweets(int id)
        {
            using (var db = new MatcherDb())
            {
                IQueryable<string> usertweets = db.Tweets.Where(w => w.UserID == id).Select(tweet => tweet.VideoLabel);
                return usertweets.ToList();
            }
        }

        private List<Tweet> GetTweetsByNotId(int id)
        {
            using (var db = new MatcherDb())
            {
                IQueryable<Tweet> potentialtweets = db.Tweets.Where(w => w.UserID != id).Distinct();
                return potentialtweets.ToList();
            }
        }

        private void SaveMatches(int id, List<string> mytweets, List<Tweet> yourtweets)
        {
            List<double> weight = new List<double>();
            foreach (string mytweet in mytweets)
            {
                foreach (var yourtweet in yourtweets)
                {
                    CalculateWeight(weight, mytweet, yourtweet);
                    GetValue(id, weight, yourtweet);
                }
                weight = new List<double>().Distinct().ToList();
            }
        }

        private void GetValue(int id, List<double> weight, Tweet yourtweet)
        {
            using (var db = new MatcherDb())
            {
                TMatching matcHH = new TMatching();
                matcHH.Weight = (weight.Sum());
                matcHH.TweetID1 = id;
                matcHH.TweetID2 = (int)yourtweet.UserID;
                db.TMatchings.Add(matcHH);
                db.SaveChanges();
            }
        }

        private static void CalculateWeight(List<double> weight, string mytweet, Tweet yourtweet)
        {
            GetMatches name = new GetMatches();
            weight.Add((double)name.LevenshteinDistance(mytweet, yourtweet.VideoLabel) / (weight.Count +1));
        }
    }

    public class GetMatches
    {

        public int LevenshteinDistance(string src, string dest)
        {
            int[,] d = new int[src.Length + 1, dest.Length + 1];
            int i, j, cost;
            char[] str1 = src.ToCharArray();
            char[] str2 = dest.ToCharArray();

            for (i = 0; i <= str1.Length; i++)
            {
                d[i, 0] = i;
            }
            for (j = 0; j <= str2.Length; j++)
            {
                d[0, j] = j;
            }
            for (i = 1; i <= str1.Length; i++)
            {
                for (j = 1; j <= str2.Length; j++)
                {

                    cost = str1[i - 1] == str2[j - 1] ? 0 : 1;
                    //same as this:
                    //if (str1[i - 1] == str2[j - 1])
                    //    cost = 0;
                    //else
                    //    cost = 1;


                    d[i, j] =
                        Math.Min(
                            d[i - 1, j] + 1, // Deletion
                            Math.Min(
                                d[i, j - 1] + 1, // Insertion
                                d[i - 1, j - 1] + cost)); // Substitution

                    if ((i > 1) && (j > 1) && (str1[i - 1] ==
                                               str2[j - 2]) && (str1[i - 2] == str2[j - 1]))
                    {
                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                    }
                }
            }

            return d[str1.Length, str2.Length];
        }


        //public static List<string> Search(
        //    string word,
        //    List<string> wordList,
        //    double fuzzyness)
        //{
        //    // Tests have prove that the !LINQ-variant is about 3 times
        //    // faster!
        //    List<string> foundWords =
        //        (
        //            from s in wordList
        //            let levenshteinDistance = LevenshteinDistance(word, s)
        //            let length = Math.Max(s.Length, word.Length)
        //            let score = 1.0 - (double)levenshteinDistance / length
        //            where score > fuzzyness
        //            select s
        //            ).ToList();

        //    return foundWords;

        //}
    }
}