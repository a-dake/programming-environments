using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace JobFairApp.Forms
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void createJobFairButton_Click(object sender, EventArgs e)
        {
            Forms.CreateFair createFair = new Forms.CreateFair();
            createFair.VisibleChanged += delegate (object source, EventArgs args)
            {
                if (!createFair.Visible)
                {
                    this.Show();
                }
            };
            createFair.Show();
        }

        private void venue_btn_Click(object sender, EventArgs e)
        {
            Forms.CreateVenue createVenue = new Forms.CreateVenue();
            createVenue.VisibleChanged += delegate (object source, EventArgs args)
            {
                if (!createVenue.Visible)
                {
                    this.Show();
                }
            };
            createVenue.Show();
        }

        private void person_btn_Click(object sender, EventArgs e)
        {
            Forms.CreatePerson createCandidate = new Forms.CreatePerson();
            createCandidate.VisibleChanged += delegate (object source, EventArgs args)
            {
                if (!createCandidate.Visible)
                {
                    this.Show();
                }
            };
            createCandidate.Show();
        }

        private void createCompanyButton_Click(object sender, EventArgs e)
        {
            Forms.AddCompanyForm createCompany = new Forms.AddCompanyForm();
            createCompany.VisibleChanged += delegate (object source, EventArgs args)
            {
                if (!createCompany.Visible)
                {
                    this.Show();
                }
            };
            createCompany.Show();
        }

        private void createTimeSlotsButton_Click(object sender, EventArgs e)
        {
            Forms.CreateInterviewTimes createTimeSlots = new Forms.CreateInterviewTimes();
            createTimeSlots.VisibleChanged += delegate (object source, EventArgs args)
            {
                if (!createTimeSlots.Visible)
                {
                    this.Show();
                }
            };
            createTimeSlots.Show();
        }

        private void companyProfileButton_Click(object sender, EventArgs e)
        {
            Forms.CompanyProfile createTimeSlots = new Forms.CompanyProfile();
            createTimeSlots.VisibleChanged += delegate (object source, EventArgs args)
            {
                if (!createTimeSlots.Visible)
                {
                    this.Show();
                }
            };
            createTimeSlots.Show();
        }

        private void searchCompanyButton_Click(object sender, EventArgs e)
        {
            Forms.SearchCompanyForm searchCompanies = new Forms.SearchCompanyForm();
            searchCompanies.VisibleChanged += delegate (object source, EventArgs args)
            {
                if (!searchCompanies.Visible)
                {
                    this.Show();
                }
            };
            searchCompanies.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            Forms.LoginForm loginForm = new Forms.LoginForm();
            loginForm.VisibleChanged += delegate (object source, EventArgs args)
            {
                if (!loginForm.Visible)
                {
                    this.Show();
                }
            };
            loginForm.Show();
        }

        private void openingFormButton_Click(object sender, EventArgs e)
        {
            OpeningForm openingForm = new OpeningForm();
            openingForm.FormClosed += delegate (object source, FormClosedEventArgs args)
            {
                this.Visible = true;
            };
            openingForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Location_Click(object sender, EventArgs e)
        {
            Forms.LocationsForm locationsForm = new Forms.LocationsForm();
            locationsForm.FormClosed += delegate (object source, FormClosedEventArgs args)
            {
                this.Visible = true;
            };
            locationsForm.Show();
        }

        private void btn_Table_Click(object sender, EventArgs e)
        {
            Forms.TablesForm tablesForm = new Forms.TablesForm();
            tablesForm.FormClosed += delegate (object source, FormClosedEventArgs args)
            {
                this.Visible = true;
            };
            tablesForm.Show();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = printDoc;
            
            //printDoc.PrintPage += new PrintPageEventHandler(this.printDoc_PrintPage);
           // printPreview.ShowDialog();
            Forms.printForm printForm = new Forms.printForm();
            printForm.Show();
            //printDoc.Print();
         

    }
        private void printDoc_PrintPage (object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            String message = "issa string";
            Font messageFont = new Font("Arial", 24, System.Drawing.GraphicsUnit.Point);
            g.DrawString(message, messageFont, Brushes.Black, 100, 100);
        }

        
}
}

