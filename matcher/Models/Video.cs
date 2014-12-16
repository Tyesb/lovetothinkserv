namespace matcher.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Video")]
    public partial class Video
    {
        [Key]
        public long VidID { get; set; }

        public DateTime? AddedDate { get; set; }

        public int? UserID { get; set; }

        [StringLength(20)]
        public string VideoLabel { get; set; }
    }
}
