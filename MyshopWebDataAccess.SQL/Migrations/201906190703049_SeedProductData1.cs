namespace MyshopWebDataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProductData1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('原味臘腸',220,1)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('煙燻豬培根',180,1)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('LE PRALINE 手工巧克力',580,1)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('義大利松露鹽',500,2)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('迷迭香調味罐',140,2)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('法國 Chateau des Graviers 紅酒',1080,3)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('Catherine & Claude Marechal Pommard紅酒',2200,3)");
        }
        
        public override void Down()
        {
        }
    }
}
