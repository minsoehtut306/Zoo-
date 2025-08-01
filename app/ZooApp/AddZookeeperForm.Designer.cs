namespace ZooApp
{
    partial class AddZookeeperForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblKeeper = new System.Windows.Forms.Label();
            this.lblAssigned = new System.Windows.Forms.Label();
            this.butUpdate = new System.Windows.Forms.Button();
            this.clbGroups = new System.Windows.Forms.CheckedListBox();
            this.cbSelectZookeeper = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(183, 554);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(165, 35);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblKeeper
            // 
            this.lblKeeper.AutoSize = true;
            this.lblKeeper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblKeeper.Location = new System.Drawing.Point(12, 28);
            this.lblKeeper.Name = "lblKeeper";
            this.lblKeeper.Size = new System.Drawing.Size(139, 20);
            this.lblKeeper.TabIndex = 6;
            this.lblKeeper.Text = "Select Zookeeper:";
            // 
            // lblAssigned
            // 
            this.lblAssigned.AutoSize = true;
            this.lblAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAssigned.Location = new System.Drawing.Point(12, 64);
            this.lblAssigned.Name = "lblAssigned";
            this.lblAssigned.Size = new System.Drawing.Size(197, 20);
            this.lblAssigned.TabIndex = 8;
            this.lblAssigned.Text = "Assigned Species Groups:";
            // 
            // butUpdate
            // 
            this.butUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.butUpdate.Location = new System.Drawing.Point(12, 554);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(165, 35);
            this.butUpdate.TabIndex = 27;
            this.butUpdate.Text = "Update";
            this.butUpdate.UseVisualStyleBackColor = true;
            this.butUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // clbGroups
            // 
            this.clbGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbGroups.FormattingEnabled = true;
            this.clbGroups.Location = new System.Drawing.Point(12, 87);
            this.clbGroups.Name = "clbGroups";
            this.clbGroups.Size = new System.Drawing.Size(336, 445);
            this.clbGroups.TabIndex = 28;
            // 
            // cbSelectZookeeper
            // 
            this.cbSelectZookeeper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectZookeeper.FormattingEnabled = true;
            this.cbSelectZookeeper.Location = new System.Drawing.Point(157, 20);
            this.cbSelectZookeeper.Name = "cbSelectZookeeper";
            this.cbSelectZookeeper.Size = new System.Drawing.Size(191, 28);
            this.cbSelectZookeeper.TabIndex = 29;
            this.cbSelectZookeeper.SelectedIndexChanged += new System.EventHandler(this.cbSelectZookeeper_SelectedIndexChanged);
            // 
            // AddZookeeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 600);
            this.Controls.Add(this.cbSelectZookeeper);
            this.Controls.Add(this.clbGroups);
            this.Controls.Add(this.butUpdate);
            this.Controls.Add(this.lblAssigned);
            this.Controls.Add(this.lblKeeper);
            this.Controls.Add(this.btnCancel);
            this.Name = "AddZookeeperForm";
            this.Text = "Manage Zookeeper Assignments";
            this.Load += new System.EventHandler(this.AddZookeeperForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblKeeper;
        private System.Windows.Forms.Label lblAssigned;
        private System.Windows.Forms.Button butUpdate;
        private System.Windows.Forms.CheckedListBox clbGroups;
        private System.Windows.Forms.ComboBox cbSelectZookeeper;
    }
}
