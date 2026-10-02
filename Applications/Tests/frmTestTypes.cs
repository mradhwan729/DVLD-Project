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
    public partial class frmTestTypes : Form
    {

        public frmTestTypes()
        {
            InitializeComponent();
        }

        void _RefershTestTypes()
        {
            dgvTestTypes.AllowUserToAddRows = false;
            dgvTestTypes.DataSource = clsTestTypes.GetAllTestTypes();
            lblCount.Text = dgvTestTypes.RowCount.ToString();

        }
        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            dgvTestTypes.AllowUserToAddRows = false;
            dgvTestTypes.DataSource = clsTestTypes.GetAllTestTypes();
            lblCount.Text = dgvTestTypes.RowCount.ToString();
            if (dgvTestTypes.Rows.Count >0)
            {
                dgvTestTypes.Columns[0].HeaderText = "Test Types ID";
                dgvTestTypes.Columns[0].Width = 140;


                dgvTestTypes.Columns[1].HeaderText = "Test Types Tite";
                dgvTestTypes.Columns[1].Width = 140;


                dgvTestTypes.Columns[2].HeaderText = "Test Types Descrption";
                dgvTestTypes.Columns[2].Width = 140;


                dgvTestTypes.Columns[3].HeaderText = "Test Types Fees";
                dgvTestTypes.Columns[3].Width = 140;



            }



        }

        private void editTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frm = new frmUpdateTestTypes((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefershTestTypes();
        }
    }
}
