namespace matcher.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tweet")]
    public partial class Tweet
    {
        public long TweetID { get; set; }

        public DateTime? AddedDate { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string VideoLabel { get; set; }
    }
}
