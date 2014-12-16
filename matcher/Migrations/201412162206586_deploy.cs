namespace matcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deploy : DbMigration
    {
        public override void Up()
        {
            //DropPrimaryKey("dbo.TMatching");
            //AddColumn("dbo.TMatching", "id", c => c.Int(nullable: false, identity: true));
            //AddPrimaryKey("dbo.TMatching", "id");
        }
        
        public override void Down()
        {
            //DropPrimaryKey("dbo.TMatching");
            //DropColumn("dbo.TMatching", "id");
            //AddPrimaryKey("dbo.TMatching", new[] { "TweetID1", "TweetID2" });
        }
    }
}
