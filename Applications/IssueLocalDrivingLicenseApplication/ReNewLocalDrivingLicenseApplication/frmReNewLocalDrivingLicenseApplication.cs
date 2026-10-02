using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBusness;
using DVLDBusinessLayer;

namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication
{
    public partial class frmReNewLocalDrivingLicenseApplication : Form
    {
        int _SelectedLicenseID = -1;
        int _NewLicenseID = -1;
        public frmReNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();

        }
        void LoadLicenseData()
        {
            clsLicense SelectedLicense = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo;

            float ApplicationFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReNew).ApplicationFees;
            float LicenseFees = SelectedLicense.LicenseClassInfo.ClassFees;

            lblLicenseFees.Text = LicenseFees.ToString();

            lblTotalFees.Text = (ApplicationFees + LicenseFees).ToString();
            lblExpirationeDate.Text = DateTime.Now.AddYears(ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength).ToShortDateString();
            lblOldLicenseID.Text = _SelectedLicenseID.ToString();


        }
        private void ctrlShowLicnseInfoWithFilter1_OnLicenseSelected(int SelectedLicenseID)
        {
            _SelectedLicenseID = SelectedLicenseID;

            lnkShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {

                ResetDefueltLicenseReNew();
                return;
            }

            clsLicense SelectedLicense = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo;


            if (SelectedLicense == null)
            {
                MessageBox.Show("Null Of License");
                return;
            }
            if (SelectedLicense.IsDetained == true)
            {
                MessageBox.Show("License Is Detained");
                btnReNew.Enabled = false;
                return;
            }

            if (SelectedLicense.ExpirationDate > DateTime.Now)
            {
                MessageBox.Show("This License Not Expiration Date " + _SelectedLicenseID + " it.");
                btnReNew.Enabled = false;
                return;
            }
            if (SelectedLicense.IsActive != true)
            {
                MessageBox.Show("Not The  License Active Exume Ser try Other Again ");
                btnReNew.Enabled = false;
                return;
            }

            LoadLicenseData();
            btnReNew.Enabled = true;

        }


        void ResetDefueltLicenseReNew()
        {

            float ApplicationFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReNew).ApplicationFees;

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationeDate.Text = "???";
            lblCreatedByUserName.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = ApplicationFees.ToString();
            lblLicenseFees.Text = "???";
            lblTotalFees.Text = "???";

            lblRLApplicationID.Text = "[???]";
            lblReNewLicenseID.Text = "[???]";
            lblOldLicenseID.Text = "[???]";

            btnReNew.Enabled = false;
            lnkShowLicense.Enabled = false;
            lnkShowLicenseHistory.Enabled = false;


        }
        private void frmReNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlShowLicnseInfoWithFilter1.OnLicenseSelected += ctrlShowLicnseInfoWithFilter1_OnLicenseSelected;

            ResetDefueltLicenseReNew();
            if (_SelectedLicenseID != -1)
            {
                ctrlShowLicnseInfoWithFilter1.LoadLicenseWithFilter(_SelectedLicenseID);
                ctrlShowLicnseInfoWithFilter1.FiltirEnable = true;
            }


        }

        private void ctrlShowLicnseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت تأكد من رغبتك في تجديد هذه الرخصة؟", "تأكيد",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.ID);

            if (NewLicense != null)
            {
                MessageBox.Show("Seccefull Renew License");
                lblRLApplicationID.Text = NewLicense.ApplicationID.ToString();
                lblReNewLicenseID.Text = NewLicense.ID.ToString();
                _NewLicenseID = NewLicense.ID;
                btnReNew.Enabled = false;
                ctrlShowLicnseInfoWithFilter1.FiltirEnable = false;
                lnkShowLicense.Enabled = true;
            }
            else
            {
                MessageBox.Show("Failed Renew License");

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int PersonID = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmLicenseHistory frm = new frmLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicnseInfo.ShowByLicenseID(_NewLicenseID);
        }

        private void lblOldLicenseID_Click(object sender, EventArgs e)
        {

        }

        private void lblApplicationFees_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void lblCreatedByUserName_Click(object sender, EventArgs e)
        {

        }

        private void lblExpirationeDate_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void lblApplicationDate_Click(object sender, EventArgs e)
        {

        }

        private void lblRLApplicationID_Click(object sender, EventArgs e)
        {

        }

        private void lblIssueDate_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void lblReNewLicenseID_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void lblApplicationID_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void gbApplicationInfo_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalFees_Click(object sender, EventArgs e)
        {

        }

        private void lblLicenseFees_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
