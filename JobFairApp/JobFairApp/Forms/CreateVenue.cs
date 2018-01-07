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
    public partial class CreateVenue : Form
    {
        Dictionary<Location, List<Table>> tables = new Dictionary<Location, List<Table>>();


        public CreateVenue()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Venue newVenue = new Venue();
            newVenue.Name = nameBox.Text;
            newVenue.ShortDescription = shortDescriptionBox.Text;
            newVenue.LongDescription = longDescriptionBox.Text.Equals("") ? 
                    shortDescriptionBox.Text : 
                    longDescriptionBox.Text;

            newVenue.Insert();

            Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Hide();
            Dispose();
        }
    }
}
