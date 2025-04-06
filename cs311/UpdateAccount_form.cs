using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs311_rabina_net_framework
{
    public partial class UpdateAccount_form : Form
    {
        string editusername,  editpassword, edittype,editstatus, username;
        int errorcount;
        public event EventHandler DataAdded;
        Class1 updateaccount = new Class1("localhost", "cs311c", "kenneth", "rabina");



        public UpdateAccount_form(string editusername, string editpassword, string edittype, string editstatus, string username)
        {
            InitializeComponent();
            this.username = username;
            this.editusername = editusername;
            this.editpassword = editpassword;
            this.edittype = edittype;
            this.editstatus = editstatus;
        }

        

        private void UpdateAccount_form_Load(object sender, EventArgs e)
        {
            tb_username.Text = editusername;
            tb_password.Text = editpassword;
            if(edittype == "ADMINISTRATOR")
            {
                cmb_usertype.SelectedIndex = 0;
            } else if (edittype == "BRANCH ADMINISTRATOR")
            {
                cmb_usertype.SelectedIndex = 1;
            } else
            {
                cmb_usertype.SelectedIndex = 2;
            }

            if(editstatus == "ACTIVE")
            {
                cmb_status.SelectedIndex = 0;
            } else
            {
                cmb_status.SelectedIndex = 1;
            }
        }

        private void validate_form()
        {
            errorcount = 0;
            
            if (string.IsNullOrEmpty(tb_password.Text))
            {
                errorProvider1.SetError(tb_username, "Password is empty");
                errorcount++;
            }
            if (tb_password.TextLength < 6)
            {
                errorProvider1.SetError(tb_password, "Password must be atleast 6 characters");
                errorcount++;
            }

            if (cmb_usertype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmb_usertype, "Select a usertype");
                errorcount++;
            }
            if (cmb_status.SelectedIndex < 0) {
                errorProvider1.SetError(cmb_usertype, "Select status");
                errorcount++;
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            tb_password.Clear();
            errorProvider1.Clear();
            
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
        private void btn_save_Click(object sender, EventArgs e)
        {
            validate_form();
            if (errorcount == 0) {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) {
                    try
                    {
                        updateaccount.executeSQL("UPDATE TABLE_ACCOUNTS SET password = '" + tb_password.Text + "', usertype ='" + cmb_usertype.Text.ToUpper() + "', status = '" + cmb_status.Text.ToUpper() + "' WHERE username = '" + tb_username.Text + "'" );
                        if (updateaccount.rowAffected > 0)
                        {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            updateaccount.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','UPDATE','ACCOUNTS MANAGEMENT','" + tb_username.Text + "','" + username + "')");
                            MessageBox.Show("Account updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
