using DataBusness;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.DetainedAndReleaseDetainedLicenses
{
    public partial class frmReleaseDetainedLicense : Form
    {
        int _SelectedLicenseID = -1;

        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }


        private void ctrlShowLicnseInfoWithFilter1_OnLicenseSelected(int SelectedLicenseID)
        {

            _SelectedLicenseID = SelectedLicenseID;
            lnkShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            clsLicense SelectedLicense = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo;
            if (SelectedLicense == null)
            {
                MessageBox.Show("No Thing License Data");
                return;
            }
            if (SelectedLicense.IsDetained == false)
            {
                MessageBox.Show("This is Not License Detained");
                return;
            }

            btnRelease.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsApplications applications = new clsApplications();
            applications.ApplicantPersonID = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            applications.ApplicationDate = DateTime.Now;
            applications.LastStatusDate = DateTime.Now;
            applications.ApplicationTypeID = (int)clsApplications.enApplicationType.ReleaseDetained;
            applications.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            applications.PaidFees = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.ReleaseDetained).ApplicationFees;
            applications.CreatedByUserID = clsGlobal.CurrentUser.ID;
            if (!applications.Save())
                return;

            clsDetainedLicenses DetainedLicenses = clsDetainedLicenses.FindByLicenseID(_SelectedLicenseID);
            bool IsReleased = DetainedLicenses.ReleaseDetainLicense(clsGlobal.CurrentUser.ID, applications.ID);


            if (IsReleased)
            {
                MessageBox.Show("Detained License Released Successfully with Application ID = " + applications.ID,
                                "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRelease.Enabled = false;
                lnkShowLicenseHistory.Enabled = true;
                ctrlShowLicnseInfoWithFilter1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed to release the detained license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            ctrlShowLicnseInfoWithFilter1.OnLicenseSelected += ctrlShowLicnseInfoWithFilter1_OnLicenseSelected;
            btnRelease.Enabled = false;
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

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_SelectedLicenseID != -1)
            {
                frmShowLicnseInfo.ShowByLicenseID(_SelectedLicenseID);
            }
        }
    }
}
