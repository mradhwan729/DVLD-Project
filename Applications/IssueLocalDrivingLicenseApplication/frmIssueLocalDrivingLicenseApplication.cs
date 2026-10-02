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
using WindowsFormsApp_Project_DVLD_Course_19;

namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication
{
    public partial class frmIssueLocalDrivingLicenseApplication : Form
    {
        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        
        int _LocalDrivingLicenseApplicationID = -1;
       

        public frmIssueLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmIssueLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadDateChecked();

        }
        void _LoadDateChecked()
        {
            ctrlDrivingLicenseApplicationInfo1.LoadlDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.Find(_LocalDrivingLicenseApplicationID);


            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Nothing Date Local");
                this.Close();
                return;
            }

            clsLicense _License = clsLicense.GetLicenseInByApplicationID(_LocalDrivingLicenseApplication.ApplicationID);

            if (_License != null)
            {
                MessageBox.Show("Yes This is Person Have License");
                btnIssue.Enabled = false;
                rtxtNotes.Enabled = false;
                return;

            }

            byte _PassedTests = _LocalDrivingLicenseApplication.GetPassedTestCount();
            if (_PassedTests != 3)
            {
                MessageBox.Show("Error Please Agein The Test");
                btnIssue.Enabled = false;
                rtxtNotes.Enabled = false;
                return;
            }



        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            

            string Notes = rtxtNotes.Text.Trim();
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirstTime(Notes, clsGlobal.CurrentUser.ID);

            if (LicenseID !=-1)
            {
                MessageBox.Show("icense Issued Successfully with LicenseID: " + LicenseID);
                btnIssue.Enabled = false;
                rtxtNotes.Enabled = false;
            }
            else
            {
                MessageBox.Show("icense Issued Failed with LicenseID: " + LicenseID);

            }



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
