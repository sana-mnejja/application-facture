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
            

            RapportFacture RapportF = new RapportFacture();


            List<Facture> Listefacture = new List<Facture>();

            RapportF.Parameters["Client"].Value = TxtClient.Text;
            RapportF.Parameters["dateemission"].Value = DateTime.Now;
            RapportF.DataSource = Listefacture;

            ReportPrintTool tool = new ReportPrintTool(RapportF);
            tool.ShowPreview();
        }
    }
}