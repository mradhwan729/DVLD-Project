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

namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.Tests
{
    public partial class frmTakeTest : Form
    {
        int _TestAppointmentID = -1;
        clsTest _Test;

        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {

            ctrlScheduleTest1.LoadInfoByAppointmentID(_TestAppointmentID);
            if (ctrlScheduleTest1.TestAppointment.IsLocked)
            {
                btnSave.Enabled = false;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                rtxtNotes.Enabled = false;
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment locked.";

            }
            else
            {
                // إذا كان الموعد مفتوحاً: نجهز كائن اختبار جديد للإضافة
                _Test = new clsTest();
                rbPass.Checked = true; // تحديد نجاح كخيار افتراضي
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results.",
                                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = rtxtNotes.Text;
            _Test.CreatedByUserID = clsGlobal.CurrentUser.ID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

                // تعطيل عناصر التحكم فور الحفظ
                rbFail.Enabled = false;
                rbPass.Enabled = false;
                rtxtNotes.Enabled = false;

                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
