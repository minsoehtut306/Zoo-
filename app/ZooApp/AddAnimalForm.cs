using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class AddAnimalForm : Form
    {
        private bool isEditMode = false;
        private int editingAid = -1;

        public AddAnimalForm()
        {
            InitializeComponent();
        }

        private void AddAnimalForm_Load(object sender, EventArgs e)
        {
            LoadAnimalList();
            LoadSpeciesDropdown();
            LoadSpeciesGroupDropdown();
            LoadEnclosureDropdown();

            cbSex.Items.Clear();
            cbSex.Items.AddRange(new[] { "M", "F" });
            cbSex.SelectedIndex = 0;

            cbSelectAnimal.Items.Insert(0, "Add New Animal");
            cbSelectAnimal.SelectedIndex = 0;

            btnUpdateSpecies.Enabled = false;
            btnDeleteSpecies.Enabled = false;
            btnUpdateSpeciesGroup.Enabled = false;
            btnDeleteSpeciesGroup.Enabled = false;
        }

        private void LoadAnimalList()
        {
            cbSelectAnimal.Items.Clear();
            cbSelectAnimal.Items.Add("Add New Animal");

            var dt = DatabaseHelper.ExecuteQuery(Queries.SelectAllAnimals);
            foreach (DataRow row in dt.Rows)
                cbSelectAnimal.Items.Add(new ComboBoxItem($"{row["aid"]} - {row["name"]}", row["aid"].ToString()));
        }

        private void LoadSpeciesDropdown()
        {
            cbSpecies.Items.Clear();
            cbSpecies.Items.Add("Add New Species");

            var dt = DatabaseHelper.ExecuteQuery(Queries.SelectAllSpecies);
            foreach (DataRow row in dt.Rows)
                cbSpecies.Items.Add(row["latinName"].ToString());

            cbSpecies.SelectedIndex = 0;
        }

        private void LoadSpeciesGroupDropdown()
        {
            cbSpeciesGroup.Items.Clear();
            cbSpeciesGroup.Items.Add("Add New Species Group");

            var dt = DatabaseHelper.ExecuteQuery(Queries.SelectAllSpeciesGroups);
            foreach (DataRow row in dt.Rows)
                cbSpeciesGroup.Items.Add(row["latinName"].ToString());

            cbSpeciesGroup.SelectedIndex = 0;
        }

        private void LoadEnclosureDropdown()
        {
            cbEnclosure.Items.Clear();
            var dt = DatabaseHelper.ExecuteQuery(Queries.LoadEnclosuresQuery);
            foreach (DataRow row in dt.Rows)
                cbEnclosure.Items.Add(row["eid"].ToString());
        }

        private void cbSelectAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectAnimal.SelectedIndex == 0 || cbSelectAnimal.SelectedItem == null || cbSelectAnimal.SelectedItem.ToString() == "Add New Animal")
            {
                isEditMode = false;
                editingAid = -1;
                ClearForm();
                return;
            }

            if (cbSelectAnimal.SelectedItem is ComboBoxItem selected)
            {
                editingAid = int.Parse(selected.Value);
                isEditMode = true;
                LoadAnimalById(editingAid);
            }
        }

        private void LoadAnimalById(int aid)
        {
            string query = Queries.SelectAnimalById;
            var dt = DatabaseHelper.ExecuteQuery(query, new[] { new OracleParameter("aid", aid) });

            if (dt.Rows.Count == 0) return;

            var row = dt.Rows[0];
            txtAnimalName.Text = row["name"].ToString();
            dtpDOB.Value = Convert.ToDateTime(row["dob"]);
            txtWeight.Text = row["weight"].ToString();
            txtOrigin.Text = row["originCountry"].ToString();
            txtFeeding.Text = row["feedingInterval"].ToString();
            cbSex.SelectedItem = row["sex"].ToString();
            cbEnclosure.SelectedItem = row["enclosureID"].ToString();

            cbSpecies.SelectedItem = row["speciesName"].ToString();
            txtLatinName.Text = row["speciesName"].ToString();
            txtCommonName.Text = row["speciesCommon"].ToString();
            txtRequiredBiome.Text = row["requiredBiome"].ToString();
            txtRelatedSpeciesGroup.Text = row["speciesGroup"].ToString();

            cbSpeciesGroup.SelectedItem = row["speciesGroup"].ToString();
            txtGroupLatin.Text = row["speciesGroup"].ToString();
            txtGroupCommon.Text = row["groupCommon"].ToString();
        }

        private void ClearForm()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox txt) txt.Clear();
                else if (c is ComboBox cb && cb.Name != "cbSelectAnimal") cb.SelectedIndex = -1;
            }

            if (cbSex.Items.Count > 0) cbSex.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Today;
        }
        private void butAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtAnimalName.Text.Trim();
                DateTime dob = dtpDOB.Value;
                decimal weight = decimal.Parse(txtWeight.Text);
                string origin = txtOrigin.Text.Trim().ToUpper();
                int feeding = int.Parse(txtFeeding.Text);
                string sex = cbSex.SelectedItem.ToString();
                int enclosure = int.Parse(cbEnclosure.SelectedItem.ToString());
                string species = cbSpecies.SelectedItem.ToString();

                string nextIdQuery = "SELECT NVL(MAX(aid), 0) + 1 FROM " + DatabaseHelper.Table("Animal");
                int newAid = Convert.ToInt32(DatabaseHelper.ExecuteQuery(nextIdQuery).Rows[0][0]);

                string insert = Queries.InsertAnimal;

                OracleParameter[] parameters = {
            new OracleParameter("aid", newAid),
            new OracleParameter("name", name),
            new OracleParameter("dob", dob),
            new OracleParameter("weight", weight),
            new OracleParameter("origin", origin),
            new OracleParameter("feeding", feeding),
            new OracleParameter("sex", sex),
            new OracleParameter("enclosure", enclosure),
            new OracleParameter("species", species)
        };

                DatabaseHelper.ExecuteNonQuery(insert, parameters);
                MessageBox.Show("Animal added.");
                LoadAnimalList();
                cbSelectAnimal.SelectedIndex = cbSelectAnimal.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!isEditMode || editingAid == -1) return;

            try
            {
                string update = Queries.UpdateAnimal;

                OracleParameter[] parameters = {
            new OracleParameter("name", txtAnimalName.Text.Trim()),
            new OracleParameter("dob", dtpDOB.Value),
            new OracleParameter("weight", decimal.Parse(txtWeight.Text)),
            new OracleParameter("origin", txtOrigin.Text.Trim().ToUpper()),
            new OracleParameter("feeding", int.Parse(txtFeeding.Text)),
            new OracleParameter("sex", cbSex.SelectedItem.ToString()),
            new OracleParameter("enclosure", cbEnclosure.SelectedItem.ToString()),
            new OracleParameter("species", cbSpecies.SelectedItem.ToString()),
            new OracleParameter("aid", editingAid)
        };

                DatabaseHelper.ExecuteNonQuery(update, parameters);
                MessageBox.Show("Animal updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            if (!isEditMode || editingAid == -1) return;

            if (MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                string delete = Queries.DeleteAnimal;
                DatabaseHelper.ExecuteNonQuery(delete, new[] {
            new OracleParameter("aid", editingAid)
        });
                MessageBox.Show("Animal deleted.");
                LoadAnimalList();
                cbSelectAnimal.SelectedIndex = 0;
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Animal Form Cancel");
            this.Close();
        }
        private void cbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSpecies.SelectedIndex == 0 || cbSpecies.SelectedItem == null)
            {
                txtLatinName.Clear();
                txtCommonName.Clear();
                txtRequiredBiome.Clear();
                txtRelatedSpeciesGroup.Clear();

                btnUpdateSpecies.Enabled = false;
                btnDeleteSpecies.Enabled = false;
                return;
            }

            string selectedLatin = cbSpecies.SelectedItem.ToString();
            var dt = DatabaseHelper.ExecuteQuery(Queries.SelectSpeciesByLatinName, new[] {
        new OracleParameter("name", selectedLatin)
    });

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                txtLatinName.Text = row["latinName"].ToString();
                txtCommonName.Text = row["commonName"].ToString();
                txtRequiredBiome.Text = row["requiredBiome"].ToString();
                txtRelatedSpeciesGroup.Text = row["speciesGroup"].ToString();

                btnUpdateSpecies.Enabled = true;
                btnDeleteSpecies.Enabled = true;
            }
        }

        private void btnAddSpecies_Click(object sender, EventArgs e)
        {
            try
            {
                string insert = Queries.InsertSpecies;

                OracleParameter[] parameters = {
            new OracleParameter("latin", txtLatinName.Text.Trim()),
            new OracleParameter("common", txtCommonName.Text.Trim()),
            new OracleParameter("biome", txtRequiredBiome.Text.Trim()),
            new OracleParameter("group", txtRelatedSpeciesGroup.Text.Trim())
        };

                DatabaseHelper.ExecuteNonQuery(insert, parameters);
                MessageBox.Show("Species added.");
                LoadSpeciesDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add species failed: " + ex.Message);
            }
        }

        private void btnUpdateSpecies_Click(object sender, EventArgs e)
        {
            try
            {
                string update = Queries.UpdateSpecies;

                OracleParameter[] parameters = {
            new OracleParameter("common", txtCommonName.Text.Trim()),
            new OracleParameter("biome", txtRequiredBiome.Text.Trim()),
            new OracleParameter("group", txtRelatedSpeciesGroup.Text.Trim()),
            new OracleParameter("latin", txtLatinName.Text.Trim())
        };

                DatabaseHelper.ExecuteNonQuery(update, parameters);
                MessageBox.Show("Species updated.");
                LoadSpeciesDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update species failed: " + ex.Message);
            }
        }

        private void btnDeleteSpecies_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = Queries.DeleteSpecies;
                DatabaseHelper.ExecuteNonQuery(delete, new[] {
            new OracleParameter("latin", txtLatinName.Text.Trim())
        });
                MessageBox.Show("Species deleted.");
                LoadSpeciesDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete species failed: " + ex.Message);
            }
        }

        private void cbSpeciesGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSpeciesGroup.SelectedIndex == 0 || cbSpeciesGroup.SelectedItem == null)
            {
                txtGroupLatin.Clear();
                txtGroupCommon.Clear();

                btnUpdateSpeciesGroup.Enabled = false;
                btnDeleteSpeciesGroup.Enabled = false;
                return;
            }

            string selectedLatin = cbSpeciesGroup.SelectedItem.ToString();
            var dt = DatabaseHelper.ExecuteQuery(Queries.SelectSpeciesGroupByLatinName, new[] {
        new OracleParameter("name", selectedLatin)
    });

            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                txtGroupLatin.Text = row["latinName"].ToString();
                txtGroupCommon.Text = row["commonName"].ToString();

                btnUpdateSpeciesGroup.Enabled = true;
                btnDeleteSpeciesGroup.Enabled = true;
            }
        }

        private void btnAddSpeciesGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string insert = Queries.InsertSpeciesGroup;
                DatabaseHelper.ExecuteNonQuery(insert, new[] {
            new OracleParameter("latin", txtGroupLatin.Text.Trim()),
            new OracleParameter("common", txtGroupCommon.Text.Trim())
        });
                MessageBox.Show("Group added.");
                LoadSpeciesGroupDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add group failed: " + ex.Message);
            }
        }

        private void btnUpdateSpeciesGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string update = Queries.UpdateSpeciesGroup;
                DatabaseHelper.ExecuteNonQuery(update, new[] {
            new OracleParameter("common", txtGroupCommon.Text.Trim()),
            new OracleParameter("latin", txtGroupLatin.Text.Trim())
        });
                MessageBox.Show("Group updated.");
                LoadSpeciesGroupDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update group failed: " + ex.Message);
            }
        }

        private void btnDeleteSpeciesGroup_Click(object sender, EventArgs e)
        {
            try
            {
                string delete = Queries.DeleteSpeciesGroup;
                DatabaseHelper.ExecuteNonQuery(delete, new[] {
            new OracleParameter("latin", txtGroupLatin.Text.Trim())
        });
                MessageBox.Show("Group deleted.");
                LoadSpeciesGroupDropdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete group failed: " + ex.Message);
            }
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }
    }
}


