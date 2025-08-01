using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ZooApp
{
    // <summary>
    // Staff selection form that supports both Oracle and MongoDB.
    // </summary>
    public partial class SelectStaffForm : Form
    {
        private DataTable staffList;
        private List<BsonDocument> mongoStaffList;
        public SelectStaffForm()
        {
            InitializeComponent();
        }

        // <summary>
        // On form load, populate the staff dropdown.
        // @authors: Min Soe Htut

        // </summary>
        private void SelectStaffForm_Load(object sender, EventArgs e)
        {
            comboBoxSelectStaff_LoadStaffList();
        }

        /**
         * <summary>
         * Loads a list of all staff members into the combobox items
         * @author Dolf ten Have
         * Min Soe Htut
         * </summary>
         */
        private void comboBoxSelectStaff_LoadStaffList()
        {
            cbSelectStaff.Items.Clear();
            cbSelectStaff.Items.Add("Select Your Name");

            if (Queries.getDBType() == Queries.DBType.Mongo)
            {
                mongoStaffList = MongoDBHelper.FindAll(MongoDBHelper.DBCollection.Staff);
                foreach (var doc in mongoStaffList)
                {
                    string fullName = $"{doc["fName"]} {doc["lName"]}";
                    cbSelectStaff.Items.Add(fullName);
                }
            }
            else
            {
                getStaff();
                for (int i = 0; i < staffList.Rows.Count; i++)
                {
                    cbSelectStaff.Items.Add(staffList.Rows[i]["Fullname"]);
                }
            }

            cbSelectStaff.SelectedIndex = 0;
        }

        /** <summary>
        *  Gets the staff names for the dropdown names list.
        *  @author Dolf ten Have
        * </summary>
        * <returns>a DataTable containging the full name of all the staff members in the DB</returns>
        */
        private void getStaff()
        {
            String query = $"SELECT sid, fname || ' ' || lname AS \"Fullname\" FROM {DatabaseHelper.Table("STAFF")}";
            staffList = DatabaseHelper.ExecuteQuery(query);

        }

        // <summary>
        // Opens AddStaffForm dialog and refreshes staff list after adding new staff.
        // @author Min Soe Htut
        // </summary>
        private void buttonAddStaff_Click(object sender, EventArgs e)
        {
            using (AddStaffForm form = new AddStaffForm())
            {
                form.ShowDialog();
                comboBoxSelectStaff_LoadStaffList();
            }
        }


        // <summary>
        // Handle the Quit button click event.
        // Closes the application.
        // @author Min Soe Htut
        // </summary>
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /**
         * <summary>
         * Checks if a staff member has been selected by the user. Otherwise an alert message is shown to notify the user to select their name.
         * @author Dolf ten Have
         * Min Soe Htut
         * </summary>
         */
        private void buttonLogin_Click(object sender, EventArgs e)
        {
           Label chooseNameAlert;

            //Issues a warning to the user to choose a name.
           if (cbSelectStaff.SelectedIndex < 1) {
                chooseNameAlert = new Label();
                chooseNameAlert.Text = "Please select your name to continue.";
                chooseNameAlert.AutoSize= true;
                chooseNameAlert.ForeColor = Color.Red;
                chooseNameAlert.Location = new Point(cbSelectStaff.Location.X, cbSelectStaff.Location.Y + cbSelectStaff.Height);
                this.Controls.Add(chooseNameAlert);
                return;
            }
            try
            {
                int staffIdInt;

                if (Queries.getDBType() == Queries.DBType.Mongo)
                {
                    MongoDBHelper.Initialize("Zoo");
                    var selectedStaff = mongoStaffList[cbSelectStaff.SelectedIndex - 1];
                    staffIdInt = selectedStaff.Contains("sid") ? selectedStaff["sid"].AsInt32 : -1;
                }

                else
                {
                    string staffId = staffList.Rows[cbSelectStaff.SelectedIndex - 1][0].ToString();
                    staffIdInt = int.Parse(staffId);
                }

                this.Hide();
                new MainForm(staffIdInt).ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //Otherwise move to the next page
        }

        /// <summary>
        /// Opens the AddVetForm dialog to manage vet staff.
        /// </summary>
        private void butUpdateVet_Click(object sender, EventArgs e)
        {
            new AddVetForm().ShowDialog();
        }

        /// <summary>
        /// Opens the AddZookeeperForm dialog to manage zookeeper staff.
        /// </summary>
        private void butUpdateZooKeeper_Click(object sender, EventArgs e)
        {
            new AddZookeeperForm().ShowDialog();
        }

    }
}
