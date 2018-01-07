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

namespace JobFairApp.Forms
{
    public partial class CompanyProfile : Form {

        public Company Company
        {
            get
            {
                return (Company)companyBox.SelectedItem;
            }
            set
            {
                foreach (Object o in companyBox.Items)
                {
                    if(((Company)o).ID == value.ID)
                    {
                        companyBox.SelectedItem = o;
                    }
                }
            }
        }

        List<String> specialtiesList = new List<String>();
        public CompanyProfile()
        {
            InitializeComponent();
            initialCBox();
            
        }

        public void initialCBox()
        {
            string Sql = "SELECT * FROM Companies";
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                companyBox.Items.Add(new Company().FromDataReader(DR));
            }

            DR.Close();

            ////read the filters
            //String query = "SELECT Name FROM Specialties";

            //SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            //connection.Open();

            //SqlCommand command = new SqlCommand();
            //command.CommandText = query;
            //command.CommandType = CommandType.Text;
            //command.Connection = connection;

            //SqlDataReader reader = command.ExecuteReader();

            ////ensure that specialties start out sorted
            //while (reader.Read())
            //{
            //   specialtiesList.Add((String)reader[0]);
            //}
            //connection.Close();
        }

        private void companyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Company selectedCompany = (Company)companyBox.SelectedItem;
            
            companyLabel.Text = selectedCompany.name;
            emailLabel.Text = selectedCompany.email;
            phoneLabel.Text = selectedCompany.phone;
            descriptionBox.Text = selectedCompany.description;

            Context.Company = selectedCompany.ID;

            return;
            
            //string selectedCompanyName;
            //selectedCompanyName = companyBox.SelectedItem.ToString();
            //companyLabel.Text = selectedCompanyName;



            //string Sql = "SELECT Email FROM Companies WHERE Name ='"+selectedCompanyName+"'";
            //SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            //conn.Open();
            //SqlCommand cmd = new SqlCommand(Sql, conn);
            //SqlDataReader DR = cmd.ExecuteReader();
            ////seems to not be reading anything idk
            //while (DR.Read())
            //{
            //    emailLabel.Text = DR[0].ToString();
            //    //MessageBox.Show(DR[0].ToString());
            //}

            //Sql = "SELECT Phone FROM Companies WHERE Name ='" + selectedCompanyName + "'";
            //conn = new SqlConnection(MySQLUtils.ConnectionString);
            //conn.Open();
            //cmd = new SqlCommand(Sql, conn);
            //DR = cmd.ExecuteReader();
            ////seems to not be reading anything idk
            //while (DR.Read())
            //{
            //    phoneLabel.Text = DR[0].ToString();
            //    //MessageBox.Show(DR[0].ToString());
            //}

            //Sql = "SELECT Description FROM Companies WHERE Name ='" + selectedCompanyName + "'";
            //conn = new SqlConnection(MySQLUtils.ConnectionString);
            //conn.Open();
            //cmd = new SqlCommand(Sql, conn);
            //DR = cmd.ExecuteReader();
            ////seems to not be reading anything idk
            //while (DR.Read())
            //{
            //    descriptionBox.Text = DR[0].ToString();
            //    //MessageBox.Show(DR[0].ToString());
            //}

        }

        private void requestInterviewBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Comp: " + Context.Company);

            AddInterviewForm form = new AddInterviewForm();
            
            form.ShowDialog();
        }

        private void CompanyProfile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'jobFairDataSet.Specialties' table. You can move, or remove it, as needed.
            this.specialtiesTableAdapter.Fill(this.jobFairDataSet.Specialties);

        }
    }
}
