using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Project_DVLD_Course_19
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            ctrlPersonControl1.LoadPersonInfo(PersonID);
        }


        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonControl1.LoadPersonInfo(NationalNo);
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPersonControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
