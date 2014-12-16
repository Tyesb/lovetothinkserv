namespace matcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedlabellengthtweet : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tweet", "VideoLabel", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tweet", "VideoLabel", c => c.String(maxLength: 20));
        }
    }
}
