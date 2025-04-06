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
    public partial class NewAccount_form : Form
    {

        private string username;
        private int errorcount;
        public event EventHandler DataAdded;
        Class1 newaccount = new Class1("localhost", "cs311c", "kenneth", "rabina");
        public NewAccount_form(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void validate_form()
        {
            errorcount = 0;
            if (string.IsNullOrEmpty(tb_username.Text))
            {
                errorProvider1.SetError(tb_username, "Username is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(tb_username.Text))
            {
                errorProvider1.SetError(tb_username, "Password is empty");
                errorcount++;
            }
            if(tb_password.TextLength < 6)
            {
                errorProvider1.SetError(tb_password, "Password must be atleast 6 characters");
                errorcount++;
            }

            try
            {
                DataTable dt = newaccount.GetData("SELECT * FROM TABLE_ACCOUNTS WHERE username = '" + tb_username.Text + "'");
                if (dt.Rows.Count > 0) 
                {
                    errorProvider1.SetError(tb_username, "Username already used");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cmb_usertype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmb_usertype, "Select a usertype");
                errorcount++;   
            }
        }


           private void btn_save_Click(object sender, EventArgs e)
        {
            validate_form();
            if (errorcount == 0)
            {
                errorcount = 0;
                errorProvider1.Clear();
                DialogResult dr = MessageBox.Show("Are you sure you want to add this account?","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    try
                    {
                        newaccount.executeSQL("INSERT INTO TABLE_ACCOUNTS(username, password, usertype, status, createdby, datecreated) VALUES('" + tb_username.Text + "', '" + tb_password.Text + "','" + cmb_usertype.Text.ToUpper() + "','ACTIVE', '" + username + "','" + DateTime.Now.ToShortDateString() + "')");
                        if (newaccount.rowAffected > 0)
                        {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            newaccount.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','ADD','ACCOUNTS MANAGEMENT','" + tb_username.Text + "','" + username + "')");
                            MessageBox.Show("New account added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private void cb_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showpass.Checked == true)
            {
                tb_password.PasswordChar = '\0';
            }
            else
            {
                tb_password.PasswordChar = '*';
            }
        }
    }
}
