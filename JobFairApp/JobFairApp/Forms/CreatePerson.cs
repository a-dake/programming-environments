using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JobFairApp.Classes;

namespace JobFairApp.Forms
{
    public partial class CreatePerson : Form
    {
        Person p;

        public CreatePerson()
        {
            InitializeComponent();
            p = new Person();
        }

        
        private void CreatePerson_Load(object sender, EventArgs e)
        {

        }

        private void m_btn_Submit_Click(object sender, EventArgs e)
        {
            Person p = new Person();

            p.First = m_tb_First.Text;
            p.MI = m_tb_MI.Text[0];
            p.Last = m_tb_Last.Text;
            p.Address1 = m_tb_Address1.Text;
            p.Address2 = m_tb_Address2.Text;
            p.City = m_tb_City.Text;
            p.State = m_tb_State.Text;
            p.Zip = m_tb_Zip.Text;
            p.Email = m_tb_Email.Text;
            p.Phone = m_tb_Phone.Text;

            p.Insert();

            
            if(m_cb_Candidate.Checked)
            {
                Candidate c = new Candidate();
                c.PersonID = p.ID;
                c.Insert();
            }
            if(m_cb_Interviewer.Checked)
            {
                Interviewer i = new Interviewer();
                i.PersonID = p.ID;
                i.Insert();
            }

            Context.Person = p.ID;
            MessageBox.Show("Person sucessfully added to database.");
        }
    }
}
