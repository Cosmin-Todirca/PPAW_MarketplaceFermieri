namespace Repository_CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class insertData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO clientis Values('Mazarache','George','MG@acme.com','0712123123')," +
                "('Condensatu','Ion','CI@acme.com','0712123124');");

            Sql("INSERT INTO vanzatoris Values('Mazarachev','Georgev','MGv@acme.com','0712123103')," +
    "('Condensatuv','Ionv','CIv@acme.com','0712123104');");

        }

        public override void Down()
        {
        }
    }
}
