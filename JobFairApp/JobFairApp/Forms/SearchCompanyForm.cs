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
using System.Data.SqlClient;

namespace JobFairApp.Forms
{
    public partial class SearchCompanyForm : Form
    {
        private ICollection<String> potentialFilters;
        private ICollection<String> addedFilters;

        public string SearchText
        {
            get
            {
                return searchBox.Text;
            }
            set
            {
                searchBox.Text = value;//triggers TextChangedEvent which does search
            }
        }

        public SearchCompanyForm()
        {
            InitializeComponent();
            potentialFilters = new SortedSet<String>();
            addedFilters = new SortedSet<String>();
            LoadFilters();
        }

        private void LoadFilters()
        {
            //read the filters
            String query = "SELECT Name FROM Specialties";

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            command.Connection = connection;

            SqlDataReader reader = command.ExecuteReader();

            //ensure that specialties start out sorted
            while (reader.Read())
            {
                potentialFilters.Add((String)reader[0]);
            }
            connection.Close();


            //potentialFilters.Sort();//only uncomment if using a type that is unsorted by default

            foreach (String s in potentialFilters)
            {
                Label newLabel = new Label();
                newLabel.AutoEllipsis = true;
                newLabel.Text = s;
                newLabel.Click += addFilter_Click;
                potentialFiltersPanel.Controls.Add(newLabel);
            }
        }

        #region Designer-made events (these ones are shells for other methods, actual processes below if made)
        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoSearch();
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            DoSearch();
        }
        private void filterPanel_ControlChanged(object source, ControlEventArgs args)
        {
            VerticallyArrangeContents((Control)source);
        }
        #endregion

        #region dynamically assigned events
        private void VerticallyArrangeContents(Control container)
        {
            if (container.Controls.Count == 0) return;

            Control first = container.Controls[0];
            first.Location = new Point(2, 1);

            for(int i = 1; i < container.Controls.Count; i++)
            {
                Control c = container.Controls[i];
                int newX = 2;
                int newY= container.Controls[i - 1].Bottom + 1;
                c.Location = new Point(newX, newY);
            }
        }
        private void addFilter_Click(object sender, EventArgs args)
        {
            Control src = (Control)sender;

            String filter = src.Text;
            Label newFilter = new Label();
            newFilter.AutoEllipsis = true;
            newFilter.Text = filter;
            newFilter.Click += removeFilter_Click;
            addedFiltersPanel.Controls.Add(newFilter);

            //remove filter label
            for(int i = 0; i < potentialFiltersPanel.Controls.Count; i++)
             if(potentialFiltersPanel.Controls[i].Text == filter)
              potentialFiltersPanel.Controls.RemoveAt(i);

            potentialFilters.Remove(filter);
            addedFilters.Add(filter);
        }
        private void removeFilter_Click(object sender, EventArgs args)
        {
            Control src = (Control)sender;

            String filter = src.Text;
            Label newFilter = new Label();
            newFilter.AutoEllipsis = true;
            newFilter.Text = filter;
            newFilter.Click += addFilter_Click;
            potentialFiltersPanel.Controls.Add(newFilter);

            //remove filter label
            for (int i = 0; i < addedFiltersPanel.Controls.Count; i++)
                if (addedFiltersPanel.Controls[i].Text == filter)
                    addedFiltersPanel.Controls.RemoveAt(i);

            addedFilters.Remove(filter);
            potentialFilters.Add(filter);
        }
        #endregion

