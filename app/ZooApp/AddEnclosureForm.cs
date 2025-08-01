using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class AddEnclosureForm : Form
    {
        private bool isEditMode = false;
        private int editingEid = -1;
        private string selectedZone = "";

        public AddEnclosureForm()
        {
            InitializeComponent();
        }

        public AddEnclosureForm(DataRow enclosureRow) : this()
        {
            if (enclosureRow != null)
            {
                isEditMode = true;
                editingEid = Convert.ToInt32(enclosureRow["eid"]);
                LoadExistingData(enclosureRow);
            }
        }

        private void AddEnclosureForm_Load(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                this.Text = "Edit Enclosure";
                btnSubmit.Text = "Update";
            }
            else
            {
                this.Text = "Add New Enclosure";
                btnSubmit.Text = "Add";
                lblSelectedZone.Text = "No zone selected";
            }
        }

        private void LoadExistingData(DataRow row)
        {
            txtBiome.Text = row["biome"].ToString();
            txtSize.Text = row["esize"].ToString();
            selectedZone = row["zoneName"].ToString();
            lblSelectedZone.Text = $"Selected: {selectedZone}";
        }

        private void btnSelectZone_Click(object sender, EventArgs e)
        {
            using (var form = new SelectZoneForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selectedZone = form.SelectedZoneName;
                    lblSelectedZone.Text = $"Selected: {selectedZone}";
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string biome = txtBiome.Text.Trim();

                if (!int.TryParse(txtSize.Text.Trim(), out int size) || size <= 0)
                {
                    MessageBox.Show("Zone size must be a positive number.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(selectedZone))
                {
                    MessageBox.Show("Please select a zone.");
                    return;
                }

                string table = DatabaseHelper.Table("ENCLOSURE");

                if (isEditMode)
                {
                    string update = $"UPDATE {table} SET biome = :biome, esize = :eSize, zoneName = :zoneName WHERE eid = :eid";
                    OracleParameter[] parameters = {
                        new OracleParameter("biome", biome),
                        new OracleParameter("eSize", size),
                        new OracleParameter("zoneName", selectedZone),
                        new OracleParameter("eid", editingEid)
                    };
                    DatabaseHelper.ExecuteNonQuery(update, parameters);
                    MessageBox.Show("Enclosure updated successfully.");
                }
                else
                {
                    string getEidQuery = $"SELECT NVL(MAX(eid), 0) + 1 FROM {table}";
                    int newEid = Convert.ToInt32(DatabaseHelper.ExecuteQuery(getEidQuery).Rows[0][0]);

                    string insert = $"INSERT INTO {table} (eid, biome, esize, zoneName) VALUES (:eid, :biome, :eSize, :zoneName)";
                    OracleParameter[] parameters = {
                        new OracleParameter("eid", newEid),
                        new OracleParameter("biome", biome),
                        new OracleParameter("eSize", size),
                        new OracleParameter("zoneName", selectedZone)
                    };
                    DatabaseHelper.ExecuteNonQuery(insert, parameters);
                    MessageBox.Show("Enclosure added successfully.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
