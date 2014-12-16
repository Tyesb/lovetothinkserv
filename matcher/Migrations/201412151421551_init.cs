namespace matcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TMatching",
                c => new
                {
                        id = c.Int(nullable:  false, identity: true),
                        TweetID1 = c.Long(nullable: false),
                        TweetID2 = c.Long(nullable: false),
                        Weight = c.Int(),
                    })
                .PrimaryKey(t => new{ t.id });
            
            CreateTable(
                "dbo.Tweet",
                c => new
                    {
                        TweetID = c.Long(nullable: false, identity: true),
                        AddedDate = c.DateTime(),
                        UserID = c.Int(),
                        VideoLabel = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.TweetID);
            
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        VidID = c.Long(nullable: false, identity: true),
                        AddedDate = c.DateTime(),
                        UserID = c.Int(),
                        VideoLabel = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.VidID);
            
            CreateTable(
                "dbo.VMatching",
                c => new
                    {
                        Vid1 = c.Long(nullable: false),
                        Vid2 = c.Long(nullable: false),
                        Weight = c.Int(),
                    })
                .PrimaryKey(t => new { t.Vid1, t.Vid2 });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VMatching");
            DropTable("dbo.Video");
            DropTable("dbo.Tweet");
            DropTable("dbo.TMatching");
        }
    }
}
