namespace application_facture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Date = c.DateTime(nullable: false),
                        Client = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LigneFactures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Produit = c.String(),
                        Quantite = c.Int(nullable: false),
                        PrixUnitaire = c.Double(nullable: false),
                        Facture_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factures", t => t.Facture_Id)
                .Index(t => t.Facture_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LigneFactures", "Facture_Id", "dbo.Factures");
            DropIndex("dbo.LigneFactures", new[] { "Facture_Id" });
            DropTable("dbo.LigneFactures");
            DropTable("dbo.Factures");
        }
    }
}
