namespace EShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Goods");
        }
    }
}
