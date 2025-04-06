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
    public partial class UpdateCourse_form : Form
    {
        string coursecode, editdescription, username;
        int errorcount;
        public event EventHandler DataAdded;
        Class1 updatecourse = new Class1("localhost", "cs311c", "kenneth", "rabina");
        public UpdateCourse_form(string coursecode, string editdescription, string username)
        {
            InitializeComponent();
            this.coursecode = coursecode;
            this.editdescription = editdescription;
            this.username = username;
        }

        

        private void validate_form()
        {
            errorcount= 0;
         

  
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            tb_description.Clear();
        }

        private void UpdateCourse_form_Load(object sender, EventArgs e)
        {
            tb_coursecode.Text = coursecode;
            tb_description.Text = editdescription;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            validate_form();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this course?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updatecourse.executeSQL("UPDATE TABLE_COURSES SET description = '" + tb_description.Text + "' WHERE coursecode = '" + tb_coursecode.Text + "'");
                        if (updatecourse.rowAffected > 0)
                        {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            updatecourse.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','UPDATE','COURSE MANAGEMENT','" + tb_coursecode.Text + "','" + username + "')");
                            MessageBox.Show("Course updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
