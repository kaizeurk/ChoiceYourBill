namespace ChoiceYourBill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContracts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Pwd", c => c.String());
            AlterColumn("dbo.Users", "Lastname", c => c.String(nullable: false, maxLength: 80));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Lastname", c => c.String());
            DropColumn("dbo.Users", "Pwd");
        }
    }
}
