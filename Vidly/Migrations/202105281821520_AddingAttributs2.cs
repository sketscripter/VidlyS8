namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAttributs2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IDN", c => c.String(maxLength: 14));
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "Phone", c => c.String());
            AddColumn("dbo.Movies", "Director", c => c.String());
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Studio", c => c.String());
            AddColumn("dbo.Series", "Director", c => c.String());
            AddColumn("dbo.Series", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Series", "Studio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Series", "Studio");
            DropColumn("dbo.Series", "ReleaseDate");
            DropColumn("dbo.Series", "Director");
            DropColumn("dbo.Movies", "Studio");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "Director");
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "IDN");
        }
    }
}
