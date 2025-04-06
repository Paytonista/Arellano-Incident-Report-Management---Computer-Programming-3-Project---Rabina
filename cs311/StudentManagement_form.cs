using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cs311_rabina_net_framework
{
    public partial class StudentManagement_form : Form
    {
        private string username;
        private string selectedCourseCode;
        private string selectedCourseName;
        private DataTable courseDataTable;
        public StudentManagement_form(string username)
        {
            this.username = username;
            InitializeComponent();
        }


        Class1 students = new Class1("localhost", "cs311c", "kenneth", "rabina");
        

        private void StudentManagement_form_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = students.GetData("SELECT studentID, lastname, firstname, middlename, level, [strand/course] FROM TABLE_STUDENTS ORDER by studentID");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int row;

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = students.GetData("SELECT studentID, lastname, firstname, middlename, level, [strand/course] FROM TABLE_STUDENTS WHERE studentID LIKE '%" + tb_search.Text + "%' OR  lastname LIKE '%" + tb_search.Text + "%' OR  lastname LIKE '%" + tb_search.Text + "%' OR  [strand/course] LIKE '%" + tb_search.Text + "%' ORDER by studentID");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)

            {
                try
                {

                    string selecteduser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    students.executeSQL("DELETE FROM TABLE_STUDENTS WHERE studentID = '" + selecteduser + "'");
                    if (students.rowAffected > 0)
                    {
                        btn_refresh_Click(sender, e);
                        students.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','DELETE','STUDENT MANAGEMENT','" + selecteduser + "','" + username + "')");
                        MessageBox.Show("Student deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            StudentManagement_form_Load(sender, e);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {


            string editstudentid = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editlastname = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string editfirstname = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string editmiddlename = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string editlevel = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string editcoursestrand = dataGridView1.Rows[row].Cells[5].Value.ToString();

            
            UpdateStudent_form updateaccountform = new UpdateStudent_form(editstudentid, editlastname, editfirstname, editmiddlename, editlevel, editcoursestrand, username);
            updateaccountform.DataAdded += new EventHandler(btn_refresh_Click);

            updateaccountform.ShowDialog();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            NewStudent_form newstudentform = new NewStudent_form(username);
            newstudentform.DataAdded += new EventHandler(btn_refresh_Click);

            newstudentform.ShowDialog();
        }
    }
}
