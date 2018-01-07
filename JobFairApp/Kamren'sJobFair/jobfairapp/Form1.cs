using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobFairApp
{
    public partial class Form1 : Form
    {
        public Form1()
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
            //MessageBox.Show("We don't have that yet lmao");
        }

        private void venue_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            this.Hide();
            Forms.CreateCandidate createCandidate = new Forms.CreateCandidate();
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

        private void button1_Click(object sender, EventArgs e)
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
    }
}
