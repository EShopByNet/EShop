namespace EShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        goodsId = c.String(nullable: false, maxLength: 128, unicode: false),
                        small = c.String(unicode: false),
                        big = c.String(unicode: false),
                        tiny = c.String(unicode: false),
                        thumbnail = c.String(unicode: false),
                        original = c.String(unicode: false),
                        isDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        goodsId = c.String(nullable: false, maxLength: 128, unicode: false),
                        userId = c.String(nullable: false, maxLength: 128, unicode: false),
                        number = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cat",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 20, unicode: false),
                        parentId = c.Int(nullable: false),
                        description = c.String(unicode: false),
                        themePic = c.String(unicode: false),
                        isShow = c.Boolean(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        name = c.String(nullable: false, maxLength: 25, storeType: "nvarchar"),
                        remarks = c.String(maxLength: 100, storeType: "nvarchar"),
                        image = c.String(unicode: false),
                        costPrice = c.Double(nullable: false),
                        price = c.Double(nullable: false),
                        catId = c.Int(nullable: false),
                        selesCount = c.Int(nullable: false),
                        comment = c.Int(nullable: false),
                        sealCountAftermonth = c.Int(nullable: false),
                        praise = c.Int(nullable: false),
                        collectCount = c.Int(nullable: false),
                        inventory = c.Int(nullable: false),
                        area = c.String(unicode: false),
                        createTime = c.String(unicode: false),
                        publishTime = c.String(unicode: false),
                        modifyTime = c.String(unicode: false),
                        detail = c.String(unicode: false),
                        isPublish = c.Boolean(nullable: false),
                        isDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        nickName = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        name = c.String(unicode: false),
                        sex = c.String(unicode: false),
                        age = c.Int(nullable: false),
                        phone = c.String(unicode: false),
                        address = c.String(unicode: false),
                        email = c.String(unicode: false),
                        password = c.String(nullable: false, unicode: false),
                        salt = c.String(nullable: false, unicode: false),
                        oldPassword = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        userId = c.String(nullable: false, maxLength: 128, unicode: false),
                        goodsId = c.String(nullable: false, maxLength: 128, unicode: false),
                        number = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        orderState = c.Int(nullable: false),
                        consigneeName = c.String(unicode: false),
                        consigneeAddress = c.String(unicode: false),
                        consigneePhone = c.String(nullable: false, unicode: false),
                        message = c.String(unicode: false),
                        createDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        goodsId = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        name = c.String(nullable: false, maxLength: 15, storeType: "nvarchar"),
                        logo = c.String(unicode: false),
                        userId = c.String(nullable: false, maxLength: 128, unicode: false),
                        storeLv = c.Int(nullable: false),
                        isDisable = c.Int(nullable: false),
                        bussinessLicense = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        address = c.String(unicode: false),
                        descript = c.String(unicode: false),
                        createTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Store");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Order");
            DropTable("dbo.Member");
            DropTable("dbo.Goods");
            DropTable("dbo.Cat");
            DropTable("dbo.Cart");
            DropTable("dbo.Album");
        }
    }
}
