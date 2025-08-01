namespace ZooApp
{
    partial class SelectStaffForm
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
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonAddStaff = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.cbSelectStaff = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butUpdateVet = new System.Windows.Forms.Button();
            this.butUpdateZooKeeper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonQuit
            // 
            this.buttonQuit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonQuit.Location = new System.Drawing.Point(12, 539);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(336, 40);
            this.buttonQuit.TabIndex = 4;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonAddStaff
            // 
            this.buttonAddStaff.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonAddStaff.Location = new System.Drawing.Point(12, 493);
            this.buttonAddStaff.Name = "buttonAddStaff";
            this.buttonAddStaff.Size = new System.Drawing.Size(336, 40);
            this.buttonAddStaff.TabIndex = 3;
            this.buttonAddStaff.Text = "Add New Staff";
            this.buttonAddStaff.UseVisualStyleBackColor = true;
            this.buttonAddStaff.Click += new System.EventHandler(this.buttonAddStaff_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonLogin.Location = new System.Drawing.Point(12, 447);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(336, 40);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Log In";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelWelcome.Location = new System.Drawing.Point(60, 40);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(200, 25);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to Zoo App";
            // 
            // cbSelectStaff
            // 
            this.cbSelectStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectStaff.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbSelectStaff.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbSelectStaff.FormattingEnabled = true;
            this.cbSelectStaff.Location = new System.Drawing.Point(31, 129);
            this.cbSelectStaff.Name = "cbSelectStaff";
            this.cbSelectStaff.Size = new System.Drawing.Size(280, 29);
            this.cbSelectStaff.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Your Name:";
            // 
            // butUpdateVet
            // 
            this.butUpdateVet.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.butUpdateVet.Location = new System.Drawing.Point(178, 401);
            this.butUpdateVet.Name = "butUpdateVet";
            this.butUpdateVet.Size = new System.Drawing.Size(170, 40);
            this.butUpdateVet.TabIndex = 6;
            this.butUpdateVet.Text = "UpdateVet";
            this.butUpdateVet.UseVisualStyleBackColor = true;
            this.butUpdateVet.Click += new System.EventHandler(this.butUpdateVet_Click);
            // 
            // butUpdateZooKeeper
            // 
            this.butUpdateZooKeeper.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.butUpdateZooKeeper.Location = new System.Drawing.Point(12, 401);
            this.butUpdateZooKeeper.Name = "butUpdateZooKeeper";
            this.butUpdateZooKeeper.Size = new System.Drawing.Size(160, 40);
            this.butUpdateZooKeeper.TabIndex = 7;
            this.butUpdateZooKeeper.Text = "Update Zoo Keeper";
            this.butUpdateZooKeeper.UseVisualStyleBackColor = true;
            this.butUpdateZooKeeper.Click += new System.EventHandler(this.butUpdateZooKeeper_Click);
            // 
            // SelectStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 600);
            this.Controls.Add(this.butUpdateZooKeeper);
            this.Controls.Add(this.butUpdateVet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.cbSelectStaff);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonAddStaff);
            this.Controls.Add(this.buttonQuit);
            this.Name = "SelectStaffForm";
            this.Text = "SelectStaffForm";
            this.Load += new System.EventHandler(this.SelectStaffForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonAddStaff;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.ComboBox cbSelectStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butUpdateVet;
        private System.Windows.Forms.Button butUpdateZooKeeper;
    }
}
