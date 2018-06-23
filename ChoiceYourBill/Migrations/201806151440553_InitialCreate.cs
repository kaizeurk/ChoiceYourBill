namespace ChoiceYourBill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPoll = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdVote = c.Int(nullable: false),
                        Restaurant_Id = c.Int(),
                        User_Id = c.Int(),
                        Poll_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Polls", t => t.Poll_Id)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Poll_Id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdResto = c.Int(nullable: false),
                        Name = c.String(),
                        Fone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        Firstname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Poll_Id", "dbo.Polls");
            DropForeignKey("dbo.Votes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Votes", "Restaurant_Id", "dbo.Restaurants");
            DropIndex("dbo.Votes", new[] { "Poll_Id" });
            DropIndex("dbo.Votes", new[] { "User_Id" });
            DropIndex("dbo.Votes", new[] { "Restaurant_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Votes");
            DropTable("dbo.Polls");
        }
    }
}
