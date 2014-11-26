namespace MultiPolls.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmailConfirmation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "ConfirmedEmail", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ConfirmedEmail");
            DropColumn("dbo.AspNetUsers", "Email");
        }
    }
}
