using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class SelectSpeciesGroupForm : Form
    {
        public string SelectedGroupName { get; private set; }

        public SelectSpeciesGroupForm()
        {
            InitializeComponent();
        }

        private void SelectSpeciesGroupForm_Load(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void LoadGroups()
        {
            try
            {
                string query = "SELECT latinName, commonName FROM m2s_speciesgroup ORDER BY latinName";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                lstGroups.DataSource = dt;
                lstGroups.DisplayMember = "commonName";
                lstGroups.ValueMember = "latinName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load species groups: " + ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lstGroups.SelectedItem is DataRowView row)
            {
                SelectedGroupName = row["latinName"].ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please select a species group.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            using (var form = new AddSpeciesGroupForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGroups();
                }
            }
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            if (lstGroups.SelectedItem is DataRowView row)
            {
                string latin = row["latinName"].ToString();
                using (var form = new AddSpeciesGroupForm(latin))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadGroups();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a group to edit.");
            }
        }
    }
}
