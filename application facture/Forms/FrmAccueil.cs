using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using DeclarationAlgerie;
using System.Threading;

namespace application_facture
{
    public partial class FrmAccueil : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmAccueil()
        {
            InitializeComponent();
        }
        public void FormshowNotParent(Form frm)
        {
            // waiting Form
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm1), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Veuillez patienter....");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
            }
            SplashScreenManager.CloseForm();
            //waiting Form
            // frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }
        private void BtnFacture_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormshowNotParent(application_facture.Forms.FrmFacture.InstanceFrmFacture);
        }
    }
}