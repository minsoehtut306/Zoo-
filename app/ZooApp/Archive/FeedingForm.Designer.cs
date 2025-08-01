namespace ZooApp
{
    partial class FeedingForm
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
            this.lblAnimal = new System.Windows.Forms.Label();
            this.cbAnimal = new System.Windows.Forms.ComboBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.cbStaff = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblFood = new System.Windows.Forms.Label();
            this.txtFood = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Animal Label
            this.lblAnimal.AutoSize = true;
            this.lblAnimal.Location = new System.Drawing.Point(30, 30);
            this.lblAnimal.Text = "Animal:";

            // Animal ComboBox
            this.cbAnimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimal.Location = new System.Drawing.Point(120, 30);
            this.cbAnimal.Size = new System.Drawing.Size(200, 21);

            // Staff Label
            this.lblStaff.AutoSize = true;
            this.lblStaff.Location = new System.Drawing.Point(30, 70);
            this.lblStaff.Text = "Staff:";

            // Staff ComboBox
            this.cbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStaff.Location = new System.Drawing.Point(120, 70);
            this.cbStaff.Size = new System.Drawing.Size(200, 21);

            // Date Label
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(30, 110);
            this.lblDate.Text = "Date:";

            // DateTimePicker
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(120, 110);
            this.dtpDate.Size = new System.Drawing.Size(200, 20);

            // Food Label
            this.lblFood.AutoSize = true;
            this.lblFood.Location = new System.Drawing.Point(30, 150);
            this.lblFood.Text = "Food Type:";

            // Food TextBox
            this.txtFood.Location = new System.Drawing.Point(120, 150);
            this.txtFood.Size = new System.Drawing.Size(200, 20);

            // Amount Label
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(30, 190);
            this.lblAmount.Text = "Amount (g):";

            // Amount TextBox
            this.txtAmount.Location = new System.Drawing.Point(120, 190);
            this.txtAmount.Size = new System.Drawing.Size(200, 20);

            // Submit Button
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(60, 240);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // Cancel Button
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(200, 240);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FeedingForm
            this.ClientSize = new System.Drawing.Size(370, 300);
            this.Controls.Add(this.lblAnimal);
            this.Controls.Add(this.cbAnimal);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.cbStaff);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblFood);
            this.Controls.Add(this.txtFood);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Name = "FeedingForm";
            this.Text = "Record Feeding";
            this.Load += new System.EventHandler(this.FeedingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblAnimal;
        private System.Windows.Forms.ComboBox cbAnimal;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.ComboBox cbStaff;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblFood;
        private System.Windows.Forms.TextBox txtFood;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}
