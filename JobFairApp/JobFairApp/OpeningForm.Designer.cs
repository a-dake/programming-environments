namespace JobFairApp
{
    partial class OpeningForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.jobFairBox = new System.Windows.Forms.ComboBox();
            this.m_btn_newJobFair = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btn_Admin = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btn_NewCompany = new System.Windows.Forms.Button();
            this.m_btn_ReturningCompany = new System.Windows.Forms.Button();
            this.m_btn_ReturningUser = new System.Windows.Forms.Button();
            this.m_btn_NewUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select the job fair\r\nyou will be attending";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // jobFairBox
            // 
            this.jobFairBox.DisplayMember = "Title";
            this.jobFairBox.FormattingEnabled = true;
            this.jobFairBox.Location = new System.Drawing.Point(28, 69);
            this.jobFairBox.Name = "jobFairBox";
            this.jobFairBox.Size = new System.Drawing.Size(121, 21);
            this.jobFairBox.TabIndex = 1;
            this.jobFairBox.ValueMember = "ID";
            this.jobFairBox.SelectedIndexChanged += new System.EventHandler(this.jobFairBox_SelectedIndexChanged);
            // 
            // m_btn_newJobFair
            // 
            this.m_btn_newJobFair.Location = new System.Drawing.Point(3, 153);
            this.m_btn_newJobFair.Name = "m_btn_newJobFair";
            this.m_btn_newJobFair.Size = new System.Drawing.Size(83, 23);
            this.m_btn_newJobFair.TabIndex = 3;
            this.m_btn_newJobFair.Text = "New Job Fair";
            this.m_btn_newJobFair.UseVisualStyleBackColor = true;
            this.m_btn_newJobFair.Click += new System.EventHandler(this.m_btn_newJobFair_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btn_Admin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_btn_newJobFair);
            this.panel1.Controls.Add(this.jobFairBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 179);
            this.panel1.TabIndex = 4;
            // 
            // m_btn_Admin
            // 
            this.m_btn_Admin.Location = new System.Drawing.Point(139, 152);
            this.m_btn_Admin.Name = "m_btn_Admin";
            this.m_btn_Admin.Size = new System.Drawing.Size(75, 23);
            this.m_btn_Admin.TabIndex = 4;
            this.m_btn_Admin.Text = "I\'m an Admin";
            this.m_btn_Admin.UseVisualStyleBackColor = true;
            this.m_btn_Admin.Click += new System.EventHandler(this.m_btn_Admin_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btn_NewCompany);
            this.panel2.Controls.Add(this.m_btn_ReturningCompany);
            this.panel2.Controls.Add(this.m_btn_ReturningUser);
            this.panel2.Controls.Add(this.m_btn_NewUser);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(238, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 179);
            this.panel2.TabIndex = 5;
            // 
            // m_btn_NewCompany
            // 
            this.m_btn_NewCompany.Location = new System.Drawing.Point(59, 67);
            this.m_btn_NewCompany.Name = "m_btn_NewCompany";
            this.m_btn_NewCompany.Size = new System.Drawing.Size(109, 23);
            this.m_btn_NewCompany.TabIndex = 4;
            this.m_btn_NewCompany.Text = "New Company";
            this.m_btn_NewCompany.UseVisualStyleBackColor = true;
            this.m_btn_NewCompany.Click += new System.EventHandler(this.m_btn_NewCompany_Click);
            // 
            // m_btn_ReturningCompany
            // 
            this.m_btn_ReturningCompany.Location = new System.Drawing.Point(59, 96);
            this.m_btn_ReturningCompany.Name = "m_btn_ReturningCompany";
            this.m_btn_ReturningCompany.Size = new System.Drawing.Size(109, 23);
            this.m_btn_ReturningCompany.TabIndex = 3;
            this.m_btn_ReturningCompany.Text = "Returning Company";
            this.m_btn_ReturningCompany.UseVisualStyleBackColor = true;
            this.m_btn_ReturningCompany.Click += new System.EventHandler(this.m_btn_ReturningCompany_Click);
            // 
            // m_btn_ReturningUser
            // 
            this.m_btn_ReturningUser.Location = new System.Drawing.Point(59, 125);
            this.m_btn_ReturningUser.Name = "m_btn_ReturningUser";
            this.m_btn_ReturningUser.Size = new System.Drawing.Size(109, 23);
            this.m_btn_ReturningUser.TabIndex = 2;
            this.m_btn_ReturningUser.Text = "Returning User";
            this.m_btn_ReturningUser.UseVisualStyleBackColor = true;
            this.m_btn_ReturningUser.Click += new System.EventHandler(this.m_btn_ReturningUser_Click);
            // 
            // m_btn_NewUser
            // 
            this.m_btn_NewUser.Location = new System.Drawing.Point(59, 153);
            this.m_btn_NewUser.Name = "m_btn_NewUser";
            this.m_btn_NewUser.Size = new System.Drawing.Size(109, 23);
            this.m_btn_NewUser.TabIndex = 1;
            this.m_btn_NewUser.Text = "New User";
            this.m_btn_NewUser.UseVisualStyleBackColor = true;
            this.m_btn_NewUser.Click += new System.EventHandler(this.m_btn_NewUser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(28, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "Who would you like\r\n to sign in as?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OpeningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 200);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OpeningForm";
            this.Text = "selectJobfairForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox jobFairBox;
        private System.Windows.Forms.Button m_btn_newJobFair;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button m_btn_NewCompany;
        private System.Windows.Forms.Button m_btn_ReturningCompany;
        private System.Windows.Forms.Button m_btn_ReturningUser;
        private System.Windows.Forms.Button m_btn_NewUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_btn_Admin;
    }
}