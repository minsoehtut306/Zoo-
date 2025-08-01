using System;
using System.Data;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    /// <summary>
    /// Login form allowing selection between Oracle and MongoDB datasets.
    /// Initializes the appropriate connection depending on user choice.
    /// </summary>
    /// @ author:Min Soe Htut
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Holds the selected dataset so other forms can access it.
        /// </summary>
        public static string SelectedDataset { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates dataset options into the ComboBox when the form loads.
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            cbDataset.Items.Add("MongoDB Dataset");
            cbDataset.Items.Add("Small Dataset (M2S)");
            cbDataset.Items.Add("Large Dataset (M2L)");
            cbDataset.SelectedIndex = 0; // Default to MongoDB
        }

        /// <summary>
        /// Handles the Connect button click.
        /// Initializes the selected database (MongoDB or Oracle).
        /// </summary>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedDataset = cbDataset.SelectedItem.ToString();

                if (SelectedDataset.Contains("MongoDB"))
                {
                    //Sets the currently used DB type in mongoDB.
                    Queries.setDBType(Queries.DBType.Mongo);

                    // MongoDB selected
                    MongoDBHelper.Initialize("Zoo");
                    var testData = MongoDBHelper.FindAll(MongoDBHelper.DBCollection.Staff);

                    MessageBox.Show(
                        $"MongoDB Zoo database connected. {testData.Count} staff found.",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    //Sets the currently used DBtype to Oracle.
                    Queries.setDBType(Queries.DBType.Oracle);
                    // Oracle selected
                    string prefix = SelectedDataset.Contains("M2L") ? "M2L" : "M2S";
                    DatabaseHelper.SetTablePrefix(prefix);

                    string query = $"SELECT COUNT(*) FROM {DatabaseHelper.Table("ANIMAL")}";
                    DataTable dt = DatabaseHelper.ExecuteQuery(query);
                    int count = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;

                    MessageBox.Show(
                        $"{SelectedDataset} loaded. {count} animals found.",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

                // Move to next form
                this.Hide();
                new SelectStaffForm().ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Shows a list of accessible Oracle tables in a popup window.
        /// </summary>
        private void btnCheckTables_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery("SELECT table_name FROM user_tables ORDER BY table_name");

                Form popup = new Form
                {
                    Width = 400,
                    Height = 500,
                    Text = "Accessible Tables"
                };

                TextBox txtOutput = new TextBox
                {
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    ScrollBars = ScrollBars.Vertical,
                    ReadOnly = true
                };

                foreach (DataRow row in dt.Rows)
                    txtOutput.AppendText(row["TABLE_NAME"].ToString() + Environment.NewLine);

                popup.Controls.Add(txtOutput);
                popup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckCollections_Click(object sender, EventArgs e)
        {
            // Step 1: List all collections
            var client = new MongoClient("mongodb+srv://minsoehtut306:Minmin306htut1@cluster0.d7amife.mongodb.net/"); // or use your existing one
            var database = client.GetDatabase("Zoo");
            var collections = database.ListCollectionNames().ToList();

            string output = "Collections in 'Zoo' DB:\n\n";
            foreach (var name in collections)
            {
                output += name + "\n";
            }

            // Step 2: Look inside speciesGroup if it exists
            if (collections.Contains("speciesGroup"))
            {
                var speciesGroupCollection = database.GetCollection<BsonDocument>("speciesGroup");
                var documents = speciesGroupCollection.Find(new BsonDocument()).ToList();

                if (documents.Count > 0)
                {
                    output += "\nDocuments in 'speciesGroup':\n";
                    foreach (var doc in documents)
                    {
                        string name = doc.Contains("commonName") ? doc["commonName"].AsString : "(No commonName)";
                        output += $"- {name}\n";
                    }
                }
                else
                {
                    output += "\nNo documents found in 'speciesGroup'.";
                }
            }
            else
            {
                output += "\n'speciesGroup' collection not found!";
            }

            MessageBox.Show(output);
        }

    }
}
