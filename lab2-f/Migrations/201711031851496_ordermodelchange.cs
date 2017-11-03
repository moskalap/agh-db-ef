namespace lab2_f.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordermodelchange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "CompanyName_CompanyName", newName: "CompanyName");
            RenameIndex(table: "dbo.Orders", name: "IX_CompanyName_CompanyName", newName: "IX_CompanyName");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_CompanyName", newName: "IX_CompanyName_CompanyName");
            RenameColumn(table: "dbo.Orders", name: "CompanyName", newName: "CompanyName_CompanyName");
        }
    }
}
