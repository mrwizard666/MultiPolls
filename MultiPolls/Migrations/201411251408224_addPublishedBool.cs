namespace MultiPolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPublishedBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "IsPublished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Polls", "IsPublished");
        }
    }
}
