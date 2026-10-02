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


namespace WindowsFormsApp_Project_DVLD_Course_19.User.Controls
{
    public partial class ctrlPersonInfoAndLoginInfo : UserControl
    {
        clsUser _User;
        int _UserID = -1;
        public int UserID
            {
            get { return _UserID; } 
            }
        public ctrlPersonInfoAndLoginInfo()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonControl1_Load(object sender, EventArgs e)
        {

        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUser.Find(UserID);

            if (_User == null)
            {
                MessageBox.Show("No Information User");
                //this.close();
                return;

            }
            _FillUserInfo();

        }
        private void _FillUserInfo()
        {
            lblUserID.Text = _User.ID.ToString();
            lblUserName.Text = _User.UserName;
            //lblIsActive.Text = _User.IsActive.ToString();
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";

            ctrlPersonControl1.LoadPersonInfo(_User.PersonID);

        }


        private void ctrlPersonInfoAndLoginInfo_Load(object sender, EventArgs e)
        {
           

        }
    }
}
