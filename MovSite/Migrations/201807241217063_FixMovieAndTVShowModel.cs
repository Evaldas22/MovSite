namespace MovSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMovieAndTVShowModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TVShows", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TVShows", "WhenSeen", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TVShows", "RatingInIMDB", c => c.Double(nullable: false));
            AlterColumn("dbo.TVShows", "MyRating", c => c.Double(nullable: false));
            DropColumn("dbo.Movies", "Seen");
            DropColumn("dbo.TVShows", "Seen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TVShows", "Seen", c => c.Boolean());
            AddColumn("dbo.Movies", "Seen", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TVShows", "MyRating", c => c.Double());
            AlterColumn("dbo.TVShows", "RatingInIMDB", c => c.Double());
            AlterColumn("dbo.TVShows", "WhenSeen", c => c.DateTime());
            AlterColumn("dbo.TVShows", "ReleaseDate", c => c.DateTime());
        }
    }
}
