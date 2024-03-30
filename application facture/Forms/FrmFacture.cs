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
    }
}