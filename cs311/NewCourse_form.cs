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
    public partial class NewCourse_form : Form
    {

        string username;
        public event EventHandler DataAdded;

        int errorcount;
        Class1 course = new Class1("localhost", "cs311c", "kenneth", "rabina");
        public NewCourse_form(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void validate_form()
        {
            errorProvider1.Clear();
            errorcount = 0;
            try
            {
                DataTable dt = course.GetData("SELECT * FROM TABLE_COURSES WHERE coursecode = '" + tb_coursecode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(tb_coursecode, "Course code already used");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validate course code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (string.IsNullOrEmpty(tb_coursecode.Text))
            {
                errorProvider1.SetError(tb_coursecode, "Course code is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(tb_description.Text))
            {
                errorProvider1.SetError(tb_description, "Course Description is empty");
                errorcount++;
            }
            

            /*
            if (tb_password.TextLength < 6)
            {
                errorProvider1.SetError(tb_password, "Password must be atleast 6 characters");
                errorcount++;
            }
            */






           
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            validate_form();
            if (errorcount == 0)
            {
                errorcount = 0;
                errorProvider1.Clear();
                DialogResult dr = MessageBox.Show("Are you sure you want to add this course?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        course.executeSQL("INSERT INTO TABLE_COURSES(coursecode, description, datecreated, createdby) VALUES('" + tb_coursecode.Text + "', '" + tb_description.Text + "','" + DateTime.Now.ToShortDateString() + "','" + username +  "')");
                        if (course.rowAffected > 0)
                        {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            course.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','ADD','COURSE MANAGEMENT','" + tb_coursecode.Text + "','" + username + "')");
                            MessageBox.Show("New course added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            tb_coursecode.Clear();
            tb_description.Clear();
        }
    }
}
