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



namespace WindowsFormsApp_Project_DVLD_Course_19
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {

            Action<int> hendler = OnPersonSelected;
            if (hendler != null)
                hendler(PersonID);

        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;

            }

        }


        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;

            }

        }





        int _PersonID = -1;
        clsPerson _Person;

        public int PersonID
        {
            get { return ctrlPersonControl1.PersonID; }
        }
        public clsPerson Person
        {
            get { return ctrlPersonControl1.SelectedPersonInfo; }
        }
        //void FindPerson()
        //{
        //    if (string.IsNullOrEmpty(txtFilterValue.Text))
        //        return;


        //    switch (cbFilterBy.Text)
        //    {
        //        case "Person ID":
        //            int pPersonID = Convert.ToInt32(txtFilterValue.Text);
        //            _Person = clsPerson.Find(pPersonID);
        //            break;
        //        case "National No":
        //            string NationalNo = txtFilterValue.Text.Trim();
        //            _Person = clsPerson.Find(NationalNo);
        //            break;

        //        default:
        //            _Person = null;
        //            break;
        //    }

        //    if (_Person != null)
        //    {
        //        // تم العثور على الشخص -> قم بتحميل بياناته في الـ User Control
        //        ctrlPersonControl1.LoadPersonInfo(_Person.PersonID);
        //    }
        //    else
        //    {
        //        MessageBox.Show("لم يتم العثور على الشخص المطلوب!", "غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }


        //}

        public void LoadPersonInfo(int PersonID)
        {
            //cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();

        }
        void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonControl1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "National No":
                    ctrlPersonControl1.LoadPersonInfo((txtFilterValue.Text));
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
                OnPersonSelected(ctrlPersonControl1.PersonID);

        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            // تمرير الـ DataBack event ليعيد الـ PersonID الجديد تلقائياً
            frm.DataBack += Frm_DataBack;
            frm.ShowDialog();
        }



        private void Frm_DataBack(object sender, int PersonID)
        {
            // تحديد الخيار في الـ ComboBox على Person ID
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonControl1.LoadPersonInfo(PersonID);
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        //private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    txtFilterValue.Clear();
        //    txtFilterValue.Focus();
        //}

        private void ctrlPersonControl1_Load(object sender, EventArgs e)
        {

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
