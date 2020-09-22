﻿namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateNameIntoMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE DurationInMonths = 0");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE DurationInMonths = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Quar erly' WHERE DurationInMonths = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly' WHERE DurationInMonths = 12");
        }

        public override void Down()
        {
            Sql("UPDATE MembershipTypes SET Name = Default");
        }
    }
}
