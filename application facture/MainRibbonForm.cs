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
using System.Threading;
using DevExpress.XtraWaitForm;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using application_facture.Model;
using application_facture.Forms;
using application_facture;

namespace application_facture
{
    public partial class MainRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        public MainRibbonForm()
        {
            InitializeComponent();
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
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
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

      
      

        private void MainRibbonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

     

       

       

       
        
       

        private void bardashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(application_facture.Forms.FrmAccueil.InstanceFrmAccueil);
        }

        private void MainRibbonForm_Load(object sender, EventArgs e)
        {
            Formshow(application_facture.Forms.FrmAccueil.InstanceFrmAccueil);
        }

      


      


        private void barButtonItemDevis_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formshow(application_facture.Forms.FrmFacture.InstanceFrmFacture);
        }

      

       
       
        
    }
}