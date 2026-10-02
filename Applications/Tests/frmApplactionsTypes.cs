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
using WindowsFormsApp_Project_DVLD_Course_19.Applactions;

namespace WindowsFormsApp_Project_DVLD_Course_19
{
    public partial class frmApplactionsTypes : Form
    {

        DataTable _GetApplactionTypes =clsApplicationTypes.GetAllApplicationTypes();
        public frmApplactionsTypes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new frmUpdateApplcationTypes((int)dgvApplactionTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshApplactionTypesList();
        }

        private void ApplactionsTypes_Load(object sender, EventArgs e)
        {
            dgvApplactionTypes.DataSource = _GetApplactionTypes;
            lblCount.Text =dgvApplactionTypes.RowCount.ToString();

            if (dgvApplactionTypes.Rows.Count>0)
            {
                dgvApplactionTypes.Columns[0].HeaderText = "Applaction Types ID";
                dgvApplactionTypes.Columns[0].Width = 200;

                dgvApplactionTypes.Columns[1].HeaderText = "Applaction Types Title";
                dgvApplactionTypes.Columns[1].Width = 200;

                dgvApplactionTypes.Columns[2].HeaderText = "Applaction Types Fees";
                dgvApplactionTypes.Columns[2].Width = 200;


            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    void  _RefreshApplactionTypesList ()
        {
            dgvApplactionTypes.DataSource = clsApplicationTypes.GetAllApplicationTypes();
            lblCount.Text = dgvApplactionTypes.RowCount.ToString();

        }
        private void editApplactionTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUpdateApplcationTypes((int)dgvApplactionTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshApplactionTypesList();
           // ApplactionsTypes_Load(null, null);
        }
    }
}
