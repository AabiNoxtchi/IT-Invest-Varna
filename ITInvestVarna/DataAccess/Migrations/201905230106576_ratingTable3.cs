namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "RatingValue", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 100));
            DropColumn("dbo.Ratings", "RatingValue");
        }
    }
}
