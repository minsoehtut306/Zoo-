namespace ZooApp
{
    partial class AddSpeciesGroupForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblLatinName;
        private System.Windows.Forms.Label lblCommonName;
        private System.Windows.Forms.TextBox txtLatinName;
        private System.Windows.Forms.TextBox txtCommonName;
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
            this.lblLatinName = new System.Windows.Forms.Label();
            this.lblCommonName = new System.Windows.Forms.Label();
            this.txtLatinName = new System.Windows.Forms.TextBox();
            this.txtCommonName = new System.Windows.Forms.TextBox();
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
            this.lblCommonName.Location = new System.Drawing.Point(20, 60);
            this.lblCommonName.Name = "lblCommonName";
            this.lblCommonName.Size = new System.Drawing.Size(94, 15);
            this.lblCommonName.Text = "Common Name:";

            // txtCommonName
            this.txtCommonName.Location = new System.Drawing.Point(120, 57);
            this.txtCommonName.Name = "txtCommonName";
            this.txtCommonName.Size = new System.Drawing.Size(200, 23);

            // btnSubmit
            this.btnSubmit.Location = new System.Drawing.Point(165, 100);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 27);
            this.btnSubmit.Text = "Add";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(245, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddSpeciesGroupForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(340, 150);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtCommonName);
            this.Controls.Add(this.lblCommonName);
            this.Controls.Add(this.txtLatinName);
            this.Controls.Add(this.lblLatinName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddSpeciesGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Species Group";
            this.Load += new System.EventHandler(this.AddSpeciesGroupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
