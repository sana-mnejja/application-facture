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

       

        
    }
}
