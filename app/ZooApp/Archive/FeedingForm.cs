using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class FeedingForm : Form
    {
        public FeedingForm()
        {
            InitializeComponent();
        }

        private void FeedingForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Load animals
                string animalQuery = $"SELECT aid, name FROM {DatabaseHelper.Table("ANIMAL")} ORDER BY name";
                DataTable animalTable = DatabaseHelper.ExecuteQuery(animalQuery);
                cbAnimal.DisplayMember = "name";
                cbAnimal.ValueMember = "aid";
                cbAnimal.DataSource = animalTable;

                // Load staff
                string staffQuery = $"SELECT sid, fName || ' ' || lName AS fullName FROM {DatabaseHelper.Table("STAFF")} ORDER BY fName";
                DataTable staffTable = DatabaseHelper.ExecuteQuery(staffQuery);
                cbStaff.DisplayMember = "fullName";
                cbStaff.ValueMember = "sid";
                cbStaff.DataSource = staffTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int animalId = Convert.ToInt32(cbAnimal.SelectedValue);
                int staffId = Convert.ToInt32(cbStaff.SelectedValue);
                DateTime dateTime = dtpDate.Value;
                decimal amount = decimal.Parse(txtAmount.Text);
                string foodType = txtFood.Text.Trim();

                string query = $"INSERT INTO {DatabaseHelper.Table("FEED")} (animalId, staffId, dateTime, amount, foodType) " +
                               "VALUES (:animalId, :staffId, :dateTime, :amount, :foodType)";

                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("animalId", animalId),
                    new OracleParameter("staffId", staffId),
                    new OracleParameter("dateTime", dateTime),
                    new OracleParameter("amount", amount),
                    new OracleParameter("foodType", foodType)
                };

                DatabaseHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Feeding record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving feeding record: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FeedingForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
