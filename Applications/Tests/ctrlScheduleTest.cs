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
    public partial class ctrlScheduleTest : UserControl
    {

        clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        clsTestAppointments _TestAppointment;
        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID = -1;
        byte _Trial = 0;
        int _TestID = -1;
        int _TestAppointmentID = -1;
        public bool EnableDate
        {
            get { return dtpDate.Enabled; }
            set { dtpDate.Enabled = value; }
        }
        public int TestID=> _TestID;
        public int TestAppointmentID => _TestAppointmentID;
        public byte Trail => _Trial;
        public clsTestAppointments TestAppointment => _TestAppointment;
        public clsLocalDrivingLicenseApplications LocalDrivingLicenseApplications => _LocalDrivingLicenseApplication;
        public DateTime SelectedDate => dtpDate.Value;

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }





        public clsTestTypes.enTestType TestType
        {
            get { return _TestType; }
            set
            {
                _TestType = value;
                switch (_TestType)
                {
                    case clsTestTypes.enTestType.VisionTest:
                        gbTestType.Text = "Version Test";
                        pbTestTypeImage.Image = Properties.Resources.Vision_512;

                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        gbTestType.Text = "Wretting Test";
                        pbTestTypeImage.Image = Properties.Resources.Written_Test_512;
                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        gbTestType.Text = "Street Test";
                        pbTestTypeImage.Image = Properties.Resources.Street_Test_32;
                        break;
                    default:

                        break;
                }

            }


        }


        // تحضير البيانات لجدولة موعد عبر طلب الرخصة
        public void LoadInfo(int LocalDrivingLicenseApplicationID, clsTestTypes.enTestType TestType, int TestAppointmentID = -1)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestType = TestType;
            _TestAppointmentID = TestAppointmentID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.Find(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("خطأ: لم يتم العثور على بيانات الرخصة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Trial = _LocalDrivingLicenseApplication.GetTrialCount(_LocalDrivingLicenseApplicationID, (int)_TestType);

            if (_TestAppointmentID != -1)
            {
                _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);
                if (_TestAppointment != null)
                {
                    dtpDate.MinDate = DateTime.MinValue; // السماح بالتنسيق للأعياد/التواريخ السابقة
                    dtpDate.Value = _TestAppointment.AppointmentDate;
                    _TestID = _TestAppointment.TestID;

                    // إذا كان الموعد مقفلاً أو صُدرت له نتيجة اختبار يغلق التاريخ
                    if (_TestAppointment.IsLocked)
                    {
                        dtpDate.Enabled = false;
                    }
                    else
                    {
                        dtpDate.Enabled = true;
                    }
                }
            }
            else
            {
                // التصحيح: إنشاء كائن جديد لمنع NullReferenceException في الواجهة الخارجية
                _TestAppointment = new clsTestAppointments();

                dtpDate.Value = DateTime.Now;
                dtpDate.MinDate = DateTime.Now;
                dtpDate.Enabled = true;
            }

            _FillCommonData();
        }        // تحضير البيانات لإجراء الاختبار أو التعديل المباشر عبر الموعد
        public void LoadInfoByAppointmentID(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show("خطأ: لم يتم العثور على الموعد المطلوب!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            this.TestType = (clsTestTypes.enTestType)_TestAppointment.TestTypeID;
            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.Find(_LocalDrivingLicenseApplicationID);
            _Trial = _LocalDrivingLicenseApplication.GetTrialCount(_LocalDrivingLicenseApplicationID, (int)_TestType);

            dtpDate.Value = _TestAppointment.AppointmentDate;
            dtpDate.Enabled = false;

            _FillCommonData();
        }

        private void _FillCommonData()
        {
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplication.SelectedPersonInfo.FullName;
            lblTrial.Text = _Trial.ToString();
            lblFees.Text = clsTestTypes.Find((int)_TestType).TestFees.ToString("0.##");
        }

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {

        }

        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
    }
}
