namespace ZooApp
{
    partial class AddZoneForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtColour;
        private System.Windows.Forms.TextBox txtHexcode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblColour;
        private System.Windows.Forms.Label lblHex;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtColour = new System.Windows.Forms.TextBox();
            this.txtHexcode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblColour = new System.Windows.Forms.Label();
            this.lblHex = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(73, 15);
            this.lblName.Text = "Zone Name:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);

            // lblColour
            this.lblColour.AutoSize = true;
            this.lblColour.Location = new System.Drawing.Point(20, 60);
            this.lblColour.Name = "lblColour";
            this.lblColour.Size = new System.Drawing.Size(47, 15);
            this.lblColour.Text = "Colour:";

            // txtColour
            this.txtColour.Location = new System.Drawing.Point(120, 57);
            this.txtColour.Name = "txtColour";
            this.txtColour.Size = new System.Drawing.Size(200, 23);

            // lblHex
            this.lblHex.AutoSize = true;
            this.lblHex.Location = new System.Drawing.Point(20, 100);
            this.lblHex.Name = "lblHex";
            this.lblHex.Size = new System.Drawing.Size(79, 15);
            this.lblHex.Text = "Hex Code (#):";

            // txtHexcode
            this.txtHexcode.Location = new System.Drawing.Point(120, 97);
            this.txtHexcode.Name = "txtHexcode";
            this.txtHexcode.Size = new System.Drawing.Size(200, 23);

            // btnSubmit
            this.btnSubmit.Location = new System.Drawing.Point(165, 140);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 27);
            this.btnSubmit.Text = "Add";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(245, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddZoneForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(340, 190);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtHexcode);
            this.Controls.Add(this.lblHex);
            this.Controls.Add(this.txtColour);
            this.Controls.Add(this.lblColour);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddZoneForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Zone";
            this.Load += new System.EventHandler(this.AddZoneForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
