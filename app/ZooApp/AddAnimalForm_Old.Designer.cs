namespace ZooApp
{
    partial class AddAnimalForm
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
            this.txtAnimalName = new System.Windows.Forms.TextBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtFeedingInterval = new System.Windows.Forms.TextBox();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.cbEnclosure = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAnimalName = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblFeedingInterval = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblEnclosure = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();

            this.cbSpecies = new System.Windows.Forms.ComboBox();
            this.btnEditSpecies = new System.Windows.Forms.Button();
            this.btnUpdateSpecies = new System.Windows.Forms.Button();
            this.btnNewSpecies = new System.Windows.Forms.Button();
            this.lblSpeciesCommon = new System.Windows.Forms.Label();
            this.txtSpeciesCommon = new System.Windows.Forms.TextBox();
            this.lblSpeciesLatin = new System.Windows.Forms.Label();
            this.txtSpeciesLatin = new System.Windows.Forms.TextBox();
            this.lblBiome = new System.Windows.Forms.Label();
            this.txtBiome = new System.Windows.Forms.TextBox();

            this.lblGroupCommon = new System.Windows.Forms.Label();
            this.txtGroupCommon = new System.Windows.Forms.TextBox();
            this.lblGroupLatin = new System.Windows.Forms.Label();
            this.txtGroupLatin = new System.Windows.Forms.TextBox();
            this.btnEditGroup = new System.Windows.Forms.Button();
            this.btnUpdateGroup = new System.Windows.Forms.Button();
            this.btnNewGroup = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // Labels and fields for Animal Info
            this.lblAnimalName.Text = "Name:";
            this.lblAnimalName.Location = new System.Drawing.Point(20, 20);
            this.txtAnimalName.Location = new System.Drawing.Point(120, 20);
            this.txtAnimalName.Size = new System.Drawing.Size(287, 20);

            this.lblDOB.Text = "Date of Birth:";
            this.lblDOB.Location = new System.Drawing.Point(20, 55);
            this.dtpDOB.Location = new System.Drawing.Point(120, 55);
            this.dtpDOB.Size = new System.Drawing.Size(287, 20);

            this.lblWeight.Text = "Weight (kg):";
            this.lblWeight.Location = new System.Drawing.Point(20, 90);
            this.txtWeight.Location = new System.Drawing.Point(120, 90);
            this.txtWeight.Size = new System.Drawing.Size(287, 20);

            this.lblCountry.Text = "Origin Country:";
            this.lblCountry.Location = new System.Drawing.Point(20, 125);
            this.txtCountry.Location = new System.Drawing.Point(120, 125);
            this.txtCountry.Size = new System.Drawing.Size(287, 20);

            this.lblFeedingInterval.Text = "Feeding Interval:";
            this.lblFeedingInterval.Location = new System.Drawing.Point(20, 160);
            this.txtFeedingInterval.Location = new System.Drawing.Point(120, 160);
            this.txtFeedingInterval.Size = new System.Drawing.Size(287, 20);

            this.lblSex.Text = "Sex:";
            this.lblSex.Location = new System.Drawing.Point(20, 195);
            this.cbSex.Location = new System.Drawing.Point(120, 195);
            this.cbSex.Size = new System.Drawing.Size(287, 21);

            this.lblEnclosure.Text = "Enclosure:";
            this.lblEnclosure.Location = new System.Drawing.Point(20, 230);
            this.cbEnclosure.Location = new System.Drawing.Point(120, 230);
            this.cbEnclosure.Size = new System.Drawing.Size(287, 21);

            // Species ComboBox
            this.label1.Text = "Species:";
            this.label1.Location = new System.Drawing.Point(20, 265);
            this.cbSpecies.Location = new System.Drawing.Point(120, 265);
            this.cbSpecies.Size = new System.Drawing.Size(287, 21);
            this.cbSpecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecies.SelectedIndexChanged += new System.EventHandler(this.cbSpecies_SelectedIndexChanged);

            // Species Buttons
            this.btnEditSpecies.Text = "Edit";
            this.btnEditSpecies.Location = new System.Drawing.Point(120, 295);
            this.btnEditSpecies.Size = new System.Drawing.Size(60, 23);
            this.btnEditSpecies.Click += new System.EventHandler(this.btnEditSpecies_Click);

            this.btnUpdateSpecies.Text = "Update";
            this.btnUpdateSpecies.Location = new System.Drawing.Point(190, 295);
            this.btnUpdateSpecies.Size = new System.Drawing.Size(70, 23);
            this.btnUpdateSpecies.Click += new System.EventHandler(this.btnUpdateSpecies_Click);

            this.btnNewSpecies.Text = "New";
            this.btnNewSpecies.Location = new System.Drawing.Point(270, 295);
            this.btnNewSpecies.Size = new System.Drawing.Size(70, 23);
            this.btnNewSpecies.Click += new System.EventHandler(this.btnNewSpecies_Click);

            // Species TextBoxes
            this.lblSpeciesCommon.Text = "Common Name:";
            this.lblSpeciesCommon.Location = new System.Drawing.Point(20, 330);
            this.txtSpeciesCommon.Location = new System.Drawing.Point(120, 330);
            this.txtSpeciesCommon.Size = new System.Drawing.Size(287, 20);
            this.txtSpeciesCommon.ReadOnly = true;

            this.lblSpeciesLatin.Text = "Latin Name:";
            this.lblSpeciesLatin.Location = new System.Drawing.Point(20, 360);
            this.txtSpeciesLatin.Location = new System.Drawing.Point(120, 360);
            this.txtSpeciesLatin.Size = new System.Drawing.Size(287, 20);
            this.txtSpeciesLatin.ReadOnly = true;

            this.lblBiome.Text = "Required Biome:";
            this.lblBiome.Location = new System.Drawing.Point(20, 390);
            this.txtBiome.Location = new System.Drawing.Point(120, 390);
            this.txtBiome.Size = new System.Drawing.Size(287, 20);
            this.txtBiome.ReadOnly = true;

            // Group Info
            this.lblGroupCommon.Text = "Group Common:";
            this.lblGroupCommon.Location = new System.Drawing.Point(20, 420);
            this.txtGroupCommon.Location = new System.Drawing.Point(120, 420);
            this.txtGroupCommon.Size = new System.Drawing.Size(287, 20);
            this.txtGroupCommon.ReadOnly = true;

            this.lblGroupLatin.Text = "Group Latin:";
            this.lblGroupLatin.Location = new System.Drawing.Point(20, 450);
            this.txtGroupLatin.Location = new System.Drawing.Point(120, 450);
            this.txtGroupLatin.Size = new System.Drawing.Size(287, 20);
            this.txtGroupLatin.ReadOnly = true;

            // Group Buttons
            this.btnEditGroup.Text = "Edit";
            this.btnEditGroup.Location = new System.Drawing.Point(120, 480);
            this.btnEditGroup.Size = new System.Drawing.Size(60, 23);
            this.btnEditGroup.Click += new System.EventHandler(this.btnEditGroup_Click);

            this.btnUpdateGroup.Text = "Update";
            this.btnUpdateGroup.Location = new System.Drawing.Point(190, 480);
            this.btnUpdateGroup.Size = new System.Drawing.Size(70, 23);
            this.btnUpdateGroup.Click += new System.EventHandler(this.btnUpdateGroup_Click);

            this.btnNewGroup.Text = "New";
            this.btnNewGroup.Location = new System.Drawing.Point(270, 480);
            this.btnNewGroup.Size = new System.Drawing.Size(70, 23);
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);

            // Submit and Cancel
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Location = new System.Drawing.Point(120, 520);
            this.btnSubmit.Size = new System.Drawing.Size(100, 30);
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(307, 520);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblAnimalName);
            this.Controls.Add(this.txtAnimalName);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.lblFeedingInterval);
            this.Controls.Add(this.txtFeedingInterval);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.lblEnclosure);
            this.Controls.Add(this.cbEnclosure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSpecies);
            this.Controls.Add(this.btnEditSpecies);
            this.Controls.Add(this.btnUpdateSpecies);
            this.Controls.Add(this.btnNewSpecies);
            this.Controls.Add(this.lblSpeciesCommon);
            this.Controls.Add(this.txtSpeciesCommon);
            this.Controls.Add(this.lblSpeciesLatin);
            this.Controls.Add(this.txtSpeciesLatin);
            this.Controls.Add(this.lblBiome);
            this.Controls.Add(this.txtBiome);
            this.Controls.Add(this.lblGroupCommon);
            this.Controls.Add(this.txtGroupCommon);
            this.Controls.Add(this.lblGroupLatin);
            this.Controls.Add(this.txtGroupLatin);
            this.Controls.Add(this.btnEditGroup);
            this.Controls.Add(this.btnUpdateGroup);
            this.Controls.Add(this.btnNewGroup);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);

            this.ClientSize = new System.Drawing.Size(440, 580);
            this.Name = "AddAnimalForm";
            this.Text = "Add or Edit Animal";
            this.Load += new System.EventHandler(this.AddAnimalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtAnimalName;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtFeedingInterval;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.ComboBox cbEnclosure;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblAnimalName;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblFeedingInterval;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblEnclosure;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ComboBox cbSpecies;
        private System.Windows.Forms.Button btnEditSpecies;
        private System.Windows.Forms.Button btnUpdateSpecies;
        private System.Windows.Forms.Button btnNewSpecies;
        private System.Windows.Forms.Label lblSpeciesCommon;
        private System.Windows.Forms.TextBox txtSpeciesCommon;
        private System.Windows.Forms.Label lblSpeciesLatin;
        private System.Windows.Forms.TextBox txtSpeciesLatin;
        private System.Windows.Forms.Label lblBiome;
        private System.Windows.Forms.TextBox txtBiome;

        private System.Windows.Forms.Label lblGroupCommon;
        private System.Windows.Forms.TextBox txtGroupCommon;
        private System.Windows.Forms.Label lblGroupLatin;
        private System.Windows.Forms.TextBox txtGroupLatin;
        private System.Windows.Forms.Button btnEditGroup;
        private System.Windows.Forms.Button btnUpdateGroup;
        private System.Windows.Forms.Button btnNewGroup;
    }
}
