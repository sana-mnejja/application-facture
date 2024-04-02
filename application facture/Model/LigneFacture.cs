
using application_facture.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public EnumUnite Unite { get; set; }
        public decimal PrixUnitaireTTC { get; set; }

        public string MontantString { get; set; }


        [Required]
        public decimal MontantTTC { get { return Math.Round(Decimal.Multiply(PrixUnitaireTTC, Quantite)); } }


    }
}
