using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class AddSpeciesGroupForm : Form
    {
        private readonly string editingLatinName = null;

        public AddSpeciesGroupForm(string latinNameToEdit = null)
        {
            InitializeComponent();
            editingLatinName = latinNameToEdit;
        }

        private void AddSpeciesGroupForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(editingLatinName))
            {
                this.Text = "Edit Species Group";
                btnSubmit.Text = "Update";
                txtLatinName.Enabled = false; // Cannot change primary key
                LoadExistingData();
            }
            else
            {
                this.Text = "Add Species Group";
                btnSubmit.Text = "Add";
            }
        }

        private void LoadExistingData()
        {
            string query = "SELECT * FROM m2s_speciesgroup WHERE latinName = :latin";
            var param = new OracleParameter[] { new OracleParameter("latin", editingLatinName) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count == 1)
            {
                var row = dt.Rows[0];
                txtLatinName.Text = row["latinName"].ToString();
                txtCommonName.Text = row["commonName"].ToString();
            }
            else
            {
                MessageBox.Show("Species group not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string latin = txtLatinName.Text.Trim();
            string common = txtCommonName.Text.Trim();

            if (string.IsNullOrEmpty(latin) || string.IsNullOrEmpty(common))
            {
                MessageBox.Show("Both Latin name and Common name are required.");
                return;
            }

            try
            {
                if (editingLatinName != null)
                {
                    string update = "UPDATE m2s_speciesgroup SET commonName = :common WHERE latinName = :latin";
                    var parameters = new OracleParameter[]
                    {
                        new OracleParameter("common", common),
                        new OracleParameter("latin", latin)
                    };

                    DatabaseHelper.ExecuteNonQuery(update, parameters);
                    MessageBox.Show("Group updated.");
                }
                else
                {
                    string insert = "INSERT INTO m2s_speciesgroup (latinName, commonName) VALUES (:latin, :common)";
                    var parameters = new OracleParameter[]
                    {
                        new OracleParameter("latin", latin),
                        new OracleParameter("common", common)
                    };

                    DatabaseHelper.ExecuteNonQuery(insert, parameters);
                    MessageBox.Show("Group added.");
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
