namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasestart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        City = c.String(),
                        Street = c.String(),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        AddressId = c.Int(),
                        Phone_Number = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.AddressId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        Phone = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        IsCompany = c.Boolean(nullable: false),
                        ImgPath = c.String(),
                        About = c.String(),
                        ActivationCode = c.Guid(nullable: false),
                        IsEmailVerified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        DateTimeModified = c.DateTime(precision: 0, storeType: "datetime2"),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Type = c.String(),
                        StartDateTime = c.DateTime(precision: 0, storeType: "datetime2"),
                        EndDateTime = c.DateTime(precision: 0, storeType: "datetime2"),
                        Location = c.String(),
                        ImgPath = c.String(),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        DateTimeModified = c.DateTime(precision: 0, storeType: "datetime2"),
                        Text = c.String(),
                        UserId = c.Int(),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ArticleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgPath = c.String(),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.KeyWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SearchHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        UserId = c.Int(),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ArticleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.KeyWordArticles",
                c => new
                    {
                        KeyWord_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KeyWord_Id, t.Article_Id })
                .ForeignKey("dbo.KeyWords", t => t.KeyWord_Id, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .Index(t => t.KeyWord_Id)
                .Index(t => t.Article_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Articles", "UserId", "dbo.Users");
            DropForeignKey("dbo.SearchHistories", "UserId", "dbo.Users");
            DropForeignKey("dbo.SearchHistories", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.KeyWordArticles", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.KeyWordArticles", "KeyWord_Id", "dbo.KeyWords");
            DropForeignKey("dbo.Galleries", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Addresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.PhoneNumbers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.PhoneNumbers", new[] { "UserId" });
            DropIndex("dbo.Articles", new[] { "UserId" });
            DropIndex("dbo.SearchHistories", new[] { "UserId" });
            DropIndex("dbo.SearchHistories", new[] { "ArticleId" });
            DropIndex("dbo.KeyWordArticles", new[] { "Article_Id" });
            DropIndex("dbo.KeyWordArticles", new[] { "KeyWord_Id" });
            DropIndex("dbo.Galleries", new[] { "ArticleId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropIndex("dbo.PhoneNumbers", new[] { "AddressId" });
            DropTable("dbo.KeyWordArticles");
            DropTable("dbo.SearchHistories");
            DropTable("dbo.KeyWords");
            DropTable("dbo.Galleries");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
            DropTable("dbo.Users");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.Addresses");
        }
    }
}
