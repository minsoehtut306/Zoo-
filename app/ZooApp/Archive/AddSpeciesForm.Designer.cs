namespace ZooApp
{
    partial class AddSpeciesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLatinName;
        private System.Windows.Forms.TextBox txtCommonName;
        private System.Windows.Forms.TextBox txtBiome;
        private System.Windows.Forms.Label lblLatinName;
        private System.Windows.Forms.Label lblCommonName;
        private System.Windows.Forms.Label lblBiome;
        private System.Windows.Forms.Label lblGroupLabel;
        private System.Windows.Forms.Label lblSelectedGroup;
        private System.Windows.Forms.Button btnSelectGroup;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtLatinName = new System.Windows.Forms.TextBox();
            this.txtCommonName = new System.Windows.Forms.TextBox();
            this.txtBiome = new System.Windows.Forms.TextBox();
            this.lblLatinName = new System.Windows.Forms.Label();
            this.lblCommonName = new System.Windows.Forms.Label();
            this.lblBiome = new System.Windows.Forms.Label();
            this.lblGroupLabel = new System.Windows.Forms.Label();
            this.lblSelectedGroup = new System.Windows.Forms.Label();
            this.btnSelectGroup = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblLatinName
            this.lblLatinName.AutoSize = true;
            this.lblLatinName.Location = new System.Drawing.Point(20, 20);
            this.lblLatinName.Name = "lblLatinName";
            this.lblLatinName.Size = new System.Drawing.Size(69, 15);
            this.lblLatinName.Text = "Latin Name:";

            // txtLatinName
            this.txtLatinName.Location = new System.Drawing.Point(120, 17);
            this.txtLatinName.Name = "txtLatinName";
            this.txtLatinName.Size = new System.Drawing.Size(200, 23);

            // lblCommonName
            this.lblCommonName.AutoSize = true;
            this.lblCommonName.Location = new System.Drawing.Point(20, 55);
            this.lblCommonName.Name = "lblCommonName";
            this.lblCommonName.Size = new System.Drawing.Size(94, 15);
            this.lblCommonName.Text = "Common Name:";

            // txtCommonName
            this.txtCommonName.Location = new System.Drawing.Point(120, 52);
            this.txtCommonName.Name = "txtCommonName";
            this.txtCommonName.Size = new System.Drawing.Size(200, 23);

            // lblBiome
            this.lblBiome.AutoSize = true;
            this.lblBiome.Location = new System.Drawing.Point(20, 90);
            this.lblBiome.Name = "lblBiome";
            this.lblBiome.Size = new System.Drawing.Size(93, 15);
            this.lblBiome.Text = "Required Biome:";

            // txtBiome
            this.txtBiome.Location = new System.Drawing.Point(120, 87);
            this.txtBiome.Name = "txtBiome";
            this.txtBiome.Size = new System.Drawing.Size(200, 23);

            // lblGroupLabel
            this.lblGroupLabel.AutoSize = true;
            this.lblGroupLabel.Location = new System.Drawing.Point(20, 125);
            this.lblGroupLabel.Name = "lblGroupLabel";
            this.lblGroupLabel.Size = new System.Drawing.Size(84, 15);
            this.lblGroupLabel.Text = "Species Group:";

            // lblSelectedGroup
            this.lblSelectedGroup.AutoSize = true;
            this.lblSelectedGroup.Location = new System.Drawing.Point(120, 125);
            this.lblSelectedGroup.Name = "lblSelectedGroup";
            this.lblSelectedGroup.Size = new System.Drawing.Size(115, 15);
            this.lblSelectedGroup.Text = "No group selected.";

            // btnSelectGroup
            this.btnSelectGroup.Location = new System.Drawing.Point(120, 145);
            this.btnSelectGroup.Name = "btnSelectGroup";
            this.btnSelectGroup.Size = new System.Drawing.Size(120, 25);
            this.btnSelectGroup.Text = "Select Group";
            this.btnSelectGroup.UseVisualStyleBackColor = true;
            this.btnSelectGroup.Click += new System.EventHandler(this.btnSelectGroup_Click);

            // btnSubmit
            this.btnSubmit.Location = new System.Drawing.Point(165, 190);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 27);
            this.btnSubmit.Text = "Add";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(245, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddSpeciesForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(340, 240);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSelectGroup);
            this.Controls.Add(this.lblSelectedGroup);
            this.Controls.Add(this.lblGroupLabel);
            this.Controls.Add(this.txtBiome);
            this.Controls.Add(this.lblBiome);
            this.Controls.Add(this.txtCommonName);
            this.Controls.Add(this.lblCommonName);
            this.Controls.Add(this.txtLatinName);
            this.Controls.Add(this.lblLatinName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddSpeciesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Species";
            this.Load += new System.EventHandler(this.AddSpeciesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
