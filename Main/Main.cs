using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_Project_DVLD_Course_19.Login;
using WindowsFormsApp_Project_DVLD_Course_19.User;
using WindowsFormsApp_Project_DVLD_Course_19.Applactions;
using DataBusness;
using WindowsFormsApp_Project_DVLD_Course_19.Drivers;
using WindowsFormsApp_Project_DVLD_Course_19.Applications;
using WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication;
using WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.ReplacementforLostorDamagedLicense;
using WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.DetainedLicenses;
using WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.DetainedAndReleaseDetainedLicenses;
using WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.ShowListDetainedAndReleaseDetainedLicenses;

namespace WindowsFormsApp_Project_DVLD_Course_19
{
    public partial class frmMain : Form
    {
        public clsUser User;
        frmLogin _frmLogin;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();

            _frmLogin = frm;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm =new frmListPeople();
            frm.ShowDialog();


        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
           this.Close();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListUsers();
            frm.ShowDialog();

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.ID);
            frm.ShowDialog();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword1 frm = new frmChangePassword1(clsGlobal.CurrentUser.ID);
            frm.ShowDialog();

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplactionsTypes frm = new frmApplactionsTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypes frm = new frmTestTypes();
            frm.ShowDialog();
            

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication();
            frm.ShowDialog();

        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalDrivingLicenseApplication frm = new frmShowLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrivers frm = new frmDrivers();
            frm.ShowDialog();
        }

        private void msMainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmLogin.Close();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIntrnationalLicenseApplication frm = new frmIntrnationalLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListIntrnationalLicenseApplication frm = new frmListIntrnationalLicenseApplication();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReNewLocalDrivingLicenseApplication frm = new frmReNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementforLostorDamagedLicense frm = new frmReplacementforLostorDamagedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainedLicenses frm = new frmDetainedLicenses();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }
    }
}
