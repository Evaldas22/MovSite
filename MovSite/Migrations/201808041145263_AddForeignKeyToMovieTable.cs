namespace MovSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToMovieTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Movies", "UserID");
            AddForeignKey("dbo.Movies", "UserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Movies", new[] { "UserID" });
            DropColumn("dbo.Movies", "UserID");
        }
    }
}
