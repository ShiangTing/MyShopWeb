namespace MyshopWebDataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeViewModelToProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItemViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItemViewModels", "Product_Id", "dbo.Products");
            DropIndex("dbo.CartItemViewModels", new[] { "Product_Id" });
            DropTable("dbo.CartItemViewModels");
        }
    }
}
