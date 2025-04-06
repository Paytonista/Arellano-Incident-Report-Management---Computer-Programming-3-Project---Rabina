using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs311_rabina_net_framework
{
    public partial class Main_form : Form
    {
        private string username, usertype;

        
        public Main_form(string username, string usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
        }

        

        private void Main_form_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Username: " + username;
            toolStripStatusLabel2.Text = "User type: " + usertype;

            if (usertype == "ADMINISTRATOR")
            {
                accountsToolStripMenuItem.Visible = true;
                eventsToolStripMenuItem.Visible = true;
                ticketsToolStripMenuItem.Visible = true;
            }
            else if (usertype == "BRANCH ADMINISTRATOR")
            {
                accountsToolStripMenuItem.Visible = false;
                eventsToolStripMenuItem.Visible = true;
                ticketsToolStripMenuItem.Visible = true;    
            } 
            else
            {
                ticketsToolStripMenuItem.Visible = true;
            }
        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentManagement_form studentform = new StudentManagement_form(username);
            studentform.MdiParent = this;
            studentform.Show();
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoursesManagement_form coursesmanagement = new CoursesManagement_form(username);
            coursesmanagement.MdiParent = this;
            coursesmanagement.Show();
        }

        private void strandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StrandsManagement_form strandsmanagement = new StrandsManagement_form(username);
            strandsmanagement.MdiParent = this;
            strandsmanagement.Show();
        }

        private void violationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViolationsManagement_form violationsmanagement = new ViolationsManagement_form(username);
            violationsmanagement.MdiParent = this;
            violationsmanagement.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void casesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CasesManagement_form casesmanagement = new CasesManagement_form(username);
            casesmanagement.MdiParent = this;
            casesmanagement.Show();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts_form accountsform = new Accounts_form(username);
            accountsform.MdiParent = this;
            accountsform.Show();
        }

    }
}
