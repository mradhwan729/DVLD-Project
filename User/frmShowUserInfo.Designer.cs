namespace WindowsFormsApp_Project_DVLD_Course_19.User
{
    partial class frmShowUserInfo
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
            this.ctrlPersonInfoAndLoginInfo1 = new WindowsFormsApp_Project_DVLD_Course_19.User.Controls.ctrlPersonInfoAndLoginInfo();
            this.SuspendLayout();
            // 
            // ctrlPersonInfoAndLoginInfo1
            // 
            this.ctrlPersonInfoAndLoginInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonInfoAndLoginInfo1.Name = "ctrlPersonInfoAndLoginInfo1";
            this.ctrlPersonInfoAndLoginInfo1.Size = new System.Drawing.Size(760, 502);
            this.ctrlPersonInfoAndLoginInfo1.TabIndex = 0;
            this.ctrlPersonInfoAndLoginInfo1.Load += new System.EventHandler(this.ctrlPersonInfoAndLoginInfo1_Load);
            // 
            // frmShowUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.ctrlPersonInfoAndLoginInfo1);
            this.Name = "frmShowUserInfo";
            this.Text = "frmShowUserInfo";
            this.Load += new System.EventHandler(this.frmShowUserInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlPersonInfoAndLoginInfo ctrlPersonInfoAndLoginInfo1;
    }
}