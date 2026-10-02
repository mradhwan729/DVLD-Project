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

namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.Control
{
    public partial class ctrlShowLicnseInfo : UserControl
    {
        clsLicense _License;
        int ApplicationID = -1;
        int _LicenseID = -1;

        public clsLicense SelectedLicenseInfo => _License;
        public int LicenseID => _LicenseID;

        //public clsLicense SelectedLicenseInfo
        //{
        //    get { return _License; }
        //}
        //public int LicenseID
        //{
        //    get { return _LicenseID; }
        //}
        public ctrlShowLicnseInfo()
        {
            InitializeComponent();
        }
        void RestLicenseInfo()
        {
            _License = null;
            _LicenseID = -1;
            lblClass.Text = "???";
            lblName.Text = "???";
            lblLicenseID.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            lblIssueDate.Text = "???";
            lblIssueReason.Text = "???";
            lblNotes.Text = "???";
            lblIsActive.Text = "???";
            lblDateOfBirth.Text = "???";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "???";
            lblIsDetained.Text = "???";
        }

        public void Load_FillLicenseInfo(int LocalDrivingLicenseApplicationID)
        {

            clsLocalDrivingLicenseApplications LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.Find(LocalDrivingLicenseApplicationID);
            ApplicationID = LocalDrivingLicenseApplications.ApplicationID;
            _License = clsLicense.GetLicenseInByApplicationID(ApplicationID);



            if (_License == null)
            {
                RestLicenseInfo();
                MessageBox.Show("NoThing License Information.");
                return;
            }
            _FillLicenseInfo();
        }
        public bool Load_FillLicenseInfoByLicenseID(int LicenseID)
        {
            _License = clsLicense.Find(LicenseID);
            _LicenseID = LicenseID;
            if (_License == null)
            {
                RestLicenseInfo();
                MessageBox.Show("NoThing License Information.");
                return false;
            }
            _FillLicenseInfo();
            return true;
        }


        void _FillLicenseInfo()
        {
            lblClass.Text = _License.LicenseClassName;
            lblName.Text = _License.SelectedPersonInfo.SelectedPersonInfo.FullName;
            lblLicenseID.Text = _License.ID.ToString();
            lblNationalNo.Text = _License.SelectedPersonInfo.SelectedPersonInfo.NationalNo;
            lblGendor.Text = (_License.SelectedPersonInfo.SelectedPersonInfo.Gendor == 0 ? "Male" : "Famale");
            lblIssueDate.Text =_License.IssueDate.ToString();
            lblIssueReason.Text = ((clsLicense.enIssueReason)_License.IssueReason).ToString();
            lblNotes.Text = _License.Notes.ToString();
            lblIsActive.Text = (_License.IsActive == true ? "Yes" : "No");
            lblDateOfBirth.Text = _License.SelectedPersonInfo.SelectedPersonInfo.DateOfBirth.ToString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString();
            lblIsDetained.Text = (_License.IsDetained == true ? "Yes" : "No");


        }



        private void label6_Click(object sender, EventArgs e)
        {

        }




        private void ctrlShowLicnseInfo_Load(object sender, EventArgs e)
        {

        }

        private void gbDriverLicenseInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
