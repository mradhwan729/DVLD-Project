using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_Project_DVLD_Course_19.Applactions.Control;
using DataBusness;
using WindowsFormsApp_Project_DVLD_Course_19.Applications.Tests;

namespace WindowsFormsApp_Project_DVLD_Course_19.Applactions.Tests
{
    public partial class frmVersoinTest : Form
    {

        int _LocalDrivingLicenseID = -1;
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        void _RefershAppolments()
        {

            dgvApplloments.DataSource = clsLocalDrivingLicenseApplications.GetTestAppointmentsPerLocalDrivingLicenseID(_LocalDrivingLicenseID, (int)_TestType);
            lblRecordsCount.Text = dgvApplloments.Rows.Count.ToString();

        }

        public frmVersoinTest(int LocalDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            _TestType = clsTestTypes.enTestType.VisionTest;
        }
        public frmVersoinTest(int LocalDrivingLicenseID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            _TestType = TestType;
        }

        private void frmVersoinTest_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.LoadlDrivingLicenseApplicationInfo(_LocalDrivingLicenseID);

            // تحديث الجدول عند الفتح
            _RefershAppolments();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. الفحص عبر طبقة البزنس لتحديد ما إذا كان الشخص يملك موعداً نشطاً مفتوحاً


            // 1. الفحص الأول: هل نجح الطالب في هذا الاختبار سابقاً؟
            if (clsLocalDrivingLicenseApplications.IsPassedTest(_LocalDrivingLicenseID, _TestType))
            {
                MessageBox.Show("This person already passed this test, you cannot add a new appointment!",
                                "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // إيقاف التنفيذ وعدم فتح شاشة الموعد
            }

            if (clsLocalDrivingLicenseApplications.IsThereAnActiveScheduledTest(_LocalDrivingLicenseID, _TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment",
                                "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. إذا لم يكن هناك موعد نشط، يتم فتح شاشة إضافة الموعد بشكل طبيعي
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseID, _TestType);
            frm.ShowDialog();

            // 3. تحديث القائمة بعد إغلاق شاشة الإضافة
            _RefershAppolments();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseID, _TestType, (int)dgvApplloments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefershAppolments();

        }

        private void ratakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTakeTest frm = new frmTakeTest((int)dgvApplloments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            // إعادة تحميل البيانات فور إغلاق الشاشة
            _RefershAppolments();
            // 2. إعادة تحميل كروت التفاصيل لكي تتحدث خانة Passed Tests
            ctrlDrivingLicenseApplicationInfo1.LoadlDrivingLicenseApplicationInfo(_LocalDrivingLicenseID);

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
