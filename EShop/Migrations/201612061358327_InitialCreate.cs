namespace EShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cart",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        GoodsId = c.String(nullable: false, unicode: false),
                        UserId = c.String(nullable: false, unicode: false),
                        Number = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.cat",
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
                "dbo.detail",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Descript = c.String(unicode: false),
                        pics = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.goods",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Nane = c.String(nullable: false, maxLength: 25, storeType: "nvarchar"),
                        CatId = c.Int(nullable: false),
                        DetailId = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.member",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        NickName = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                        Sex = c.String(unicode: false),
                        Age = c.Int(nullable: false),
                        Phone = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                        Salt = c.String(nullable: false, unicode: false),
                        OldPassword = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.order",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.Int(nullable: false),
                        GoodsId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.store",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        name = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        logo = c.String(unicode: false),
                        userId = c.String(nullable: false, unicode: false),
                        storeLv = c.Int(nullable: false),
                        isDisable = c.Int(nullable: false),
                        bussinessLicense = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        address = c.String(unicode: false),
                        descript = c.String(unicode: false),
                        createTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.store");
            DropTable("dbo.order");
            DropTable("dbo.member");
            DropTable("dbo.goods");
            DropTable("dbo.detail");
            DropTable("dbo.cat");
            DropTable("dbo.cart");
        }
    }
}
