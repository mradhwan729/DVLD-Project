namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication
{
    partial class frmShowLicnseInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlShowLicnseInfo1 = new WindowsFormsApp_Project_DVLD_Course_19.Applications.Control.ctrlShowLicnseInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowLicnseInfo1
            // 
            this.ctrlShowLicnseInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlShowLicnseInfo1.Name = "ctrlShowLicnseInfo1";
            this.ctrlShowLicnseInfo1.Size = new System.Drawing.Size(664, 502);
            this.ctrlShowLicnseInfo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(580, 508);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowLicnseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 649);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlShowLicnseInfo1);
            this.Name = "frmShowLicnseInfo";
            this.Text = "frmShowLicnseInfo";
            this.Load += new System.EventHandler(this.frmShowLicnseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.ctrlShowLicnseInfo ctrlShowLicnseInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}