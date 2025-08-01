using System;
using System.Windows.Forms;

namespace ZooApp
{
    public partial class AddAnimalForm : Form
    {
        public AddAnimalForm()
        {
            InitializeComponent();
        }

        private void AddAnimalForm_Load(object sender, EventArgs e)
        {
            // Populate combo boxes (e.g., cbSex, cbEnclosure, cbSpecies) if needed
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // TODO: Handle submit logic
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Load selected species details into fields (common name, latin, biome)
        }

        private void btnEditSpecies_Click(object sender, EventArgs e)
        {
            // TODO: Enable editing of species fields
        }

        private void btnUpdateSpecies_Click(object sender, EventArgs e)
        {
            // TODO: Save changes to selected species
        }

        private void btnNewSpecies_Click(object sender, EventArgs e)
        {
            // TODO: Clear species fields for new entry
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            // TODO: Enable editing of group fields
        }

        private void btnUpdateGroup_Click(object sender, EventArgs e)
        {
            // TODO: Save changes to selected group
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            // TODO: Clear group fields for new entry
        }
    }
}
