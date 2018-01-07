using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using JobFairApp.Classes;

namespace JobFairApp
{
    public partial class OpeningForm : Form
    {
        public OpeningForm()
        {
            InitializeComponent();
            initialCBox();
        }

        public void initialCBox()
        {
            string Sql = "SELECT * FROM JobFairs";
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                jobFairBox.Items.Add(new JobFair().FromDataReader(DR));
            }

            DR.Close();
            
        }
        
        private void m_btn_ReturningUser_Click(object sender, EventArgs e)
        {
            Forms.LoginForm login = new Forms.LoginForm();
            login.Show();
           // this.Hide();
        }

        private void m_btn_NewCompany_Click(object sender, EventArgs e)
        {
            Forms.AddCompanyForm newCompany = new Forms.AddCompanyForm();
            newCompany.Show();
           // this.Hide();
        }

        private void jobFairBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            JobFair fair = (JobFair)jobFairBox.SelectedItem;

            Context.JobFair = fair.ID;
        }

        private void m_btn_Admin_Click(object sender, EventArgs e)
        {
            Forms.AdminForm adminForm = new Forms.AdminForm();
            adminForm.Show();
           // this.Hide();
        }

        private void m_btn_newJobFair_Click(object sender, EventArgs e)
        {
            Forms.CreateFair fair = new Forms.CreateFair();
            fair.Show();
          //  this.Hide();
        }

        private void m_btn_ReturningCompany_Click(object sender, EventArgs e)
        {
            Forms.CompanyProfile profile = new Forms.CompanyProfile();
            profile.Show();
           // this.Hide();
        }

        private void m_btn_NewUser_Click(object sender, EventArgs e)
        {
            Forms.CreatePerson newPerson = new Forms.CreatePerson();
            newPerson.Show();
            //this.Hide();
        }
    }
}
