using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication
{
    public partial class frmShowLicnseInfo : Form
    {
        private int _LicenseID = -1;
        int _LocalDrivingLicenseApplicationID = -1;

        public frmShowLicnseInfo(int LicenseID, bool IsLicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        public frmShowLicnseInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        public static void ShowByLocalAppID(int LocalDrivingLicenseApplicationID)
        {
            frmShowLicnseInfo frm = new frmShowLicnseInfo(LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
        }
        public static void ShowByLicenseID(int LicenseID)
        {
            frmShowLicnseInfo frm = new frmShowLicnseInfo(LicenseID, true);
            frm.ShowDialog();
        }
        private void frmShowLicnseInfo_Load(object sender, EventArgs e)
        {
            // التحقق من النمط المستدعى وتنفيذ الفحص المناسب
            if (_LicenseID != -1)
            {
                ctrlShowLicnseInfo1.Load_FillLicenseInfoByLicenseID(_LicenseID);
            }
            else if (_LocalDrivingLicenseApplicationID != -1)
            {
                ctrlShowLicnseInfo1.Load_FillLicenseInfo(_LocalDrivingLicenseApplicationID);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
