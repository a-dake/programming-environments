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
    public partial class printForm : Form
    {
        public printForm()
        {
            InitializeComponent();
        }

        private void printForm_Load(object sender, EventArgs e)
        {// TODO: This line of code loads data into the 'jobFairDataSet6.InterviewInfo_1' table. You can move, or remove it, as needed.
            jobFairDataSet6.EnforceConstraints = false;
            this.interviewInfo_1TableAdapter.Fill(this.jobFairDataSet6.InterviewInfo_1);
            //this is a mess im so sorry - Anna
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);

            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
