using System.Windows.Forms;

namespace ZooApp
{
    partial class StaffActivityForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblInfo = new Label();
            this.SuspendLayout();

            // 
            // lblInfo
            // 
            this.lblInfo.Text = "Staff Activity Form - Under Construction";
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(30, 30);

            // 
            // StaffActivityForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.lblInfo);
            this.Name = "StaffActivityForm";
            this.Text = "Staff Activity Form";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
