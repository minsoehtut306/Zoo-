using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ZooApp
{
    public partial class FeedForm : Form
    {
        // Constants that provide the min and max for what an animal could be fed
        private const decimal MIN = 0.01M;
        private const decimal MAX = 99999.99M;
        // The aIDs of the animals to be fed
        private int[] aids;
        private int sid;
        // Boolean to allow nuds to change each other
        private Boolean isFirstChange;


        /// <summary>
        /// Constructor for the feed form.
        /// </summary>
        /// <param name="a">Array of int Animal IDs</param>
        /// <param name="s">int Staff ID</param>
        public FeedForm(int[] a, int s)
        {
            isFirstChange = true;
            aids = a;
            sid = s;
            InitializeComponent();
        }

        private void FeedForm_Load(object sender, EventArgs e)
        {
            int length = aids.Length;
            labelTitle.Text = $"Feeding {length} Animals";

            // M for deciMal
            // Set the min/max for numeric up downs
            numericUpDownPerAnimal.Minimum = MIN;
            numericUpDownPerAnimal.Maximum = MAX;
            numericUpDownTotalAmount.Minimum = MIN * length;

            // ENSURE that the max does not exceed the decimal max (it shouldn't)
            decimal maxTotal;
            try
            {
                maxTotal = MAX * length;
            }
            catch (Exception ex)
            {
                maxTotal = Decimal.MaxValue;
            }

            numericUpDownTotalAmount.Maximum = maxTotal;

            // Set initial value
            numericUpDownPerAnimal.Value = 1M;
        }

        private void numericUpDownPerAnimal_ValueChanged(object sender, EventArgs e)
        {
            if (isFirstChange)
            {
                isFirstChange = false;
                numericUpDownTotalAmount.Value = numericUpDownPerAnimal.Value * aids.Length;
            }
            isFirstChange = true;
        }

        private void numericUpDownTotalAmount_ValueChanged(object sender, EventArgs e)
        {
            if (isFirstChange)
            {
                isFirstChange = false;
                numericUpDownPerAnimal.Value = numericUpDownTotalAmount.Value / aids.Length;
            }
            isFirstChange = true;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            // Check for errors in the string
            String foodType = textBoxFoodType.Text;
            if (!foodType.All(Char.IsLetter))
            {
                MessageBox.Show("Please enter only letters to the food type!");
                textBoxFoodType.Clear();
                return;
            }
            else if (foodType == "")
            {
                MessageBox.Show("Please enter a food type.");
                return;
            }
            else if (foodType.Length > 30)
            {
                MessageBox.Show("Food type can only be 30 characters long!");
                textBoxFoodType.Clear();
                return;
            }

            decimal foodAmount = numericUpDownPerAnimal.Value;

            // Now we can make and execute the query.
            String queryStart = $"INSERT INTO {DatabaseHelper.Table("FEED")} VALUES ";

            OracleParameter[] parameters = new OracleParameter[] {
                new OracleParameter("food", OracleDbType.Varchar2, foodType, ParameterDirection.Input)
            };

            // Add an insert for each animal id
            
            for (int i = 0; i < aids.Length; i++)
            {
                String query = queryStart + $"({sid}, {aids[i]}, CURRENT_TIMESTAMP, {foodAmount}, ':food')";
                try
                {
                    DatabaseHelper.ExecuteNonQuery(query);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error with inputting feeding, please try again");
                    this.Close();
                }
            }

            MessageBox.Show("Successfully recorded feeding!");

            // And relinquish control back to the main form
            this.Close();
        }
    }
}
