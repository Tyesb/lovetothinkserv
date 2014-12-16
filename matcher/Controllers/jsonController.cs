using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using matcher;
using matcher.Models;



namespace LoveToThinkServiceFinal.Controllers
{

    public class jsonController : ApiController
    {
        public MatcherDb db = new MatcherDb();
        // GET: api/json
        //public IQueryable<Post> Get() 
        //{
        //    return db.Users;
        //}

        // GET: api/json/5
        public List<returnObj> Get(int id)
        {
            List<returnObj> sending = new List<returnObj>();
            //IQueryable<TMatching> lst = (db.TMatchings.Where(w => w.TweetID1 == id));
            foreach (var ret in (db.TMatchings.Where(w => w.TweetID1 == id || w.TweetID2 == id)))
            {
                returnObj returned = new returnObj();
                returned.UserIdOne =(int) ret.TweetID1;
                returned.UserIdTwo = (int)ret.TweetID2;
                returned.Weight = (double) (1 - (ret.Weight / 100));
                sending.Add(returned);

            }
            sending.Distinct();
            return sending;
        }

        // POST: api/json
        public List<returnObj> Post([FromBody]fun.RootObject json)
        {
            foreach (var t in json.tweets)
            {
                foreach (var h in t.hashtags)
                {
                    Tweet input = new Tweet();
                    input.TweetID = (db.Tweets.Count() + 1);
                    input.VideoLabel = h.ToString();
                    input.UserID = json.user_id;
                    db.Tweets.Add(input);
                    db.SaveChanges();
                }
            }
            foreach (var vl in json.videos)
            {
                Video video = new Video();
                video.VidID = (db.Videos.Count() + 1);
                video.UserID = json.user_id;
                video.VideoLabel = vl.label;
                db.Videos.Add(video);
                db.SaveChanges();
            }
            List<returnObj> callback = new List<returnObj>();
            foreach (var f in db.Tweets)
            {
                returnObj ret = new returnObj();
                ret.UserIdOne = (int)f.UserID;
                callback.Add(ret);
            }
            Matcha mtc = new Matcha();
            mtc.UsersPrevPosts(json.user_id);
            //foreach (var i in json)
            //{
            //    Console.Write(i.user_id);
            // }
            //foreach (var t in json.user.tweets)
            //{
            //    foreach (var tweet in t.hashtags)
            //    {
            //        Tweet valueTweet = new Tweet();
            //        valueTweet.UserID = json.user.user_id;
            //        valueTweet.VideoLabel = tweet;
            //        db.Tweets.Add(valueTweet);
            //    }
            //}
            //foreach (var q in json.user.videos)
            //{
            //    foreach (var vid in q.label)
            //    {
            //        Video video = new Video();
            //        video.UserID = json.user.user_id;
            //        video.VideoLabel = q.label;
            //    }
            //}
            //db.SaveChanges();
            // Matcha.UsersPrevPosts(json.user.user_id);
            //foreach (var VARIABLE in json)
            //{

            //}
            //returnObj callback = new returnObj();
            //callback.UserIdOne = json.user.user_id;
            //callback.UserIdTwo = json.matches.Count;

            //foreach (var V in json.matches)
            //{
            //    foreach (var uid2 in db.TMatchings.Where(w => w.TweetID2 != json.user.user_id))
            //    {
            //    TMatching t = new TMatching();
            //    t.TweetID1 = json.user.user_id;
            //    t.TweetID2 = uid2.TweetID2;
            //    Matcha.UsersPrevPosts(json.user.user_id);
            //    }

            //    foreach (var aa in )
            //    {

            //        returnObj callback = new returnObj();
            //        callback.UserIdOne = json.user.user_id;
            //        callback.UserIdTwo = json.matches.Count;
            //        //callback.tweetweight = (double)aa.content / db.TMatchings.Count(w => w.TweetID1 == callback.UserIdOne && w.TweetID2 == callback.UserIdTwo);
            //        callback.tweetweight = (double)(json.matches.Count() / json.user.tweets);
            //        callback.vidweight = (double)(json.matches.Count() / json.user.videos.Count);

            //        return callback;
            //    }
            //}
            return callback;
        }

        // PUT: api/json/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/json/5
        public void Delete(int id)
        {
        }
    }
}
