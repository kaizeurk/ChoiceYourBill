namespace ChoiceYourBill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_foreign_key_on_new_vote : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Votes", "User_Id", "dbo.Users");
            DropIndex("dbo.Votes", new[] { "Restaurant_Id" });
            DropIndex("dbo.Votes", new[] { "User_Id" });
            RenameColumn(table: "dbo.Votes", name: "Restaurant_Id", newName: "RestaurantId");
            RenameColumn(table: "dbo.Votes", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Votes", "RestaurantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Votes", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Votes", "RestaurantId");
            CreateIndex("dbo.Votes", "UserId");
            AddForeignKey("dbo.Votes", "RestaurantId", "dbo.Restaurants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Votes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Votes", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Votes", new[] { "UserId" });
            DropIndex("dbo.Votes", new[] { "RestaurantId" });
            AlterColumn("dbo.Votes", "UserId", c => c.Int());
            AlterColumn("dbo.Votes", "RestaurantId", c => c.Int());
            RenameColumn(table: "dbo.Votes", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Votes", name: "RestaurantId", newName: "Restaurant_Id");
            CreateIndex("dbo.Votes", "User_Id");
            CreateIndex("dbo.Votes", "Restaurant_Id");
            AddForeignKey("dbo.Votes", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Votes", "Restaurant_Id", "dbo.Restaurants", "Id");
        }
    }
}
