namespace BugsBox.Pharmacy.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFS : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesOrder", "SalerName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SalesOrder", "SalerName", c => c.String(nullable: false));
        }
    }
}
