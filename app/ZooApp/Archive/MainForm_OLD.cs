using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ZooApp
{
    public partial class MainForm_OLD : Form
    {
        // Variables to allow paging through large datasets.
        // Could potentially be moved to another class that manages state.
        private const int PAGE_SIZE = 50;
        // The page number, starting from 0
        private int[] dataTablePos = new int[4];
        private DataTable
            animalsDt,
            enclosureDt,
            staffDt,
            feedingCareDt,
            rolesDt;

        private DataTable TabIndexToDt(int a)
        {
            switch (a)
            {
                case 0:
                    return animalsDt;
                case 1:
                    return enclosureDt;
                case 2:
                    return staffDt;
                case 3:
                    return feedingCareDt;
                default:
                    return null;
            }
        }
        private DataGridView currentDGV;

        public MainForm_OLD()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Set initial filter date to a month ago
                dateTimePicker_feedCare.Value = DateTime.Now.AddDays(-30);

                LoadAnimals();
                LoadEnclosures();
                LoadStaff();
                LoadFeedingAndCare();
                LoadRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load data: {ex.Message}", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Display info about the page
        private void LoadPageInfo()
        {
            // 0 = Animal
            // 1 = Enclosures
            // 2 = Staff
            // 3 = Feeding/Care
            int index = tabMain.SelectedIndex;
            int currPage = dataTablePos[index];
            
            // Make sure that the panel containing the page info is always available!
            panel_pageControl.Parent = tabMain.TabPages[index];
            // CurrentDGV Rows -1 because there is an extra empty row that is returned from these queries
            label_pageInfo.Text = String.Format("Displaying page {0}, with {1} items.", (currPage + 1), currentDGV.Rows.Count - 1);
            textBox_pageNum.Text = (currPage + 1).ToString();
        }

        private void LoadAnimals(string nameFilter = "")
        {
            try
            {
                string query = $@"
                    SELECT 
                        a.aid,
                        a.name,
                        a.sex,
                        a.dob,
                        a.weight,
                        a.feedingInterval,
                        a.originCountry,
                        a.enclosureID,
                        e.biome,
                        e.zoneName,
                        a.speciesName,
                        sg.commonName AS speciesGroup
                    FROM {DatabaseHelper.Table("ANIMAL")} a
                    LEFT JOIN {DatabaseHelper.Table("ENCLOSURE")} e ON a.enclosureID = e.eid
                    LEFT JOIN {DatabaseHelper.Table("SPECIES")} s ON a.speciesName = s.latinName
                    LEFT JOIN {DatabaseHelper.Table("SPECIESGROUP")} sg ON s.speciesGroup = sg.latinName
                    WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(nameFilter))
                {
                    query += $" AND LOWER(a.name) LIKE '%{nameFilter.ToLower()}%'";
                }
                query += " ORDER BY a.aid ASC";

                // Workaround for currentDGV
                currentDGV = animalsDataGridView;
                animalsDt = DatabaseHelper.ExecuteQuery(query);
                animalsDataGridView.AutoGenerateColumns = true;
                animalsDataGridView.DataSource = GetDataTablePage(animalsDt, dataTablePos[tabMain.SelectedIndex]);
                LoadPageInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading animals: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Refresh the data using the already obtained data from the query.
        /// </summary>
        private void RefreshAnimals()
        {
            animalsDataGridView.DataSource = GetDataTablePage(animalsDt, dataTablePos[tabMain.SelectedIndex]);
            currentDGV = animalsDataGridView;
            LoadPageInfo();
        }

        /// <summary>
        /// Method to get a subset of a DataTable, e.g. Rows 50-100, returned as a new DataTable.
        /// </summary>
        /// <param name="dt">The DataTable to take the subset from.</param>
        /// <param name="start">The starting index, inclusive</param>
        /// <param name="end">The ending index, exclusive</param>
        /// <returns></returns>
        private DataTable GetDataTablePage(DataTable dt, int pageNum)
        {
            DataTable returnDt = dt.Clone();
            int start = pageNum * PAGE_SIZE;
            int numRows = dt.Rows.Count;
            int end = start + PAGE_SIZE;
            // Make sure in bounds
            if (!(end < numRows)) end = numRows - 1;
            
            for (int i = start; i < end; i++)
            {
                DataRow row = dt.Rows[i];
                returnDt.Rows.Add(row.ItemArray);
            }
            return returnDt;
        }

        private void LoadEnclosures()
        {
            string query = $"SELECT e.eid, e.biome, e.esize, z.name AS zoneName " +
                           $"FROM {DatabaseHelper.Table("ENCLOSURE")} e " +
                           $"JOIN {DatabaseHelper.Table("ZONE")} z ON e.zoneName = z.name";

            enclosureDt = DatabaseHelper.ExecuteQuery(query);
            enclosuresDataGridView.DataSource = GetDataTablePage(enclosureDt, dataTablePos[tabMain.SelectedIndex]);

            PopulateBiomeFilter();
            PopulateZoneFilter();
        }


        private void RefreshEnclosures()
        {
            enclosuresDataGridView.DataSource = GetDataTablePage(enclosureDt, dataTablePos[tabMain.SelectedIndex]);
            currentDGV = enclosuresDataGridView;
            LoadPageInfo();
        }

        private void LoadStaff(string nameFilter = "", string roleFilter = "")
        {
            string table = DatabaseHelper.Table("STAFF");
            string feedTable = DatabaseHelper.Table("FEED");
            string careTable = DatabaseHelper.Table("CARE");

            string query = $@"
        SELECT
            s.sid,
            s.fName,
            s.lName,
            s.streetNumber,
            s.streetName,
            s.suburb,
            s.city,
            s.postCode,
            s.fName || ' ' || s.lName AS fullName,
            s.dob,
            s.sex,
            s.phNumber,
            s.email,
            s.clinic,
            s.streetNumber || ' ' || s.streetName || ', ' || s.suburb || ', ' || s.city || ' ' || s.postCode AS address,
            CASE
                WHEN EXISTS (SELECT 1 FROM {feedTable} f WHERE f.staffID = s.sid) THEN 'Zookeeper'
                WHEN EXISTS (SELECT 1 FROM {careTable} c WHERE c.staffID = s.sid) THEN 'Vet'
                ELSE 'Unknown'
            END AS role
        FROM {table} s
        WHERE 1 = 1
    ";

            // Filter by name
            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                query += $@" AND (
            LOWER(s.fName) LIKE '%{nameFilter.ToLower()}%' OR 
            LOWER(s.lName) LIKE '%{nameFilter.ToLower()}%' OR 
            LOWER(s.fName || ' ' || s.lName) LIKE '%{nameFilter.ToLower()}%')";
            }

            // Filter by role
            if (!string.IsNullOrWhiteSpace(roleFilter) && roleFilter != "All")
            {
                if (roleFilter == "Zookeeper")
                {
                    query += $" AND EXISTS (SELECT 1 FROM {feedTable} f WHERE f.staffID = s.sid)";
                }
                else if (roleFilter == "Vet")
                {
                    query += $" AND EXISTS (SELECT 1 FROM {careTable} c WHERE c.staffID = s.sid)";
                }
                else if (roleFilter == "Unknown")
                {
                    query += $@"
                AND NOT EXISTS (SELECT 1 FROM {feedTable} f WHERE f.staffID = s.sid)
                AND NOT EXISTS (SELECT 1 FROM {careTable} c WHERE c.staffID = s.sid)";
                }
            }

            // Execute and load results
            staffDt = DatabaseHelper.ExecuteQuery(query);
            staffDataGridView.AutoGenerateColumns = true;
            staffDataGridView.DataSource = GetDataTablePage(staffDt, dataTablePos[tabMain.SelectedIndex]);
            LoadPageInfo();
        }


        private void RefreshStaff()
        {
            staffDataGridView.DataSource = GetDataTablePage(staffDt, dataTablePos[tabMain.SelectedIndex]);
            currentDGV = staffDataGridView;
            LoadPageInfo();
        }

        private void LoadFeedingAndCare()
        {
            // Prepare variables for insertion into the query
            string date = DatabaseHelper.ConvertDateTimeToSQLString(dateTimePicker_feedCare.Value);
            string staffID = "S.sid";
            string animalID = "A.aid";
            if (textBox_staffIdFeedCare.Text != "")
            {
                try
                {
                    // Attempt to parse the text as int, if not parsable then will be caught
                    staffID = int.Parse(textBox_staffIdFeedCare.Text).ToString();
                }
                catch {
                    MessageBox.Show("Staff ID was not a valid number!");
                    staffID = "S.sid";
                }
            }
            if (textBox_animalIdFeedCare.Text != "")
            {
                try
                {
                    // Attempt to parse the text as int, if not parsable then will be caught
                    animalID = int.Parse(textBox_animalIdFeedCare.Text).ToString();
                }
                catch
                {
                    MessageBox.Show("Animal ID was not a valid number!");
                    animalID = "A.aid";
                }
            }

            string feedingQuery = $@"
                 SELECT 
            F.staffID,
            S.fName || ' ' || S.lName AS StaffName,
            F.animalID,
            A.name AS AnimalName,
            F.dateTime,
            'Feeding' AS Type,
            F.foodType AS FoodType,
            TO_CHAR(F.amount) AS FoodAmount,
            NULL AS CareType,
            NULL AS VetNotes
             FROM {DatabaseHelper.Table("FEED")} F
             JOIN {DatabaseHelper.Table("STAFF")} S ON F.staffID = S.sid
             JOIN {DatabaseHelper.Table("ANIMAL")} A ON F.animalID = A.aid
             WHERE F.dateTime > to_timestamp('{date}', 'YYYY-MM-DD')
            AND F.staffID = {staffID}
            AND F.animalID = {animalID}
            ";

            string medicalQuery = $@"
                SELECT 
            C.staffID,
            S.fName || ' ' || S.lName AS StaffName,
            C.animalID,
            A.name AS AnimalName,
            C.dateTime,
            'Care' AS Type,
            NULL AS FoodType,
            NULL AS FoodAmount,
            C.care AS CareType,
            C.notes AS VetNotes
            FROM {DatabaseHelper.Table("CARE")} C
            JOIN {DatabaseHelper.Table("STAFF")} S ON C.staffID = S.sid
            JOIN {DatabaseHelper.Table("ANIMAL")} A ON C.animalID = A.aid
            WHERE C.dateTime > to_timestamp('{date}', 'YYYY-MM-DD')
            AND C.staffID = {staffID}
            AND C.animalID = {animalID}
            ";

            // Create the query based on inputs
            int numChecked = 0;
            string query = "";
            if (checkBox_feedingHistory.Checked)
            {
                numChecked++;
                query += feedingQuery;
            }

            if (checkBox_medicalHistory.Checked)
            {
                if (numChecked != 0)
                {
                    query += " UNION ALL ";
                }
                numChecked++;
                query += medicalQuery;
            }

            if (numChecked != 0)
            {
                query += " ORDER BY dateTime DESC";
                feedingCareDt = DatabaseHelper.ExecuteQuery(query);
            }
            else
            {
                feedingCareDt = new DataTable();
            }

            //feedingCareDt = DatabaseHelper.ExecuteQuery(query);
            feedingDataGridView.AutoGenerateColumns = true;
            feedingDataGridView.DataSource = GetDataTablePage(feedingCareDt, dataTablePos[tabMain.SelectedIndex]);
            LoadPageInfo();
        }

        private void LoadRoles()
        {
            string query = $"SELECT DISTINCT clinic FROM {DatabaseHelper.Table("STAFF")}";
            rolesDt = DatabaseHelper.ExecuteQuery(query);

            cbStaffRoleFilter.Items.Clear();
            cbStaffRoleFilter.Items.Add("All");

            foreach (DataRow row in rolesDt.Rows)
            {
                cbStaffRoleFilter.Items.Add(row["clinic"].ToString());
            }

            cbStaffRoleFilter.SelectedIndex = 0;
        }

        private void RefreshFeedingAndCare()
        {
            feedingDataGridView.DataSource = GetDataTablePage(feedingCareDt, dataTablePos[tabMain.SelectedIndex]);
            currentDGV = feedingDataGridView;
            LoadPageInfo();
        }



        // --------- Button Clicks ---------
        private void btnRefreshAnimals_Click(object sender, EventArgs e) => LoadAnimals();
        private void btnRefreshEnclosures_Click(object sender, EventArgs e) => LoadEnclosures();
        private void btnRefreshStaff_Click(object sender, EventArgs e) => LoadStaff();
        private void btnRecordFeeding_Click(object sender, EventArgs e) => new FeedingForm().ShowDialog();
        private void btnRecordCare_Click(object sender, EventArgs e) => new VetForm().ShowDialog();



        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            //using (AddStaffForm form = new AddStaffForm())
            //{
            //    form.ShowDialog();
            //    LoadStaff();
            //}
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            //if (staffDataGridView.SelectedRows.Count > 0)
            //{
            //    DataRowView row = staffDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
            //    if (row != null)
            //    {
            //        using (AddStaffForm form = new AddStaffForm(row.Row))
            //        {
            //            form.ShowDialog();
            //            LoadStaff();
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select a staff member to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            using (var form = new AddAnimalForm())
            {
                form.ShowDialog();
                LoadAnimals();
            }
        }

        private void btnEditAnimal_Click(object sender, EventArgs e)
        {
            if (animalsDataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = animalsDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
                if (row != null)
                {
                    //Removed the constructor input to fox the error
                    //old line using (AddAnimalForm form = new AddAnimalForm(row.Row))
                    using (AddAnimalForm form = new AddAnimalForm())
                    {
                        form.ShowDialog();
                        LoadAnimals();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an animal to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnEditEnclosure_Click(object sender, EventArgs e)
        {
            if (enclosuresDataGridView.SelectedRows.Count > 0)
            {
                DataRowView rowView = enclosuresDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    using (var form = new AddEnclosureForm(rowView.Row))
                    {
                        form.ShowDialog();
                        LoadEnclosures(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an enclosure to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            IntToLoadData(tabMain.SelectedIndex);
            LoadPageInfo();
        }

        private void button_prevPage_Click(object sender, EventArgs e)
        {
            int pageNum = dataTablePos[tabMain.SelectedIndex];
            if (pageNum > 0)
            {
                dataTablePos[tabMain.SelectedIndex] -= 1;
                IntToLoadData(tabMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Already at first page!");
            }
        }

        private void button_nextPage_Click(object sender, EventArgs e)
        {
            int pageNum = dataTablePos[tabMain.SelectedIndex];
            if (pageNum < TabIndexToDt(tabMain.SelectedIndex).Rows.Count / PAGE_SIZE)
            {
                dataTablePos[tabMain.SelectedIndex] += 1;
                IntToLoadData(tabMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No more pages!");
            }
        }

        private void IntToLoadData(int a)
        {
            switch (a)
            {
                case 0:
                    RefreshAnimals();
                    break;
                case 1:
                    RefreshEnclosures();
                    break;
                case 2:
                    RefreshStaff();
                    break;
                case 3:
                    RefreshFeedingAndCare();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Get the Zookeepers that are qualified for this animal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ZookeepersQualified_Click(object sender, EventArgs e)
        {
            if (animalsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an animal first.", "No Animal Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drv = animalsDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null) return;

            int aid = Convert.ToInt32(drv["aid"]);
            String query = Queries.ZookeepersQualifiedForAnimal + $" AND a.aid = '{aid}'";
            new Report(DatabaseHelper.ExecuteQuery(query), $"Zookeepers Qualified for Animal ID: {aid}").Show();
        }



        private void button_filterFeedCare_Click(object sender, EventArgs e)
        {
            dataTablePos[3] = 0;
            LoadFeedingAndCare();
            RefreshFeedingAndCare();
        }

        private void button_goToPage_Click(object sender, EventArgs e)
        {
            try
            {
                    int givenPage = int.Parse(textBox_pageNum.Text) - 1;
                    int maxPage = TabIndexToDt(tabMain.SelectedIndex).Rows.Count / PAGE_SIZE;

                    // Clamp the value to being between 0 and max page
                    if (givenPage <= maxPage && givenPage >= 0) dataTablePos[tabMain.SelectedIndex] = givenPage;
                    else if (givenPage > maxPage) dataTablePos[tabMain.SelectedIndex] = maxPage;
                    else dataTablePos[tabMain.SelectedIndex] = 0;

                    // And load the given index
                    IntToLoadData(tabMain.SelectedIndex);
            }
            catch
            {
                textBox_pageNum.Text = "0";
                dataTablePos[tabMain.SelectedIndex] = 0;
                IntToLoadData(tabMain.SelectedIndex);
                MessageBox.Show("Please input a valid page number!");
            }
        }

        private void button_animalInEnclosureReport_Click(object sender, EventArgs e)
        {
            if (enclosuresDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an Enclosure first.", "No Enclosure Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drv = enclosuresDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null) return;

            int eid = Convert.ToInt32(drv["eid"]);
            String query = Queries.AnimalsInEnclosure + $" AND e.eid = '{eid}'";
            new Report(DatabaseHelper.ExecuteQuery(query), $"Animals in Enclosure ID: {eid}").Show();
        }

        private void button_possibleEnclosuresReport_Click(object sender, EventArgs e)
        {
            if (animalsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an animal first.", "No Animal Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drv = animalsDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null) return;

            int aid = Convert.ToInt32(drv["aid"]);
            String query = Queries.PossibleEnclosuresForAnimal + $" AND a.aid = '{aid}'";
            new Report(DatabaseHelper.ExecuteQuery(query), $"Possible Enclosures for Animal ID: {aid}").Show();
        }

        private void button_getSpeciesGroupQualificationsReport_Click(object sender, EventArgs e)
        {
            if (staffDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a staff member first.", "No Staff Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drv = staffDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
            if (drv == null) return;

            int sid = Convert.ToInt32(drv["sid"]);
            String query = Queries.ZookeeperQualifications + $" AND o.staffID = '{sid}'";
            new Report(DatabaseHelper.ExecuteQuery(query), $"Qualifications for Staff ID: {sid}").Show();
        }

        private void PopulateBiomeFilter()
        {
            string query = $"SELECT DISTINCT biome FROM {DatabaseHelper.Table("ENCLOSURE")}";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            cbBiomeFilter.Items.Clear();
            cbBiomeFilter.Items.Add("All");

            foreach (DataRow row in dt.Rows)
                cbBiomeFilter.Items.Add(row["biome"].ToString());

            cbBiomeFilter.SelectedIndex = 0;
        }

        private void PopulateZoneFilter()
        {
            string query = $"SELECT DISTINCT zoneName FROM {DatabaseHelper.Table("ENCLOSURE")}";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            cbZoneFilter.Items.Clear();
            cbZoneFilter.Items.Add("All");

            foreach (DataRow row in dt.Rows)
                cbZoneFilter.Items.Add(row["zoneName"].ToString());

            cbZoneFilter.SelectedIndex = 0;
        }
        private void txtAnimalSearch_Enter(object sender, EventArgs e)
        {
            txtAnimalSearch.Clear();

        }

        private void txtAnimalSearch_Leave(object sender, EventArgs e)
        {
            txtAnimalSearch.Text = "Search Animal here";

        }

        private void txtEnclosureSearch_Enter(object sender, EventArgs e)
        {
            txtEnclosureSearch.Clear();
        }

        private void txtEnclosureSearch_Leave(object sender, EventArgs e)
        {
            txtEnclosureSearch.Text = "Search Enclosure here";
        }
        private void txtStaffSearch_Enter(object sender, EventArgs e)
        {
            txtStaffSearch.Clear();
        }

        private void txtStaffSearch_Leave(object sender, EventArgs e)
        {
            txtStaffSearch.Text = "Search Staff here";
        }

        private void cbBiomeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbZoneFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cbStaffRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchAnimal_Click(object sender, EventArgs e)
        {
            string searchName = txtAnimalSearch.Text.Trim();
            LoadAnimals(searchName);

        }
        private void btnSearchEnclosures_Click(object sender, EventArgs e)
        {

        }
        private void btnSearchStaff_Click(object sender, EventArgs e)
        {

        }


        private void txtStaffSearch_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
