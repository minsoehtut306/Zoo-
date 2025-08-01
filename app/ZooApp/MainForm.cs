using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;
using System.Drawing;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using MongoDB.Bson;

/**<summary>
 * This is the main page of the application. Giving staff members access to everything they may need to do in the zoo
 * </summary>
 */
namespace ZooApp
{
    public partial class MainForm : Form
    {
        // The ID of the staff member currently looking at this page. All info will be relevent to them
        private int staffMemberId;
        private int staffRole; //0 for ZooKeeper and 1 for Vet
        private int currentEnclosure; // -1 if no enclosure is selected
        private bool needToUpdate;
        private List<int> selectedAnimals; //A list of animals currently selected
        private List<CheckBox> selectedAnimalsCheckboxList; //contains a list of all checkboxes in the list so that it is easier to select and deselect all of them
        private List<int> EnclosureIdList; //Contains a list of id's of all the enclosures that have currently been searched for.
        private List<String> ZoneNameList; //A list of the zones that are currently selected 
        
        // For Mongo
        private readonly bool usingMongo;

        public MainForm(int staffMemberId)
        {
            currentEnclosure = -1;
            needToUpdate = true;
            this.staffMemberId = staffMemberId;
            selectedAnimals= new List<int>();
            selectedAnimalsCheckboxList= new List<CheckBox>();
            EnclosureIdList= new List<int>();
            ZoneNameList = new List<String>();
            InitializeComponent();

            // For Mongo
            usingMongo = LoginForm.SelectedDataset.Contains("MongoDB");
        }

        /**<summary>
         * Loads staff and a list of animals needed to start the main form.
         * </summary>
         */
        private void MainForm_Load(object sender, EventArgs e) {
            
            lblStaffName.Text = $"Welcome, {getStaffDetails()}";
            if(staffRole == 0)
                displayFeedingList();
            else
                groupBoxTODO.Text = "Checkup List:";
            //Load all the caring information
            // move the groupbox to the load method

            // for now, loading the animals at the same time. Will change this in future!
            populateAnimalComboBox();
        }

        /**<summary>
         * Gets the first name of the staff member that is displayed in the welcome text at the top of the screen
         * @author Dolf ten Have
         * </summary>
         */
        private String getStaffDetails()
        {
            String Query = $"SELECT fname, clinic FROM {DatabaseHelper.Table("STAFF")} WHERE sid = {staffMemberId}";
            DataTable dt = DatabaseHelper.ExecuteQuery(Query);

            if (dt.Rows[0][1].ToString() == "")
                staffRole = 0;
            else
                staffRole= 1;

            return dt.Rows[0][0].ToString();
        }

        /**<summary>
         * Displays the list of animals that need feeding on the home page
         * 
         * @author Dolf ten Have
         * </summary>
         */
        private void displayFeedingList()
        {
            if (!needToUpdate) return;

            int remainingRows = 6;

            DataTable animals_notFed = Queries.getFeedingListForStaff_AnimalsNeverFed(remainingRows, staffMemberId);
            DataTable animals_fed = null;

            remainingRows -= animals_notFed.Rows.Count;
            groupBoxTODO.Text = "Feeding List:";
            
            if(remainingRows > 0) {
                animals_fed = Queries.getFeedingListForStaff(remainingRows, staffMemberId);
            }

            //MessageBox.Show("fed: " + animals_fed.Rows.Count.ToString());

            //If there are no animals that this person has/can feed then a message is displayed to the user.
            if(remainingRows < 1) { 
                Label lbl = new Label();
                lbl.Text = "There are no Animals that you need to feed.";
                lbl.AutoSize= true;
                lbl.Location = new System.Drawing.Point(groupBoxTODO.Location.X + 10, groupBoxTODO.Location.Y + 10 + lbl.Height);
                groupBoxTODO.Controls.Add(lbl);
                return;
            }

            DateTime currentTime = DateTime.Now;
            remainingRows = animals_notFed.Rows.Count;

            //Displays all the UI components
            for (int i = 0; i < animals_notFed.Rows.Count; i++)
            {
                makeTodoUiComponent_Feed(int.Parse(animals_fed.Rows[i][0].ToString()),animals_notFed.Rows[i][1].ToString(), animals_notFed.Rows[i][2].ToString(), -1, int.Parse(animals_notFed.Rows[i][3].ToString()), i);
            }

            if (animals_fed != null)
            {
                for (int i = 0; i < animals_fed.Rows.Count; i++)
                {
                    DateTime lastFed = (DateTime)animals_fed.Rows[i][3];
                    TimeSpan hours = currentTime - lastFed;

                    int totalTime = (int)hours.TotalHours;

                    makeTodoUiComponent_Feed(int.Parse(animals_fed.Rows[i][0].ToString()),animals_fed.Rows[i][1].ToString(), animals_fed.Rows[i][2].ToString(), totalTime, int.Parse(animals_fed.Rows[i][4].ToString()), remainingRows + i);
                }
            }
        }

