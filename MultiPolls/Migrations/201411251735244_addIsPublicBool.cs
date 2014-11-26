namespace MultiPolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsPublicBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "IsPublic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Polls", "IsPublic");
        }
    }
}
