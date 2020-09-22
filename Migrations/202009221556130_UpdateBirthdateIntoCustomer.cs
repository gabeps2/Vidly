namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthdateIntoCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '19/01/1999' WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = '20/03/1980' WHERE Id = 2");
        }
        
        public override void Down()
        {
            Sql("UPDATE Customers SET Birthdate = '' WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = '' WHERE Id = 2");
        }
    }
}
