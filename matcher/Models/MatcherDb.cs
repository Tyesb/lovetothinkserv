namespace matcher.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MatcherDb : DbContext
    {
        public MatcherDb()
            : base("name=MatcherDb")
        {
        }

        public virtual DbSet<TMatching> TMatchings { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<VMatching> VMatchings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
