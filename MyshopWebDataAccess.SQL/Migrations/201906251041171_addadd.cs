namespace MyshopWebDataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addadd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "ProductCategory_Id", newName: "CategoryId");
            RenameIndex(table: "dbo.Products", name: "IX_ProductCategory_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_ProductCategory_Id");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "ProductCategory_Id");
        }
    }
}
