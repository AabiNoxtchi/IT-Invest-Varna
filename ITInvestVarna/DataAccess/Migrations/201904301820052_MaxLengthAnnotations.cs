namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "City", c => c.String(maxLength: 100));
            AlterColumn("dbo.Addresses", "Street", c => c.String(maxLength: 250));
            AlterColumn("dbo.Addresses", "Number", c => c.String(maxLength: 5));
            AlterColumn("dbo.PhoneNumbers", "Phone_Number", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Articles", "Type", c => c.String(maxLength: 100));
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.KeyWords", "Word", c => c.String(maxLength: 100));
            DropColumn("dbo.Users", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.KeyWords", "Word", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Articles", "Type", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.PhoneNumbers", "Phone_Number", c => c.String());
            AlterColumn("dbo.Addresses", "Number", c => c.String());
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
        }
    }
}
