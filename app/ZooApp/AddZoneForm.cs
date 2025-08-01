using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class AddZoneForm : Form
    {
        private readonly string editingZoneName = null;

        public AddZoneForm(string zoneNameToEdit = null)
        {
            InitializeComponent();
            editingZoneName = zoneNameToEdit;
        }

        private void AddZoneForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(editingZoneName))
            {
                this.Text = "Edit Zone";
                btnSubmit.Text = "Update";
                txtName.Enabled = false;
                LoadZoneData();
            }
            else
            {
                this.Text = "Add Zone";
                btnSubmit.Text = "Add";
            }
        }

        private void LoadZoneData()
        {
            string query = "SELECT * FROM m2s_zone WHERE name = :name";
            var param = new OracleParameter[] { new OracleParameter("name", editingZoneName) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, param);

            if (dt.Rows.Count == 1)
            {
                var row = dt.Rows[0];
                txtName.Text = row["name"].ToString();
                txtColour.Text = row["colour"].ToString();
                txtHexcode.Text = row["hexcode"].ToString();
            }
            else
            {
                MessageBox.Show("Zone not found.");
                this.Close();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string colour = txtColour.Text.Trim();
            string hex = txtHexcode.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(colour) || string.IsNullOrEmpty(hex))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (!Regex.IsMatch(hex, @"^[0-9A-Fa-f]{6}$"))
            {
                MessageBox.Show("Hex code must be 6 hexadecimal characters (e.g., FFCC00).");
                return;
            }

            try
            {
                if (editingZoneName != null)
                {
                    string update = "UPDATE m2s_zone SET colour = :colour, hexcode = :hexcode WHERE name = :name";
                    var parameters = new OracleParameter[]
                    {
                        new OracleParameter("colour", colour),
                        new OracleParameter("hexcode", hex),
                        new OracleParameter("name", name)
                    };
                    DatabaseHelper.ExecuteNonQuery(update, parameters);
                    MessageBox.Show("Zone updated.");
                }
                else
                {
                    string insert = "INSERT INTO m2s_zone (name, colour, hexcode) VALUES (:name, :colour, :hexcode)";
                    var parameters = new OracleParameter[]
                    {
                        new OracleParameter("name", name),
                        new OracleParameter("colour", colour),
                        new OracleParameter("hexcode", hex)
                    };
                    DatabaseHelper.ExecuteNonQuery(insert, parameters);
                    MessageBox.Show("Zone added.");
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
