using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace application_facture.Model
{
    public class Facture
    {
        [Key]

        public int Id { get; set; }
        // Propriétés
        public string Numero { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public List<LigneFacture> Lignes { get; set; }


        // Constructeur
        public Facture(string numero, DateTime date, string client)
        {
            Numero = numero;
            Date = date;
            Client = client;
            Lignes = new List<LigneFacture>();
        }

        // Méthode pour ajouter une ligne à la facture
        public void AjouterLigne(string produit, int quantite, double prixUnitaire)
        {
            Lignes.Add(new LigneFacture(produit, quantite, prixUnitaire));
        }

        // Méthode pour calculer le montant total de la facture
        public double CalculerMontantTotal()
        {
            double total = 0;
            foreach (var ligne in Lignes)
            {
                total += ligne.Montant();
            }
            return total;
        }
    }
}
