namespace ZooApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cbDataset;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCheckTables;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbDataset = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCheckTables = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheckCollections = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(45, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Welcome to the Zoo System";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbDataset
            // 
            this.cbDataset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataset.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbDataset.FormattingEnabled = true;
            this.cbDataset.Location = new System.Drawing.Point(12, 126);
            this.cbDataset.Name = "cbDataset";
            this.cbDataset.Size = new System.Drawing.Size(336, 29);
            this.cbDataset.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(12, 456);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(336, 40);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCheckTables
            // 
            this.btnCheckTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckTables.Location = new System.Drawing.Point(12, 502);
            this.btnCheckTables.Name = "btnCheckTables";
            this.btnCheckTables.Size = new System.Drawing.Size(336, 40);
            this.btnCheckTables.TabIndex = 3;
            this.btnCheckTables.Text = "Check Accessible Tables SQL";
            this.btnCheckTables.UseVisualStyleBackColor = true;
            this.btnCheckTables.Click += new System.EventHandler(this.btnCheckTables_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(53, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please Select the DataBase";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCheckCollections
            // 
            this.btnCheckCollections.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckCollections.Location = new System.Drawing.Point(12, 548);
            this.btnCheckCollections.Name = "btnCheckCollections";
            this.btnCheckCollections.Size = new System.Drawing.Size(336, 40);
            this.btnCheckCollections.TabIndex = 5;
            this.btnCheckCollections.Text = "Check Accessible Collections";
            this.btnCheckCollections.UseVisualStyleBackColor = true;
            this.btnCheckCollections.Click += new System.EventHandler(this.btnCheckCollections_Click);
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(360, 600);
            this.Controls.Add(this.btnCheckCollections);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cbDataset);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnCheckTables);
            this.Name = "LoginForm";
            this.Text = "ZooApp Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckCollections;
    }
}
