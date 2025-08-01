using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ZooApp
{
    public partial class VetForm : Form
    {
        public VetForm()
        {
            InitializeComponent();
        }

        private void VetForm_Load(object sender, EventArgs e)
        {
            LoadAnimals();
            LoadStaff();
        }

        private void LoadAnimals()
        {
            string query = $"SELECT aid, name FROM {DatabaseHelper.Table("ANIMAL")}";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cbAnimal.DisplayMember = "name";
            cbAnimal.ValueMember = "aid";
            cbAnimal.DataSource = dt;
        }

        private void LoadStaff()
        {
            string query = $"SELECT sid, fName || ' ' || lName AS FullName FROM {DatabaseHelper.Table("STAFF")}";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cbVet.DisplayMember = "FullName";
            cbVet.ValueMember = "sid";
            cbVet.DataSource = dt;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int animalId = Convert.ToInt32(cbAnimal.SelectedValue);
                int staffId = Convert.ToInt32(cbVet.SelectedValue);
                DateTime careTime = dtpTime.Value;
                string careType = txtCareType.Text.Trim();
                string notes = txtNotes.Text.Trim();

                if (string.IsNullOrWhiteSpace(careType))
                {
                    MessageBox.Show("Care type is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = $"INSERT INTO {DatabaseHelper.Table("CARE")} (animalID, staffID, datetime, care, notes) " +
                               "VALUES (:animalID, :staffID, :datetime, :care, :notes)";

                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("animalID", animalId),
                    new OracleParameter("staffID", staffId),
                    new OracleParameter("datetime", careTime),
                    new OracleParameter("care", careType),
                    new OracleParameter("notes", notes)
                };

                DatabaseHelper.ExecuteNonQuery(query, parameters);

                MessageBox.Show("Care record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
