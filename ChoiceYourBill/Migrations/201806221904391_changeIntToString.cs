namespace ChoiceYourBill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Polls", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Polls", "Name", c => c.Int(nullable: false));
        }
    }
}
