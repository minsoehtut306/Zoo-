namespace ZooApp
{
    partial class SelectSpeciesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cboSpeciesGroup;
        private System.Windows.Forms.ListBox lstSpecies;
        private System.Windows.Forms.Button btnAddSpecies;
        private System.Windows.Forms.Button btnEditSpecies;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblGroup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cboSpeciesGroup = new System.Windows.Forms.ComboBox();
            this.lstSpecies = new System.Windows.Forms.ListBox();
            this.btnAddSpecies = new System.Windows.Forms.Button();
            this.btnEditSpecies = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblGroup = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblGroup
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(20, 20);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(130, 15);
            this.lblGroup.Text = "Select Species Group:";

            // cboSpeciesGroup
            this.cboSpeciesGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpeciesGroup.FormattingEnabled = true;
            this.cboSpeciesGroup.Location = new System.Drawing.Point(20, 40);
            this.cboSpeciesGroup.Name = "cboSpeciesGroup";
            this.cboSpeciesGroup.Size = new System.Drawing.Size(250, 23);
            this.cboSpeciesGroup.SelectedIndexChanged += new System.EventHandler(this.cboSpeciesGroup_SelectedIndexChanged);

            // lstSpecies
            this.lstSpecies.FormattingEnabled = true;
            this.lstSpecies.ItemHeight = 15;
            this.lstSpecies.Location = new System.Drawing.Point(20, 80);
            this.lstSpecies.Name = "lstSpecies";
            this.lstSpecies.Size = new System.Drawing.Size(250, 124);

            // btnAddSpecies
            this.btnAddSpecies.Location = new System.Drawing.Point(20, 215);
            this.btnAddSpecies.Name = "btnAddSpecies";
            this.btnAddSpecies.Size = new System.Drawing.Size(75, 25);
            this.btnAddSpecies.Text = "Add";
            this.btnAddSpecies.UseVisualStyleBackColor = true;
            this.btnAddSpecies.Click += new System.EventHandler(this.btnAddSpecies_Click);

            // btnEditSpecies
            this.btnEditSpecies.Location = new System.Drawing.Point(105, 215);
            this.btnEditSpecies.Name = "btnEditSpecies";
            this.btnEditSpecies.Size = new System.Drawing.Size(75, 25);
            this.btnEditSpecies.Text = "Edit";
            this.btnEditSpecies.UseVisualStyleBackColor = true;
            this.btnEditSpecies.Click += new System.EventHandler(this.btnEditSpecies_Click);

            // btnConfirm
            this.btnConfirm.Location = new System.Drawing.Point(195, 215);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 25);
            this.btnConfirm.Text = "Select";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(195, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // SelectSpeciesForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 290);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnEditSpecies);
            this.Controls.Add(this.btnAddSpecies);
            this.Controls.Add(this.lstSpecies);
            this.Controls.Add(this.cboSpeciesGroup);
            this.Controls.Add(this.lblGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectSpeciesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Species";
            this.Load += new System.EventHandler(this.SelectSpeciesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
