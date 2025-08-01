using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class AddStaffForm : Form
    {
        private bool isEditMode = false;
        private int editingSid = -1;

        public AddStaffForm(int sid)
        {
            InitializeComponent();
            isEditMode = true;
            editingSid = sid;
            LoadStaffById(sid);
            btnAdd.Text = "Update";
        }

        public AddStaffForm()
        {
            InitializeComponent();
        }

        private void AddStaffForm_Load(object sender, EventArgs e)
        {
            cbSex.Items.Clear();
            cbSex.Items.AddRange(new object[] { "Male", "Female" });
            cbSex.SelectedIndex = 0;

            cbRole.Items.Clear();
            cbRole.Items.AddRange(new object[] { "Zookeeper", "Vet" });
            cbRole.SelectedIndex = 0;

            txtPostCode.MaxLength = 4;

            LoadStaffComboBox();

            this.Text = "Manage Staff";

            btnAdd.Enabled = true;
            butUpdate.Enabled = false;
        }

        private void LoadStaffComboBox()
        {
            cbSelectStaff.Items.Clear();
            cbSelectStaff.Items.Add("Add New Staff");

            DataTable staffList = DatabaseHelper.ExecuteQuery(Queries.SelectAllStaffBasic);

            foreach (DataRow row in staffList.Rows)
            {
                string display = $"{row["sid"]} - {row["fName"]} {row["lName"]}";
                cbSelectStaff.Items.Add(new ComboBoxItem(display, row["sid"].ToString()));
            }

            cbSelectStaff.SelectedIndex = 0;
        }

        private void cbSelectStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectStaff.SelectedIndex == 0)
            {
                ClearForm();
                isEditMode = false;
                editingSid = -1;
                btnAdd.Enabled = true;
                butUpdate.Enabled = false;
            }
            else
            {
                var selected = (ComboBoxItem)cbSelectStaff.SelectedItem;
                int sid = int.Parse(selected.Value);
                LoadStaffById(sid);
                isEditMode = true;
                editingSid = sid;
                btnAdd.Enabled = false;
                butUpdate.Enabled = true;
            }
        }

        private void ClearForm()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox) ((TextBox)c).Clear();
            }
            cbSex.SelectedIndex = 0;
            cbRole.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Today;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = txtFirstName.Text.Trim();
                string lname = txtLastName.Text.Trim();
                DateTime dob = dtpDOB.Value;
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                string sex = cbSex.SelectedItem?.ToString() == "Male" ? "M" : "F";
                string role = cbRole.SelectedItem?.ToString();

                if (!int.TryParse(txtStreetNumber.Text, out int streetNumber))
                    throw new Exception("Invalid street number");

                string streetName = txtStreetName.Text.Trim();
                string suburb = txtSuburb.Text.Trim();
                string city = txtCity.Text.Trim();
                string postCode = txtPostCode.Text.Trim();

                if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname) ||
                    string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(role))
                {
                    MessageBox.Show("All required fields must be filled.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (postCode.Length > 4)
                {
                    MessageBox.Show("Postcode must be 4 characters or fewer.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int newSid = Convert.ToInt32(DatabaseHelper.ExecuteQuery(Queries.GetNextStaffId).Rows[0][0]);

                OracleParameter[] insertParams = {
            new OracleParameter("sid", newSid),
            new OracleParameter("fName", fname),
            new OracleParameter("lName", lname),
            new OracleParameter("dob", dob),
            new OracleParameter("phNumber", phone),
            new OracleParameter("email", email),
            new OracleParameter("streetNumber", streetNumber),
            new OracleParameter("streetName", streetName),
            new OracleParameter("suburb", suburb),
            new OracleParameter("city", city),
            new OracleParameter("postCode", postCode),
            new OracleParameter("sex", sex)
        };

                DatabaseHelper.ExecuteNonQuery(Queries.InsertStaff, insertParams);

                if (role == "Vet")
                {
                    DataTable existing = DatabaseHelper.ExecuteQuery(Queries.CheckVetCareExists, new[] {
                new OracleParameter("sid", newSid)
            });

                    if (existing.Rows.Count == 0)
                    {
                        OracleParameter[] dummyCareParams = {
                    new OracleParameter("sid", newSid),
                    new OracleParameter("aid", 1),
                    new OracleParameter("dt", new DateTime(2000, 1, 1)),
                    new OracleParameter("care", "Initial Vet Assignment"),
                    new OracleParameter("notes", "Auto-generated vet entry")
                };

                        DatabaseHelper.ExecuteNonQuery(Queries.InsertDummyCare, dummyCareParams);
                    }

                    new AddVetForm(newSid).ShowDialog();
                }
                else if (role == "Zookeeper")
                {
                    OracleParameter[] dummyZookeeperParams = {
                new OracleParameter("grp", "DummySpeciesGroup"),
                new OracleParameter("sid", newSid)
            };

                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(Queries.InsertDummyOversees, dummyZookeeperParams);
                    }
                    catch { }

                    new AddZookeeperForm(newSid).ShowDialog();
                }

                MessageBox.Show("Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (!isEditMode || editingSid == -1)
            {
                MessageBox.Show("No staff selected to update.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OracleParameter[] updateParams = {
            new OracleParameter("fName", txtFirstName.Text.Trim()),
            new OracleParameter("lName", txtLastName.Text.Trim()),
            new OracleParameter("dob", dtpDOB.Value),
            new OracleParameter("phNumber", txtPhone.Text.Trim()),
            new OracleParameter("email", txtEmail.Text.Trim()),
            new OracleParameter("streetNumber", int.Parse(txtStreetNumber.Text)),
            new OracleParameter("streetName", txtStreetName.Text.Trim()),
            new OracleParameter("suburb", txtSuburb.Text.Trim()),
            new OracleParameter("city", txtCity.Text.Trim()),
            new OracleParameter("postCode", txtPostCode.Text.Trim()),
            new OracleParameter("sex", cbSex.SelectedItem.ToString() == "Male" ? "M" : "F"),
            new OracleParameter("sid", editingSid)
        };

                DatabaseHelper.ExecuteNonQuery(Queries.UpdateStaff, updateParams);

                string role = cbRole.SelectedItem.ToString();
                if (role == "Vet")
                {
                    DataTable existing = DatabaseHelper.ExecuteQuery(Queries.CheckVetCareExists, new[] {
                new OracleParameter("sid", editingSid)
            });

                    if (existing.Rows.Count == 0)
                    {
                        OracleParameter[] dummyCareParams = {
                    new OracleParameter("sid", editingSid),
                    new OracleParameter("aid", 1),
                    new OracleParameter("dt", new DateTime(2000, 1, 1)),
                    new OracleParameter("care", "Initial Vet Assignment"),
                    new OracleParameter("notes", "Auto-generated vet record")
                };

                        DatabaseHelper.ExecuteNonQuery(Queries.InsertDummyCare, dummyCareParams);
                    }

                    new AddVetForm(editingSid).ShowDialog();
                }
                else if (role == "Zookeeper")
                {
                    DataTable exists = DatabaseHelper.ExecuteQuery(Queries.CheckOverseesExists, new[] {
                new OracleParameter("sid", editingSid)
            });

                    if (exists.Rows.Count == 0)
                    {
                        OracleParameter[] dummyParams = {
                    new OracleParameter("grp", "Apterygiformes"),
                    new OracleParameter("sid", editingSid)
                };

                        try
                        {
                            DatabaseHelper.ExecuteNonQuery(Queries.InsertDummyOversees, dummyParams);
                        }
                        catch { }
                    }

                    new AddZookeeperForm(editingSid).ShowDialog();
                }

                MessageBox.Show("Staff updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void butDelete_Click(object sender, EventArgs e)
        {
            if (!isEditMode || editingSid == -1)
            {
                MessageBox.Show("Please select a staff member to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Are you sure? This will remove all related vet/zookeeper records!", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                OracleParameter sidParam = new OracleParameter("sid", editingSid);

                DatabaseHelper.ExecuteNonQuery(Queries.DeleteCareByStaff, new[] { sidParam });
                DatabaseHelper.ExecuteNonQuery(Queries.DeleteFeedByStaff, new[] { sidParam });
                DatabaseHelper.ExecuteNonQuery(Queries.DeleteOverseesByStaff, new[] { sidParam });
                DatabaseHelper.ExecuteNonQuery(Queries.DeleteStaff, new[] { sidParam });

                MessageBox.Show("Staff deleted successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SelectStaffForm().ShowDialog();
            this.Close();
        }

        private void LoadStaffById(int sid)
        {
            DataTable result = DatabaseHelper.ExecuteQuery(Queries.SelectStaffById, new[] {
        new OracleParameter("sid", sid)
    });

            if (result.Rows.Count == 0) return;

            DataRow row = result.Rows[0];
            txtFirstName.Text = row["fName"].ToString();
            txtLastName.Text = row["lName"].ToString();
            dtpDOB.Value = Convert.ToDateTime(row["dob"]);
            txtPhone.Text = row["phNumber"].ToString();
            txtEmail.Text = row["email"].ToString();
            txtStreetNumber.Text = row["streetNumber"].ToString();
            txtStreetName.Text = row["streetName"].ToString();
            txtSuburb.Text = row["suburb"].ToString();
            txtCity.Text = row["city"].ToString();
            txtPostCode.Text = row["postCode"].ToString();
            cbSex.SelectedItem = row["sex"].ToString() == "M" ? "Male" : "Female";

            string role = "Unknown";
            if (DatabaseHelper.ExecuteQuery(Queries.CheckOverseesExists, new[] { new OracleParameter("sid", sid) }).Rows.Count > 0)
                role = "Zookeeper";
            else if (DatabaseHelper.ExecuteQuery(Queries.CheckVetCareExists, new[] { new OracleParameter("sid", sid) }).Rows.Count > 0)
                role = "Vet";

            cbRole.SelectedItem = role;
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


