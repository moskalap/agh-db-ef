namespace lab2_f.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProCe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "ProductId_ProductId", c => c.Int());
            CreateIndex("dbo.OrderDetails", "ProductId_ProductId");
            AddForeignKey("dbo.OrderDetails", "ProductId_ProductId", "dbo.Products", "ProductId");
            DropColumn("dbo.OrderDetails", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderDetails", "ProductId_ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId_ProductId" });
            DropColumn("dbo.OrderDetails", "ProductId_ProductId");
        }
    }
}
