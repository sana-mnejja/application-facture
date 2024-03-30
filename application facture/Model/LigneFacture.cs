
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
        public string  Unite { get; set; }
        public double PrixUnitaireTTC { get; set; }
        public double MontantTTC { get; set; }
        public string MontantString { get; set; }


       
       
    }
}
