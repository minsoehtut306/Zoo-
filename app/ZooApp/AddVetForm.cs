using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class AddVetForm : Form
    {
        private int? currentSid;

        public AddVetForm()
        {
            InitializeComponent();
            currentSid = null;
        }

        public AddVetForm(int sid)
        {
            InitializeComponent();
            currentSid = sid;
        }

        private void AddVetForm_Load(object sender, EventArgs e)
        {
            LoadVetList();
            LoadClinicList();

            if (currentSid.HasValue)
            {
                foreach (ComboBoxItem item in cbSelectVet.Items)
                {
                    if (item.Value == currentSid.Value.ToString())
                    {
                        cbSelectVet.SelectedItem = item;
                        break;
                    }
                }
                cbSelectVet.Enabled = false;
                SetCurrentClinic(currentSid.Value);
            }

            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void LoadVetList()
        {
            OracleParameter[] param = { new OracleParameter("sid", currentSid ?? -1) };
            DataTable vets = DatabaseHelper.ExecuteQuery(Queries.SelectAllVets, param);

            cbSelectVet.Items.Clear();
            foreach (DataRow row in vets.Rows)
            {
                cbSelectVet.Items.Add(new ComboBoxItem(row["fullName"].ToString(), row["sid"].ToString()));
            }

            cbSelectVet.SelectedIndexChanged += cbSelectVet_SelectedIndexChanged;
        }

        private void LoadClinicList()
        {
            cbClinics.Items.Clear();
            cbClinics.Items.Add("Add New Clinic");

            DataTable clinics = DatabaseHelper.ExecuteQuery(Queries.SelectDistinctClinics);

            foreach (DataRow row in clinics.Rows)
            {
                cbClinics.Items.Add(row["clinic"].ToString());
            }

            cbClinics.SelectedIndex = 0;
        }

        private void SetCurrentClinic(int sid)
        {
            OracleParameter[] param = { new OracleParameter("sid", sid) };
            DataTable result = DatabaseHelper.ExecuteQuery(Queries.SelectClinicBySid, param);

            txtCurrentClinic.Text = (result.Rows.Count > 0 && result.Rows[0]["clinic"] != DBNull.Value)
                ? result.Rows[0]["clinic"].ToString()
                : "None";
        }

        private void cbSelectVet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectVet.SelectedItem is ComboBoxItem selectedVet)
            {
                SetCurrentClinic(int.Parse(selectedVet.Value));
                cbClinics.SelectedIndex = 0;
                btnAdd.Enabled = true;
            }
        }

        private void cbClinics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClinics.SelectedIndex == 0)
            {
                txtClinicName.Clear();
                btnAdd.Enabled = cbSelectVet.SelectedItem != null;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                txtClinicName.Text = cbClinics.SelectedItem.ToString();
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!(cbSelectVet.SelectedItem is ComboBoxItem selectedVet))
            {
                MessageBox.Show("Please select a vet before adding a clinic.");
                return;
            }

            string newClinic = txtClinicName.Text.Trim();
            if (string.IsNullOrWhiteSpace(newClinic))
            {
                MessageBox.Show("Please enter a clinic name.");
                return;
            }

            OracleParameter[] checkParams = { new OracleParameter("clinic", newClinic) };
            if (DatabaseHelper.ExecuteQuery(Queries.CheckClinicExists, checkParams).Rows.Count > 0)
            {
                MessageBox.Show("Clinic already exists.");
                return;
            }

            OracleParameter[] assignParams = {
        new OracleParameter("clinic", newClinic),
        new OracleParameter("sid", int.Parse(selectedVet.Value))
    };

            DatabaseHelper.ExecuteNonQuery(Queries.AssignClinicToStaff, assignParams);
            MessageBox.Show("New clinic added and assigned.");
            txtClinicName.Clear();
            LoadClinicList();
            SetCurrentClinic(int.Parse(selectedVet.Value));
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cbSelectVet.SelectedItem is ComboBoxItem vet &&
                cbClinics.SelectedItem is string selectedClinic &&
                cbClinics.SelectedIndex != 0)
            {
                OracleParameter[] parameters = {
            new OracleParameter("clinic", selectedClinic),
            new OracleParameter("sid", int.Parse(vet.Value))
        };

                DatabaseHelper.ExecuteNonQuery(Queries.AssignClinicToStaff, parameters);
                MessageBox.Show("Clinic assigned to vet.");
                LoadClinicList();
                SetCurrentClinic(int.Parse(vet.Value));
            }
            else
            {
                MessageBox.Show("Please select a vet and a clinic.");
            }

            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbClinics.SelectedItem == null || cbClinics.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an existing clinic to update.");
                return;
            }

            string oldClinic = cbClinics.SelectedItem.ToString();
            string newClinic = txtClinicName.Text.Trim();

            if (string.IsNullOrWhiteSpace(newClinic))
            {
                MessageBox.Show("Enter a new clinic name.");
                return;
            }

            OracleParameter[] parameters = {
        new OracleParameter("new", newClinic),
        new OracleParameter("old", oldClinic)
    };

            DatabaseHelper.ExecuteNonQuery(Queries.UpdateClinicName, parameters);
            MessageBox.Show("Clinic updated.");
            txtClinicName.Clear();
            LoadClinicList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbClinics.SelectedItem == null || cbClinics.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an existing clinic to delete.");
                return;
            }

            var confirm = MessageBox.Show("This will remove the clinic assignment from all vets. Continue?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            string clinic = cbClinics.SelectedItem.ToString();
            OracleParameter[] parameters = { new OracleParameter("clinic", clinic) };

            DatabaseHelper.ExecuteNonQuery(Queries.DeleteClinic, parameters);
            MessageBox.Show("Clinic deleted.");
            txtClinicName.Clear();
            LoadClinicList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

            public override string ToString()
            {
                return Text;
            }
        }
    }
}

