using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;


namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.Control
{
    public partial class ctrlShowLicnseInfoWithFilter : UserControl
    {
        // int _LicenseID = -1;
        //public clsLicense License
        //{
        //    get { return ctrlShowLicnseInfo1.SelectedLicenseInfo; }
        //}
        //public int LicenseID
        //{
        //    get { return ctrlShowLicnseInfo1.LicenseID; }
        //}


        public event Action<int> OnLicenseSelected;
        public clsLicense SelectedLicenseInfo => ctrlShowLicnseInfo1.SelectedLicenseInfo;
        public int LicenseID => ctrlShowLicnseInfo1.LicenseID;
        bool _FiltirEnable = true;
        public bool FiltirEnable
        {
            get { return _FiltirEnable; }

            set
            {
                gbFilters.Enabled = _FiltirEnable;
                _FiltirEnable = value;
            }
        }
        void FindNow()
        {
            if (!int.TryParse(txtFilterValue.Text.Trim(), out int LicenseID))
            {
                MessageBox.Show("Please Enter A Number ?");
                return;
            }
            if (ctrlShowLicnseInfo1.Load_FillLicenseInfoByLicenseID(LicenseID))
            {
                OnLicenseSelected?.Invoke(ctrlShowLicnseInfo1.LicenseID);
            }



        }
        public ctrlShowLicnseInfoWithFilter()
        {
            InitializeComponent();
        }
        public void LoadLicenseWithFilter(int LicenseID)
        {

            txtFilterValue.Text = LicenseID.ToString();
            FindNow();
        }


        private void ctrlShowLicnseInfoWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void ctrlShowLicnseInfo1_Load(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindNow();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                //تمنع الصوت المزعج
                e.Handled = true;

                FindNow();
            }
        }

        private void gbFilters_Enter(object sender, EventArgs e)
        {

        }
    }
}
