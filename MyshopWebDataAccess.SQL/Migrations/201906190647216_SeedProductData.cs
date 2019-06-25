namespace MyshopWebDataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProductData : DbMigration
    {
        public override void Up()
        { 
            Sql("INSERT INTO ProductCategories (Name) VALUES ('Food') ");
            Sql("INSERT INTO ProductCategories (Name) VALUES ('Seasoning') ");
            Sql("INSERT INTO ProductCategories (Name) VALUES ('Drink') ");
            Sql("INSERT INTO ProductCategories (Name) VALUES ('Stuff') ");
            Sql("INSERT INTO ProductCategories (Name) VALUES ('Others') ");
        }
        
        public override void Down()
        {
        }
    }
}
