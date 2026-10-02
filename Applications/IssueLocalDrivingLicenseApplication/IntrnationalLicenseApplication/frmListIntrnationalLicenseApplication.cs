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

namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication
{
    public partial class frmListIntrnationalLicenseApplication : Form
    {
        public frmListIntrnationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmListIntrnationalLicenseApplication_Load(object sender, EventArgs e)
        {
            dgvGetAllIntrnationalLicenseApplication.DataSource=clsInternationalLicenses.GetAllApplications();
        }
    }
}
