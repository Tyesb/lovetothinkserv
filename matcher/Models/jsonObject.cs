using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoveToThinkServiceFinal.Models
{

    public class Tweet
    {
        public string content { get; set; }
        public List<object> hashtags { get; set; }
    }

    public class Video
    {
        public string title { get; set; }
        public string description { get; set; }
        public string label { get; set; }
        public string author { get; set; }
    }

    public class Track
    {
        public string title { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string genre { get; set; }
        public string track_url { get; set; }
        public string image_url { get; set; }
        public List<object> tags { get; set; }
    }

    public class RootObject
    {
        public int user_id { get; set; }
        public List<Tweet> tweets { get; set; }
        public List<Video> videos { get; set; }
        public List<Track> tracks { get; set; }
    }
}

//    public class jsonObject
//    {
//        public class Tweet
//        {
//            public string content { get; set; }
//            public List<string> hashtags { get; set; }
//        }

//        public class Tweet2
//        {
//            public string content { get; set; }
//            public List<string> hashtags { get; set; }
//        }

//        public class Video
//        {
//            public string url { get; set; }
//            public string title { get; set; }
//            public string description { get; set; }
//            public string label { get; set; }
//            public string author { get; set; }
//            public List<string> keywords { get; set; }
//        }

//        public class User
//        {
//            public int user_id { get; set; }
//            public List<Tweet> tweets { get; set; }
//            public List<Video> videos { get; set; }
//        }



//        //public class Video2
//        //{
//        //    public string url { get; set; }
//        //    public string title { get; set; }
//        //    public string description { get; set; }
//        //    public string label { get; set; }
//        //    public string author { get; set; }
//        //    public List<string> keywords { get; set; }
//        //}

//        public class Match
//        {
//            public int user_id { get; set; }
//            public List<Tweet2> tweets { get; set; }
//          //  public List<Video2> videos { get; set; }
//        }

//        public class RootObject
//        {
//            public User user { get; set; }
//            public List<Match> matches { get; set; }
//        }
//    }
//}