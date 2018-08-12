namespace MovSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeSomePropertiesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "WhenSeen", c => c.DateTime());
            AlterColumn("dbo.Movies", "RatingInIMDB", c => c.Double());
            AlterColumn("dbo.TVShows", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.TVShows", "WhenSeen", c => c.DateTime());
            AlterColumn("dbo.TVShows", "RatingInIMDB", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TVShows", "RatingInIMDB", c => c.Double(nullable: false));
            AlterColumn("dbo.TVShows", "WhenSeen", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TVShows", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "RatingInIMDB", c => c.Double(nullable: false));
            AlterColumn("dbo.Movies", "WhenSeen", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
