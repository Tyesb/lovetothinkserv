namespace matcher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _fixed : DbMigration
    {
        public override void Up()
        {
       //     RenameTable(name: "dbo.TMatchings", newName: "TMatching");
        }
        
        public override void Down()
        {
          //  RenameTable(name: "dbo.TMatching", newName: "TMatchings");
        }
    }
}
