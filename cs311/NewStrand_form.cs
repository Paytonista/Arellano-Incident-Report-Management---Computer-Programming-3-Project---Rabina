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
    public partial class NewStrand_form : Form
    {
        string username;
        int errorcount;
        public event EventHandler DataAdded;
        Class1 newstrand = new Class1("localhost", "cs311c", "kenneth", "rabina");
        public NewStrand_form(string username)
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
                DataTable dt = newstrand.GetData("SELECT * FROM TABLE_STRANDS WHERE strandcode = '" + tb_strandcode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(tb_strandcode, "Strand code already used");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validate strand code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (string.IsNullOrEmpty(tb_strandcode.Text))
            {
                errorProvider1.SetError(tb_strandcode, "Strand code is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(tb_description.Text))
            {
                errorProvider1.SetError(tb_description, "Strand Description is empty");
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
                DialogResult dr = MessageBox.Show("Are you sure you want to add this strand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        newstrand.executeSQL("INSERT INTO TABLE_STRANDS(strandcode, description, datecreated, createdby) VALUES('" + tb_strandcode.Text + "', '" + tb_description.Text + "','" + DateTime.Now.ToShortDateString() + "','" + username + "')");
                        if (newstrand.rowAffected > 0)
                        {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            newstrand.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','ADD','STRAND MANAGEMENT','" + tb_strandcode.Text + "','" + username + "')");
                            MessageBox.Show("New strand added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
