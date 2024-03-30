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
                // Retrieve the value of the "Unite" column
                object Unite = gridView1.GetRowCellValue(i,"Unite");
                // Cast the value of the "PrixUnitaireTTC" column to a double
                double PrixUnitaireTTC = (double)gridView1.GetRowCellValue(i, "PrixUnitaireTTC");
                // Calculate the total amount including tax
                double MontantTTC = QuantiteValue * PrixUnitaireTTC;

                // Assign values to properties of the LigneFacture object
                ligneFacture.Produit = produitValue.ToString();
                ligneFacture.Quantite = QuantiteValue;
                ligneFacture.Unite = Unite.ToString(); ;
                ligneFacture.PrixUnitaireTTC = PrixUnitaireTTC;
                ligneFacture.MontantTTC = MontantTTC;

                // Add the LigneFacture object to the list
                listeLignesFacture.Add(ligneFacture);
            }






            RapportFacture RapportF = new RapportFacture();


            

            RapportF.Parameters["Client"].Value = TxtClient.Text;
            RapportF.Parameters["dateemission"].Value = DateTime.Now;
            RapportF.DataSource = listeLignesFacture;

            ReportPrintTool tool = new ReportPrintTool(RapportF);
            tool.ShowPreview();
        }
    }
}