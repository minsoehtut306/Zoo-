using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class SelectZoneForm : Form
    {
        public string SelectedZoneName { get; private set; }

        public SelectZoneForm()
        {
            InitializeComponent();
        }

        private void SelectZoneForm_Load(object sender, EventArgs e)
        {
            LoadZones();
        }

        private void LoadZones()
        {
            try
            {
                string query = "SELECT name, colour, hexcode FROM m2s_zone ORDER BY name";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                lstZones.DataSource = dt;
                lstZones.DisplayMember = "name";
                lstZones.ValueMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load zones: " + ex.Message);
            }
        }
        private void btnAddZone_Click(object sender, EventArgs e)
        {
            using (var form = new AddZoneForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadZones(); // Refresh zone list
                }
            }
        }

        private void btnEditZone_Click(object sender, EventArgs e)
        {
            if (lstZones.SelectedItem is DataRowView row)
            {
                string zoneName = row["name"].ToString();
                using (var form = new AddZoneForm(zoneName))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadZones(); // Refresh zone list
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a zone to edit.");
            }
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (lstZones.SelectedItem is DataRowView row)
            {
                SelectedZoneName = row["name"].ToString();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please select a zone.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
