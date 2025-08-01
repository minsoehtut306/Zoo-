using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class AddSpeciesForm : Form
    {
        private readonly string editingLatinName = null;
        private string selectedGroup = "";

        public AddSpeciesForm(string defaultGroup = null, string latinNameToEdit = null)
        {
            InitializeComponent();
            selectedGroup = defaultGroup;
            editingLatinName = latinNameToEdit;
        }

        private void AddSpeciesForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(editingLatinName))
            {
                this.Text = "Edit Species";
                LoadSpeciesData();
                btnSubmit.Text = "Update";
            }
            else
            {
                this.Text = "Add Species";
                lblSelectedGroup.Text = string.IsNullOrEmpty(selectedGroup)
                    ? "No group selected"
                    : $"Selected: {selectedGroup}";
                btnSubmit.Text = "Add";
            }
        }

        private void LoadSpeciesData()
        {
            string query = "SELECT * FROM m2s_species WHERE latinName = :latin";
            var param = new OracleParameter[] { new OracleParameter("latin", editingLatinName) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count == 1)
            {
                var row = dt.Rows[0];
                txtLatinName.Text = row["latinName"].ToString();
                txtCommonName.Text = row["commonName"].ToString();
                txtBiome.Text = row["requiredBiome"].ToString();
                selectedGroup = row["speciesGroup"].ToString();
                lblSelectedGroup.Text = $"Selected: {selectedGroup}";
                txtLatinName.Enabled = false; // prevent changing PK
            }
            else
            {
                MessageBox.Show("Species not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSelectGroup_Click(object sender, EventArgs e)
        {
            using (var form = new SelectSpeciesGroupForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selectedGroup = form.SelectedGroupName;
                    lblSelectedGroup.Text = $"Selected: {selectedGroup}";
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string latin = txtLatinName.Text.Trim();
            string common = txtCommonName.Text.Trim();
            string biome = txtBiome.Text.Trim();

            if (string.IsNullOrWhiteSpace(latin) || string.IsNullOrWhiteSpace(common))
            {
                MessageBox.Show("Latin name and common name are required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(selectedGroup))
            {
                MessageBox.Show("Please select a species group.");
                return;
            }

            try
            {
                if (editingLatinName != null)
                {
                    string update = @"UPDATE m2s_species 
                                      SET commonName = :common, 
                                          requiredBiome = :biome, 
                                          speciesGroup = :speciesGroup 
                                      WHERE latinName = :latin";

                    var updateParams = new OracleParameter[]
                    {
                        new OracleParameter("common", common),
                        new OracleParameter("biome", biome),
                        new OracleParameter("speciesGroup", selectedGroup),
                        new OracleParameter("latin", latin)
                    };

                    DatabaseHelper.ExecuteNonQuery(update, updateParams);
                    MessageBox.Show("Species updated.");
                }
                else
                {
                    string insert = @"INSERT INTO m2s_species 
                                      (latinName, commonName, requiredBiome, speciesGroup) 
                                      VALUES (:latin, :common, :biome, :speciesGroup)";

                    var insertParams = new OracleParameter[]
                    {
                        new OracleParameter("latin", latin),
                        new OracleParameter("common", common),
                        new OracleParameter("biome", biome),
                        new OracleParameter("speciesGroup", selectedGroup)
                    };

                    DatabaseHelper.ExecuteNonQuery(insert, insertParams);
                    MessageBox.Show("Species added.");
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
