namespace MyshopWebDataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProductData1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('���þ�z',220,1)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('���t�ް���',180,1)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('LE PRALINE ��u���J�O',580,1)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('�q�j�Q�Q�S�Q',500,2)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('�g�����ը���',140,2)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('�k�� Chateau des Graviers ���s',1080,3)");
            Sql("INSERT Products(Name,Price,ProductCategory_Id) VALUES('Catherine & Claude Marechal Pommard���s',2200,3)");
        }
        
        public override void Down()
        {
        }
    }
}
