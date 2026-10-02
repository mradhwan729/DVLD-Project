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

namespace WindowsFormsApp_Project_DVLD_Course_19.Applactions.Control
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;
        private int _LocalDrivingLicenseApplicationID;

        public clsLocalDrivingLicenseApplications SelectedLocalDrivingLicenseApplicationsInfo
        {
            get { return _LocalDrivingLicenseApplications; }
        }
        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public void LoadlDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {

            
            _LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.Find(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicenseApplications == null)
            {
                MessageBox.Show("No Thing LocalDrivingLicenseApplications");
                return;
            }
            _LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID;
            lblLocalDrivingLicenseApplicationID.Text = LocalDrivingLicenseApplicationID.ToString();

            lblApplicationID.Text = _LocalDrivingLicenseApplications.ApplicationID.ToString();
            lblLicnseClass.Text = _LocalDrivingLicenseApplications.LicenseClassInfo.ClassName;
            lblPassedTest.Text =_LocalDrivingLicenseApplications.GetPassedTestCount().ToString() + "/3";
            lblStatus.Text = _LocalDrivingLicenseApplications.ApplicationStatus.ToString();
            lblFees.Text = _LocalDrivingLicenseApplications.PaidFees.ToString();
            lblType.Text = _LocalDrivingLicenseApplications.ApplicationTypeClassName;
           lblDate.Text = _LocalDrivingLicenseApplications.ApplicationDate.ToShortDateString();
            lblApplicant.Text =_LocalDrivingLicenseApplications.SelectedPersonInfo.FullName;
            lblStatusDate.Text = _LocalDrivingLicenseApplications.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.ID.ToString();
            

        }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void gbApplicationBasicInfo_Enter(object sender, EventArgs e)
        {

        }

        private void lklPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_LocalDrivingLicenseApplications.SelectedPersonInfo.PersonID);
            frm.ShowDialog();
        }
    }
}
