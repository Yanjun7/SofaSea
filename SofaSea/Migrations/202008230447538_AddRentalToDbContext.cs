namespace SofaSea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalToDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        customer_ID = c.Int(nullable: false),
                        movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.movie_Id, cascadeDelete: true)
                .Index(t => t.customer_ID)
                .Index(t => t.movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "customer_ID", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "movie_Id" });
            DropIndex("dbo.Rentals", new[] { "customer_ID" });
            DropTable("dbo.Rentals");
        }
    }
}
