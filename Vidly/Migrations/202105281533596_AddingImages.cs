namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Poster", c => c.String());
            AddColumn("dbo.Movies", "Banner", c => c.String());
            AddColumn("dbo.Movies", "Description", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Description");
            DropColumn("dbo.Movies", "Banner");
            DropColumn("dbo.Movies", "Poster");
        }
    }
}
