using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooApp
{
    /// <summary>
    /// A Form that takes a DataTable, and a name, and displays a "report" based off of these inputs
    /// </summary>
    public partial class Report : Form
    {
        // Save the argument DataTable, so that it can be viewed
        private DataTable reportDt;
        private string reportName;

        /// <summary>
        /// Constructor for a Report Form.
        /// </summary>
        /// <param name="dt">The DataTable to display in the report.</param>
        /// <param name="nameOfReport">The name of the report.</param>
        public Report(DataTable dt, String nameOfReport)
        {
            InitializeComponent();
            this.Text = nameOfReport;
            label_reportDescriptor.Text = nameOfReport;
            reportDt = dt;
            reportName = nameOfReport;
            // Hopefully this isn't too big of a data source.
            dataGridView_report.DataSource = reportDt;
            dataGridView_report.AutoGenerateColumns = true;
        }

        /// <summary>
        /// A method to save the current report in a File on the system.
        /// https://stackoverflow.com/a/66635774 -- used in file writing code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_saveReport_Click(object sender, EventArgs e)
        {
            // Configure the save dialog
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save the report file";
            dialog.Filter = "Text (*.txt)|*.txt";
            dialog.ShowDialog();

            if(dialog.FileName != "")
            {
                using (StreamWriter file = new StreamWriter(dialog.FileName))
                {
                    // First write out the column names / report name, then write out the data
                    file.WriteLine(reportName);
                    file.WriteLine("");
                    string line = "";
                    for (int i = 0; i < dataGridView_report.Columns.Count; i++)
                    {
                        // cIndex = i
                        line += dataGridView_report.Columns[i].Name + "\t" + "|";
                    }
                    file.WriteLine(line);

                    for (int i = 0; i < dataGridView_report.Rows.Count - 1; i++)
                    {
                        line = "";
                        for (int j = 0; j < dataGridView_report.Columns.Count; j++)
                        {
                            line += dataGridView_report.Rows[i].Cells[j].Value.ToString() + "\t" + "|";
                        }
                        file.WriteLine(line);
                        file.WriteLine("");
                    }
                }
                MessageBox.Show("Report saved to " + dialog.FileName);
            }
        }
    }
}
