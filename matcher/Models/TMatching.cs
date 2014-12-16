namespace matcher.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("TMatching")]
    public partial class TMatching
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long TweetID1 { get; set; }

        public long TweetID2 { get; set; }

        public double? Weight { get; set; }
    }
}
