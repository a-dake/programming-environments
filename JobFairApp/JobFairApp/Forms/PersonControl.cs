using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JobFairApp.Classes;
using System.Data.SqlClient;

namespace JobFairApp.Forms
{
    public partial class PersonControl : UserControl
    {
        private bool creatingNewAccount;
        public PersonControl()
        {
            InitializeComponent();

            ID = MySQLUtils.NullID;
            PersonValid = false;
        }

        public PersonControl(int ID) : this()
        {
            creatingNewAccount = false;
            loadIDButton.Hide();

            Person p = new Person().FromID(ID);

            PersonValid = p.ID != MySQLUtils.NullID;
            if (PersonValid)
            {
                ID = p.ID;
                firstBox.Text = p.First;
                miBox.Text = "" + p.MI;
                lastBox.Text = p.Last;
                titleBox.Text = "1";
                address1Box.Text = p.Address1;
                address2Box.Text = p.Address2;
                cityBox.Text = p.City;
                stateBox.Text = p.State;
                zipBox.Text = p.Zip;
                emailBox.Text = p.Email;
                phoneBox.Text = p.Phone;
            }

        }

        public bool PersonValid
        {
            get;
            private set;
        }

        private int ID;

        public Person Person
        {
            get
            {
                Person p = new Person();
                p.ID = ID;
                p.First = firstBox.Text;
                p.MI = miBox.Text[0];
                p.Last = lastBox.Text;
                p.Title = 1;
                p.Address1 = address1Box.Text;
                p.Address2 = address2Box.Text;
                p.City = cityBox.Text;
                p.State = stateBox.Text;
                p.Zip = zipBox.Text;
                p.Email = emailBox.Text;
                p.Phone = phoneBox.Text;

                return p;
            }
        }

        public event EventHandler PersonValidated;

        private void loadIDButton_Click(object sender, EventArgs e)
        {
            Form idDialog = new Form();

            Label promptLabel = new Label();
            promptLabel.Text = "Please enter the ID:";
            promptLabel.Dock = DockStyle.Top;

            TextBox idBox = new TextBox();
            idBox.Dock = DockStyle.Top;

            idDialog.Controls.Add(promptLabel);
            idDialog.Controls.Add(idBox);

            idDialog.ShowDialog();

            if (int.TryParse(idBox.Text, out ID))
            {
                //parse was successful, now try to find entry
                Person p = new Person().FromID(ID);

                if (p.ID != MySQLUtils.NullID)//valid id, record existed
                {
                    ID = p.ID;

                    Enabled = false;
                    PersonValid = true;
                    PersonValidated?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show(this, "That record does not exist.");
                }
            }
            else
            {
                MessageBox.Show(this, "User IDs consist only of digits.");
            }
        }

        private void verifyButton_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.ID = ID;
            p.First = firstBox.Text;
            p.MI = miBox.Text[0];
            p.Last = lastBox.Text;
            p.Title = 1;
            p.Address1 = address1Box.Text;
            p.Address2 = address2Box.Text;
            p.City = cityBox.Text;
            p.State = stateBox.Text;
            p.Zip = zipBox.Text;
            p.Email = emailBox.Text;
            p.Phone = phoneBox.Text;

            if (p.Insert() != 0)
            {
                // ID is wrong send help pls, code below would work if we fix ID. -Hayden, Kamren
                ID = p.ID;
                ////Add ID to Candidates table or to Interviewers table
                //SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
                //connection.Open();
                //SqlCommand command = new SqlCommand();
                //command.CommandType = CommandType.Text;
                //command.Connection = connection;
                //String statement = "INSERT INTO Candidates (PersonID) VALUES" +
                //    "('" + ID + "')"; //Recent Canidate ID
                //command.CommandText = statement;
                //command.ExecuteNonQuery();
                //connection.Close();
                ////End of new stuff
                Enabled = false;
                PersonValid = true;
                PersonValidated?.Invoke(this, EventArgs.Empty);
            }
        }

        private void PersonControl_EnabledChanged(object sender, EventArgs e)
        {
            bool enabling = Enabled;

            loadIDButton.Enabled = enabling;
            firstBox.Enabled = enabling;
            miBox.Enabled = enabling;
            lastBox.Enabled = enabling;
            titleBox.Enabled = enabling;
            address1Box.Enabled = enabling;
            address2Box.Enabled = enabling;
            cityBox.Enabled = enabling;
            stateBox.Enabled = enabling;
            zipBox.Enabled = enabling;
            emailBox.Enabled = enabling;
            phoneBox.Enabled = enabling;
        }
    }//class(Person)
}//namespace
