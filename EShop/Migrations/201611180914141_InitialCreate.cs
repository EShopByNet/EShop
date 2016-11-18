namespace EShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        GoodsId = c.String(unicode: false),
                        UserId = c.String(unicode: false),
                        Number = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        Name = c.String(nullable: false, unicode: false),
                        IsShow = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Descript = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Nane = c.String(nullable: false, unicode: false),
                        CatId = c.Int(nullable: false),
                        DetailId = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        NickName = c.String(nullable: false, unicode: false),
                        Name = c.String(unicode: false),
                        Sex = c.String(unicode: false),
                        Age = c.Int(nullable: false),
                        Phone = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Salt = c.String(unicode: false),
                        OldPassword = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.Int(nullable: false),
                        GoodsId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
            DropTable("dbo.Members");
            DropTable("dbo.Goods");
            DropTable("dbo.Details");
            DropTable("dbo.Cats");
            DropTable("dbo.Carts");
        }
    }
}
