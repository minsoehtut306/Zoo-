namespace ZooApp
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_report = new System.Windows.Forms.DataGridView();
            this.label_reportDescriptor = new System.Windows.Forms.Label();
            this.button_saveReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_report)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_report
            // 
            this.dataGridView_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_report.Location = new System.Drawing.Point(12, 60);
            this.dataGridView_report.Name = "dataGridView_report";
            this.dataGridView_report.Size = new System.Drawing.Size(304, 404);
            this.dataGridView_report.TabIndex = 0;
            // 
            // label_reportDescriptor
            // 
            this.label_reportDescriptor.AutoSize = true;
            this.label_reportDescriptor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_reportDescriptor.Location = new System.Drawing.Point(12, 9);
            this.label_reportDescriptor.Name = "label_reportDescriptor";
            this.label_reportDescriptor.Size = new System.Drawing.Size(108, 16);
            this.label_reportDescriptor.TabIndex = 1;
            this.label_reportDescriptor.Text = "Title Of Report";
            // 
            // button_saveReport
            // 
            this.button_saveReport.Location = new System.Drawing.Point(242, 31);
            this.button_saveReport.Name = "button_saveReport";
            this.button_saveReport.Size = new System.Drawing.Size(75, 23);
            this.button_saveReport.TabIndex = 2;
            this.button_saveReport.Text = "Save Report";
            this.button_saveReport.UseVisualStyleBackColor = true;
            this.button_saveReport.Click += new System.EventHandler(this.button_saveReport_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 477);
            this.Controls.Add(this.button_saveReport);
            this.Controls.Add(this.label_reportDescriptor);
            this.Controls.Add(this.dataGridView_report);
            this.Name = "Report";
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_report;
        private System.Windows.Forms.Label label_reportDescriptor;
        private System.Windows.Forms.Button button_saveReport;
    }
}