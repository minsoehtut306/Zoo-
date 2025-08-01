namespace ZooApp
{
    partial class SelectZoneForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstZones;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddZone;
        private System.Windows.Forms.Button btnEditZone;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstZones = new System.Windows.Forms.ListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddZone = new System.Windows.Forms.Button();
            this.btnEditZone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstZones
            // 
            this.lstZones.FormattingEnabled = true;
            this.lstZones.Location = new System.Drawing.Point(20, 45);
            this.lstZones.Name = "lstZones";
            this.lstZones.Size = new System.Drawing.Size(260, 121);
            this.lstZones.TabIndex = 2;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(205, 180);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 27);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Select";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(205, 213);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(108, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Select a Zone Name:";
            // 
            // btnAddZone
            // 
            this.btnAddZone.Location = new System.Drawing.Point(20, 180);
            this.btnAddZone.Name = "btnAddZone";
            this.btnAddZone.Size = new System.Drawing.Size(75, 27);
            this.btnAddZone.TabIndex = 4;
            this.btnAddZone.Text = "Add";
            this.btnAddZone.Click += new System.EventHandler(this.btnAddZone_Click);
            // 
            // btnEditZone
            // 
            this.btnEditZone.Location = new System.Drawing.Point(114, 180);
            this.btnEditZone.Name = "btnEditZone";
            this.btnEditZone.Size = new System.Drawing.Size(75, 27);
            this.btnEditZone.TabIndex = 5;
            this.btnEditZone.Text = "Edit";
            this.btnEditZone.Click += new System.EventHandler(this.btnEditZone_Click);
            // 
            // SelectZoneForm
            // 
            this.ClientSize = new System.Drawing.Size(310, 254);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lstZones);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAddZone);
            this.Controls.Add(this.btnEditZone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SelectZoneForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Zone";
            this.Load += new System.EventHandler(this.SelectZoneForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
