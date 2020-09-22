namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetailsIntoMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255),
                        Genre = c.String(maxLength: 255),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
