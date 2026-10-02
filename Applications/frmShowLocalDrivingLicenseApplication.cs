using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DataBusness;
using WindowsFormsApp_Project_DVLD_Course_19.Applactions.Tests;
using WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication;
namespace WindowsFormsApp_Project_DVLD_Course_19.Applactions
{
    public partial class frmShowLocalDrivingLicenseApplication : Form
    {
        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplications;
        DataTable _dtAllLocalDrivingLicenseApplications;
        public frmShowLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        void _RefershLocalDrivingLicenseApplication()
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplications();

            dgvGetAllLocalDriving.DataSource = _dtAllLocalDrivingLicenseApplications;
            lblRecordsCount.Text = dgvGetAllLocalDriving.Rows.Count.ToString();
        }
        private void frmShowLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            // 1. إعادة ضبط الأعمدة لمنع التداخل والترتيب القديم
            //dgvGetAllLocalDriving.DataSource = null;
            //dgvGetAllLocalDriving.Columns.Clear();

            cbFilterBy.SelectedIndex = 0;

            _RefershLocalDrivingLicenseApplication();

            // أضف هذا الكود فوراً بعد جلب البيانات لتتحقق من أسماء الأعمدة في نافذة الـ Output
            foreach (DataColumn col in _dtAllLocalDrivingLicenseApplications.Columns)
            {
                Console.WriteLine("Column Name in DataTable: " + col.ColumnName);
            }
            if (dgvGetAllLocalDriving.Rows.Count > 0)
            {
                // التسمية عبر اسم العمود المباشر تفادياً لأي تغيير في ترتيب SQL
                dgvGetAllLocalDriving.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L.AppID";
                dgvGetAllLocalDriving.Columns["ClassName"].HeaderText = "Driving Class";
                dgvGetAllLocalDriving.Columns["NationalNo"].HeaderText = "National No";
                dgvGetAllLocalDriving.Columns["FullName"].HeaderText = "Full Name";
                dgvGetAllLocalDriving.Columns["ApplicationDate"].HeaderText = "Application Date";
                dgvGetAllLocalDriving.Columns["PaidFees"].HeaderText = "Paid Fees";
                dgvGetAllLocalDriving.Columns["PassedTests"].HeaderText = "Passed Tests";
                dgvGetAllLocalDriving.Columns["ApplicationStatus"].HeaderText = "Status";


                // ضبط العرض لجميع الأعمدة
                foreach (DataGridViewColumn col in dgvGetAllLocalDriving.Columns)
                {
                    col.Width = 140;
                }

                //if (dgvGetAllLocalDriving.Rows.Count > 0)
                //{
                //    dgvGetAllLocalDriving.Columns[0].HeaderText = "Application ID";
                //    dgvGetAllLocalDriving.Columns[0].Width = 140;

                //    dgvGetAllLocalDriving.Columns[1].HeaderText = "Driving Class";
                //    dgvGetAllLocalDriving.Columns[1].Width = 140;

                //    dgvGetAllLocalDriving.Columns[2].HeaderText = "National No ";
                //    dgvGetAllLocalDriving.Columns[2].Width = 140;

                //    dgvGetAllLocalDriving.Columns[3].HeaderText = "Full Name ";
                //    dgvGetAllLocalDriving.Columns[3].Width = 140;

                //    dgvGetAllLocalDriving.Columns[4].HeaderText = "Application Date";
                //    dgvGetAllLocalDriving.Columns[4].Width = 140;

                //    dgvGetAllLocalDriving.Columns[5].HeaderText = "Piad Fees ";
                //    dgvGetAllLocalDriving.Columns[5].Width = 140;

                //    dgvGetAllLocalDriving.Columns[6].HeaderText = "Passed Tests ";
                //    dgvGetAllLocalDriving.Columns[6].Width = 140;

                //    dgvGetAllLocalDriving.Columns[7].HeaderText = "States";
                //    dgvGetAllLocalDriving.Columns[7].Width = 140;



                //}
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplication frm = new frmNewLocalDrivingLicenseApplication();
            frm.ShowDialog();

            _RefershLocalDrivingLicenseApplication();
            //frmShowLocalDrivingLicenseApplication_Load(null, null);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            // تحديد اسم العمود بناءً على الخيار المحدد في الـ ComboBox
            switch (cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "ApplicationStatus";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            // إعادة ضبط الفلتر في حال كان النص فارغاً أو لم يتم اختيار عمود
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvGetAllLocalDriving.Rows.Count.ToString();
                return;
            }

            // منطق الفلترة المصلح
            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                // الفلترة بالـ ID (رقمي)
                if (int.TryParse(txtFilterValue.Text.Trim(), out int appID))
                {
                    _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, appID);
                }
                else
                {
                    _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                }
            }
            else
            {
                // الفلترة بالنصوص (FullName, NationalNo, Status)
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            }

            lblRecordsCount.Text = dgvGetAllLocalDriving.Rows.Count.ToString();
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGetAllLocalDriving.CurrentRow == null) return;
            int LocalDrivingLicenseApplicationID = (int)dgvGetAllLocalDriving.CurrentRow.Cells[0].Value;
            string Status = dgvGetAllLocalDriving.CurrentRow.Cells["ApplicationStatus"].Value.ToString();
            if (Status == "Completed")
            {
                MessageBox.Show("No Deleted Becous The Person Linked Other Tables");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete User [" + dgvGetAllLocalDriving.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

                if (clsLocalDrivingLicenseApplications.DeleteLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID))
                {
                    MessageBox.Show("Succfull Deleted");
                    _RefershLocalDrivingLicenseApplication();

                }
                else
                    MessageBox.Show("Failed Deleted");
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvGetAllLocalDriving.CurrentRow == null) return;

            int PassedTests = Convert.ToInt32(dgvGetAllLocalDriving.CurrentRow.Cells["PassedTests"].Value);
            string Status = dgvGetAllLocalDriving.CurrentRow.Cells["ApplicationStatus"].Value.ToString();

            scheduleVisionTestToolStripMenuItem.Enabled = (PassedTests == 0 && Status == "New");
            scheduleWrittenTestToolStripMenuItem.Enabled = (PassedTests == 1 && Status == "New");
            scheduleStreetTestToolStripMenuItem.Enabled = (PassedTests == 2 && Status == "New");
            sechduleTestsToolStripMenuItem.Enabled = (PassedTests < 3 && Status == "New");

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (PassedTests == 3 && Status == "New");


            bool isNew = (Status == "New");
            editApplicationToolStripMenuItem.Enabled = isNew;
            cancelApplicationToolStripMenuItem.Enabled = isNew;
            deleteApplicationToolStripMenuItem.Enabled = isNew;



        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVersoinTest frm = new frmVersoinTest((int)dgvGetAllLocalDriving.CurrentRow.Cells[0].Value, clsTestTypes.enTestType.VisionTest);
            frm.ShowDialog();
            _RefershLocalDrivingLicenseApplication();

        }


        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVersoinTest frm = new frmVersoinTest((int)(dgvGetAllLocalDriving.CurrentRow.Cells[0].Value), clsTestTypes.enTestType.WrittenTest);
            frm.ShowDialog();
            _RefershLocalDrivingLicenseApplication();

        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVersoinTest frm = new frmVersoinTest((int)(dgvGetAllLocalDriving.CurrentRow.Cells[0].Value), clsTestTypes.enTestType.StreetTest);
            frm.ShowDialog();
            _RefershLocalDrivingLicenseApplication();

        }

        private void sechduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueLocalDrivingLicenseApplication frm = new frmIssueLocalDrivingLicenseApplication((int)dgvGetAllLocalDriving.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefershLocalDrivingLicenseApplication();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicnseInfo frm = new frmShowLicnseInfo((int)dgvGetAllLocalDriving.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefershLocalDrivingLicenseApplication();
        }

        private void showPersonLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory.ShowHistoryByLocalAppID((int)dgvGetAllLocalDriving.CurrentRow.Cells[0].Value);
            _RefershLocalDrivingLicenseApplication();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
