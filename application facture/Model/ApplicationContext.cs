using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using application_facture.Migrations;

namespace application_facture.Model
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Context")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Configuration>());

            Database.CommandTimeout = 0;
            this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 3));
        }

        public DbSet<Facture> factures { get; set; }
        public DbSet<LigneFacture> ligneFactures { get; set; }
    }
}
