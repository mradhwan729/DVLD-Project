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

namespace WindowsFormsApp_Project_DVLD_Course_19.User
{
    public partial class frmAddNewUser : Form
    {


        public enum enMode
        {
            AddNew=0,
            Update =1
        }
        private enMode _Mode;
        private int _UserID =-1;
        private clsUser _User;


        public frmAddNewUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }

        public frmAddNewUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;

        }


        void _LoadData()
        {
            _User = clsUser.Find(_UserID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("Nothing ");
                this.Close();
                return;

            }
            lblUserID.Text = _User.ID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;

            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);


        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            // DateBack?.Invoke(this, ctrlPersonCardWithFilter1.PersonID);
            this.Close();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            _User.PersonID = ctrlPersonCardWithFilter1.PersonID; // الخطوة الأهم (ربط اليوزر بالشخص)
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();

            _User.IsActive = chkIsActive.Checked;

            // تنفيذ عملية الحفظ في الداتا بيز
            if (_User.Save())
            {
                lblUserID.Text = _User.ID.ToString(); // عرض الـ UserID الجديد الذي تم توليده
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            // في حالة التعديل، قم بالانتقال المباشر للتبويب الثاني
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"]; // أو tabControl1.SelectedIndex = 1;
                return;

            }

            // في حالة الإضافة: التأكد من اختيار شخص أولاً
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                // التحقق ممّا إذا كان الشخص يمتلك حساباً سابقاً
                if (clsUser.IsUserExist(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.",
                                    "Select another Person",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }
                else
                {
                    // تفعيل التبويب الثاني والانتقال إليه
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedIndex = 1; // الرقم 1 يعني التبويب الثاني (Login Info)
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person",
                                "Select a Person",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }



        }
        private void _ResetDefultValue()
        {
            if (_Mode ==enMode.AddNew)
            {
                _User = new clsUser();
                tpLoginInfo.Enabled = false;

                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;

            }
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked=true;


        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {

            _ResetDefultValue();

            if (_Mode == enMode.Update)
                _LoadData();

        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Agein Writting this error becus dosent equl Password");
            }


        }

        private void chkIsActive_Validating(object sender, CancelEventArgs e)
        {

            //if (!chkIsActive.Checked)
            //{

            //    errorProvider1.SetError(chkIsActive, "Dos not Active Agian Active");
            //}

            // عند التفعيل نمسح إيقونة الخطأ
            errorProvider1.SetError(chkIsActive, "");

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "This Password Empty try Again Data");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, ""); // مسح علامة الخطأ
            }
        }
    }
}
