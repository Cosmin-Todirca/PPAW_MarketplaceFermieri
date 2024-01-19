namespace Repository_CodeFirst.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository_CodeFirst.marketplace_fermieriEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repository_CodeFirst.marketplace_fermieriEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-3
            context.vanzatori.AddOrUpdate(x => x.idVanzator,
                new vanzatori()
                {
                    idVanzator = 3,
                    numeVanzator = "Gemanatuv",
                    prenumeVanzator = "Andreiv",
                    numarTelefon = "0711123103",
                    email = "GAv@mail.com"
                },
                new vanzatori()
                {
                    idVanzator = 4,
                    numeVanzator = "Cretuv",
                    prenumeVanzator = "Alinv",
                    numarTelefon = "0711123104",
                    email = "CAv@mail.com"
                });
            context.clienti.AddOrUpdate(x => x.idClient,
            new clienti()
            {
                idClient = 3,
                numeClient = "Gemanatu",
                prenumeClient = "Andrei",
                numarTelefon = "0711123123",
                email = "GA@mail.com"
            },
            new clienti()
            {
                idClient = 4,
                numeClient = "Cretu",
                prenumeClient = "Alin",
                numarTelefon = "0711123124",
                email = "CA@mail.com"
            });
        }
    }
}
