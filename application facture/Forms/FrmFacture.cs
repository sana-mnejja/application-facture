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
using application_facture.Model.Enum;

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

            // Define a list to store LigneFacture objects
            List<LigneFacture> listeLignesFacture = new List<LigneFacture>();

            // Loop through each row in gridView1
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                // Create a new LigneFacture object for each row
                LigneFacture ligneFacture = new LigneFacture();

                // Retrieve the value of the 'Produit' column
                object produitValue = gridView1.GetRowCellValue(i, "Produit");

                // Retrieve the value of the 'Quantite' column
                int QuantiteValue = (int)gridView1.GetRowCellValue(i, "Quantite");
                object uniteCellValue = gridView1.GetRowCellValue(i, "Unite");

                if (uniteCellValue != null)
                {
                    if (Enum.TryParse(uniteCellValue.ToString(), out EnumUnite uniteValue))
                    {
                        ligneFacture.Unite = uniteValue;
                    }
                    else
                    {
                        // Handle the case where the value cannot be parsed as EnumUnite
                        // For example, set a default value or log an error
                    }
                }
                else
                {
                    // Handle the case where uniteCellValue is null
                    // For example, set a default value or log an error
                }

                // Retrieve the value of the 'PrixUnitaireTTC' column
                decimal PrixUnitaireTTC = (decimal)gridView1.GetRowCellValue(i, "PrixUnitaireTTC");

                // Calculate the 'MontantTTC' based on the 'QuantiteValue' and 'PrixUnitaireTTC'
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
           .AppliquerUneUnite(Convertisseur.Entite.Unite.Creer("dinar", "dinars", " millime", "millimes"))
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