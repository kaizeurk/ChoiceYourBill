namespace ChoiceYourBill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRestaurantOnPoll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurants", "Poll_Id", "dbo.Polls");
            DropIndex("dbo.Restaurants", new[] { "Poll_Id" });
            DropColumn("dbo.Restaurants", "Poll_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Poll_Id", c => c.Int());
            CreateIndex("dbo.Restaurants", "Poll_Id");
            AddForeignKey("dbo.Restaurants", "Poll_Id", "dbo.Polls", "Id");
        }
    }
}
