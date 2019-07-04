namespace MyshopWebDataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductCategories", "ParentId", c => c.Int());
            AddColumn("dbo.ProductCategories", "RootCategory_Id", c => c.Int());
            CreateIndex("dbo.ProductCategories", "RootCategory_Id");
            AddForeignKey("dbo.ProductCategories", "RootCategory_Id", "dbo.ProductCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "RootCategory_Id", "dbo.ProductCategories");
            DropIndex("dbo.ProductCategories", new[] { "RootCategory_Id" });
            DropColumn("dbo.ProductCategories", "RootCategory_Id");
            DropColumn("dbo.ProductCategories", "ParentId");
        }
    }
}
