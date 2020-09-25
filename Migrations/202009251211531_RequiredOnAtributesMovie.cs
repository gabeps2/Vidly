namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredOnAtributesMovie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Genre", c => c.String(maxLength: 255));
            AlterColumn("dbo.Movies", "name", c => c.String(maxLength: 255));
        }
    }
}
