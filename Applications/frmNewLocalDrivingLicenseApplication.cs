//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using DataBusness;


//namespace WindowsFormsApp_Project_DVLD_Course_19.Applactions
//{
//    public partial class frmNewLocalDrivingLicenseApplication : Form
//    {
//        public enum enMode
//        {
//            AddNew = 0,
//            Update = 1
//        }
//        public enMode _Mode ;
//        clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
//        public frmNewLocalDrivingLicenseApplication()
//        {
//            InitializeComponent();
//        }

//       void _FillLicnseClass()
//        {
//            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();
//            foreach (DataRow row in dt.Rows)
//            {
//                cbLicenseClasses.Items.Add(row["ClassName"]);
//            }

//        }
//        void _DefultValue()
//        {
//            _FillLicnseClass();
//            short Fees = 15;
//            lblApplicationDate.Text = DateTime.Now.ToString();
//            cbLicenseClasses.SelectedIndex = 0;
//            lblFees.Text = Fees.ToString();
//            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
//        }


//        private void button2_Click(object sender, EventArgs e)
//        {
//            // 1. التحقق من صحة البيانات المدخلة بداخل الواجهة قبل الاستدعاء
//            if (!this.ValidateChildren())
//            {
//                MessageBox.Show("يرجى ملء جميع الحقول المطلوبة بشكل صحيح.", "تنبيه",
//                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // 2. تعبئة بيانات الكائن من مدخلات عناصر الشاشة (UI Control Mapping)
//            // ملاحظة: خصائص الأب والابن تُسند معاً لنفس الكائن (_LocalDrivingLicenseApplication)
//            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
//            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
//            _LocalDrivingLicenseApplication.ApplicationTypeID = 1; // 1 تعبر عن طلب رخصة قيادة محلية جديد
//            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
//            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
//            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
//            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.ID;

//            //// إسناد فئة الرخصة المحددة من القائمة المنسدلة (ComboBox)
//            _LocalDrivingLicenseApplication.LicenseClassID = clsLicenseClasses.Find(cbLicenseClasses.Text).ID;

//            // 3. استدعاء دالة الحفظ الذكية من طبقة البزنس (Business Layer)
//            if (_LocalDrivingLicenseApplication.Save())
//            {
//                // تحديث عنوان الشاشة ورقم الطلب بعد نجاح الحفظ
//                lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

//                // تحويل نمط الواجهة إلى Update لمنع التكرار عند إعادة الضغط
//                _Mode = enMode.Update;
//                lblTitle.Text = "تعديل طلب رخصة قيادة محلية";

//                MessageBox.Show("تم حفظ بيانات الطلب بنجاح. رقم الطلب المحلي هو: " +
//                                _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID,
//                                "تمت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                MessageBox.Show("فشلت عملية حفظ البيانات، يرجى المحاولة لاحقاً.", "خطأ",
//                                MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void label5_Click(object sender, EventArgs e)
//        {

//        }

//        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }

//        private void btnNext_Click(object sender, EventArgs e)
//        {

//            if (ctrlPersonCardWithFilter1.PersonID !=-1)
//            {

//                TabControl.SelectedTab = TabControl.TabPages["tpApplicationInfo"];
//               // TabControl.SelectedIndex = 1; // الرقم 1 يعني التبويب الثاني (Login Info)

//            }

//        }

//        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
//        {
//            _DefultValue();
//        }

//        private void btnClose_Click(object sender, EventArgs e)
//        {

//        }
//    }
//}


using System;
using System.Data;
using System.Windows.Forms;
using DataBusness;

namespace WindowsFormsApp_Project_DVLD_Course_19.Applactions
{
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;

        // Constructor للـ Add New
        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        // Constructor للـ Update
        public frmNewLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void _FillLicenseClasses()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();
            foreach (DataRow row in dt.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefaultValues()
        {
            _FillLicenseClasses();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";

                // إنشاء كائن جديد لمنع NullReferenceException
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplications();

                tpApplicationInfo.Enabled = false;
                cbLicenseClasses.SelectedIndex = 0;
                lblFees.Text = "15";
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.Find(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(clsLicenseClasses.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                TabControl.SelectedTab = TabControl.TabPages["tpApplicationInfo"];
                return;
            }

            // التأكد من اختيار شخص في حالة إضافة طلب جديد
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                TabControl.SelectedTab = TabControl.TabPages["tpApplicationInfo"];
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (!this.ValidateChildren())
        //    {
        //        MessageBox.Show("يرجى ملء جميع الحقول المطلوبة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    int LicenseClassID = clsLicenseClasses.Find(cbLicenseClasses.Text).ID;
        //    int PersonID = ctrlPersonCardWithFilter1.PersonID;

        //    // الفحص لمنع التكرار في حال كان النمط إضافة جديد
        //    if (_Mode == enMode.AddNew)
        //    {
        //        if (clsLocalDrivingLicenseApplications.IsPersonHaveActiveOrCompletedApplication(PersonID, LicenseClassID))
        //        {
        //            MessageBox.Show("هذا الشخص لديه بالفعل طلب نشط أو مكتمل لهذه الفئة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return; // إيقاف العملية
        //        }
        //        _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplications();
        //    }

        //    // إسناد البيانات للحفظ
        //    _LocalDrivingLicenseApplication.ApplicantPersonID = PersonID;
        //    _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
        //    _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
        //    _LocalDrivingLicenseApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
        //    _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
        //    _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
        //    _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.ID;
        //    _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

        //    if (_LocalDrivingLicenseApplication.Save())
        //    {
        //        lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
        //        _Mode = enMode.Update;
        //        lblTitle.Text = "Update Local Driving License Application";

        //        MessageBox.Show("Data Saved Successfully. Local Application ID = " + _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("فشلت عملية الحفظ.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("يرجى ملء جميع الحقول المطلوبة.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // جلب الـ ID الخاص بالفئة المختارة من القائمة باسم الفئة
            int LicenseClassID = clsLicenseClasses.Find(cbLicenseClasses.Text).ID;
            int PersonID = ctrlPersonCardWithFilter1.PersonID;

            // الفحص لمنع التكرار في حال كان النمط إضافة جديد
            if (_Mode == enMode.AddNew)
            {
                if (clsLocalDrivingLicenseApplications.IsPersonHaveActiveOrCompletedApplication(PersonID, LicenseClassID))
                {
                    MessageBox.Show("هذا الشخص لديه بالفعل طلب نشط أو مكتمل لهذه الفئة المختارة!", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // إيقاف الحفظ
                }

                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplications();
            }

            // إسناد البيانات للكائن
            _LocalDrivingLicenseApplication.ApplicantPersonID = PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplications.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.ID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;

            if (_LocalDrivingLicenseApplication.Save())
            {
                lblLocalDrivingLicenseApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully. Local Application ID = " + _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("فشلت عملية الحفظ.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void tpPersonalInfo_Click(object sender, EventArgs e)
        {

        }
    }
}