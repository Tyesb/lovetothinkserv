using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace matcher.Models
{
    public class fun
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
}