        /**<summary>
         * Creates a UI component for each entry that is returned to the page
         * 
         * @author Dolf ten Have
         * </summary>
         * <param name="name">The name of the Animal</param>
         * <param name="speciesName">The species Name of the Animal</param>
         * <param name="lastFed">A timestamp of when the animal was last fed</param>
         * <param name="FeedingInterval">The feeding interval of the animal</param>
         * <param name="n">The row number that this control was generated from</param>
         */
        private void makeTodoUiComponent_Feed(int aid, String name, String speciesName, int totalTime, int FeedingInterval, int n)
        {
            String timeSuffix = " hours";
            String overDue = "";


            tabHome.Controls.IndexOfKey("lbl_home_animalName0");

            Label lblName = (Label)this.Controls.Find($"lbl_home_animalName{n}", true)[0];
            Label lblSpecies = (Label)this.Controls.Find($"lbl_home_animalSpecies{n}", true)[0];
            Label lblSinceFeed = (Label)this.Controls.Find($"lbl_home_timeSinceFeed{n}", true)[0];
            Label lblF = (Label)this.Controls.Find($"lbl_home_f{n}", true)[0];
            Button btnFeed = (Button)this.Controls.Find($"btn_home_feed{n}", true)[0];
            Panel panel = (Panel)this.Controls.Find($"panel_home_feeding{n}", true)[0];

            if (totalTime != -1)
            {
                if (totalTime > FeedingInterval)
                {
                    panel.BackColor = Color.Pink;
                    totalTime -= FeedingInterval;
                    lblF.Text += "\nOverdue by:";
                    overDue = "!";
                }
                else
                {
                    panel.BackColor = Color.LightGreen;
                }


                //Yes this is terribly ugly
                if (totalTime > 24)
                {
                    totalTime = (int)totalTime / 24;
                    timeSuffix = " days";
                    if (totalTime > 365)
                    {
                        totalTime = totalTime / 365;
                        timeSuffix = "y";
                    }
                }

                lblSinceFeed.Text = totalTime.ToString() + timeSuffix + overDue;
            }
            else
            {
                lblSinceFeed.Text = "Never!";
                panel.BackColor = Color.Pink;
            }


            lblF.Visible = true;

            lblName.Visible = true;
            lblName.Text = name;

            lblSpecies.Visible = true;
            lblSpecies.Text = speciesName;

            lblSinceFeed.Visible = true;
            

            btnFeed.Visible = true;
            btnFeed.Tag = aid;
            btnFeed.Click += btnFeedClicked;
        }

        /**<summary>
         * An event handler that sends the user to the Enclosure tab.
         * It sets the current Enclosure to this tab and moved the user over to the enclosure tab
         * </summary>
         */
        private void btnFeedClicked(object sender, EventArgs e)
        {
            currentEnclosure = getAnimalEnclosure(int.Parse(((Button)sender).Tag.ToString()));
            tabControlMain.SelectTab(2);
        }

        /**<summary>Gets the enclosure id of an animal.</summary>
         *<returns>An integer with the id of the enclosure that the animal is in.</returns>
         */
        private int getAnimalEnclosure(int aid)
        {
            String query = $"SELECT enclosureid FROM {DatabaseHelper.Table("ANIMAL")} WHERE aid = {aid}";
            DataTable eid = DatabaseHelper.ExecuteQuery(query);
            return int.Parse(eid.Rows[0][0].ToString());
        }


        /**<summary>
         * Returns a string vaersion of how long ago the animal was last fed
         * </summary>
         */
        private String calculateLastFedTime(int lastFed)
        {
            String suffix = "h";

            if (lastFed == -1)
                return "Never!";

            if(lastFed > 24)
            { 
                lastFed = lastFed / 24;
                suffix = "d";
                if (lastFed > 365)
                {
                    lastFed = lastFed / 365;
                    suffix = "y";
                }
            }
            
            return lastFed.ToString()+suffix;
        }

        /**<summary>
         * Initialises the Enclosure page
         * </summary>
         */
        private void initialiseEnclosure()
        {
            vScrollBar_Enclosure.Value = panel_Enclosure_Animals.VerticalScroll.Value;
            vScrollBar_Enclosure.Minimum = panel_Enclosure_Animals.VerticalScroll.Minimum;
            vScrollBar_Enclosure.Minimum = panel_Enclosure_Animals.VerticalScroll.Minimum;
            vScrollBar_Enclosure.Scroll += vScrollBar_Enclosure_Scroll;
            vScrollBar_Enclosure.Enabled = false;

            loadEnclosureAnimals();

            vScrollBar_Enclosure.Enabled = true;
        }

        /**<summary>
         * Updates the the position of the panel to match the vertical scroll bar
         * </summary>
         */
        private void vScrollBar_Enclosure_Scroll(object sender, ScrollEventArgs e)
        {
            panel_Enclosure_Animals.VerticalScroll.Value = vScrollBar_Enclosure.Value;
        }

