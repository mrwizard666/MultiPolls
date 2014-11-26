namespace MultiPolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addHasVotedBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "HasVoted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Polls", "HasVoted");
        }
    }
}
