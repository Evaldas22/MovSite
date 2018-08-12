namespace MovSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedReleasedDatePropertyFromModels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.TVShows", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TVShows", "ReleaseDate", c => c.DateTime());
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
        }
    }
}
