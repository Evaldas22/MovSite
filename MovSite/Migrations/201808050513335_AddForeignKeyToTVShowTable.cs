namespace MovSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToTVShowTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TVShows", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.TVShows", "UserID");
            AddForeignKey("dbo.TVShows", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TVShows", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.TVShows", new[] { "UserID" });
            DropColumn("dbo.TVShows", "UserID");
        }
    }
}
