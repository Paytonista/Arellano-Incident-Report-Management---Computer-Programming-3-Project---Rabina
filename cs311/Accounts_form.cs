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
    
    public partial class Accounts_form : Form
    {
        private string username;
        public Accounts_form(string username)
        {
            InitializeComponent();
            this.username = username; 
        }
        Class1 accounts = new Class1("localhost", "cs311c", "kenneth", "rabina");
        private void Accounts_form_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = accounts.GetData("SELECT username, password, usertype, status, createdby, datecreated FROM TABLE_ACCOUNTS WHERE username <> '" + username + "' ORDER by username");
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
                DataTable dt = accounts.GetData("SELECT username, password, usertype, status, createdby, datecreated FROM TABLE_ACCOUNTS WHERE username <> '" + username + 
                    "' AND(username LIKE '%" + tb_search.Text + "%' OR  usertype LIKE '%" + tb_search.Text + "% ') ORDER by username");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Accounts_form_Load(sender, e);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            NewAccount_form newaccountform = new NewAccount_form(username);
            newaccountform.DataAdded += new EventHandler(btn_refresh_Click);

            newaccountform.ShowDialog();
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
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)

            {
                try
                {

                    string selecteduser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    accounts.executeSQL("DELETE FROM TABLE_ACCOUNTS WHERE username = '" + selecteduser + "'");
                    if (accounts.rowAffected > 0)
                    {
                        btn_refresh_Click(sender, e);
                        accounts.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','DELETE','ACCOUNTS MANAGEMENT','" + selecteduser + "','" + username + "')");
                        MessageBox.Show("Account deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       
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
            string editusername = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editpassword = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string edittype = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string editstatus = dataGridView1.Rows[row].Cells[3].Value.ToString(); 
            UpdateAccount_form updateaccountform = new UpdateAccount_form(editusername , editpassword ,edittype, editstatus, username);
            updateaccountform.DataAdded += new EventHandler(btn_refresh_Click);

            updateaccountform.ShowDialog();

        }
    }
}
