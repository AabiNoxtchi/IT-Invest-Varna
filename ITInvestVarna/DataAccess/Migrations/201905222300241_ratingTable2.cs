namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingTable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropIndex("dbo.Ratings", new[] { "UserId" });
            AlterColumn("dbo.Ratings", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Ratings");
            AddPrimaryKey("dbo.Ratings", "Id");
            CreateIndex("dbo.Ratings", "UserId");
            AddForeignKey("dbo.Ratings", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropPrimaryKey("dbo.Ratings");
            AddPrimaryKey("dbo.Ratings", "UserId");
            AlterColumn("dbo.Ratings", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "UserId");
            AddForeignKey("dbo.Ratings", "UserId", "dbo.Users", "Id");
        }
    }
}
