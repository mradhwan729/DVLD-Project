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
    public partial class frmUpdateTestTypes : Form
    {
        clsTestTypes _TestTypes;
        int _TestTypesID = 0;

        public frmUpdateTestTypes(int TestTypesID)
        {
            InitializeComponent();
            _TestTypesID = TestTypesID;
        }

        void _LoadData()
        {
            _TestTypes = clsTestTypes.Find(_TestTypesID);
            if (_TestTypes == null)
            {
                MessageBox.Show("Nothing");
                this.Close();
                return;
            }
            lblTestTypesID.Text = _TestTypesID.ToString();
            txtTile.Text = _TestTypes.TestTypeTitle;
            rtbDescreption.Text = _TestTypes.TestTypeDescription;
            txtFees.Text = _TestTypes.TestFees.ToString();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _TestTypes.ID = _TestTypesID;
            _TestTypes.TestTypeTitle = txtTile.Text;
            _TestTypes.TestTypeDescription = rtbDescreption.Text;
            _TestTypes.TestFees = (float)Convert.ToDouble(txtFees.Text);

            if (_TestTypes.Save())
            {
                MessageBox.Show("Successful Data Test Types");
            }
            else
                MessageBox.Show("Failed to Save Data"); // 👈 صلح هذه الرسالة لتكون عند الفشل

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