        #region searching
        /// <summary>
        /// Constructs a sql command from current filters and other information.
        /// Runs it and populates results panel.
        /// </summary>
        public void DoSearch()
        {
            StringBuilder statement = new StringBuilder();

            statement.Append("SELECT Companies.*, Specialties.Name FROM Companies INNER JOIN (CompanyInterests INNER JOIN Specialties " +
                "ON CompanyInterests.InterestID = Specialties.ID) ON CompanyInterests.CompanyID = Companies.ID");

            if (searchBox.Text != "")
            {
                statement.Append(" AND Companies.Name = '" + searchBox.Text + "'");
                //statement.Append("");//"AND Companies.name LIKE [text]"?
            }

            if (addedFilters.Count > 0)
            {
                statement.Append(" AND (");

                for (int i = 0; i < addedFilters.Count; i++)
                {
                    statement.Append("Specialties.Name = '");
                    statement.Append(addedFilters.ElementAt(i));
                    statement.Append("'");

                    if (i != addedFilters.Count - 1)
                        statement.Append(" OR ");
                }

                statement.Append(")");
            }

            SqlConnection connection = new SqlConnection(MySQLUtils.ConnectionString);

            connection.Open();

            SqlCommand command = new SqlCommand(statement.ToString(), connection);

            SqlDataReader reader = command.ExecuteReader();

            resultsPanel.Controls.Clear();
            
            //using a cross-product will cause the same company to appear multiple times
            //this will record used IDs in order to skip displaying copies
            SortedSet<int> foundCompanies = new SortedSet<int>();

            while (reader.Read())
            {
                Company comp = new Company().FromDataReader(reader);

                //skip duplicates
                if (foundCompanies.Contains(comp.ID)) continue;

                foundCompanies.Add(comp.ID);

                CompanyView view = new CompanyView();
                view.Company = comp;
                view.Location = new Point();

                view.LinkClicked += Company_Clicked;
                
                resultsPanel.Controls.Add(view);
            }

            VerticallyArrangeContents(resultsPanel);

            connection.Close();
        }
        #endregion

        private void Company_Clicked(object sender, CompanyView.CompanyEventArgs args)
        {
            //open company profile form
            CompanyProfile form = new CompanyProfile();
            form.FormClosed += delegate (object s, FormClosedEventArgs a)
            {
                Visible = !Visible;
            };
            Visible = false;

            form.Show();

            //view selected company
            form.Company = args.Company;
        }
    }

    public class CompanyView : UserControl
    {
        private Company company;
        public Company Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
                name.Text = company.name;
                description.Text = company.description;
                
                //interests
                List<String> interestsList = company.GetInterests();
                String text = "";
                foreach(String interest in interestsList)
                {
                    text += interest + ", ";
                }

                if (text.Length != 0)
                    interests.Text = text.Substring(0, text.Length - 2);
                else interests.Text = "";


            }
        }

        Label name;
        Label description;
        Panel divider;
        Label basicInterests;
        Label interests;
        Button profileLink;

        public delegate void CompanyEventHandler(object sneder, CompanyEventArgs args);
        public CompanyEventHandler LinkClicked;

        public CompanyView()
        {
            Size = new Size(200, 150);
            BorderStyle = BorderStyle.Fixed3D;
            
            name = new Label();
            description = new Label();
            divider = new Panel();
            basicInterests = new Label();
            interests = new Label();
            profileLink = new Button();


            name.Location = new Point(5, 5);
            name.Size = new Size(80, 25);
            name.Font = new Font(name.Font, FontStyle.Bold);

            profileLink.Location = new Point(name.Right + 10, 7);
            profileLink.Size = new Size(40, 20);
            profileLink.Text = "View";

            basicInterests.Location = new Point(5, name.Bottom + 5);
            basicInterests.Size = new Size(Width - 10, 25);
            basicInterests.Font = new Font(basicInterests.Font, FontStyle.Italic);
            basicInterests.Text = "Looking for:";

            divider.Location = new Point(-1, basicInterests.Bottom + 1);
            divider.Size = new Size(500, 1);
            divider.BackColor = Color.DarkGray;

            description.Location = new Point(10, basicInterests.Bottom + 5);
            description.Size = new Size(90, 50);
            

            name.BorderStyle = BorderStyle.FixedSingle;
            description.BorderStyle = BorderStyle.FixedSingle;
            basicInterests.BorderStyle = BorderStyle.FixedSingle;

            Controls.Add(name);
            Controls.Add(profileLink);
            Controls.Add(description);
            Controls.Add(divider);
            Controls.Add(basicInterests);

            profileLink.Click += delegate (object sender, EventArgs args)
            {
                CompanyEventArgs cargs = new CompanyEventArgs();
                cargs.Company = Company;
                LinkClicked(this, cargs);
            };
        }

        public class CompanyEventArgs : EventArgs
        {
            public Company Company;
        }
    }
}