        /**<summary>
         * Updated the maximum vertical scroll value when a control is added.
         * </summary>
         */
        private void panel_Enclosure_Animals_ControlAdded(object sender, ControlEventArgs e)
        {
            vScrollBar_Enclosure.Maximum = panel_Enclosure_Animals.VerticalScroll.Maximum;
        }

        /**<summary>
         * Updated the minimum scroll value when a control is removed
         * </summary>
         */
        private void panel_Enclosure_Animals_ControlRemoved(object sender, ControlEventArgs e)
        {
            vScrollBar_Enclosure.Minimum = panel_Enclosure_Animals.VerticalScroll.Minimum;
        }

        /**<summary>
         * Gets the enclosure name based on the ID of the enclosure.
         * If the search texbox is empty, then nothing is searched.
         * </summary>
         */
        private void button_Enclosure_Search_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_Enclosure_Search.Text))
            {
                MessageBox.Show("Please enter something into the search bar before searching.");
                return;
            }

             populateEnclosureList_ComboBox_Enclosure_Search(Queries.getEnclosuresByName(textBox_Enclosure_Search.Text));          
        }

        /**<summary>
         * Adds all the enclosures in the DataTable to the ComboBox.
         * 
         * !! IMPORTANT !!
         * 
         * The list MUST be in the format [0]eid,[1]enclosure name.
         * 
         * If you are passing this in from another tab then you may want to set currentEnclosure to -1.
         * </summary>
         * <param name="enclosureList">A DataTable of enclosures.</param>
         */
        private void populateEnclosureList_ComboBox_Enclosure_Search(DataTable enclosureList)
        {
            EnclosureIdList.Clear();
            comboBox_Enclosure_Search.Items.Clear();

            comboBox_Enclosure_Search.Items.Add(enclosureList.Rows.Count.ToString() + " Enclosures Found");

            //Adds a spoof id so that when a real enclosure is selected, it matches it list position
            EnclosureIdList.Add(-1);
            comboBox_Enclosure_Search.SelectedIndex = 0;

            for (int i = 0; i < enclosureList.Rows.Count; i++)
            {
                comboBox_Enclosure_Search.Items.Add(enclosureList.Rows[i][1].ToString() + " Enclosure");
                EnclosureIdList.Add(int.Parse(enclosureList.Rows[i][0].ToString()));
            }
        }

        /**<summary>
         * Sets the current Enclosure to the enclosure that is selected from the list of enclosures.
         * Then calls loadEnclosureAnimals().
         * </summary>
         */
        private void comboBox_Enclosure_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If the selected index is 0 then nothing new is loaded. This is the case if the header is selected or if there is already an enclosure loaded.
            if(comboBox_Enclosure_Search.SelectedIndex == 0)
            {
                return;
            }

            //If this is already the currentEnclosure, then the list is not reloaded
            if(comboBox_Enclosure_Search.SelectedIndex == currentEnclosure)
            {
                return;
            }
            
            currentEnclosure = EnclosureIdList[comboBox_Enclosure_Search.SelectedIndex];
            loadEnclosureAnimals();
        }

        /**<summary>
         * This loads all the animals that the zookeper is allowed to care for for a given enclosure int o the enxlosure tab.
         * </summary>
         */
        private void loadEnclosureAnimals()
        {
            //Doesnt load any animal data if no enclosure is currently selected
            if(currentEnclosure == -1)
            {
                return;
            }

            DataTable animals = Queries.getEnclosureAnimals(staffMemberId, currentEnclosure);
            comboBox_Enclosure_Search.Items.Clear();
            comboBox_Enclosure_Search.Items.Add(Queries.getEnclosureNameById(currentEnclosure).Rows[0][0].ToString() + " Enclosure");
            comboBox_Enclosure_Search.SelectedIndex = 0;
            panel_Enclosure_Animals.Controls.Clear();
            selectedAnimalsCheckboxList.Clear();
            selectedAnimals.Clear();
            button_feedGroup.Enabled = false;
            textBox_Enclosure_Search.Text = string.Empty;

            DateTime currentTime = DateTime.Now;

            for (int i = 0; i < animals.Rows.Count; i++)
            {
                Panel p;
                if (animals.Rows[i][3] == null)
                {
                    p = makeFeedAnimalUiComponent_Enclosure(int.Parse(animals.Rows[i][0].ToString()), animals.Rows[i][1].ToString(), animals.Rows[i][2].ToString(), -1);
                }
                else
                {
                    DateTime lastFed = (DateTime)animals.Rows[i][3];
                    TimeSpan hours = currentTime - lastFed;

                    p = makeFeedAnimalUiComponent_Enclosure(int.Parse(animals.Rows[i][0].ToString()), animals.Rows[i][1].ToString(), animals.Rows[i][2].ToString(), (int)hours.TotalHours);
                }
                p.Location = new System.Drawing.Point(0, i * 25);
                panel_Enclosure_Animals.Controls.Add(p);
            }
        }

        /**<summary>
         * Creates a panel with information about an animal and a checkbox to select it
         * </summary>
         */
        private Panel makeFeedAnimalUiComponent_Enclosure(int aid, String name, String species,int lastFed)
        {
            Panel p = new Panel();
            Label animal = new Label();
            CheckBox selectAnimal = new CheckBox();

            // sets the panel size
            p.Width = panel_Enclosure_Animals.Width;
            p.Height = 24;

            animal.Text = $"{name}, {species}, {calculateLastFedTime(lastFed)}";
            animal.AutoSize = true;

            p.Controls.Add(animal);
            animal.Location = new System.Drawing.Point(0, 0);

            p.Controls.Add(selectAnimal);
            selectAnimal.Location = new System.Drawing.Point(p.Width - selectAnimal.Width - 5, 0);
            selectAnimal.Tag = aid;
            selectAnimal.CheckedChanged += SelectAnimal_CheckedChanged;
            selectedAnimalsCheckboxList.Add(selectAnimal);

            return p;
        }


        /**<summary>
         * Adds/removes the animal id to the list of the selected animals.
         * The id is taken from the tag of the sender.
         * </summary>
         */
        private void SelectAnimal_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                selectedAnimals.Add(int.Parse(((CheckBox)sender).Tag.ToString()));
            }
            else
            {
                selectedAnimals.Remove(int.Parse(((CheckBox)sender).Tag.ToString()));
            }

            //Dissables the button when it is clicked.
            if(selectedAnimals.Count == 0)
            {
                button_feedGroup.Enabled = false;
            }
            else
            {
                button_feedGroup.Enabled = true;
            }
        }

        /**<summary>
         * Deselects all the animals currently selected for feeding
         * </summary>
         */
        private void button_selectAllFeed_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selectedAnimalsCheckboxList.Count; i++)
            {
                selectedAnimalsCheckboxList[i].Checked = true;
            }
        }

        /**<summary>
         * Unselects all the animals in the list.
         * </summary>
         */
        private void button_selectNoneFeed_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selectedAnimalsCheckboxList.Count; i++)
            {
                selectedAnimalsCheckboxList[i].Checked = false;
            }
        }

        /**<summary>
         * Feeds all the animals that are currently selected
         * </summary>
         */
        private void button_feedGroup_Click(object sender, EventArgs e)
        {
            FeedForm form = new FeedForm(selectedAnimals.ToArray(), staffMemberId);

            // ShowDialog is blocking, so reload the enclosure animals afterwards
            form.ShowDialog();
            loadEnclosureAnimals();
            needToUpdate = true;
        }



        /// <summary>
        /// Get a DataTable of Animals that are relevant to the logged in Staff.
        /// 
        /// Don't like this query at the moment but it does the job for the small dataset.
        /// </summary>
        /// <returns>DataTable of Animals</returns>
        private DataTable getStaffAnimals()
        {
            String query = $"SELECT a.aid, a.name " +
                $"FROM {DatabaseHelper.Table("ANIMAL")} a " +
                $"WHERE a.aid IN " +
                $"(SELECT a1.aid " +
                $"FROM {DatabaseHelper.Table("ANIMAL")} a1, {DatabaseHelper.Table("SPECIESGROUP")} sg, " +
                $"{DatabaseHelper.Table("SPECIES")} sp, {DatabaseHelper.Table("OVERSEES")} o, {DatabaseHelper.Table("STAFF")} st " +
                $"WHERE st.sid = o.staffid " +
                $"AND o.sgroupname = sg.latinname " +
                $"AND sg.latinname = sp.speciesgroup " +
                $"AND sp.latinname = a1.speciesname " +
                $"AND st.sid = '{staffMemberId}')";

            DataTable staffAnimals = DatabaseHelper.ExecuteQuery(query);
            return staffAnimals;
        }

        ///
        /// <summary>
        /// Method for populating the animal combobox.
        /// </summary>
        private void populateAnimalComboBox()
        {
            cbSelectAnimal.Items.Clear();

            if (Queries.getDBType() == Queries.DBType.Mongo)
            {
                var animals = GetAllAnimalsFromMongo();
                if (animals.Count == 0)
                {
                    MessageBox.Show("No animals found in MongoDB.");
                    return;
                }

                foreach (var a in animals)
                {
                    cbSelectAnimal.Items.Add(a["name"].AsString);
                }
            }
            else
            {
                DataTable queryResult = getStaffAnimals();
                foreach (DataRow row in queryResult.Rows)
                {
                    cbSelectAnimal.Items.Add(row["name"].ToString());
                }
            }
        }
        /// <summary>
        /// A helper method to get the age as a string, from a DateTime DateOfBirth.
        /// </summary>
        /// <returns>The age of the animal as a String.</returns>
        private String getAgeFromDob(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            // If the dob date is further along than the date today, then their last birthday did not happen
            if (dob.Date > today.AddYears(-age)) --age;

            return age.ToString();
        }

        private void btnAddAnimal_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AddAnimalForm().ShowDialog();
            this.Close();
        }

        private void cbSelectAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectAnimal.SelectedIndex == -1) return;

            string animalName = cbSelectAnimal.SelectedItem.ToString();

            if (Queries.getDBType() == Queries.DBType.Oracle)
            {
                // Oracle: Load full info including zone
                string query = $@"
        SELECT a.aid, a.name, a.dob, a.sex, a.weight, a.originCountry,
               a.enclosureID, e.name AS enclosureName, z.name AS zoneName,
               s.commonName AS speciesName, a.feedingInterval
        FROM {DatabaseHelper.Table("ANIMAL")} a
        JOIN {DatabaseHelper.Table("ENCLOSURE")} e ON a.enclosureID = e.eid
        JOIN {DatabaseHelper.Table("ZONE")} z ON e.zoneName = z.name
        JOIN {DatabaseHelper.Table("SPECIES")} s ON a.speciesName = s.latinName
        WHERE a.name = :name";

                OracleParameter[] param = { new OracleParameter("name", animalName) };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Animal not found.");
                    return;
                }

                DataRow row = dt.Rows[0];
                string aid = row["aid"].ToString();
                string sex = row["sex"].ToString() == "M" ? "Male" : "Female";

                txtSpecies.Text = row["speciesName"].ToString();
                txtAge.Text = getAgeFromDob(Convert.ToDateTime(row["dob"]));
                txtSex.Text = sex;
                txtWeight.Text = row["weight"].ToString() + " kg";
                txtOrigin.Text = row["originCountry"].ToString();
                txtEnclosure.Text = row["enclosureName"].ToString();
                txtZone.Text = row["zoneName"].ToString();
                txtFeedingInterval.Text = row["feedingInterval"].ToString() + " Hours";

                // Zookeepers
                string zookeeperQuery = Queries.ZookeepersQualifiedForAnimal + $" AND a.aid = :aid";
                OracleParameter[] zkParams = { new OracleParameter("aid", aid) };
                DataTable zks = DatabaseHelper.ExecuteQuery(zookeeperQuery, zkParams);
                txtZookeepers.Text = string.Join(", ", zks.AsEnumerable().Take(5)
                    .Select(r => $"{r["fname"]} {r["lname"]}"));

                // Vets
                string vetQuery = $@"
        SELECT DISTINCT s.fname, s.lname 
        FROM {DatabaseHelper.Table("CARE")} c
        JOIN {DatabaseHelper.Table("STAFF")} s ON c.staffID = s.sid
        WHERE c.animalID = :aid";
                DataTable vets = DatabaseHelper.ExecuteQuery(vetQuery, zkParams);
                txtVets.Text = string.Join(", ", vets.AsEnumerable().Take(5)
                    .Select(r => $"{r["fname"]} {r["lname"]}"));

                // Last Fed and Cared: Days Ago
                string lastFed = "Never Fed!";
                string lastCare = "Never Cared!";

                var feed = DatabaseHelper.ExecuteQuery($@"
            SELECT datetime FROM {DatabaseHelper.Table("FEED")} 
            WHERE animalID = :aid 
            ORDER BY datetime DESC FETCH FIRST 1 ROWS ONLY", zkParams);

                if (feed.Rows.Count > 0)
                {
                    DateTime dtFed = Convert.ToDateTime(feed.Rows[0]["datetime"]);
                    lastFed = getDaysAgo(dtFed);
                }

                var care = DatabaseHelper.ExecuteQuery($@"
            SELECT datetime FROM {DatabaseHelper.Table("CARE")} 
            WHERE animalID = :aid 
            ORDER BY datetime DESC FETCH FIRST 1 ROWS ONLY", zkParams);

                if (care.Rows.Count > 0)
                {
                    DateTime dtCare = Convert.ToDateTime(care.Rows[0]["datetime"]);
                    lastCare = getDaysAgo(dtCare);
                }

                txtLastFed.Text = lastFed;
                txtLastCare.Text = lastCare;
            }
            else
            {
                var speciesGroups = MongoDBHelper.FindAll(MongoDBHelper.DBCollection.SpeciesGroup);

                var selectedAnimalInfo = speciesGroups
                    .SelectMany(group => group["species"].AsBsonArray
                        .SelectMany(species => species["animals"].AsBsonArray
                            .Where(a => a["name"].AsString == animalName)
                            .Select(a => new
                            {
                                animal = a,
                                speciesName = species["commonName"].AsString,
                                speciesGroup = group["latinName"].AsString,  // for staff.oversees
                                groupCommon = group["commonName"].AsString
                            })))
                    .FirstOrDefault();

                if (selectedAnimalInfo == null)
                {
                    MessageBox.Show("Animal not found.");
                    return;
                }

                var animal = selectedAnimalInfo.animal;
                var speciesName = selectedAnimalInfo.speciesName;
                var speciesGroup = selectedAnimalInfo.speciesGroup;
                var groupCommon = selectedAnimalInfo.groupCommon;
                int aid = animal["aid"].AsInt32;

                // Animal Details
                txtSpecies.Text = speciesName;
                txtAge.Text = getAgeFromDob(animal["dob"].ToUniversalTime());
                txtSex.Text = animal["sex"].AsString == "M" ? "Male" : "Female";
                txtWeight.Text = animal["weight"] + " kg";
                txtOrigin.Text = animal["originCountry"].AsString;
                txtFeedingInterval.Text = animal["feedingInterval"] + " Hours";

                // Enclosure and Zone
                var (enclosureName, zoneName) = MongoDBHelper.GetEnclosureZoneByAnimalId(aid);
                txtEnclosure.Text = enclosureName;
                txtZone.Text = zoneName;

                // Zookeepers
                txtZookeepers.Text = string.Join(", ",
                    MongoDBHelper.GetZookeeperNamesByGroup(speciesGroup).Take(5));

                // Vets
                txtVets.Text = string.Join(", ",
                    MongoDBHelper.GetVetNamesByAnimalId(aid).Take(5));

                if (string.IsNullOrWhiteSpace(txtVets.Text))
                {
                    txtVets.Text = "None Assigned";
                }

                // Last Fed
                var feeds = MongoDBHelper.FindAll(MongoDBHelper.DBCollection.Feed)
                    .Where(f => f["animalID"].AsInt32 == aid)
                    .OrderByDescending(f => f["datetime"]);

                txtLastFed.Text = feeds.Any()
                    ? getDaysAgo(feeds.First()["datetime"].ToLocalTime())
                    : "Never Fed!";

                // Last Cared
                var cares = MongoDBHelper.FindAll(MongoDBHelper.DBCollection.Care)
                    .Where(c => c["animalID"].AsInt32 == aid)
                    .OrderByDescending(c => c["datetime"]);

                txtLastCare.Text = cares.Any()
                    ? getDaysAgo(cares.First()["datetime"].ToLocalTime())
                    : "Never Cared!";
            }
        }

        /// <summary>
        /// Method for populating the Zone UI with elements.
        /// Gets the current page from the NumericUpDown Control.
        /// </summary>
        private void populateZoneUIElements()
        {
            // Get page info
            NumericUpDown nud = this.numericUpDownZonePage;
            int currentPage = (int)nud.Value;
            // bottom row inclusive
            int bottomRowNum = ((currentPage - 1) * 6) + 1;
            // top row inclusive
            int topRowNum = currentPage * 6;

            // Query to get basic info on each Zone to populate the UI elements
            // Change this to be on rowname too?
            String initZoneDataQuery = $"SELECT * FROM " +
                $"(SELECT name, colour, hexcode, rownum rnum " +
                $"FROM " +
                    $"(SELECT distinct z.name, z.colour, z.hexcode " +
                    $"FROM {DatabaseHelper.Table("ZONE")} z, {DatabaseHelper.Table("ENCLOSURE")} e, " +
                    $"{DatabaseHelper.Table("ANIMAL")} a, {DatabaseHelper.Table("SPECIES")} sp, " +
                    $"{DatabaseHelper.Table("SPECIESGROUP")} sg, {DatabaseHelper.Table("OVERSEES")} o " +
                    $"WHERE o.staffid = {staffMemberId} " +
                    $"AND o.sgroupname = sg.latinname " +
                    $"AND sg.latinname = sp.speciesgroup " +
                    $"AND sp.latinname = a.speciesname " +
                    $"AND a.enclosureID = e.eid " +
                    $"AND e.zonename = z.name " +
                    $"ORDER BY z.name) " +
                    $"WHERE rownum <= {topRowNum}) " +
                    $"WHERE rnum >= {bottomRowNum} ";
            if (textBoxZoneSearch.Text != "")
            {
                initZoneDataQuery +=
                    $"AND name LIKE '%{textBoxZoneSearch.Text}%'";
            }

            DataTable basicZoneInfo = DatabaseHelper.ExecuteQuery(initZoneDataQuery);

            // Write result to the list of zone names
            ZoneNameList = new List<String>();
            for (int i = 0; i < basicZoneInfo.Rows.Count; i++)
            {
                ZoneNameList.Add(basicZoneInfo.Rows[i]["name"].ToString());
            }
            
            // WRITE SOMETHING FOR IF NO ZONE IS FOUND

            // Populate UI elements!
            for (int i = 1; i < basicZoneInfo.Rows.Count + 1; i++)
            {
                // First get the list of animals in that enclosure that are relevant...
                String animalsNeedingQuery = $"SELECT t.aid, a.feedinginterval, t.\"MAX(F.DATETIME)\" as \"DATETIME\" " +
                    $"FROM m2s_animal a, " +
                    $"(SELECT a.aid, MAX(f.datetime) " +
                    $"FROM m2s_enclosure e, " +
                    $"{DatabaseHelper.Table("ANIMAL")} a, {DatabaseHelper.Table("FEED")} f, {DatabaseHelper.Table("CARE")} c, " +
                    $"{DatabaseHelper.Table("SPECIES")} sp, {DatabaseHelper.Table("SPECIESGROUP")} sg, " +
                    $"{DatabaseHelper.Table("OVERSEES")} o " +
                    $"WHERE o.staffid = '{staffMemberId}' " +
                    $"AND o.sgroupname = sg.latinname " +
                    $"AND sg.latinname = sp.speciesgroup " +
                    $"AND sp.latinname = a.speciesname " +
                    $"AND a.enclosureID = e.eid " +
                    $"AND e.zonename = '{basicZoneInfo.Rows[i - 1]["name"].ToString()}' " +
                    $"AND f.animalid = a.aid " +
                    $"GROUP BY a.aid) t " +
                    $"WHERE a.aid = t.aid";

                DataTable animalCount = DatabaseHelper.ExecuteQuery(animalsNeedingQuery);

                // Get the number of animals that could be helped
                int numAnimalsNeedingCare = 0;
                for (int j = 0; j < animalCount.Rows.Count; j++)
                {
                    int fInterval = int.Parse(animalCount.Rows[j]["feedingInterval"].ToString());
                    DateTime minDate = DateTime.Today.AddMinutes(-(fInterval * 60));
                    if (minDate > DateTime.Parse(animalCount.Rows[j]["datetime"].ToString())) numAnimalsNeedingCare++;
                }

                Panel panelZ = (Panel)this.Controls.Find($"panelZone{i}", true)[0];
                Label zoneNameLabel = (Label)this.Controls.Find($"labelZoneName{i}", true)[0];
                Label animalsNeedingAttention = (Label)this.Controls.Find($"labelZoneAnimalsAttention{i}", true)[0];

                panelZ.BackColor = (Color)ColorTranslator.FromHtml("#" + basicZoneInfo.Rows[i - 1]["hexcode"].ToString());
                zoneNameLabel.Text = basicZoneInfo.Rows[i - 1]["name"].ToString();
                animalsNeedingAttention.Text = $"{numAnimalsNeedingCare} animals you can attend to!";

                panelZ.Show();
            }

            for (int i = basicZoneInfo.Rows.Count + 1; i < 7; i++)
            {
                Panel panelZ = (Panel)this.Controls.Find($"panelZone{i}", true)[0];
                panelZ.Hide();
            }
        }

        private void resetZonePaging()
        {
            int numBoxes = 6;
            // If search box contains nothing, then search all.
            OracleParameter[] parameters = null;
            String countQuery;
            if (textBoxZoneSearch.Text != "")
            {
                countQuery = $"SELECT COUNT(distinct name) as \"count\" " +
                $"FROM {DatabaseHelper.Table("ZONE")} " +
                $"WHERE name LIKE '%:input%' " +
                $"AND name IN (" +
                    $"SELECT z.name " +
                    $"FROM {DatabaseHelper.Table("ZONE")} z, {DatabaseHelper.Table("ENCLOSURE")} e, " +
                    $"{DatabaseHelper.Table("ANIMAL")} a, {DatabaseHelper.Table("SPECIES")} sp, " +
                    $"{DatabaseHelper.Table("SPECIESGROUP")} sg, {DatabaseHelper.Table("OVERSEES")} o " +
                    $"WHERE o.staffid = '{staffMemberId}' " +
                    $"AND o.sgroupname = sg.latinname " +
                    $"AND sg.latinname = sp.speciesgroup " +
                    $"AND sp.latinname = a.speciesname " +
                    $"AND a.enclosureID = e.eid " +
                    $"AND e.zonename = z.name)";

                parameters = new OracleParameter[]
                {
                    new OracleParameter("input", OracleDbType.Varchar2, textBoxZoneSearch.Text, ParameterDirection.Input)
                };
            }
            else
            {
                countQuery = $"SELECT COUNT(distinct name) AS \"count\" " +
                $"FROM {DatabaseHelper.Table("ZONE")} " +
                $"WHERE name IN (" +
                    $"SELECT z.name " +
                    $"FROM {DatabaseHelper.Table("ZONE")} z, {DatabaseHelper.Table("ENCLOSURE")} e, " +
                    $"{DatabaseHelper.Table("ANIMAL")} a, {DatabaseHelper.Table("SPECIES")} sp, " +
                    $"{DatabaseHelper.Table("SPECIESGROUP")} sg, {DatabaseHelper.Table("OVERSEES")} o " +
                    $"WHERE o.staffid = '{staffMemberId}' " +
                    $"AND o.sgroupname = sg.latinname " +
                    $"AND sg.latinname = sp.speciesgroup " +
                    $"AND sp.latinname = a.speciesname " +
                    $"AND a.enclosureID = e.eid " +
                    $"AND e.zonename = z.name)";
            }

            DataTable countDt = DatabaseHelper.ExecuteQuery(countQuery, parameters);
            int totalCount = int.Parse(countDt.Rows[0]["count"].ToString());
            int numPages = ((totalCount - 1 )/ numBoxes) + 1;
         
            NumericUpDown nud = this.numericUpDownZonePage;
            nud.Value = 1;
            nud.Minimum = 1;
            nud.Maximum = numPages;
        }

        /// <summary>
        /// Method for getting the Zones according to a search string.
        /// </summary>
        /// <param name="toSearch"></param>
        /// <returns></returns>
        private DataTable getZones(String toSearch = null)
        {
            String dataQuery = "";
            String countQuery = "";
            return null;
        }

        private void btnSelectZone_Click(object sender, EventArgs e)
        {
            // 😊 get zone name
            String btnText = ((Button)sender).Name;
            int index = int.Parse(btnText.Substring(btnText.Length - 1)) - 1;
            String zoneName = ZoneNameList[index];

            // Make sure to set the current enclosure to -1!
            currentEnclosure = -1;
            DataTable enclosuresToShow;

            // If using mongo:
            if (usingMongo)
            {
                List<(int, string)> enclosures = MongoDBHelper.GetEnclosuresFromZoneName(zoneName);
                enclosuresToShow = new DataTable();
                enclosuresToShow.Columns.Add("eid", typeof(int));
                enclosuresToShow.Columns.Add("name", typeof(string));
                foreach ((int, string) enc in enclosures)
                {
                    enclosures.Add(enc);
                }
            }
            else
            {
                // Get a DataTable with:
                // [0] eid
                // [1] eName
                String query = $"SELECT distinct e.eid, e.name " +
                    $"FROM {DatabaseHelper.Table("ENCLOSURE")} e, {DatabaseHelper.Table("SPECIES")} sp, " +
                    $"{DatabaseHelper.Table("SPECIESGROUP")} sg, {DatabaseHelper.Table("OVERSEES")} o, " +
                    $"{DatabaseHelper.Table("ANIMAL")} a " +
                    $"WHERE e.zoneName = '{ZoneNameList[index]}' " +
                    $"AND a.enclosureID = e.eid " +
                    $"AND a.speciesName = sp.latinname " +
                    $"AND sp.speciesgroup = o.sGroupName " +
                    $"AND o.staffID = '{staffMemberId}' ";

                enclosuresToShow = DatabaseHelper.ExecuteQuery(query);
            }

            populateEnclosureList_ComboBox_Enclosure_Search(enclosuresToShow);

            // Now switch tabs, combobox is populated. 
            tabControlMain.SelectedIndex = 2;
        }

        private void btnAddFeed_Click(object sender, EventArgs e)
        {
            // Placeholder for feed logic
        }

        private void btnAddCare_Click(object sender, EventArgs e)
        {
            // Placeholder for care logic
        }
        private void cbZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Load enclosures in selected zone
        }

        private void cbEnclosure_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Load animals in selected enclosure
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Add new enclosure or animal (could open a form)
        }

        /// <summary>
        /// This should be where data is loaded on demand for each tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //return;
            // 0 = Home
            // 1 = Animal
            // 2 = Enclosure
            // 3 = Zone
            int index = ((TabControl)sender).SelectedIndex;
            switch (index)
            {
                case 0:
                    // Home Tab Logic
                    displayFeedingList();
                    return;
                case 1:
                    // Animal Tab Logic
                    populateAnimalComboBox();
                    return;
                case 2:
                    // Enclosure Tab Logic
                    initialiseEnclosure();
                    return;
                case 3:
                    // Zone Tab Logic
                    resetZonePaging();
                    populateZoneUIElements();
                    return;
                default:
                    return;

            }
        }

        private void buttonZoneSearch_Click(object sender, EventArgs e)
        {
            resetZonePaging();
            populateZoneUIElements();
        }

        private void numericUpDownZonePage_ValueChanged(object sender, EventArgs e)
        {
            populateZoneUIElements();
        }

        //mongo helper class
        private List<BsonDocument> GetAllAnimalsFromMongo()
        {
            var animals = MongoDBHelper.AggregateSpeciesAnimals();

            if (animals.Count == 0)
            {
                MessageBox.Show("No animals found in MongoDB.");
            }

            return animals;
        }


        private string getDaysAgo(DateTime dt)
        {
            int days = (DateTime.Today - dt.Date).Days;
            return days == 0 ? "Today" : $"{days} day(s) ago";
        }

        /**
         * Calls a load function after a tab is selected
         */
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
        }

        /**
         * Gets the staff names for the dropdown names list
         */
        private void getStaff()
        {
            return;
        }
    }
}
