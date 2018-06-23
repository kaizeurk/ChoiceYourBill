namespace ChoiceYourBill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedPoll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Polls", "IdPoll");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Polls", "IdPoll", c => c.Int(nullable: false));
            DropColumn("dbo.Polls", "Name");
        }
    }
}
