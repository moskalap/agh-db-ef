namespace orderingProduct.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderDetailsModelChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "Product_ProductId" });
            AddColumn("dbo.OrderDetails", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "Product_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Product_ProductId", c => c.Int());
            DropColumn("dbo.OrderDetails", "ProductId");
            CreateIndex("dbo.OrderDetails", "Product_ProductId");
            AddForeignKey("dbo.OrderDetails", "Product_ProductId", "dbo.Products", "ProductId");
        }
    }
}
