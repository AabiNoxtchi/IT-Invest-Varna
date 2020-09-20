namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        UserIdBeingRated = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserIdBeingRated)
                .Index(t => t.UserId)
                .Index(t => t.UserIdBeingRated);
            
            AlterColumn("dbo.KeyWords", "Word", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserIdBeingRated", "dbo.Users");
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropIndex("dbo.Ratings", new[] { "UserIdBeingRated" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            AlterColumn("dbo.KeyWords", "Word", c => c.String(maxLength: 100));
            DropTable("dbo.Ratings");
        }
    }
}
