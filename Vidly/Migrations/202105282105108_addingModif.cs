namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModif : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Series", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Series", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
