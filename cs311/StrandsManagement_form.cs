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
    public partial class StrandsManagement_form : Form
    {

        string username;
        public StrandsManagement_form(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        Class1 courses = new Class1("localhost", "cs311c", "kenneth", "rabina");

        private void StrandsManagement_form_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = courses.GetData("SELECT coursecode, description, datecreated, createdby FROM TABLE_COURSES ORDER by coursecode");
                DataTable dt2 = courses.GetData("SELECT strandcode, description, datecreated, createdby FROM TABLE_STRANDS ORDER by strandcode");
                
                dataGridView2.DataSource = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_search2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt2 = courses.GetData("SELECT strandcode, description, datecreated, createdby FROM TABLE_STRANDS WHERE strandcode LIKE '%" + tb_search2.Text + "%' OR  description LIKE '%" + tb_search2.Text + "%' ORDER by strandcode");
                dataGridView2.DataSource = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            NewCourse_form newcourse = new NewCourse_form(username);
            newcourse.Show();
        }

        private int row;

        private void btn_add2_Click(object sender, EventArgs e)
        {
            NewStrand_form newstrand = new NewStrand_form(username);
            newstrand.DataAdded += new EventHandler(btn_refresh2_Click);

            newstrand.ShowDialog();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void btn_delete2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this strand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)

            {
                try
                {

                    string selecteduser = dataGridView2.Rows[row].Cells[0].Value.ToString();
                    courses.executeSQL("DELETE FROM TABLE_STRANDS WHERE strandcode = '" + selecteduser + "'");
                    if (courses.rowAffected > 0)
                    {
                        btn_refresh2_Click(sender, e);
                        courses.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','DELETE','STRAND MANAGEMENT','" + selecteduser + "','" + username + "')");
                        MessageBox.Show("Strand deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btn_refresh2_Click(object sender, EventArgs e)
        {
            StrandsManagement_form_Load(sender, e);
        }

        private void btn_update2_Click(object sender, EventArgs e)
        {
            string editstrandcode = dataGridView2.Rows[row].Cells[0].Value.ToString();
            string editstranddescription = dataGridView2.Rows[row].Cells[1].Value.ToString();
            
            UpdateStrand_form updatestrandform = new UpdateStrand_form(editstrandcode, editstranddescription, username);
            updatestrandform.DataAdded += new EventHandler(btn_refresh2_Click);

            updatestrandform.ShowDialog();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
