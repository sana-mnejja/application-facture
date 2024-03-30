namespace application_facture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class montantsting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LigneFactures", "MontantTTC", c => c.Double(nullable: false));
            AddColumn("dbo.LigneFactures", "MontantString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LigneFactures", "MontantString");
            DropColumn("dbo.LigneFactures", "MontantTTC");
        }
    }
}
