namespace ChoiceYourBill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_active_flag_in_poll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "ActiveFlag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Polls", "ActiveFlag");
        }
    }
}
