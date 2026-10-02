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
    public partial class frmFindPersonCard : Form
    {
        public frmFindPersonCard()
        {
            InitializeComponent();
        }

        public int SelectedPersonID
        {
            get { return ctrlPersonCardWithFilter1.PersonID; }
        }
        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        { 
        



        
        }

    }
}

