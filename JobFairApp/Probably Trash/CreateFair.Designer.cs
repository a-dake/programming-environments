namespace JobFairApp.Forms
{
    partial class CreateFair
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
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cbVenueNames = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblSelectVenue = new System.Windows.Forms.Label();
            this.lblSelectStartDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lblAddaTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Location = new System.Drawing.Point(15, 69);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.DateTimePicker.TabIndex = 0;
            // 
            // cbVenueNames
            // 
            this.cbVenueNames.FormattingEnabled = true;
            this.cbVenueNames.Location = new System.Drawing.Point(15, 29);
            this.cbVenueNames.Name = "cbVenueNames";
            this.cbVenueNames.Size = new System.Drawing.Size(121, 21);
            this.cbVenueNames.TabIndex = 2;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(197, 226);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblSelectVenue
            // 
            this.lblSelectVenue.AutoSize = true;
            this.lblSelectVenue.Location = new System.Drawing.Point(12, 13);
            this.lblSelectVenue.Name = "lblSelectVenue";
            this.lblSelectVenue.Size = new System.Drawing.Size(74, 13);
            this.lblSelectVenue.TabIndex = 4;
            this.lblSelectVenue.Text = "Select Venue:";
            // 
            // lblSelectStartDate
            // 
            this.lblSelectStartDate.AutoSize = true;
            this.lblSelectStartDate.Location = new System.Drawing.Point(12, 53);
            this.lblSelectStartDate.Name = "lblSelectStartDate";
            this.lblSelectStartDate.Size = new System.Drawing.Size(91, 13);
            this.lblSelectStartDate.TabIndex = 5;
            this.lblSelectStartDate.Text = "Select Start Date:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(15, 96);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(94, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Add a Description:";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(18, 113);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(254, 20);
            this.tbDescription.TabIndex = 7;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(18, 153);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(254, 20);
            this.tbTitle.TabIndex = 9;
            // 
            // lblAddaTitle
            // 
            this.lblAddaTitle.AutoSize = true;
            this.lblAddaTitle.Location = new System.Drawing.Point(15, 136);
            this.lblAddaTitle.Name = "lblAddaTitle";
            this.lblAddaTitle.Size = new System.Drawing.Size(61, 13);
            this.lblAddaTitle.TabIndex = 8;
            this.lblAddaTitle.Text = "Add a Title:";
            // 
            // CreateFair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lblAddaTitle);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblSelectStartDate);
            this.Controls.Add(this.lblSelectVenue);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cbVenueNames);
            this.Controls.Add(this.DateTimePicker);
            this.Name = "CreateFair";
            this.Text = "CreateFair";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.ComboBox cbVenueNames;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblSelectVenue;
        private System.Windows.Forms.Label lblSelectStartDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lblAddaTitle;
    }
}