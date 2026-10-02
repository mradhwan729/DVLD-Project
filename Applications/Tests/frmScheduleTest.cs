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
    public partial class frmScheduleTest : Form
    {
        public enum enMode { AddNew = 1, Update = 2 }
        private enMode _Mode = enMode.AddNew;

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        private int _TestAppointmentID = -1;

        private clsTestAppointments _TestAppointment;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType, int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
            _TestAppointmentID = TestAppointmentID;
            _Mode = (_TestAppointmentID == -1) ? enMode.AddNew : enMode.Update;
        }
        //public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType)
        //{
        //    InitializeComponent();
        //    _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        //    _TestType = TestType;
        //    _Mode = enMode.AddNew;
        //}

        //public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType, int TestAppointmentID)
        //{
        //    InitializeComponent();
        //    _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        //    _TestType = TestType;
        //    _TestAppointmentID = TestAppointmentID;
        //    _Mode = enMode.Update;
        //}



        private void frmSechederTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestType, _TestAppointmentID);

            // 2. إسناد الكائن من الكنترول دائماً (سواءً كان جديداً أو تعديلاً)
            _TestAppointment = ctrlScheduleTest1.TestAppointment;
           
            if (_TestAppointment == null)
                return;

            // 3. التحقق مما إذا كان الموعد مقفلاً لإظهار الرسالة وتجميد الزر
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment locked.";
                btnSave.Enabled = false;
                ctrlScheduleTest1.EnableDate = false; // تعطيل تاريخ الاختبار أيضاً
             
            }
            else
            {
                lblUserMessage.Visible = false;
                btnSave.Enabled = true;
            }

            _HandleRetakeTestInfo();



        }


        private void _HandleRetakeTestInfo()
        {
            if (ctrlScheduleTest1.Trail == 0)
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRAppFees.Text = "0";
                lblTotalFees.Text = clsTestTypes.Find((int)_TestType).TestFees.ToString("0.##");
                lblRTestAppID.Text = "N/A";
            }
            else
            {
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                decimal retakeFees = (decimal)clsApplicationTypes.Find(8).ApplicationFees;
                decimal testFees = (decimal)clsTestTypes.Find((int)_TestType).TestFees;

                lblRAppFees.Text = retakeFees.ToString("0.##");
                lblTotalFees.Text = (testFees + retakeFees).ToString("0.##");
                lblRTestAppID.Text = (_Mode == enMode.AddNew) ? "N/A" : _TestAppointment.RetakeTestApplicationID.ToString();
            }
        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
                           // إنشاء طلب إعادة اختبار جديد إذا كان المتقدم يملك محاولات سابقة وفي وضع الإضافة
                if (_Mode == enMode.AddNew && ctrlScheduleTest1.Trail > 0)
                {
                    clsApplications retakeApp = new clsApplications();
                    retakeApp.ApplicantPersonID = ctrlScheduleTest1.LocalDrivingLicenseApplications.ApplicantPersonID;
                    retakeApp.ApplicationDate = DateTime.Now;
                    retakeApp.ApplicationTypeID = 8; // Retake Test Application
                    retakeApp.ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                    retakeApp.LastStatusDate = DateTime.Now;
                    retakeApp.PaidFees = clsApplicationTypes.Find(8).ApplicationFees;
                    retakeApp.CreatedByUserID = clsGlobal.CurrentUser.ID;

                    if (!retakeApp.Save())
                    {
                        MessageBox.Show("Faild to Create application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _TestAppointment.RetakeTestApplicationID = retakeApp.ID;
                    lblRTestAppID.Text = retakeApp.ID.ToString();
                }

                _TestAppointment.TestTypeID = (int)_TestType;
                _TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
                _TestAppointment.AppointmentDate = ctrlScheduleTest1.SelectedDate;
                _TestAppointment.PaidFees = (float)clsTestTypes.Find((int)_TestType).TestFees;
                _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.ID;
                _TestAppointment.IsLocked = false;

                if (_TestAppointment.Save())
                {
                    _Mode = enMode.Update;
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            



        }
    }
}
