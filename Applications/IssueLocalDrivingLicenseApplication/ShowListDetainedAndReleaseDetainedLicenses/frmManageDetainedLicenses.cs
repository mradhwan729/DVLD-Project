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
using WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.DetainedAndReleaseDetainedLicenses;
using WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.DetainedLicenses;

namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.ShowListDetainedAndReleaseDetainedLicenses
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        void _RefreshDetainInfo()
        {
            dgvGetDetainInfo.DataSource = clsDetainedLicenses.GetDetainInfo();
            lblRecordsCount.Text = dgvGetDetainInfo.Rows.Count.ToString();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {

            _RefreshDetainInfo();
            if (dgvGetDetainInfo.RowCount > 0)
            {
                dgvGetDetainInfo.Columns[3].HeaderText = "Is Released";
                dgvGetDetainInfo.Columns[4].HeaderText = "Fine Fees";
                dgvGetDetainInfo.Columns[5].HeaderText = "Release Date";

            }


            foreach (DataGridViewColumn col in dgvGetDetainInfo.Columns)
            {
                col.Width = 130;
            }

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainedLicenses frm = new frmDetainedLicenses();
            frm.ShowDialog();
            _RefreshDetainInfo();


        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            _RefreshDetainInfo();

        }

        private void dgvGetDetainInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
