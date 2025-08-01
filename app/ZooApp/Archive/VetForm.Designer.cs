namespace ZooApp
{
    partial class VetForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cbAnimal = new System.Windows.Forms.ComboBox();
            this.cbVet = new System.Windows.Forms.ComboBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtCareType = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAnimal = new System.Windows.Forms.Label();
            this.lblVet = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblCareType = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // cbAnimal
            this.cbAnimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnimal.Location = new System.Drawing.Point(130, 20);
            this.cbAnimal.Name = "cbAnimal";
            this.cbAnimal.Size = new System.Drawing.Size(200, 21);

            // cbVet
            this.cbVet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVet.Location = new System.Drawing.Point(130, 60);
            this.cbVet.Name = "cbVet";
            this.cbVet.Size = new System.Drawing.Size(200, 21);

            // dtpTime
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpTime.Location = new System.Drawing.Point(130, 100);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(200, 20);

            // txtCareType
            this.txtCareType.Location = new System.Drawing.Point(130, 140);
            this.txtCareType.Name = "txtCareType";
            this.txtCareType.Size = new System.Drawing.Size(200, 20);

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(130, 180);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(200, 60);

            // btnSubmit
            this.btnSubmit.Location = new System.Drawing.Point(70, 260);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 30);
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(200, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Labels
            this.lblAnimal.Location = new System.Drawing.Point(30, 20);
            this.lblAnimal.Text = "Animal:";
            this.lblVet.Location = new System.Drawing.Point(30, 60);
            this.lblVet.Text = "Vet (Staff):";
            this.lblTime.Location = new System.Drawing.Point(30, 100);
            this.lblTime.Text = "Time:";
            this.lblCareType.Location = new System.Drawing.Point(30, 140);
            this.lblCareType.Text = "Care Type:";
            this.lblNotes.Location = new System.Drawing.Point(30, 180);
            this.lblNotes.Text = "Notes:";

            // VetForm
            this.ClientSize = new System.Drawing.Size(380, 320);
            this.Controls.Add(this.cbAnimal);
            this.Controls.Add(this.cbVet);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.txtCareType);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblAnimal);
            this.Controls.Add(this.lblVet);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblCareType);
            this.Controls.Add(this.lblNotes);
            this.Text = "Record Care";
            this.Load += new System.EventHandler(this.VetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cbAnimal;
        private System.Windows.Forms.ComboBox cbVet;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.TextBox txtCareType;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAnimal;
        private System.Windows.Forms.Label lblVet;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCareType;
        private System.Windows.Forms.Label lblNotes;
    }
}
