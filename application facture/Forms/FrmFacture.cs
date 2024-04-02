using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using application_facture.Rapport;
using DevExpress.XtraReports.UI;
using application_facture.Model;
using DevExpress.XtraGrid.Views.Grid;
using Convertisseur;
using Convertisseur.Entite;
using DevExpress.XtraPrinting;
using System.IO;

namespace application_facture.Forms
{
    public partial class FrmFacture : DevExpress.XtraEditors.XtraForm
    {
 
        private static FrmFacture _FrmFacture;
        public static FrmFacture InstanceFrmFacture
        {
            get
            {
                if (_FrmFacture == null)
                    _FrmFacture = new FrmFacture();
                return _FrmFacture;
            }
        }
        public FrmFacture()
        {
             Model.ApplicationContext db = new Model.ApplicationContext();
            InitializeComponent();

        }

        private void FrmFacture_Load(object sender, EventArgs e)
        {

        }

        private void FrmFacture_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmFacture = null;
           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void BtnFacture_Click(object sender, EventArgs e)
        {

            List<LigneFacture> listeLignesFacture = new List<LigneFacture>();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                // Create a new LigneFacture object for each iteration
                LigneFacture ligneFacture = new LigneFacture();

                // Obtain the value of the "Produit" column for the current row
                object produitValue = gridView1.GetRowCellValue(i, "Produit");
                // Cast the value of the "Quantite" column to an int
                int QuantiteValue = (int)gridView1.GetRowCellValue(i, "Quantite");
 
                // Cast the value of the "PrixUnitaireTTC" column to a double
                decimal PrixUnitaireTTC = (decimal)gridView1.GetRowCellValue(i, "PrixUnitaireTTC");
                // Calculate the total amount including tax
                decimal MontantTTC = QuantiteValue * PrixUnitaireTTC;

                // Assign values to properties of the LigneFacture object
                ligneFacture.Produit = produitValue.ToString();
                ligneFacture.Quantite = QuantiteValue;
             
                ligneFacture.PrixUnitaireTTC = PrixUnitaireTTC;
             

                // Add the LigneFacture object to the list
                listeLignesFacture.Add(ligneFacture);
            }






            RapportFacture RapportF = new RapportFacture();


            var convertisseur = ConvertisseurNombreEnLettre.Parametrage
           .AppliquerUneUnite(Unite.Creer("dinar", "dinars", " millime", "millimes"))
.ModifierLaVirgule("et")
           .ValiderLeParametrage();
            decimal totalMontantTTC = listeLignesFacture.Sum(x => x.MontantTTC);
            string montantEnLettres = convertisseur.Convertir(totalMontantTTC);
            RapportF.Parameters["Client"].Value = TxtClient.Text;
            RapportF.Parameters["dateemission"].Value = DateTime.Now;
            RapportF.Parameters["TotalTTC"].Value = listeLignesFacture.Sum(x => x.MontantTTC);
            RapportF.Parameters["TotalEnChiffre"].Value = montantEnLettres;
            RapportF.DataSource = listeLignesFacture;
     
            ReportPrintTool tool = new ReportPrintTool(RapportF);
            RapportF.ShowPreview();
            // Spécifier les options d'exportation PDF
            PdfExportOptions options = new PdfExportOptions();
            options.ShowPrintDialogOnOpen = true; // Afficher la boîte de dialogue d'impression lors de l'ouverture du PDF
            options.Compressed = true; // Activer la compression du PDF

            // Exportation du rapport vers un fichier PDF sur le bureau
            string pdfFileName = "RapportFacture1.pdf";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string pdfFilePath = Path.Combine(desktopPath, pdfFileName);

            RapportF.ExportToPdf(pdfFilePath, options);

            // Afficher un message pour informer l'utilisateur que le rapport a été exporté avec succès
            MessageBox.Show("Le rapport a été exporté sur votre bureau sous le nom : " + pdfFileName, "Exportation réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void repositoryItemButtonDelete_Click(object sender, EventArgs e)
        {
            gridView1.DeleteSelectedRows();
        }
    }
}