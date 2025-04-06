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
    public partial class Login_form : Form
    {
        public Login_form()
        {
            InitializeComponent();
        }

        Class1 login = new Class1("localhost", "cs311c", "kenneth", "rabina");
        private int error_count;

        private void btn_login_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if(string.IsNullOrEmpty(tb_username.Text))
            {
                errorProvider1.SetError(tb_username, "Username is empty");
            }

            if(string.IsNullOrEmpty(tb_password.Text))
            {
                errorProvider1.SetError(tb_password, "Password is empty");
            }

            error_count = 0;
            foreach(Control c in errorProvider1.ContainerControl.Controls)
            {
                if(!(string.IsNullOrEmpty(errorProvider1.GetError(c))))
                {
                    error_count++;
                }
            }

            if (error_count == 0) {
                try
                {
                    DataTable dt = login.GetData("SELECT * FROM TABLE_ACCOUNTS WHERE username =  '" +  tb_username.Text + "' AND password = '" + tb_password.Text + "' AND status = 'ACTIVE'");
                    if (dt.Rows.Count > 0)
                    {
                       Main_form mainform = new Main_form(tb_username.Text, dt.Rows[0].Field<string>("usertype"));
                       mainform.Show();
                       this.Hide(); 
                    }
                    else
                    {
                        MessageBox.Show("Login failed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on Login" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tb_username.Clear();
            tb_password.Clear();
        }

        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_showpass.Checked == true)
            {
                tb_password.PasswordChar = '\0';
            }
            else
            {
                tb_password.PasswordChar = '*';
            }
        }

        private void tb_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                btn_login_Click(sender, e);
            }
        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_form_Load(object sender, EventArgs e)
        {

        }
    }
}
