
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application_facture.Model
{
    public class LigneFacture
    {
        // Propriétés
        public int Id { get; set; }
        public string Produit { get; set; }
        public int Quantite { get; set; }
        public double PrixUnitaire { get; set; }

      

        // Méthode pour calculer le montant de cette ligne
        public double Montant()
        {
            return Quantite * PrixUnitaire;
        }
        // Constructeur
        public LigneFacture(string produit, int quantite, double prixUnitaire)
        {
            Produit = produit;
            Quantite = quantite;
            PrixUnitaire = prixUnitaire;
        }
    }
}
