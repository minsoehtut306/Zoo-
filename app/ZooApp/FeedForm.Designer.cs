namespace ZooApp
{
    partial class FeedForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTotalAmount = new System.Windows.Forms.Label();
            this.labelPerAnimal = new System.Windows.Forms.Label();
            this.labelFoodType = new System.Windows.Forms.Label();
            this.numericUpDownPerAnimal = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTotalAmount = new System.Windows.Forms.NumericUpDown();
            this.textBoxFoodType = new System.Windows.Forms.TextBox();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.panelLink = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerAnimal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 24);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Feeding X Animals";
            // 
            // labelTotalAmount
            // 
            this.labelTotalAmount.AutoSize = true;
            this.labelTotalAmount.Location = new System.Drawing.Point(13, 83);
            this.labelTotalAmount.Name = "labelTotalAmount";
            this.labelTotalAmount.Size = new System.Drawing.Size(73, 13);
            this.labelTotalAmount.TabIndex = 1;
            this.labelTotalAmount.Text = "Total Amount:";
            // 
            // labelPerAnimal
            // 
            this.labelPerAnimal.AutoSize = true;
            this.labelPerAnimal.Location = new System.Drawing.Point(13, 57);
            this.labelPerAnimal.Name = "labelPerAnimal";
            this.labelPerAnimal.Size = new System.Drawing.Size(60, 13);
            this.labelPerAnimal.TabIndex = 2;
            this.labelPerAnimal.Text = "Per Animal:";
            // 
            // labelFoodType
            // 
            this.labelFoodType.AutoSize = true;
            this.labelFoodType.Location = new System.Drawing.Point(13, 109);
            this.labelFoodType.Name = "labelFoodType";
            this.labelFoodType.Size = new System.Drawing.Size(61, 13);
            this.labelFoodType.TabIndex = 3;
            this.labelFoodType.Text = "Food Type:";
            // 
            // numericUpDownPerAnimal
            // 
            this.numericUpDownPerAnimal.DecimalPlaces = 2;
            this.numericUpDownPerAnimal.Location = new System.Drawing.Point(102, 50);
            this.numericUpDownPerAnimal.Name = "numericUpDownPerAnimal";
            this.numericUpDownPerAnimal.Size = new System.Drawing.Size(99, 20);
            this.numericUpDownPerAnimal.TabIndex = 4;
            this.numericUpDownPerAnimal.ValueChanged += new System.EventHandler(this.numericUpDownPerAnimal_ValueChanged);
            // 
            // numericUpDownTotalAmount
            // 
            this.numericUpDownTotalAmount.DecimalPlaces = 2;
            this.numericUpDownTotalAmount.Location = new System.Drawing.Point(102, 76);
            this.numericUpDownTotalAmount.Name = "numericUpDownTotalAmount";
            this.numericUpDownTotalAmount.Size = new System.Drawing.Size(99, 20);
            this.numericUpDownTotalAmount.TabIndex = 5;
            this.numericUpDownTotalAmount.ValueChanged += new System.EventHandler(this.numericUpDownTotalAmount_ValueChanged);
            // 
            // textBoxFoodType
            // 
            this.textBoxFoodType.Location = new System.Drawing.Point(102, 102);
            this.textBoxFoodType.Name = "textBoxFoodType";
            this.textBoxFoodType.Size = new System.Drawing.Size(99, 20);
            this.textBoxFoodType.TabIndex = 6;
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(102, 138);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(75, 23);
            this.buttonEnter.TabIndex = 7;
            this.buttonEnter.Text = "Enter";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // panelLink
            // 
            this.panelLink.Location = new System.Drawing.Point(125, 57);
            this.panelLink.Name = "panelLink";
            this.panelLink.Size = new System.Drawing.Size(52, 28);
            this.panelLink.TabIndex = 8;
            // 
            // FeedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 171);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.textBoxFoodType);
            this.Controls.Add(this.numericUpDownTotalAmount);
            this.Controls.Add(this.numericUpDownPerAnimal);
            this.Controls.Add(this.labelFoodType);
            this.Controls.Add(this.labelPerAnimal);
            this.Controls.Add(this.labelTotalAmount);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelLink);
            this.Name = "FeedForm";
            this.Text = "Feed";
            this.Load += new System.EventHandler(this.FeedForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerAnimal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTotalAmount;
        private System.Windows.Forms.Label labelPerAnimal;
        private System.Windows.Forms.Label labelFoodType;
        private System.Windows.Forms.NumericUpDown numericUpDownPerAnimal;
        private System.Windows.Forms.NumericUpDown numericUpDownTotalAmount;
        private System.Windows.Forms.TextBox textBoxFoodType;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Panel panelLink;
    }
}