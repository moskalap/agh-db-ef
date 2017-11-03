namespace lab2_f.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModelChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EMail", c => c.String());
            AddColumn("dbo.Customers", "Adress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Adress");
            DropColumn("dbo.Customers", "EMail");
        }
    }
}
