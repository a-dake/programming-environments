using JobFairApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobFairApp.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            LoadNames();
        }

        private void LoadNames()
        {
            string Sql = "SELECT * FROM People";
            SqlConnection conn = new SqlConnection(MySQLUtils.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sql, conn);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                cbox_Names.Items.Add(new Person().FromDataReader(DR));

            }
            conn.Close();
        }


        private void createUser_btn_Click(object sender, EventArgs e)
        {
            Forms.CreatePerson createPerson = new Forms.CreatePerson();
            createPerson.FormClosed += delegate (object source, FormClosedEventArgs args)
            {
                this.Show();
            };
            createPerson.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'jobFairDataSet.People' table. You can move, or remove it, as needed.
            //  this.peopleTableAdapter.Fill(this.jobFairDataSet.People);

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            Person selectedPerson = (Person)cbox_Names.SelectedItem;

            Context.Person = selectedPerson.ID;

            Forms.UserProfile profile = new Forms.UserProfile();
            profile.FormClosed += delegate (object source, FormClosedEventArgs args)
            {
                this.Show();
            };
            profile.Show();
        }
    }
}
