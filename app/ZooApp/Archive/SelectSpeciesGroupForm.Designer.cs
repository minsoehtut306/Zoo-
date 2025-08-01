namespace ZooApp
{
    partial class SelectSpeciesGroupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstGroups;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnEditGroup;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnEditGroup = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(160, 15);
            this.lblTitle.Text = "Select a Species Group:";

            // lstGroups
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.ItemHeight = 15;
            this.lstGroups.Location = new System.Drawing.Point(20, 45);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.Size = new System.Drawing.Size(260, 124);

            // btnAddGroup
            this.btnAddGroup.Location = new System.Drawing.Point(20, 180);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(75, 27);
            this.btnAddGroup.Text = "Add";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);

            // btnEditGroup
            this.btnEditGroup.Location = new System.Drawing.Point(105, 180);
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size(75, 27);
            this.btnEditGroup.Text = "Edit";
            this.btnEditGroup.UseVisualStyleBackColor = true;
            this.btnEditGroup.Click += new System.EventHandler(this.btnEditGroup_Click);

            // btnConfirm
            this.btnConfirm.Location = new System.Drawing.Point(190, 180);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 27);
            this.btnConfirm.Text = "Select";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(190, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // SelectSpeciesGroupForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(310, 260);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnEditGroup);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.lstGroups);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SelectSpeciesGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Species Group";
            this.Load += new System.EventHandler(this.SelectSpeciesGroupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
