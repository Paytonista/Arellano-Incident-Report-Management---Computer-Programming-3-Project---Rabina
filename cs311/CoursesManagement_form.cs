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
    public partial class CoursesManagement_form : Form
    {

        string username;
        public CoursesManagement_form(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        Class1 courses = new Class1("localhost", "cs311c", "kenneth", "rabina");

        private void CoursesManagement_form_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = courses.GetData("SELECT coursecode, description, datecreated, createdby FROM TABLE_COURSES ORDER by coursecode");
                DataTable dt2 = courses.GetData("SELECT strandcode, description, datecreated, createdby FROM TABLE_STRANDS ORDER by strandcode");
                dataGridView1.DataSource = dt;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = courses.GetData("SELECT coursecode, description, datecreated, createdby FROM TABLE_COURSES WHERE coursecode LIKE '%" + tb_search.Text + "%' OR  description LIKE '%" + tb_search.Text + "%' ORDER by coursecode");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_search2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            NewCourse_form newcourse = new NewCourse_form(username);
            newcourse.DataAdded += new EventHandler(btn_refresh_Click);

            newcourse.ShowDialog();
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
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this course?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)

            {
                try
                {

                    string selecteduser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    courses.executeSQL("DELETE FROM TABLE_COURSES WHERE coursecode = '" + selecteduser + "'");
                    if (courses.rowAffected > 0)
                    {
                        btn_refresh_Click(sender, e);
                        courses.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','DELETE','COURSE MANAGEMENT','" + selecteduser + "','" + username + "')");
                        MessageBox.Show("Course deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            string editcoursecode = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editdescription = dataGridView1.Rows[row].Cells[1].Value.ToString();
            UpdateCourse_form updatecourseform = new UpdateCourse_form(editcoursecode, editdescription, username);
            updatecourseform.DataAdded += new EventHandler(btn_refresh_Click);

            updatecourseform.ShowDialog();

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            CoursesManagement_form_Load(sender, e);
        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            NewStrand_form newstrand = new NewStrand_form(username);
            newstrand.Show();
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
           
        }

        private void btn_refresh2_Click(object sender, EventArgs e)
        {
            CoursesManagement_form_Load(sender, e);
        }

        private void btn_update2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
