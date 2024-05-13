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
using DevExpress.XtraSplashScreen;
using System.Threading;
using application_facture.Rapport;
using DevExpress.XtraReports.UI;
using System.Globalization;
using DevExpress.XtraReports.Parameters;


namespace application_facture.Forms
{
    public partial class FrmAccueil : DevExpress.XtraEditors.XtraForm
    {
        private static FrmAccueil _FrmAccueil;
        public static FrmAccueil InstanceFrmAccueil
        {
            get
            {
                if (_FrmAccueil == null)
                    _FrmAccueil = new FrmAccueil();
                return _FrmAccueil;
            }
        }
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
        public void Formshow(Form frm)
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
            frm.MdiParent =Application.OpenForms.OfType<MainRibbonForm>().First();
            frm.Show();
            frm.Activate();
        }

        private void FrmAccueil_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmAccueil = null;
        }

     
        

       

       

       

        

       


      

        private void FrmAccueil_Load(object sender, EventArgs e)
        {
            // verification de licence
           //  LicenseInvalideLayout(tileIClients);
            //   AuthorisationdeLayout(tileIClients);

        }
        void LicenseInvalideLayout(TileItem item)
        {
            item.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkGray;
            item.AppearanceItem.Normal.Options.UseBackColor = true;
            item.Tag = 0;
        }
        void AuthorisationdeLayout(TileItem item)
        {
            item.AppearanceItem.Normal.BackColor = System.Drawing.Color.DarkSlateGray;
            item.AppearanceItem.Normal.Options.UseBackColor = true;
            item.Tag = 0;
        }

       

    

        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            Formshow(application_facture.Forms.FrmFacture.InstanceFrmFacture); 
        }


       

       
       
    }
}