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
using WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication;

namespace WindowsFormsApp_Project_DVLD_Course_19.Applications
{
    public partial class frmIntrnationalLicenseApplication : Form
    {
        int _SelectedLicenseID = -1;
        int _IntrnationalLicenseID = -1;
        public frmIntrnationalLicenseApplication()
        {
            InitializeComponent();
        }

        void DefultLicenseValue()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblExpirationeDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblFees.Text = clsApplicationTypes.Find(6).ApplicationFees.ToString();
            btnIssue.Enabled = false;
        }
        private void frmIntrnationalLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlShowLicnseInfoWithFilter1.OnLicenseSelected += ctrlShowLicnseInfoWithFilter1_OnLicenseSelected;
            DefultLicenseValue();
            if (_SelectedLicenseID != -1)
            {
                ctrlShowLicnseInfoWithFilter1.LoadLicenseWithFilter(_SelectedLicenseID);
                ctrlShowLicnseInfoWithFilter1.FiltirEnable = false;
            }

        }

        private void ctrlShowLicnseInfoWithFilter1_OnLicenseSelected(int SelectedLicenseID)
        {
            _SelectedLicenseID = SelectedLicenseID;
            lblLocalLicenseID.Text = _SelectedLicenseID.ToString();
            lnkShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1) return;

            clsLicense SelectedLicenseInfo = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo;
            if (SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("No The Class License Equel Orderiny");
                btnIssue.Enabled = false;
                return;
            }
            if (SelectedLicenseInfo.IsActive != true)
            {
                MessageBox.Show("Not The  License Active Exume Ser try Other Again ");
                btnIssue.Enabled = false;
                return;
            }
            int activeInternationalLicenseID = clsInternationalLicenses.GetActiveInternationalLicenseIDByDriverID(SelectedLicenseInfo.DriverID);
            if (activeInternationalLicenseID != -1)
            {
                MessageBox.Show($"Person already has an active international license with ID = {activeInternationalLicenseID}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }


            btnIssue.Enabled = true;

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            if (ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo == null)
            {
                MessageBox.Show("الرجاء اختيار رخصة محلية أولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsInternationalLicenses InternationalLicense = new clsInternationalLicenses();

            // تعبئة البيانات الأساسية للأب
            InternationalLicense.ApplicantPersonID = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID; // أو حسب الخاصية الموجودة لديك
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationTypes.Find(6).ApplicationFees;

            // **تأكد هنا من إسناد UserID الصحيح**
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.ID;

            // تعبئة بيانات الرخصة الدولية
            InternationalLicense.DriverID = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.ID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IsActive = true;

            // **تأكد هنا أيضاً من إسناد UserID الصحيح**
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.ID;

            if (InternationalLicense.Save())
            {
                MessageBox.Show($"تم إصدار الرخصة الدولية بنجاح! رقم الرخصة: {InternationalLicense.ID}", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnIssue.Enabled = false;
                _IntrnationalLicenseID = InternationalLicense.InternationalLicenseID;
            }
            else
            {
                MessageBox.Show("فشلت عملية حفظ الرخصة الدولية!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }







        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlShowLicnseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicnseInfo.ShowByLicenseID(_IntrnationalLicenseID);
        }

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmLicenseHistory frm = new frmLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
