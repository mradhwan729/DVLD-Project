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
    public partial class frmLicenseHistory : Form
    {
      static  int _LocalDrivingLicenseApplicationID = -1;
        int _PersonID = -1;
        public frmLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        public static void ShowHistoryByLocalAppID(int LocalAppID)
        {
            clsLocalDrivingLicenseApplications LocalApp = clsLocalDrivingLicenseApplications.Find(LocalAppID);
            if (LocalApp != null)
            {
                frmLicenseHistory frm = new frmLicenseHistory(LocalApp.ApplicantPersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("لا يوجد بيانات لهذا الطلب!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void _RefershLicenseInfo()
        {
            //clsLocalDrivingLicenseApplications LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.Find(_LocalDrivingLicenseApplicationID);
            //_PersonID = LocalDrivingLicenseApplications.ApplicantPersonID;
            dgvLocalLicenseHistory.DataSource = clsLicense.GetLicensesByPersonID(_PersonID);
            lblLocalCount.Text = dgvLocalLicenseHistory.Rows.Count.ToString();
        }
        void OrderLicenseTable()
        {
            _RefershLicenseInfo();
            if (dgvLocalLicenseHistory.Rows.Count > 0)
            {
                dgvLocalLicenseHistory.Columns[0].HeaderText = "Lic ID";
                dgvLocalLicenseHistory.Columns[1].HeaderText = "App ID";
                dgvLocalLicenseHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenseHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenseHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenseHistory.Columns[5].HeaderText = "Is Active";
            }


            foreach (DataGridViewColumn col in dgvLocalLicenseHistory.Columns)
            {
                col.Width = 100;
            }

        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            OrderLicenseTable();
            ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
        }

        private void lblLocalCount_Click(object sender, EventArgs e)
        {

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalLicenseHistory.CurrentRow != null && dgvLocalLicenseHistory.CurrentRow.Index >= 0)
            {
                int LicenseID = (int)dgvLocalLicenseHistory.CurrentRow.Cells[0].Value;

                // فتح واجهة تفاصيل الرخصة وتمرير رقم الرخصة
                frmShowLicnseInfo frm = new frmShowLicnseInfo(LicenseID, true);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("يرجى تحديد رخصة من القائمة أولاً!", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
