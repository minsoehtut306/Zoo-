using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class AddZookeeperForm : Form
    {
        private int? currentSid;

        public AddZookeeperForm()
        {
            InitializeComponent();
        }

        public AddZookeeperForm(int sid)
        {
            InitializeComponent();
            currentSid = sid;
        }

        private void AddZookeeperForm_Load(object sender, EventArgs e)
        {
            LoadZookeeperList();
            LoadGroupList();

            if (currentSid.HasValue)
            {
                foreach (ComboBoxItem item in cbSelectZookeeper.Items)
                {
                    if (item.Value == currentSid.Value.ToString())
                    {
                        cbSelectZookeeper.SelectedItem = item;
                        cbSelectZookeeper.Enabled = false;
                        cbSelectZookeeper_SelectedIndexChanged(null, null);
                        break;
                    }
                }
            }
        }

        private void LoadZookeeperList()
        {
            DataTable keepers = DatabaseHelper.ExecuteQuery(Queries.SelectAllZookeepers);

            cbSelectZookeeper.Items.Clear();
            foreach (DataRow row in keepers.Rows)
            {
                cbSelectZookeeper.Items.Add(new ComboBoxItem(
                    row["fullName"].ToString(),
                    row["sid"].ToString()
                ));
            }

            cbSelectZookeeper.SelectedIndex = -1;
        }

        private void LoadGroupList()
        {
            DataTable groups = DatabaseHelper.ExecuteQuery(Queries.SelectAllSpeciesGroupNames);

            clbGroups.Items.Clear();
            foreach (DataRow row in groups.Rows)
            {
                clbGroups.Items.Add(row["commonName"].ToString());
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!(cbSelectZookeeper.SelectedItem is ComboBoxItem selectedKeeper))
            {
                MessageBox.Show("Please select a zookeeper.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int sid = int.Parse(selectedKeeper.Value);

            // Step 1: Delete current group assignments
            OracleParameter[] deleteParam = { new OracleParameter("sid", sid) };
            DatabaseHelper.ExecuteNonQuery(Queries.DeleteZookeeperAssignments, deleteParam);

            // Step 2: Re-insert the checked groups
            foreach (var item in clbGroups.CheckedItems)
            {
                if (item is ComboBoxItem group)
                {
                    OracleParameter[] insertParams = {
                new OracleParameter("grp", group.Value),
                new OracleParameter("sid", sid)
            };
                    DatabaseHelper.ExecuteNonQuery(Queries.InsertZookeeperAssignment, insertParams);
                }
            }

            MessageBox.Show("Zookeeper assignments updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSelectZookeeper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbSelectZookeeper.SelectedItem is ComboBoxItem selectedKeeper))
                return;

            int sid = int.Parse(selectedKeeper.Value);

            // Reload all groups first
            clbGroups.Items.Clear();
            DataTable allGroups = DatabaseHelper.ExecuteQuery(Queries.SelectAllSpeciesGroups);
            foreach (DataRow row in allGroups.Rows)
            {
                clbGroups.Items.Add(new ComboBoxItem(row["commonName"].ToString(), row["latinName"].ToString()), false);
            }

            // Load assigned species groups for this keeper
            OracleParameter[] param = { new OracleParameter("sid", sid) };
            DataTable assignedGroups = DatabaseHelper.ExecuteQuery(Queries.SelectAssignedGroupsByStaff, param);

            // Tick the assigned groups
            for (int i = 0; i < clbGroups.Items.Count; i++)
            {
                if (clbGroups.Items[i] is ComboBoxItem item)
                {
                    bool isAssigned = assignedGroups.AsEnumerable()
                        .Any(r => r["sGroupName"].ToString() == item.Value);
                    clbGroups.SetItemChecked(i, isAssigned);
                }
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