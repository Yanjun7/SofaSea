namespace SofaSea.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPropertiesOfGenreAndMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 225),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
