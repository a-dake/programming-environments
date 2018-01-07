using JobFairApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobFairApp.Forms
{
    public partial class AddCompanyForm : Form
    {
        public AddCompanyForm()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            Company company = new Company();

            company.name = nameTxt.Text;
            company.email = emailTxt.Text;
            company.phone = phoneTxt.Text;
            company.description = descriptionTxt.Text;

            company.Insert();


            Hide();
        }

        private void AddCompanyForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'jobFairDataSet1.Specialties' table. You can move, or remove it, as needed.
            this.specialtiesTableAdapter.Fill(this.jobFairDataSet1.Specialties);

        }
    }
}
