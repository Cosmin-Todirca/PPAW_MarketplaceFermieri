namespace Repository_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primaIncercare_10112023 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.clientis",
                c => new
                    {
                        idClient = c.Int(nullable: false, identity: true),
                        numeClient = c.String(),
                        prenumeClient = c.String(),
                        email = c.String(),
                        numarTelefon = c.String(),
                    })
                .PrimaryKey(t => t.idClient);
            
            CreateTable(
                "dbo.comenzis",
                c => new
                    {
                        idComanda = c.Int(nullable: false, identity: true),
                        idClient = c.Int(nullable: false),
                        dataComanda = c.DateTime(nullable: false),
                        situatieComanda = c.String(),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.idComanda)
                .ForeignKey("dbo.clientis", t => t.idClient, cascadeDelete: true)
                .Index(t => t.idClient);
            
            CreateTable(
                "dbo.obiecteComandas",
                c => new
                    {
                        idObiectComanda = c.Int(nullable: false, identity: true),
                        idComanda = c.Int(nullable: false),
                        idProdus = c.Int(nullable: false),
                        idClient = c.Int(nullable: false),
                        situatiePlata = c.String(),
                        cantitateComanda = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.idObiectComanda)
                .ForeignKey("dbo.clientis", t => t.idClient, cascadeDelete: true)
                .ForeignKey("dbo.comenzis", t => t.idComanda, cascadeDelete: true)
                .ForeignKey("dbo.produses", t => t.idProdus, cascadeDelete: true)
                .Index(t => t.idComanda)
                .Index(t => t.idProdus)
                .Index(t => t.idClient);
            
            CreateTable(
                "dbo.produses",
                c => new
                    {
                        idProdus = c.Int(nullable: false, identity: true),
                        idVanzator = c.Int(nullable: false),
                        numeProdus = c.String(),
                        descriereProdus = c.String(),
                        pret = c.Decimal(nullable: false, precision: 18, scale: 2),
                        unitateDeMasura = c.String(),
                        cantitate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        imagine = c.String(),
                    })
                .PrimaryKey(t => t.idProdus)
                .ForeignKey("dbo.vanzatoris", t => t.idVanzator, cascadeDelete: true)
                .Index(t => t.idVanzator);
            
            CreateTable(
                "dbo.vanzatoris",
                c => new
                    {
                        idVanzator = c.Int(nullable: false, identity: true),
                        numeVanzator = c.String(),
                        prenumeVanzator = c.String(),
                        email = c.String(),
                        numarTelefon = c.String(),
                    })
                .PrimaryKey(t => t.idVanzator);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.obiecteComandas", "idProdus", "dbo.produses");
            DropForeignKey("dbo.produses", "idVanzator", "dbo.vanzatoris");
            DropForeignKey("dbo.obiecteComandas", "idComanda", "dbo.comenzis");
            DropForeignKey("dbo.obiecteComandas", "idClient", "dbo.clientis");
            DropForeignKey("dbo.comenzis", "idClient", "dbo.clientis");
            DropIndex("dbo.produses", new[] { "idVanzator" });
            DropIndex("dbo.obiecteComandas", new[] { "idClient" });
            DropIndex("dbo.obiecteComandas", new[] { "idProdus" });
            DropIndex("dbo.obiecteComandas", new[] { "idComanda" });
            DropIndex("dbo.comenzis", new[] { "idClient" });
            DropTable("dbo.vanzatoris");
            DropTable("dbo.produses");
            DropTable("dbo.obiecteComandas");
            DropTable("dbo.comenzis");
            DropTable("dbo.clientis");
        }
    }
}
