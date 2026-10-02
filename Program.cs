using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_Project_DVLD_Course_19.Login;


namespace WindowsFormsApp_Project_DVLD_Course_19
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

            //try
            //{
            //    Application.Run(new Form1());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Fatal Error: " + ex.Message);
            //    throw;
            //}

        }
    }
}
