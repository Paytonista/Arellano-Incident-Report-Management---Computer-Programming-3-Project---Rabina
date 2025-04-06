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
    public partial class ViolationsManagement_form : Form
    {

        string username;
        
        public ViolationsManagement_form(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        Class1 courses = new Class1("localhost", "cs311c", "kenneth", "rabina");

        private void ViolationsManagement_form_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = courses.GetData("SELECT code, description, status, violationtype, datecreated, createdby FROM TABLE_VIOLATIONS ORDER by code");
                dataGridView1.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = courses.GetData("SELECT code, description, status, violationtype, datecreated, createdby FROM TABLE_VIOLATIONS WHERE code LIKE '%" + tb_search.Text + "%' OR  violationtype LIKE '%" + tb_search.Text + "%' ORDER by code");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btn_add_Click(object sender, EventArgs e)
        {
            NewViolation_form newviolation = new NewViolation_form(username);
            newviolation.DataAdded += new EventHandler(btn_refresh_Click);

            newviolation.ShowDialog();
        }

        private int row;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row = (int)e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on select", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)

            {
                try
                {

                    string selecteduser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    courses.executeSQL("DELETE FROM TABLE_VIOLATIONS WHERE code = '" + selecteduser + "'");
                    if (courses.rowAffected > 0)
                    {
                        btn_refresh_Click(sender, e);
                        courses.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','DELETE','VIOLATION MANAGEMENT','" + selecteduser + "','" + username + "')");
                        MessageBox.Show("Violation deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string editviolationcode = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editdescription = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string editstatus = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string edittype = dataGridView1.Rows[row].Cells[3].Value.ToString();
            UpdateViolation_form updateviolation = new UpdateViolation_form(editviolationcode, editdescription, editstatus, edittype, username);
            updateviolation.DataAdded += new EventHandler(btn_refresh_Click);

            updateviolation.ShowDialog();

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            ViolationsManagement_form_Load(sender, e);
        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            NewStrand_form newstrand = new NewStrand_form(username);
            newstrand.Show();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

       

       
    }
}
