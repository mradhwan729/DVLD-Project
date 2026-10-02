using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WindowsFormsApp_Project_DVLD_Course_19.User.Controls;


namespace WindowsFormsApp_Project_DVLD_Course_19.User
{
    public partial class frmShowUserInfo : Form
    {

        int _UserID= -1;
        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrlPersonInfoAndLoginInfo1.LoadUserInfo(_UserID);

        }

        private void ctrlPersonInfoAndLoginInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
