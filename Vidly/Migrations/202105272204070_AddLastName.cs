namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "LastName");
        }
    }
}
