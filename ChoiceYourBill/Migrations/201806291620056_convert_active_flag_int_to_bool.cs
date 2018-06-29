namespace ChoiceYourBill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convert_active_flag_int_to_bool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Polls", "ActiveFlag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Polls", "ActiveFlag", c => c.Int(nullable: false));
        }
    }
}
