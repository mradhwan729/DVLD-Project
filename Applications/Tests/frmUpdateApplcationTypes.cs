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

namespace WindowsFormsApp_Project_DVLD_Course_19.Applactions
{
    public partial class frmUpdateApplcationTypes : Form
    {
        clsApplicationTypes _ApplicationTypes;
        int _ApplicationTypesID = -1;
        public frmUpdateApplcationTypes(int ApplicationTypesID)
        {
            InitializeComponent();
            _ApplicationTypesID = ApplicationTypesID;
        }



        void _LoadData()
        {
            _ApplicationTypes=clsApplicationTypes.Find(_ApplicationTypesID);
            if (_ApplicationTypes ==null)
            {
                MessageBox.Show("Nothing Applcation Types");
                this.Close();
                return;

            }
            lblApplactionTypesID.Text = _ApplicationTypesID.ToString();
            txtTile.Text = _ApplicationTypes.ApplicationTypeTitle;
            txtFees.Text = _ApplicationTypes.ApplicationFees.ToString();
        }
        private void frmUpdateApplcationTypes_Load(object sender, EventArgs e)
        {


            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {



            _ApplicationTypes.ApplicationTypeTitle = txtTile.Text.Trim();
            _ApplicationTypes.ApplicationFees = (float)Convert.ToDouble(txtFees.Text.Trim());

            if (_ApplicationTypes.Save())
            {
                MessageBox.Show("Susscafull Saved Date.");

            }
            else
                MessageBox.Show("Failed Saved Date.");


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
