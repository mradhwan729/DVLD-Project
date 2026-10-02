using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;
using DataBusness;


namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.DetainedLicenses
{
    public partial class frmDetainedLicenses : Form
    {
        int _SelectedLicenseID = -1;
        public frmDetainedLicenses()
        {
            InitializeComponent();
        }



        private void frmDetainedLicenses_Load(object sender, EventArgs e)
        {
            ctrlShowLicnseInfoWithFilter1.OnLicenseSelected += ctrlShowLicnseInfoWithFilter1_OnLicenseSelected;
            btnDetain.Enabled = false;


        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            float FineFees = Convert.ToSingle(txtFineFees.Text.Trim());
            clsDetainedLicenses detainedLicense = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.DetainLicense(FineFees, clsGlobal.CurrentUser.ID);
            if (detainedLicense != null)
            {
                MessageBox.Show("License Detained Successfully with ID=" + detainedLicense.ID, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // عرض رقم الحجز في الشاشة
                lblDetainID.Text = detainedLicense.ID.ToString();

                // تعطيل زر الحجز والأداة لمنع التكرار
                btnDetain.Enabled = false;
                ctrlShowLicnseInfoWithFilter1.FiltirEnable = false;
                txtFineFees.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed to Detain License!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ctrlShowLicnseInfoWithFilter1_OnLicenseSelected(int SelectedLicenseID)
        {


            _SelectedLicenseID = SelectedLicenseID;

            lnkShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                //ResetDefueltLicenseReNew();
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
                btnDetain.Enabled = false;
                return;
            }

            btnDetain.Enabled = true;

        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_SelectedLicenseID != -1)
            {
                frmShowLicnseInfo.ShowByLicenseID(_SelectedLicenseID);
            }
        }

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_SelectedLicenseID != -1)
            {
                int PersonID = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
                frmLicenseHistory frm = new frmLicenseHistory(PersonID);
                frm.ShowDialog();
            }
        }

        private void ctrlShowLicnseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
