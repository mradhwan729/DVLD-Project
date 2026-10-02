namespace WindowsFormsApp_Project_DVLD_Course_19.Applications.IssueLocalDrivingLicenseApplication
{
    partial class frmLicenseHistory
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
            this.components = new System.ComponentModel.Container();
            this.ctrlPersonCardWithFilter1 = new WindowsFormsApp_Project_DVLD_Course_19.ctrlPersonCardWithFilter();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tcLocal = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLocalCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.tcIntrational = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvIntarntionalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl.SuspendLayout();
            this.tcLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseHistory)).BeginInit();
            this.tcIntrational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntarntionalLicenseHistory)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(747, 393);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tcLocal);
            this.TabControl.Controls.Add(this.tcIntrational);
            this.TabControl.Location = new System.Drawing.Point(8, 399);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(739, 264);
            this.TabControl.TabIndex = 2;
            // 
            // tcLocal
            // 
            this.tcLocal.Controls.Add(this.label4);
            this.tcLocal.Controls.Add(this.lblLocalCount);
            this.tcLocal.Controls.Add(this.label1);
            this.tcLocal.Controls.Add(this.dgvLocalLicenseHistory);
            this.tcLocal.Location = new System.Drawing.Point(4, 25);
            this.tcLocal.Name = "tcLocal";
            this.tcLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tcLocal.Size = new System.Drawing.Size(731, 235);
            this.tcLocal.TabIndex = 0;
            this.tcLocal.Text = "Local";
            this.tcLocal.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "# Records:";
            // 
            // lblLocalCount
            // 
            this.lblLocalCount.AutoSize = true;
            this.lblLocalCount.Location = new System.Drawing.Point(98, 212);
            this.lblLocalCount.Name = "lblLocalCount";
            this.lblLocalCount.Size = new System.Drawing.Size(22, 17);
            this.lblLocalCount.TabIndex = 18;
            this.lblLocalCount.Text = "??";
            this.lblLocalCount.Click += new System.EventHandler(this.lblLocalCount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Local Licenses History";
            // 
            // dgvLocalLicenseHistory
            // 
            this.dgvLocalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenseHistory.Location = new System.Drawing.Point(-4, 28);
            this.dgvLocalLicenseHistory.Name = "dgvLocalLicenseHistory";
            this.dgvLocalLicenseHistory.RowHeadersWidth = 51;
            this.dgvLocalLicenseHistory.RowTemplate.Height = 26;
            this.dgvLocalLicenseHistory.Size = new System.Drawing.Size(729, 181);
            this.dgvLocalLicenseHistory.TabIndex = 2;
            // 
            // tcIntrational
            // 
            this.tcIntrational.Controls.Add(this.label2);
            this.tcIntrational.Controls.Add(this.lblRecordsCount);
            this.tcIntrational.Controls.Add(this.label3);
            this.tcIntrational.Controls.Add(this.dgvIntarntionalLicenseHistory);
            this.tcIntrational.Location = new System.Drawing.Point(4, 25);
            this.tcIntrational.Name = "tcIntrational";
            this.tcIntrational.Padding = new System.Windows.Forms.Padding(3);
            this.tcIntrational.Size = new System.Drawing.Size(731, 235);
            this.tcIntrational.TabIndex = 1;
            this.tcIntrational.Text = "Intrational";
            this.tcIntrational.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(98, 212);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(22, 17);
            this.lblRecordsCount.TabIndex = 18;
            this.lblRecordsCount.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Intrational Licenses History";
            // 
            // dgvIntarntionalLicenseHistory
            // 
            this.dgvIntarntionalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntarntionalLicenseHistory.Location = new System.Drawing.Point(1, 26);
            this.dgvIntarntionalLicenseHistory.Name = "dgvIntarntionalLicenseHistory";
            this.dgvIntarntionalLicenseHistory.RowHeadersWidth = 51;
            this.dgvIntarntionalLicenseHistory.RowTemplate.Height = 26;
            this.dgvIntarntionalLicenseHistory.Size = new System.Drawing.Size(729, 183);
            this.dgvIntarntionalLicenseHistory.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 56);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 662);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Name = "frmLicenseHistory";
            this.Text = "frmLicenseHistory";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            this.TabControl.ResumeLayout(false);
            this.tcLocal.ResumeLayout(false);
            this.tcLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseHistory)).EndInit();
            this.tcIntrational.ResumeLayout(false);
            this.tcIntrational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntarntionalLicenseHistory)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tcLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLocalLicenseHistory;
        private System.Windows.Forms.TabPage tcIntrational;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvIntarntionalLicenseHistory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLocalCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}