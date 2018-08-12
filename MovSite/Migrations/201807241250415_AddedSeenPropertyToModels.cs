namespace MovSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeenPropertyToModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Seen", c => c.Boolean(nullable: false));
            AddColumn("dbo.TVShows", "Seen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TVShows", "Seen");
            DropColumn("dbo.Movies", "Seen");
        }
    }
}
