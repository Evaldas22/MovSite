namespace MovSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReleaseDatePropertyToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.Int());
            AddColumn("dbo.TVShows", "ReleaseDate", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TVShows", "ReleaseDate");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
