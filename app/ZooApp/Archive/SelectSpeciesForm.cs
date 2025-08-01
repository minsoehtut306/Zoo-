using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class SelectSpeciesForm : Form
    {
        public string SelectedSpeciesName { get; private set; }

        public SelectSpeciesForm()
        {
            InitializeComponent();
        }

        private void SelectSpeciesForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load species groups
                string query = "SELECT latinName FROM m2s_speciesgroup ORDER BY latinName";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cboSpeciesGroup.DataSource = dt;
                cboSpeciesGroup.DisplayMember = "latinName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load species groups: " + ex.Message);
            }
        }

        private void cboSpeciesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSpeciesList();
        }

        private void LoadSpeciesList()
        {
            try
            {
                string groupName = cboSpeciesGroup.Text;

                string query = "SELECT latinName, commonName FROM m2s_species WHERE speciesGroup = :speciesGroup";
                OracleParameter[] param = { new OracleParameter("speciesGroup", groupName) };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, param);
                lstSpecies.DisplayMember = "latinName"; // could change to show both names
                lstSpecies.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load species: " + ex.Message);
            }
        }
        private void LoadSpeciesGroups()
        {
            string query = "SELECT latinName FROM m2s_speciesgroup ORDER BY latinName";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cboSpeciesGroup.DataSource = dt;
            cboSpeciesGroup.DisplayMember = "latinName";
        }


        private void btnAddSpecies_Click(object sender, EventArgs e)
        {
            string currentGroup = cboSpeciesGroup.Text;

            using (var form = new AddSpeciesForm(currentGroup))
            {
                form.ShowDialog();
                LoadSpeciesGroups();
                cboSpeciesGroup.SelectedIndex = cboSpeciesGroup.FindStringExact(currentGroup);
            }
        }


        private void btnEditSpecies_Click(object sender, EventArgs e)
        {
            if (lstSpecies.SelectedItem == null)
            {
                MessageBox.Show("Please select a species to edit.");
                return;
            }

            DataRowView row = lstSpecies.SelectedItem as DataRowView;
            if (row == null) return;

            string latinName = row["latinName"].ToString();

            using (var form = new AddSpeciesForm(null, latinName))
            {
                form.ShowDialog();
                LoadSpeciesList(); // refresh after editing
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lstSpecies.SelectedItem != null)
            {
                DataRowView row = lstSpecies.SelectedItem as DataRowView;
                SelectedSpeciesName = row["latinName"].ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please select a species.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
