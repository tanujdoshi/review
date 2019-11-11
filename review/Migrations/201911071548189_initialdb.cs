namespace review.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.adminns",
                c => new
                    {
                        Adminid = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Adminid);
            
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        productname = c.String(),
                        img = c.String(),
                        catId = c.Int(nullable: false),
                        subcatId = c.Int(nullable: false),
                        category_Id = c.Int(),
                        subcategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.categories", t => t.category_Id)
                .ForeignKey("dbo.subcategories", t => t.subcategory_Id)
                .Index(t => t.category_Id)
                .Index(t => t.subcategory_Id);
            
            CreateTable(
                "dbo.reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        content = c.String(),
                        rating = c.Int(nullable: false),
                        productId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.products", t => t.productId, cascadeDelete: true)
                .ForeignKey("dbo.users", t => t.userId, cascadeDelete: true)
                .Index(t => t.productId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        catId = c.Int(nullable: false),
                        category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.categories", t => t.category_Id)
                .Index(t => t.category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.products", "subcategory_Id", "dbo.subcategories");
            DropForeignKey("dbo.subcategories", "category_Id", "dbo.categories");
            DropForeignKey("dbo.reviews", "userId", "dbo.users");
            DropForeignKey("dbo.reviews", "productId", "dbo.products");
            DropForeignKey("dbo.products", "category_Id", "dbo.categories");
            DropIndex("dbo.subcategories", new[] { "category_Id" });
            DropIndex("dbo.reviews", new[] { "userId" });
            DropIndex("dbo.reviews", new[] { "productId" });
            DropIndex("dbo.products", new[] { "subcategory_Id" });
            DropIndex("dbo.products", new[] { "category_Id" });
            DropTable("dbo.subcategories");
            DropTable("dbo.users");
            DropTable("dbo.reviews");
            DropTable("dbo.products");
            DropTable("dbo.categories");
            DropTable("dbo.adminns");
        }
    }
}
