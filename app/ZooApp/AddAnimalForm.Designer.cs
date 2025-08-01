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
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.txtFeeding = new System.Windows.Forms.TextBox();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.cbEnclosure = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
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
            this.btnDeleteSpecies = new System.Windows.Forms.Button();
            this.btnUpdateSpecies = new System.Windows.Forms.Button();
            this.btnAddSpecies = new System.Windows.Forms.Button();
            this.lblSpeciesCommon = new System.Windows.Forms.Label();
            this.txtCommonName = new System.Windows.Forms.TextBox();
            this.lblSpeciesLatin = new System.Windows.Forms.Label();
            this.txtLatinName = new System.Windows.Forms.TextBox();
            this.lblBiome = new System.Windows.Forms.Label();
            this.txtRequiredBiome = new System.Windows.Forms.TextBox();
            this.lblGroupCommon = new System.Windows.Forms.Label();
            this.txtGroupCommon = new System.Windows.Forms.TextBox();
            this.lblGroupLatin = new System.Windows.Forms.Label();
            this.txtGroupLatin = new System.Windows.Forms.TextBox();
            this.btnDeleteSpeciesGroup = new System.Windows.Forms.Button();
            this.btnUpdateSpeciesGroup = new System.Windows.Forms.Button();
            this.btnAddSpeciesGroup = new System.Windows.Forms.Button();
            this.cbSpeciesGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.butAdd = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRelatedSpeciesGroup = new System.Windows.Forms.TextBox();
            this.cbSelectAnimal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtAnimalName
            // 
            this.txtAnimalName.Location = new System.Drawing.Point(120, 39);
            this.txtAnimalName.Name = "txtAnimalName";
            this.txtAnimalName.Size = new System.Drawing.Size(228, 20);
            this.txtAnimalName.TabIndex = 1;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(120, 65);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(228, 20);
            this.dtpDOB.TabIndex = 3;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(120, 91);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(228, 20);
            this.txtWeight.TabIndex = 5;
            // 
            // txtOrigin
            // 
            this.txtOrigin.Location = new System.Drawing.Point(120, 117);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(228, 20);
            this.txtOrigin.TabIndex = 7;
            // 
            // txtFeeding
            // 
            this.txtFeeding.Location = new System.Drawing.Point(120, 143);
            this.txtFeeding.Name = "txtFeeding";
            this.txtFeeding.Size = new System.Drawing.Size(228, 20);
            this.txtFeeding.TabIndex = 9;
            // 
            // cbSex
            // 
            this.cbSex.Location = new System.Drawing.Point(120, 169);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(228, 21);
            this.cbSex.TabIndex = 11;
            // 
            // cbEnclosure
            // 
            this.cbEnclosure.Location = new System.Drawing.Point(120, 196);
            this.cbEnclosure.Name = "cbEnclosure";
            this.cbEnclosure.Size = new System.Drawing.Size(228, 21);
            this.cbEnclosure.TabIndex = 13;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(140, 550);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(246, 586);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAnimalName
            // 
            this.lblAnimalName.Location = new System.Drawing.Point(14, 39);
            this.lblAnimalName.Name = "lblAnimalName";
            this.lblAnimalName.Size = new System.Drawing.Size(100, 23);
            this.lblAnimalName.TabIndex = 0;
            this.lblAnimalName.Text = "Animal Name:";
            // 
            // lblDOB
            // 
            this.lblDOB.Location = new System.Drawing.Point(14, 65);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(100, 23);
            this.lblDOB.TabIndex = 2;
            this.lblDOB.Text = "Date of Birth:";
            // 
            // lblWeight
            // 
            this.lblWeight.Location = new System.Drawing.Point(14, 91);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(100, 23);
            this.lblWeight.TabIndex = 4;
            this.lblWeight.Text = "Weight (kg):";
            // 
            // lblCountry
            // 
            this.lblCountry.Location = new System.Drawing.Point(14, 117);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(100, 23);
            this.lblCountry.TabIndex = 6;
            this.lblCountry.Text = "Origin Country:";
            // 
            // lblFeedingInterval
            // 
            this.lblFeedingInterval.Location = new System.Drawing.Point(14, 143);
            this.lblFeedingInterval.Name = "lblFeedingInterval";
            this.lblFeedingInterval.Size = new System.Drawing.Size(100, 23);
            this.lblFeedingInterval.TabIndex = 8;
            this.lblFeedingInterval.Text = "Feeding Interval:";
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(14, 169);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(100, 23);
            this.lblSex.TabIndex = 10;
            this.lblSex.Text = "Sex:";
            // 
            // lblEnclosure
            // 
            this.lblEnclosure.Location = new System.Drawing.Point(14, 196);
            this.lblEnclosure.Name = "lblEnclosure";
            this.lblEnclosure.Size = new System.Drawing.Size(100, 23);
            this.lblEnclosure.TabIndex = 12;
            this.lblEnclosure.Text = "Enclosure:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Species:";
            // 
            // cbSpecies
            // 
            this.cbSpecies.AllowDrop = true;
            this.cbSpecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecies.Location = new System.Drawing.Point(116, 250);
            this.cbSpecies.Name = "cbSpecies";
            this.cbSpecies.Size = new System.Drawing.Size(232, 21);
            this.cbSpecies.TabIndex = 15;
            this.cbSpecies.SelectedIndexChanged += new System.EventHandler(this.cbSpecies_SelectedIndexChanged);
            // 
            // btnDeleteSpecies
            // 
            this.btnDeleteSpecies.Location = new System.Drawing.Point(116, 277);
            this.btnDeleteSpecies.Name = "btnDeleteSpecies";
            this.btnDeleteSpecies.Size = new System.Drawing.Size(66, 23);
            this.btnDeleteSpecies.TabIndex = 16;
            this.btnDeleteSpecies.Text = "Delete";
            this.btnDeleteSpecies.Click += new System.EventHandler(this.btnDeleteSpecies_Click);
            // 
            // btnUpdateSpecies
            // 
            this.btnUpdateSpecies.Location = new System.Drawing.Point(188, 277);
            this.btnUpdateSpecies.Name = "btnUpdateSpecies";
            this.btnUpdateSpecies.Size = new System.Drawing.Size(76, 23);
            this.btnUpdateSpecies.TabIndex = 17;
            this.btnUpdateSpecies.Text = "Update";
            this.btnUpdateSpecies.Click += new System.EventHandler(this.btnUpdateSpecies_Click);
            // 
            // btnAddSpecies
            // 
            this.btnAddSpecies.Location = new System.Drawing.Point(270, 277);
            this.btnAddSpecies.Name = "btnAddSpecies";
            this.btnAddSpecies.Size = new System.Drawing.Size(76, 23);
            this.btnAddSpecies.TabIndex = 18;
            this.btnAddSpecies.Text = "Add New";
            this.btnAddSpecies.Click += new System.EventHandler(this.btnAddSpecies_Click);
            // 
            // lblSpeciesCommon
            // 
            this.lblSpeciesCommon.Location = new System.Drawing.Point(12, 336);
            this.lblSpeciesCommon.Name = "lblSpeciesCommon";
            this.lblSpeciesCommon.Size = new System.Drawing.Size(125, 23);
            this.lblSpeciesCommon.TabIndex = 19;
            this.lblSpeciesCommon.Text = "Species Common Name:";
            // 
            // txtCommonName
            // 
            this.txtCommonName.Location = new System.Drawing.Point(145, 332);
            this.txtCommonName.Name = "txtCommonName";
            this.txtCommonName.ReadOnly = true;
            this.txtCommonName.Size = new System.Drawing.Size(203, 20);
            this.txtCommonName.TabIndex = 20;
            // 
            // lblSpeciesLatin
            // 
            this.lblSpeciesLatin.Location = new System.Drawing.Point(14, 309);
            this.lblSpeciesLatin.Name = "lblSpeciesLatin";
            this.lblSpeciesLatin.Size = new System.Drawing.Size(115, 23);
            this.lblSpeciesLatin.TabIndex = 21;
            this.lblSpeciesLatin.Text = "Species Latin Name:";
            // 
            // txtLatinName
            // 
            this.txtLatinName.Location = new System.Drawing.Point(145, 306);
            this.txtLatinName.Name = "txtLatinName";
            this.txtLatinName.ReadOnly = true;
            this.txtLatinName.Size = new System.Drawing.Size(203, 20);
            this.txtLatinName.TabIndex = 22;
            // 
            // lblBiome
            // 
            this.lblBiome.Location = new System.Drawing.Point(10, 358);
            this.lblBiome.Name = "lblBiome";
            this.lblBiome.Size = new System.Drawing.Size(100, 23);
            this.lblBiome.TabIndex = 23;
            this.lblBiome.Text = "Required Biome:";
            // 
            // txtRequiredBiome
            // 
            this.txtRequiredBiome.Location = new System.Drawing.Point(143, 358);
            this.txtRequiredBiome.Name = "txtRequiredBiome";
            this.txtRequiredBiome.ReadOnly = true;
            this.txtRequiredBiome.Size = new System.Drawing.Size(203, 20);
            this.txtRequiredBiome.TabIndex = 24;
            // 
            // lblGroupCommon
            // 
            this.lblGroupCommon.Location = new System.Drawing.Point(12, 524);
            this.lblGroupCommon.Name = "lblGroupCommon";
            this.lblGroupCommon.Size = new System.Drawing.Size(155, 23);
            this.lblGroupCommon.TabIndex = 25;
            this.lblGroupCommon.Text = "Species Group Common Name:";
            // 
            // txtGroupCommon
            // 
            this.txtGroupCommon.Location = new System.Drawing.Point(173, 521);
            this.txtGroupCommon.Name = "txtGroupCommon";
            this.txtGroupCommon.ReadOnly = true;
            this.txtGroupCommon.Size = new System.Drawing.Size(175, 20);
            this.txtGroupCommon.TabIndex = 26;
            // 
            // lblGroupLatin
            // 
            this.lblGroupLatin.Location = new System.Drawing.Point(14, 495);
            this.lblGroupLatin.Name = "lblGroupLatin";
            this.lblGroupLatin.Size = new System.Drawing.Size(141, 23);
            this.lblGroupLatin.TabIndex = 27;
            this.lblGroupLatin.Text = "Species Group Latin Name:";
            // 
            // txtGroupLatin
            // 
            this.txtGroupLatin.Location = new System.Drawing.Point(173, 492);
            this.txtGroupLatin.Name = "txtGroupLatin";
            this.txtGroupLatin.ReadOnly = true;
            this.txtGroupLatin.Size = new System.Drawing.Size(175, 20);
            this.txtGroupLatin.TabIndex = 28;
            // 
            // btnDeleteSpeciesGroup
            // 
            this.btnDeleteSpeciesGroup.Location = new System.Drawing.Point(116, 463);
            this.btnDeleteSpeciesGroup.Name = "btnDeleteSpeciesGroup";
            this.btnDeleteSpeciesGroup.Size = new System.Drawing.Size(66, 23);
            this.btnDeleteSpeciesGroup.TabIndex = 29;
            this.btnDeleteSpeciesGroup.Text = "Delete";
            this.btnDeleteSpeciesGroup.Click += new System.EventHandler(this.btnDeleteSpeciesGroup_Click);
            // 
            // btnUpdateSpeciesGroup
            // 
            this.btnUpdateSpeciesGroup.Location = new System.Drawing.Point(188, 463);
            this.btnUpdateSpeciesGroup.Name = "btnUpdateSpeciesGroup";
            this.btnUpdateSpeciesGroup.Size = new System.Drawing.Size(76, 23);
            this.btnUpdateSpeciesGroup.TabIndex = 30;
            this.btnUpdateSpeciesGroup.Text = "Update";
            this.btnUpdateSpeciesGroup.Click += new System.EventHandler(this.btnUpdateSpeciesGroup_Click);
            // 
            // btnAddSpeciesGroup
            // 
            this.btnAddSpeciesGroup.Location = new System.Drawing.Point(270, 463);
            this.btnAddSpeciesGroup.Name = "btnAddSpeciesGroup";
            this.btnAddSpeciesGroup.Size = new System.Drawing.Size(76, 23);
            this.btnAddSpeciesGroup.TabIndex = 31;
            this.btnAddSpeciesGroup.Text = "Add New";
            this.btnAddSpeciesGroup.Click += new System.EventHandler(this.btnAddSpeciesGroup_Click);
            // 
            // cbSpeciesGroup
            // 
            this.cbSpeciesGroup.AllowDrop = true;
            this.cbSpeciesGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeciesGroup.Location = new System.Drawing.Point(116, 436);
            this.cbSpeciesGroup.Name = "cbSpeciesGroup";
            this.cbSpeciesGroup.Size = new System.Drawing.Size(232, 21);
            this.cbSpeciesGroup.TabIndex = 34;
            this.cbSpeciesGroup.SelectedIndexChanged += new System.EventHandler(this.cbSpeciesGroup_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 35;
            this.label2.Text = "Species Group:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Select Animal:";
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(246, 550);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(100, 30);
            this.butAdd.TabIndex = 38;
            this.butAdd.Text = "Add";
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(140, 586);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(100, 30);
            this.butDelete.TabIndex = 39;
            this.butDelete.Text = "Delete";
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 23);
            this.label6.TabIndex = 44;
            this.label6.Text = "Realted Species Group:";
            // 
            // txtRelatedSpeciesGroup
            // 
            this.txtRelatedSpeciesGroup.Location = new System.Drawing.Point(143, 384);
            this.txtRelatedSpeciesGroup.Name = "txtRelatedSpeciesGroup";
            this.txtRelatedSpeciesGroup.ReadOnly = true;
            this.txtRelatedSpeciesGroup.Size = new System.Drawing.Size(203, 20);
            this.txtRelatedSpeciesGroup.TabIndex = 45;
            // 
            // cbSelectAnimal
            // 
            this.cbSelectAnimal.FormattingEnabled = true;
            this.cbSelectAnimal.Location = new System.Drawing.Point(120, 9);
            this.cbSelectAnimal.Name = "cbSelectAnimal";
            this.cbSelectAnimal.Size = new System.Drawing.Size(228, 21);
            this.cbSelectAnimal.TabIndex = 46;
            this.cbSelectAnimal.SelectedIndexChanged += new System.EventHandler(this.cbSelectAnimal_SelectedIndexChanged);
            // 
            // AddAnimalForm
            // 
            this.ClientSize = new System.Drawing.Size(360, 625);
            this.Controls.Add(this.cbSelectAnimal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRelatedSpeciesGroup);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSpeciesGroup);
            this.Controls.Add(this.lblAnimalName);
            this.Controls.Add(this.txtAnimalName);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtOrigin);
            this.Controls.Add(this.lblFeedingInterval);
            this.Controls.Add(this.txtFeeding);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.lblEnclosure);
            this.Controls.Add(this.cbEnclosure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSpecies);
            this.Controls.Add(this.btnDeleteSpecies);
            this.Controls.Add(this.btnUpdateSpecies);
            this.Controls.Add(this.btnAddSpecies);
            this.Controls.Add(this.lblSpeciesCommon);
            this.Controls.Add(this.txtCommonName);
            this.Controls.Add(this.lblSpeciesLatin);
            this.Controls.Add(this.txtLatinName);
            this.Controls.Add(this.lblBiome);
            this.Controls.Add(this.txtRequiredBiome);
            this.Controls.Add(this.lblGroupCommon);
            this.Controls.Add(this.txtGroupCommon);
            this.Controls.Add(this.lblGroupLatin);
            this.Controls.Add(this.txtGroupLatin);
            this.Controls.Add(this.btnDeleteSpeciesGroup);
            this.Controls.Add(this.btnUpdateSpeciesGroup);
            this.Controls.Add(this.btnAddSpeciesGroup);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCancel);
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
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.TextBox txtFeeding;
        private System.Windows.Forms.ComboBox cbSex;
        private System.Windows.Forms.ComboBox cbEnclosure;
        private System.Windows.Forms.Button btnUpdate;
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
        private System.Windows.Forms.Button btnDeleteSpecies;
        private System.Windows.Forms.Button btnUpdateSpecies;
        private System.Windows.Forms.Button btnAddSpecies;
        private System.Windows.Forms.Label lblSpeciesCommon;
        private System.Windows.Forms.TextBox txtCommonName;
        private System.Windows.Forms.Label lblSpeciesLatin;
        private System.Windows.Forms.TextBox txtLatinName;
        private System.Windows.Forms.Label lblBiome;
        private System.Windows.Forms.TextBox txtRequiredBiome;

        private System.Windows.Forms.Label lblGroupCommon;
        private System.Windows.Forms.TextBox txtGroupCommon;
        private System.Windows.Forms.Label lblGroupLatin;
        private System.Windows.Forms.TextBox txtGroupLatin;
        private System.Windows.Forms.Button btnDeleteSpeciesGroup;
        private System.Windows.Forms.Button btnUpdateSpeciesGroup;
        private System.Windows.Forms.Button btnAddSpeciesGroup;
        private System.Windows.Forms.ComboBox cbSpeciesGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRelatedSpeciesGroup;
        private System.Windows.Forms.ComboBox cbSelectAnimal;
    }
}
