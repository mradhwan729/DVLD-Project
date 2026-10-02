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
using DVLDBusinessLayer;


namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication.ReplacementforLostorDamagedLicense
{
    public partial class frmReplacementforLostorDamagedLicense : Form
    {
        int _SelectedLicenseID = -1;
        int _ReplacementLicenseID = -1;
        public frmReplacementforLostorDamagedLicense()
        {
            InitializeComponent();
        }
        clsLicense.enIssueReason _GetIssueReason()
        {
            return rbDamagedLicense.Checked ? clsLicense.enIssueReason.ReplacementForDamaged : clsLicense.enIssueReason.ReplacementForLost;
        }
        // دالة مساعدة للحصول على نوع الطلب الصحيح لجدول الرسوم
        clsApplicationTypes.enApplicationType _GetApplicationType()
        {
            return rbDamagedLicense.Checked ?
                clsApplicationTypes.enApplicationType.ReplesmentForDamaged :
                clsApplicationTypes.enApplicationType.ReplesmentForLost;
        }

        void ResetDefueltLicenseReNew()
        {

            float ApplicationFees = clsApplicationTypes.Find((int)_GetApplicationType()).ApplicationFees;

            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUserName.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = ApplicationFees.ToString();
            lblLicenseFees.Text = "???";
            lblTotalFees.Text = "???";

            lblRLApplicationID.Text = "[???]";
            lblReplacedLicenseID.Text = "[???]";
            lblOldLicenseID.Text = "[???]";

            btnIssueReplesement.Enabled = false;
            lnkShowLicense.Enabled = false;
            lnkShowLicenseHistory.Enabled = false;


        }



        private void btnIssueReplesement_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Went Issue Replesment Damaged Or Lost ?", "Accept", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense ReplacementLicense = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.ReplaceOrRenew(txtNotes.Text.Trim(), clsGlobal.CurrentUser.ID, _GetIssueReason());

            if (ReplacementLicense != null)
            {
                MessageBox.Show("Seccefull Replesment License");
                lblRLApplicationID.Text = ReplacementLicense.ApplicationID.ToString();
                lblReplacedLicenseID.Text = ReplacementLicense.ID.ToString();
                _ReplacementLicenseID = ReplacementLicense.ID;
                btnIssueReplesement.Enabled = false;
                ctrlShowLicnseInfoWithFilter1.FiltirEnable = false;
                lnkShowLicense.Enabled = true;

                // أضف هذين السطرين لإغلاق الخيارات بعد الحفظ
                rbDamagedLicense.Enabled = false;
                rbLostLicense.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed Replesment License");

            }


        }


        private void ctrlShowLicnseInfoWithFilter1_OnLicenseSelected(int SelectedLicenseID)
        {
            _SelectedLicenseID = SelectedLicenseID;

            lnkShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                ResetDefueltLicenseReNew();
                return;
            }

            clsLicense SelectedLicense = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo;


            if (SelectedLicense == null)
            {
                MessageBox.Show("Null Of License");
                return;
            }
            if (SelectedLicense.IsDetained == true)
            {
                MessageBox.Show("License Is Detained");
                btnIssueReplesement.Enabled = false;
                return;
            }
            //if (SelectedLicense.ExpirationDate < DateTime.Now)
            //{
            //    MessageBox.Show("This License is Expired! You cannot issue a replacement. Please Renew it first.",
            //                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    btnIssueReplesement.Enabled = false;
            //    return;
            //}

            if (SelectedLicense.IsActive != true)
            {
                MessageBox.Show("Not The  License Active Exume Ser try Other Again ");
                btnIssueReplesement.Enabled = false;
                return;
            }

            lblOldLicenseID.Text = _SelectedLicenseID.ToString();
            btnIssueReplesement.Enabled = true;
        }

        private void frmReplacementforLostorDamagedLicense_Load(object sender, EventArgs e)
        {
            ctrlShowLicnseInfoWithFilter1.OnLicenseSelected += ctrlShowLicnseInfoWithFilter1_OnLicenseSelected;

            rbDamagedLicense.Checked = true;
            ResetDefueltLicenseReNew();
            rbDamagedLicense.Enabled = true;
            if (_SelectedLicenseID != -1)
            {
                ctrlShowLicnseInfoWithFilter1.LoadLicenseWithFilter(_SelectedLicenseID);
                ctrlShowLicnseInfoWithFilter1.FiltirEnable = true;
            }
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            float ApplicationFees = clsApplicationTypes.Find((int)_GetApplicationType()).ApplicationFees;

            lblApplicationFees.Text = ApplicationFees.ToString();
            lblOldLicenseID.Text = _SelectedLicenseID.ToString();
            lblTitle.Text = "Replesement For Damaged";
            this.Text = lblTitle.Text;
            lblOldLicenseID.Text = _SelectedLicenseID.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            float ApplicationFees = clsApplicationTypes.Find((int)_GetApplicationType()).ApplicationFees;

            lblApplicationFees.Text = ApplicationFees.ToString();
            lblOldLicenseID.Text = _SelectedLicenseID.ToString();
            lblTitle.Text = "Replesement For Lost";
            this.Text = lblTitle.Text;
            lblOldLicenseID.Text = _SelectedLicenseID.ToString();
        }

        private void lnkShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicnseInfo.ShowByLicenseID(_ReplacementLicenseID);

        }

        private void lnkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlShowLicnseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmLicenseHistory frm = new frmLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void ctrlShowLicnseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
