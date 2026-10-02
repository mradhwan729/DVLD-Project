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
    public partial class frmChangePassword1 : Form
    {
        clsUser _User;
        public frmChangePassword1()
        {
            InitializeComponent();
        }


        public frmChangePassword1(int UserID)
        {
            InitializeComponent();
            ChangePasswordUser(UserID);
        }


        public void ChangePasswordUser(int UserID)
        {
            _User = clsUser.Find(UserID);
            if (_User == null)
            {
                MessageBox.Show("No Data User");
                return;
            }

            ctrlPersonInfoAndLoginInfo1.LoadUserInfo(UserID);
        }

        private void frmChangePassword1_Load(object sender, EventArgs e)
        {


        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {

            if (txtCurrentPassword.Text != _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "This Password Not Equel Current Password Try Again");

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _User.Password = txtNewPassword.Text;
            if (_User.Save())
            {
                MessageBox.Show("Succfull Change Password");
            }

            else
                MessageBox.Show("Error Change Password");

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This New Password Not Equel Confirm Password Try Again");

            }

        }
    }
}
