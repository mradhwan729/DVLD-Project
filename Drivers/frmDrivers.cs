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
using WindowsFormsApp_Project_DVLD_Course_19;

namespace WindowsFormsApp_Project_DVLD_Course_19.Drivers
{
    public partial class frmDrivers : Form
    {
        public frmDrivers()
        {
            InitializeComponent();
        }

        void _RefershLicenseInfo()
        {

            dgvDrivers.DataSource = clsDriver.GetDriversInfo();
            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
        }
        void OrderLicenseTable()
        {
            _RefershLicenseInfo();
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[2].HeaderText = "Full Name";
                dgvDrivers.Columns[3].HeaderText = "Date";
                dgvDrivers.Columns[4].HeaderText = "Active Licenses";
            }


            foreach (DataGridViewColumn col in dgvDrivers.Columns)
            {
                col.Width = 200;
            }

        }
        private void frmDrivers_Load(object sender, EventArgs e)
        {
            OrderLicenseTable();

        }
    }
}
