namespace application_facture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LigneFactures", "Unite", c => c.String());
            AddColumn("dbo.LigneFactures", "PrixUnitaireTTC", c => c.Double(nullable: false));
            DropColumn("dbo.LigneFactures", "PrixUnitaire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LigneFactures", "PrixUnitaire", c => c.Double(nullable: false));
            DropColumn("dbo.LigneFactures", "PrixUnitaireTTC");
            DropColumn("dbo.LigneFactures", "Unite");
        }
    }
}
