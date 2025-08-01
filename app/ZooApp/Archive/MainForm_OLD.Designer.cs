namespace ZooApp
{
    partial class MainForm_OLD
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
            this.components = new System.ComponentModel.Container();
            this.tabFeedingCare = new System.Windows.Forms.TabPage();
            this.button_filterFeedCare = new System.Windows.Forms.Button();
            this.label_dateFeedCare = new System.Windows.Forms.Label();
            this.dateTimePicker_feedCare = new System.Windows.Forms.DateTimePicker();
            this.label_staffIdFeedCare = new System.Windows.Forms.Label();
            this.label_animalIdFeedCare = new System.Windows.Forms.Label();
            this.textBox_staffIdFeedCare = new System.Windows.Forms.TextBox();
            this.textBox_animalIdFeedCare = new System.Windows.Forms.TextBox();
            this.checkBox_medicalHistory = new System.Windows.Forms.CheckBox();
            this.checkBox_feedingHistory = new System.Windows.Forms.CheckBox();
            this.feedingDataGridView = new System.Windows.Forms.DataGridView();
            this.btnRecordFeeding = new System.Windows.Forms.Button();
            this.btnRecordCare = new System.Windows.Forms.Button();
            this.tabStaff = new System.Windows.Forms.TabPage();
            this.button_getSpeciesGroupQualificationsReport = new System.Windows.Forms.Button();
            this.btnEditStaff = new System.Windows.Forms.Button();
            this.txtStaffSearch = new System.Windows.Forms.TextBox();
            this.btnSearchStaff = new System.Windows.Forms.Button();
            this.staffDataGridView = new System.Windows.Forms.DataGridView();
            this.cbStaffRoleFilter = new System.Windows.Forms.ComboBox();
            this.btnRefreshStaff = new System.Windows.Forms.Button();
            this.btnAddStaff = new System.Windows.Forms.Button();
            this.tabEnclosures = new System.Windows.Forms.TabPage();
            this.button_animalInEnclosureReport = new System.Windows.Forms.Button();
            this.cbZoneFilter = new System.Windows.Forms.ComboBox();
            this.txtEnclosureSearch = new System.Windows.Forms.TextBox();
            this.btnSearchEnclosures = new System.Windows.Forms.Button();
            this.btnAddEnclosure_Click = new System.Windows.Forms.Button();
            this.btnEditEnclosure = new System.Windows.Forms.Button();
            this.enclosuresDataGridView = new System.Windows.Forms.DataGridView();
            this.cbBiomeFilter = new System.Windows.Forms.ComboBox();
            this.btnRefreshEnclosures = new System.Windows.Forms.Button();
            this.tabAnimals = new System.Windows.Forms.TabPage();
            this.txtAnimalSearch = new System.Windows.Forms.TextBox();
            this.button_possibleEnclosuresReport = new System.Windows.Forms.Button();
            this.button_ZookeepersQualified = new System.Windows.Forms.Button();
            this.panel_pageControl = new System.Windows.Forms.Panel();
            this.button_goToPage = new System.Windows.Forms.Button();
            this.label_pageInfo = new System.Windows.Forms.Label();
            this.button_prevPage = new System.Windows.Forms.Button();
            this.button_nextPage = new System.Windows.Forms.Button();
            this.textBox_pageNum = new System.Windows.Forms.TextBox();
            this.label_pageNum = new System.Windows.Forms.Label();
            this.btnEditAnimal = new System.Windows.Forms.Button();
            this.btnAddAnimal = new System.Windows.Forms.Button();
            this.btnSearchAnimal = new System.Windows.Forms.Button();
            this.animalsDataGridView = new System.Windows.Forms.DataGridView();
            this.btnRefreshAnimals = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabFeedingCare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feedingDataGridView)).BeginInit();
            this.tabStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffDataGridView)).BeginInit();
            this.tabEnclosures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enclosuresDataGridView)).BeginInit();
            this.tabAnimals.SuspendLayout();
            this.panel_pageControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalsDataGridView)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFeedingCare
            // 
            this.tabFeedingCare.Controls.Add(this.button_filterFeedCare);
            this.tabFeedingCare.Controls.Add(this.label_dateFeedCare);
            this.tabFeedingCare.Controls.Add(this.dateTimePicker_feedCare);
            this.tabFeedingCare.Controls.Add(this.label_staffIdFeedCare);
            this.tabFeedingCare.Controls.Add(this.label_animalIdFeedCare);
            this.tabFeedingCare.Controls.Add(this.textBox_staffIdFeedCare);
            this.tabFeedingCare.Controls.Add(this.textBox_animalIdFeedCare);
            this.tabFeedingCare.Controls.Add(this.checkBox_medicalHistory);
            this.tabFeedingCare.Controls.Add(this.checkBox_feedingHistory);
            this.tabFeedingCare.Controls.Add(this.feedingDataGridView);
            this.tabFeedingCare.Controls.Add(this.btnRecordFeeding);
            this.tabFeedingCare.Controls.Add(this.btnRecordCare);
            this.tabFeedingCare.Location = new System.Drawing.Point(4, 22);
            this.tabFeedingCare.Name = "tabFeedingCare";
            this.tabFeedingCare.Size = new System.Drawing.Size(1177, 767);
            this.tabFeedingCare.TabIndex = 3;
            this.tabFeedingCare.Text = "Feeding / Care";
            // 
            // button_filterFeedCare
            // 
            this.button_filterFeedCare.Location = new System.Drawing.Point(500, 28);
            this.button_filterFeedCare.Name = "button_filterFeedCare";
            this.button_filterFeedCare.Size = new System.Drawing.Size(75, 23);
            this.button_filterFeedCare.TabIndex = 11;
            this.button_filterFeedCare.Text = "Filter";
            this.button_filterFeedCare.UseVisualStyleBackColor = true;
            this.button_filterFeedCare.Click += new System.EventHandler(this.button_filterFeedCare_Click);
            // 
            // label_dateFeedCare
            // 
            this.label_dateFeedCare.AutoSize = true;
            this.label_dateFeedCare.Location = new System.Drawing.Point(295, 9);
            this.label_dateFeedCare.Name = "label_dateFeedCare";
            this.label_dateFeedCare.Size = new System.Drawing.Size(117, 13);
            this.label_dateFeedCare.TabIndex = 10;
            this.label_dateFeedCare.Text = "Get data past this date:";
            // 
            // dateTimePicker_feedCare
            // 
            this.dateTimePicker_feedCare.Location = new System.Drawing.Point(294, 31);
            this.dateTimePicker_feedCare.Name = "dateTimePicker_feedCare";
            this.dateTimePicker_feedCare.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_feedCare.TabIndex = 9;
            // 
            // label_staffIdFeedCare
            // 
            this.label_staffIdFeedCare.AutoSize = true;
            this.label_staffIdFeedCare.Location = new System.Drawing.Point(17, 36);
            this.label_staffIdFeedCare.Name = "label_staffIdFeedCare";
            this.label_staffIdFeedCare.Size = new System.Drawing.Size(46, 13);
            this.label_staffIdFeedCare.TabIndex = 8;
            this.label_staffIdFeedCare.Text = "Staff ID:";
            // 
            // label_animalIdFeedCare
            // 
            this.label_animalIdFeedCare.AutoSize = true;
            this.label_animalIdFeedCare.Location = new System.Drawing.Point(17, 8);
            this.label_animalIdFeedCare.Name = "label_animalIdFeedCare";
            this.label_animalIdFeedCare.Size = new System.Drawing.Size(55, 13);
            this.label_animalIdFeedCare.TabIndex = 7;
            this.label_animalIdFeedCare.Text = "Animal ID:";
            // 
            // textBox_staffIdFeedCare
            // 
            this.textBox_staffIdFeedCare.Location = new System.Drawing.Point(78, 31);
            this.textBox_staffIdFeedCare.Name = "textBox_staffIdFeedCare";
            this.textBox_staffIdFeedCare.Size = new System.Drawing.Size(100, 20);
            this.textBox_staffIdFeedCare.TabIndex = 6;
            // 
            // textBox_animalIdFeedCare
            // 
            this.textBox_animalIdFeedCare.Location = new System.Drawing.Point(78, 7);
            this.textBox_animalIdFeedCare.Name = "textBox_animalIdFeedCare";
            this.textBox_animalIdFeedCare.Size = new System.Drawing.Size(100, 20);
            this.textBox_animalIdFeedCare.TabIndex = 5;
            // 
            // checkBox_medicalHistory
            // 
            this.checkBox_medicalHistory.AutoSize = true;
            this.checkBox_medicalHistory.Checked = true;
            this.checkBox_medicalHistory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_medicalHistory.Location = new System.Drawing.Point(184, 34);
            this.checkBox_medicalHistory.Name = "checkBox_medicalHistory";
            this.checkBox_medicalHistory.Size = new System.Drawing.Size(104, 17);
            this.checkBox_medicalHistory.TabIndex = 4;
            this.checkBox_medicalHistory.Text = "Medical History?";
            this.checkBox_medicalHistory.UseVisualStyleBackColor = true;
            // 
            // checkBox_feedingHistory
            // 
            this.checkBox_feedingHistory.AutoSize = true;
            this.checkBox_feedingHistory.Checked = true;
            this.checkBox_feedingHistory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_feedingHistory.Location = new System.Drawing.Point(184, 8);
            this.checkBox_feedingHistory.Name = "checkBox_feedingHistory";
            this.checkBox_feedingHistory.Size = new System.Drawing.Size(105, 17);
            this.checkBox_feedingHistory.TabIndex = 3;
            this.checkBox_feedingHistory.Text = "Feeding History?";
            this.checkBox_feedingHistory.UseVisualStyleBackColor = true;
            // 
            // feedingDataGridView
            // 
            this.feedingDataGridView.Location = new System.Drawing.Point(20, 60);
            this.feedingDataGridView.Name = "feedingDataGridView";
            this.feedingDataGridView.Size = new System.Drawing.Size(1137, 690);
            this.feedingDataGridView.TabIndex = 0;
            // 
            // btnRecordFeeding
            // 
            this.btnRecordFeeding.Location = new System.Drawing.Point(1037, 31);
            this.btnRecordFeeding.Name = "btnRecordFeeding";
            this.btnRecordFeeding.Size = new System.Drawing.Size(120, 23);
            this.btnRecordFeeding.TabIndex = 1;
            this.btnRecordFeeding.Text = "Record Feeding";
            this.btnRecordFeeding.Click += new System.EventHandler(this.btnRecordFeeding_Click);
            // 
            // btnRecordCare
            // 
            this.btnRecordCare.Location = new System.Drawing.Point(1037, 3);
            this.btnRecordCare.Name = "btnRecordCare";
            this.btnRecordCare.Size = new System.Drawing.Size(120, 23);
            this.btnRecordCare.TabIndex = 2;
            this.btnRecordCare.Text = "Record Vet Care";
            this.btnRecordCare.Click += new System.EventHandler(this.btnRecordCare_Click);
            // 
            // tabStaff
            // 
            this.tabStaff.Controls.Add(this.button_getSpeciesGroupQualificationsReport);
            this.tabStaff.Controls.Add(this.btnEditStaff);
            this.tabStaff.Controls.Add(this.txtStaffSearch);
            this.tabStaff.Controls.Add(this.btnSearchStaff);
            this.tabStaff.Controls.Add(this.staffDataGridView);
            this.tabStaff.Controls.Add(this.cbStaffRoleFilter);
            this.tabStaff.Controls.Add(this.btnRefreshStaff);
            this.tabStaff.Controls.Add(this.btnAddStaff);
            this.tabStaff.Location = new System.Drawing.Point(4, 22);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.Size = new System.Drawing.Size(1177, 767);
            this.tabStaff.TabIndex = 2;
            this.tabStaff.Text = "Staff";
            // 
            // button_getSpeciesGroupQualificationsReport
            // 
            this.button_getSpeciesGroupQualificationsReport.Location = new System.Drawing.Point(492, 23);
            this.button_getSpeciesGroupQualificationsReport.Name = "button_getSpeciesGroupQualificationsReport";
            this.button_getSpeciesGroupQualificationsReport.Size = new System.Drawing.Size(127, 23);
            this.button_getSpeciesGroupQualificationsReport.TabIndex = 8;
            this.button_getSpeciesGroupQualificationsReport.Text = "Show Qualifications";
            this.button_getSpeciesGroupQualificationsReport.UseVisualStyleBackColor = true;
            this.button_getSpeciesGroupQualificationsReport.Click += new System.EventHandler(this.button_getSpeciesGroupQualificationsReport_Click);
            // 
            // btnEditStaff
            // 
            this.btnEditStaff.Location = new System.Drawing.Point(987, 13);
            this.btnEditStaff.Name = "btnEditStaff";
            this.btnEditStaff.Size = new System.Drawing.Size(75, 41);
            this.btnEditStaff.TabIndex = 6;
            this.btnEditStaff.Text = "Edit Staff";
            this.btnEditStaff.UseVisualStyleBackColor = true;
            this.btnEditStaff.Click += new System.EventHandler(this.btnEditStaff_Click);
            // 
            // txtStaffSearch
            // 
            this.txtStaffSearch.Location = new System.Drawing.Point(20, 23);
            this.txtStaffSearch.Name = "txtStaffSearch";
            this.txtStaffSearch.Size = new System.Drawing.Size(178, 20);
            this.txtStaffSearch.TabIndex = 5;
            this.txtStaffSearch.Text = "Search Staff here";
            this.txtStaffSearch.TextChanged += new System.EventHandler(this.txtStaffSearch_TextChanged);
            this.txtStaffSearch.MouseEnter += new System.EventHandler(this.txtStaffSearch_Enter);
            this.txtStaffSearch.MouseLeave += new System.EventHandler(this.txtStaffSearch_Leave);
            // 
            // btnSearchStaff
            // 
            this.btnSearchStaff.Location = new System.Drawing.Point(204, 23);
            this.btnSearchStaff.Name = "btnSearchStaff";
            this.btnSearchStaff.Size = new System.Drawing.Size(75, 23);
            this.btnSearchStaff.TabIndex = 4;
            this.btnSearchStaff.Text = "Search";
            this.btnSearchStaff.UseVisualStyleBackColor = true;
            this.btnSearchStaff.Click += new System.EventHandler(this.btnSearchStaff_Click);
            // 
            // staffDataGridView
            // 
            this.staffDataGridView.Location = new System.Drawing.Point(20, 60);
            this.staffDataGridView.Name = "staffDataGridView";
            this.staffDataGridView.Size = new System.Drawing.Size(1138, 694);
            this.staffDataGridView.TabIndex = 0;
            // 
            // cbStaffRoleFilter
            // 
            this.cbStaffRoleFilter.Location = new System.Drawing.Point(285, 25);
            this.cbStaffRoleFilter.Name = "cbStaffRoleFilter";
            this.cbStaffRoleFilter.Size = new System.Drawing.Size(120, 21);
            this.cbStaffRoleFilter.TabIndex = 1;
            this.cbStaffRoleFilter.Text = "Role Filter";
            this.cbStaffRoleFilter.SelectedIndexChanged += new System.EventHandler(this.cbStaffRoleFilter_SelectedIndexChanged);
            // 
            // btnRefreshStaff
            // 
            this.btnRefreshStaff.Location = new System.Drawing.Point(411, 23);
            this.btnRefreshStaff.Name = "btnRefreshStaff";
            this.btnRefreshStaff.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshStaff.TabIndex = 2;
            this.btnRefreshStaff.Text = "Refresh";
            this.btnRefreshStaff.Click += new System.EventHandler(this.btnRefreshStaff_Click);
            // 
            // btnAddStaff
            // 
            this.btnAddStaff.Location = new System.Drawing.Point(1068, 13);
            this.btnAddStaff.Name = "btnAddStaff";
            this.btnAddStaff.Size = new System.Drawing.Size(90, 41);
            this.btnAddStaff.TabIndex = 3;
            this.btnAddStaff.Text = "Add Staff";
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);
            // 
            // tabEnclosures
            // 
            this.tabEnclosures.Controls.Add(this.button_animalInEnclosureReport);
            this.tabEnclosures.Controls.Add(this.cbZoneFilter);
            this.tabEnclosures.Controls.Add(this.txtEnclosureSearch);
            this.tabEnclosures.Controls.Add(this.btnSearchEnclosures);
            this.tabEnclosures.Controls.Add(this.btnAddEnclosure_Click);
            this.tabEnclosures.Controls.Add(this.btnEditEnclosure);
            this.tabEnclosures.Controls.Add(this.enclosuresDataGridView);
            this.tabEnclosures.Controls.Add(this.cbBiomeFilter);
            this.tabEnclosures.Controls.Add(this.btnRefreshEnclosures);
            this.tabEnclosures.Location = new System.Drawing.Point(4, 22);
            this.tabEnclosures.Name = "tabEnclosures";
            this.tabEnclosures.Size = new System.Drawing.Size(1177, 767);
            this.tabEnclosures.TabIndex = 1;
            this.tabEnclosures.Text = "Enclosures";
            // 
            // button_animalInEnclosureReport
            // 
            this.button_animalInEnclosureReport.Location = new System.Drawing.Point(378, 16);
            this.button_animalInEnclosureReport.Name = "button_animalInEnclosureReport";
            this.button_animalInEnclosureReport.Size = new System.Drawing.Size(117, 23);
            this.button_animalInEnclosureReport.TabIndex = 8;
            this.button_animalInEnclosureReport.Text = "Animals in Enclosure";
            this.button_animalInEnclosureReport.UseVisualStyleBackColor = true;
            this.button_animalInEnclosureReport.Click += new System.EventHandler(this.button_animalInEnclosureReport_Click);
            // 
            // cbZoneFilter
            // 
            this.cbZoneFilter.DisplayMember = "cbBiome Filter";
            this.cbZoneFilter.Location = new System.Drawing.Point(251, 32);
            this.cbZoneFilter.Name = "cbZoneFilter";
            this.cbZoneFilter.Size = new System.Drawing.Size(120, 21);
            this.cbZoneFilter.TabIndex = 7;
            this.cbZoneFilter.Text = " Filter By Zone";
            this.cbZoneFilter.ValueMember = "Biome";
            this.cbZoneFilter.SelectedIndexChanged += new System.EventHandler(this.cbZoneFilter_SelectedIndexChanged);
            // 
            // txtEnclosureSearch
            // 
            this.txtEnclosureSearch.Location = new System.Drawing.Point(16, 20);
            this.txtEnclosureSearch.Name = "txtEnclosureSearch";
            this.txtEnclosureSearch.Size = new System.Drawing.Size(148, 20);
            this.txtEnclosureSearch.TabIndex = 6;
            this.txtEnclosureSearch.Text = "Search Enclosures here ";
            this.txtEnclosureSearch.MouseEnter += new System.EventHandler(this.txtEnclosureSearch_Enter);
            this.txtEnclosureSearch.MouseLeave += new System.EventHandler(this.txtEnclosureSearch_Leave);
            // 
            // btnSearchEnclosures
            // 
            this.btnSearchEnclosures.Location = new System.Drawing.Point(170, 3);
            this.btnSearchEnclosures.Name = "btnSearchEnclosures";
            this.btnSearchEnclosures.Size = new System.Drawing.Size(75, 23);
            this.btnSearchEnclosures.TabIndex = 5;
            this.btnSearchEnclosures.Text = "Search";
            this.btnSearchEnclosures.UseVisualStyleBackColor = true;
            this.btnSearchEnclosures.Click += new System.EventHandler(this.btnSearchEnclosures_Click);
            // 
            // btnAddEnclosure_Click
            // 
            this.btnAddEnclosure_Click.Location = new System.Drawing.Point(1061, 20);
            this.btnAddEnclosure_Click.Name = "btnAddEnclosure_Click";
            this.btnAddEnclosure_Click.Size = new System.Drawing.Size(89, 34);
            this.btnAddEnclosure_Click.TabIndex = 4;
            this.btnAddEnclosure_Click.Text = "Add Enclosure";
            this.btnAddEnclosure_Click.UseVisualStyleBackColor = true;
            // 
            // btnEditEnclosure
            // 
            this.btnEditEnclosure.Location = new System.Drawing.Point(966, 20);
            this.btnEditEnclosure.Name = "btnEditEnclosure";
            this.btnEditEnclosure.Size = new System.Drawing.Size(89, 34);
            this.btnEditEnclosure.TabIndex = 3;
            this.btnEditEnclosure.Text = "Edit Enclosure";
            this.btnEditEnclosure.UseVisualStyleBackColor = true;
            this.btnEditEnclosure.Click += new System.EventHandler(this.btnEditEnclosure_Click);
            // 
            // enclosuresDataGridView
            // 
            this.enclosuresDataGridView.Location = new System.Drawing.Point(-4, 60);
            this.enclosuresDataGridView.Name = "enclosuresDataGridView";
            this.enclosuresDataGridView.Size = new System.Drawing.Size(1154, 688);
            this.enclosuresDataGridView.TabIndex = 0;
            // 
            // cbBiomeFilter
            // 
            this.cbBiomeFilter.DisplayMember = "cbBiome Filter";
            this.cbBiomeFilter.Location = new System.Drawing.Point(251, 5);
            this.cbBiomeFilter.Name = "cbBiomeFilter";
            this.cbBiomeFilter.Size = new System.Drawing.Size(120, 21);
            this.cbBiomeFilter.TabIndex = 1;
            this.cbBiomeFilter.Text = " Filter By Biome";
            this.cbBiomeFilter.ValueMember = "Biome";
            this.cbBiomeFilter.SelectedIndexChanged += new System.EventHandler(this.cbBiomeFilter_SelectedIndexChanged);
            // 
            // btnRefreshEnclosures
            // 
            this.btnRefreshEnclosures.Location = new System.Drawing.Point(170, 31);
            this.btnRefreshEnclosures.Name = "btnRefreshEnclosures";
            this.btnRefreshEnclosures.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshEnclosures.TabIndex = 2;
            this.btnRefreshEnclosures.Text = "Refresh";
            this.btnRefreshEnclosures.Click += new System.EventHandler(this.btnRefreshEnclosures_Click);
            // 
            // tabAnimals
            // 
            this.tabAnimals.Controls.Add(this.txtAnimalSearch);
            this.tabAnimals.Controls.Add(this.button_possibleEnclosuresReport);
            this.tabAnimals.Controls.Add(this.button_ZookeepersQualified);
            this.tabAnimals.Controls.Add(this.panel_pageControl);
            this.tabAnimals.Controls.Add(this.btnEditAnimal);
            this.tabAnimals.Controls.Add(this.btnAddAnimal);
            this.tabAnimals.Controls.Add(this.btnSearchAnimal);
            this.tabAnimals.Controls.Add(this.animalsDataGridView);
            this.tabAnimals.Controls.Add(this.btnRefreshAnimals);
            this.tabAnimals.Location = new System.Drawing.Point(4, 22);
            this.tabAnimals.Name = "tabAnimals";
            this.tabAnimals.Size = new System.Drawing.Size(1177, 767);
            this.tabAnimals.TabIndex = 0;
            this.tabAnimals.Text = "Animals";
            // 
            // txtAnimalSearch
            // 
            this.txtAnimalSearch.Location = new System.Drawing.Point(20, 19);
            this.txtAnimalSearch.Name = "txtAnimalSearch";
            this.txtAnimalSearch.Size = new System.Drawing.Size(160, 20);
            this.txtAnimalSearch.TabIndex = 13;
            this.txtAnimalSearch.Text = "Search Animal here";
            this.txtAnimalSearch.MouseEnter += new System.EventHandler(this.txtAnimalSearch_Enter);
            this.txtAnimalSearch.MouseLeave += new System.EventHandler(this.txtAnimalSearch_Leave);
            // 
            // button_possibleEnclosuresReport
            // 
            this.button_possibleEnclosuresReport.Location = new System.Drawing.Point(478, 16);
            this.button_possibleEnclosuresReport.Name = "button_possibleEnclosuresReport";
            this.button_possibleEnclosuresReport.Size = new System.Drawing.Size(117, 23);
            this.button_possibleEnclosuresReport.TabIndex = 12;
            this.button_possibleEnclosuresReport.Text = "Possible Enclosures";
            this.button_possibleEnclosuresReport.UseVisualStyleBackColor = true;
            this.button_possibleEnclosuresReport.Click += new System.EventHandler(this.button_possibleEnclosuresReport_Click);
            // 
            // button_ZookeepersQualified
            // 
            this.button_ZookeepersQualified.Location = new System.Drawing.Point(348, 16);
            this.button_ZookeepersQualified.Name = "button_ZookeepersQualified";
            this.button_ZookeepersQualified.Size = new System.Drawing.Size(124, 23);
            this.button_ZookeepersQualified.TabIndex = 11;
            this.button_ZookeepersQualified.Text = "Zookeepers Qualified";
            this.button_ZookeepersQualified.UseVisualStyleBackColor = true;
            this.button_ZookeepersQualified.Click += new System.EventHandler(this.button_ZookeepersQualified_Click);
            // 
            // panel_pageControl
            // 
            this.panel_pageControl.Controls.Add(this.button_goToPage);
            this.panel_pageControl.Controls.Add(this.label_pageInfo);
            this.panel_pageControl.Controls.Add(this.button_prevPage);
            this.panel_pageControl.Controls.Add(this.button_nextPage);
            this.panel_pageControl.Controls.Add(this.textBox_pageNum);
            this.panel_pageControl.Controls.Add(this.label_pageNum);
            this.panel_pageControl.Location = new System.Drawing.Point(614, 4);
            this.panel_pageControl.Name = "panel_pageControl";
            this.panel_pageControl.Size = new System.Drawing.Size(346, 50);
            this.panel_pageControl.TabIndex = 10;
            // 
            // button_goToPage
            // 
            this.button_goToPage.Location = new System.Drawing.Point(179, -1);
            this.button_goToPage.Name = "button_goToPage";
            this.button_goToPage.Size = new System.Drawing.Size(75, 23);
            this.button_goToPage.TabIndex = 5;
            this.button_goToPage.Text = "Go To Page";
            this.button_goToPage.UseVisualStyleBackColor = true;
            this.button_goToPage.Click += new System.EventHandler(this.button_goToPage_Click);
            // 
            // label_pageInfo
            // 
            this.label_pageInfo.AutoSize = true;
            this.label_pageInfo.Location = new System.Drawing.Point(4, 31);
            this.label_pageInfo.Name = "label_pageInfo";
            this.label_pageInfo.Size = new System.Drawing.Size(53, 13);
            this.label_pageInfo.TabIndex = 4;
            this.label_pageInfo.Text = "Page Info";
            // 
            // button_prevPage
            // 
            this.button_prevPage.Location = new System.Drawing.Point(179, 24);
            this.button_prevPage.Name = "button_prevPage";
            this.button_prevPage.Size = new System.Drawing.Size(75, 23);
            this.button_prevPage.TabIndex = 3;
            this.button_prevPage.Text = "Prev Page";
            this.button_prevPage.UseVisualStyleBackColor = true;
            this.button_prevPage.Click += new System.EventHandler(this.button_prevPage_Click);
            // 
            // button_nextPage
            // 
            this.button_nextPage.Location = new System.Drawing.Point(260, 24);
            this.button_nextPage.Name = "button_nextPage";
            this.button_nextPage.Size = new System.Drawing.Size(75, 23);
            this.button_nextPage.TabIndex = 2;
            this.button_nextPage.Text = "Next Page";
            this.button_nextPage.UseVisualStyleBackColor = true;
            this.button_nextPage.Click += new System.EventHandler(this.button_nextPage_Click);
            // 
            // textBox_pageNum
            // 
            this.textBox_pageNum.Location = new System.Drawing.Point(73, 1);
            this.textBox_pageNum.Name = "textBox_pageNum";
            this.textBox_pageNum.Size = new System.Drawing.Size(100, 20);
            this.textBox_pageNum.TabIndex = 1;
            // 
            // label_pageNum
            // 
            this.label_pageNum.AutoSize = true;
            this.label_pageNum.Location = new System.Drawing.Point(4, 4);
            this.label_pageNum.Name = "label_pageNum";
            this.label_pageNum.Size = new System.Drawing.Size(63, 13);
            this.label_pageNum.TabIndex = 0;
            this.label_pageNum.Text = "Go to page:";
            // 
            // btnEditAnimal
            // 
            this.btnEditAnimal.Location = new System.Drawing.Point(984, 17);
            this.btnEditAnimal.Name = "btnEditAnimal";
            this.btnEditAnimal.Size = new System.Drawing.Size(75, 37);
            this.btnEditAnimal.TabIndex = 6;
            this.btnEditAnimal.Text = "Edit Animal";
            this.btnEditAnimal.UseVisualStyleBackColor = true;
            this.btnEditAnimal.Click += new System.EventHandler(this.btnEditAnimal_Click);
            // 
            // btnAddAnimal
            // 
            this.btnAddAnimal.Location = new System.Drawing.Point(1065, 17);
            this.btnAddAnimal.Name = "btnAddAnimal";
            this.btnAddAnimal.Size = new System.Drawing.Size(90, 37);
            this.btnAddAnimal.TabIndex = 4;
            this.btnAddAnimal.Text = "Add Animal";
            this.btnAddAnimal.Click += new System.EventHandler(this.btnAddAnimal_Click);
            // 
            // btnSearchAnimal
            // 
            this.btnSearchAnimal.Location = new System.Drawing.Point(186, 17);
            this.btnSearchAnimal.Name = "btnSearchAnimal";
            this.btnSearchAnimal.Size = new System.Drawing.Size(75, 22);
            this.btnSearchAnimal.TabIndex = 5;
            this.btnSearchAnimal.Text = "Search";
            this.btnSearchAnimal.Click += new System.EventHandler(this.btnSearchAnimal_Click);
            // 
            // animalsDataGridView
            // 
            this.animalsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.animalsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.animalsDataGridView.Location = new System.Drawing.Point(20, 60);
            this.animalsDataGridView.Name = "animalsDataGridView";
            this.animalsDataGridView.Size = new System.Drawing.Size(1135, 695);
            this.animalsDataGridView.TabIndex = 0;
            // 
            // btnRefreshAnimals
            // 
            this.btnRefreshAnimals.Location = new System.Drawing.Point(267, 17);
            this.btnRefreshAnimals.Name = "btnRefreshAnimals";
            this.btnRefreshAnimals.Size = new System.Drawing.Size(75, 22);
            this.btnRefreshAnimals.TabIndex = 3;
            this.btnRefreshAnimals.Text = "Refresh";
            this.btnRefreshAnimals.Click += new System.EventHandler(this.btnRefreshAnimals_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabAnimals);
            this.tabMain.Controls.Add(this.tabEnclosures);
            this.tabMain.Controls.Add(this.tabStaff);
            this.tabMain.Controls.Add(this.tabFeedingCare);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1185, 793);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1209, 817);
            this.Controls.Add(this.tabMain);
            this.Name = "MainForm";
            this.Text = "Zoo Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabFeedingCare.ResumeLayout(false);
            this.tabFeedingCare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feedingDataGridView)).EndInit();
            this.tabStaff.ResumeLayout(false);
            this.tabStaff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffDataGridView)).EndInit();
            this.tabEnclosures.ResumeLayout(false);
            this.tabEnclosures.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enclosuresDataGridView)).EndInit();
            this.tabAnimals.ResumeLayout(false);
            this.tabAnimals.PerformLayout();
            this.panel_pageControl.ResumeLayout(false);
            this.panel_pageControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.animalsDataGridView)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddEnclosure;
        private System.Windows.Forms.TabPage tabFeedingCare;
        private System.Windows.Forms.DataGridView feedingDataGridView;
        private System.Windows.Forms.Button btnRecordFeeding;
        private System.Windows.Forms.Button btnRecordCare;
        private System.Windows.Forms.TabPage tabStaff;
        private System.Windows.Forms.Button btnEditStaff;
        private System.Windows.Forms.TextBox txtStaffSearch;
        private System.Windows.Forms.Button btnSearchStaff;
        private System.Windows.Forms.DataGridView staffDataGridView;
        private System.Windows.Forms.ComboBox cbStaffRoleFilter;
        private System.Windows.Forms.Button btnRefreshStaff;
        private System.Windows.Forms.Button btnAddStaff;
        private System.Windows.Forms.TabPage tabEnclosures;
        private System.Windows.Forms.Button btnAddEnclosure_Click;
        private System.Windows.Forms.Button btnEditEnclosure;
        private System.Windows.Forms.DataGridView enclosuresDataGridView;
        private System.Windows.Forms.ComboBox cbBiomeFilter;
        private System.Windows.Forms.Button btnRefreshEnclosures;
        private System.Windows.Forms.TabPage tabAnimals;
        private System.Windows.Forms.Button btnEditAnimal;
        private System.Windows.Forms.Button btnAddAnimal;
        private System.Windows.Forms.Button btnSearchAnimal;
        private System.Windows.Forms.DataGridView animalsDataGridView;
        private System.Windows.Forms.Button btnRefreshAnimals;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.Button btnSearchEnclosures;
        private System.Windows.Forms.TextBox txtEnclosureSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel_pageControl;
        private System.Windows.Forms.Label label_pageInfo;
        private System.Windows.Forms.Button button_prevPage;
        private System.Windows.Forms.Button button_nextPage;
        private System.Windows.Forms.TextBox textBox_pageNum;
        private System.Windows.Forms.Label label_pageNum;
        private System.Windows.Forms.Button button_ZookeepersQualified;
        private System.Windows.Forms.ComboBox cbZoneFilter;
        private System.Windows.Forms.Label label_dateFeedCare;
        private System.Windows.Forms.DateTimePicker dateTimePicker_feedCare;
        private System.Windows.Forms.Label label_staffIdFeedCare;
        private System.Windows.Forms.Label label_animalIdFeedCare;
        private System.Windows.Forms.TextBox textBox_staffIdFeedCare;
        private System.Windows.Forms.TextBox textBox_animalIdFeedCare;
        private System.Windows.Forms.CheckBox checkBox_medicalHistory;
        private System.Windows.Forms.CheckBox checkBox_feedingHistory;
        private System.Windows.Forms.Button button_filterFeedCare;
        private System.Windows.Forms.Button button_goToPage;
        private System.Windows.Forms.Button button_animalInEnclosureReport;
        private System.Windows.Forms.Button button_possibleEnclosuresReport;
        private System.Windows.Forms.Button button_getSpeciesGroupQualificationsReport;
        private System.Windows.Forms.TextBox txtAnimalSearch;
    }
}
