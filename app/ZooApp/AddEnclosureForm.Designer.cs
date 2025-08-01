namespace ZooApp
{
    partial class AddEnclosureForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtBiome = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblBiome = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelectedZone = new System.Windows.Forms.Label();
            this.btnSelectZone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBiome
            // 
            this.txtBiome.Location = new System.Drawing.Point(117, 16);
            this.txtBiome.Margin = new System.Windows.Forms.Padding(2);
            this.txtBiome.Name = "txtBiome";
            this.txtBiome.Size = new System.Drawing.Size(227, 20);
            this.txtBiome.TabIndex = 0;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(117, 48);
            this.txtSize.Margin = new System.Windows.Forms.Padding(2);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(227, 20);
            this.txtSize.TabIndex = 1;
            // 
            // lblBiome
            // 
            this.lblBiome.AutoSize = true;
            this.lblBiome.Location = new System.Drawing.Point(22, 19);
            this.lblBiome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBiome.Name = "lblBiome";
            this.lblBiome.Size = new System.Drawing.Size(39, 13);
            this.lblBiome.TabIndex = 3;
            this.lblBiome.Text = "Biome:";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(22, 51);
            this.lblSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(58, 13);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "Zone Size:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(117, 122);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(99, 24);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(255, 122);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSelectedZone
            // 
            this.lblSelectedZone.AutoSize = true;
            this.lblSelectedZone.Location = new System.Drawing.Point(217, 87);
            this.lblSelectedZone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedZone.Name = "lblSelectedZone";
            this.lblSelectedZone.Size = new System.Drawing.Size(90, 13);
            this.lblSelectedZone.TabIndex = 10;
            this.lblSelectedZone.Text = "No zone selected";
            // 
            // btnSelectZone
            // 
            this.btnSelectZone.Location = new System.Drawing.Point(117, 82);
            this.btnSelectZone.Name = "btnSelectZone";
            this.btnSelectZone.Size = new System.Drawing.Size(95, 23);
            this.btnSelectZone.TabIndex = 9;
            this.btnSelectZone.Text = "Select Zone";
            this.btnSelectZone.UseVisualStyleBackColor = true;
            this.btnSelectZone.Click += new System.EventHandler(this.btnSelectZone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Zone Name:";
            // 
            // AddEnclosureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 162);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectZone);
            this.Controls.Add(this.lblSelectedZone);
            this.Controls.Add(this.txtBiome);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblBiome);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddEnclosureForm";
            this.Text = "Add/Edit Enclosure";
            this.Load += new System.EventHandler(this.AddEnclosureForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtBiome;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblBiome;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSelectedZone;
        private System.Windows.Forms.Button btnSelectZone;
        private System.Windows.Forms.Label label1;
    }
}
