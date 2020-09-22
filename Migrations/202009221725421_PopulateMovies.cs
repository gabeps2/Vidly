namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Wall-e', 'Kids', 09/11/2020, 09/11/2020, 5)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Shrek!', 'Kids', 09/11/2020, 09/11/2020, 1)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('Titanic', 'Comedy', 09/11/2020, 09/11/2020, 2)");
            Sql("INSERT INTO Movies (Name, Genre, ReleaseDate, DateAdded, NumberInStock) VALUES ('300', 'War', 09/11/2020, 09/11/2020, 3)");
        }

        public override void Down()
        {
            Sql("DELETE * FROM Movies");
        }
    }
}
