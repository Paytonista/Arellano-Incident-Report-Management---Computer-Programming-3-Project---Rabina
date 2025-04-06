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
    public partial class NewViolation_form : Form
    {
        string username, validatecode;
        int errorcount;
        Class1 newstrand = new Class1("localhost", "cs311c", "kenneth", "rabina");
        public event EventHandler DataAdded;
        public NewViolation_form(string username)
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
                validatecode = tb_violationcode.Text + "-" + dateTimePicker1.Value.Date;


                DataTable dt = newstrand.GetData("SELECT * FROM TABLE_VIOLATIONS WHERE code = '" + validatecode + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(tb_violationcode, "Violation code already used");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validate violation code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (string.IsNullOrEmpty(tb_violationcode.Text))
            {
                errorProvider1.SetError(tb_violationcode, "Violation code is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(tb_description.Text))
            {
                errorProvider1.SetError(tb_description, "Violation Description is empty");
                errorcount++;
            }
            if (cmb_violationtype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmb_violationtype, "Violation type is empty");
                errorcount++;
            }


            







        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            tb_violationcode.Text = "";
            tb_description.Text = "";
            cmb_violationtype.SelectedIndex = 0;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            validate_form();
            if (errorcount == 0)
            {
                errorcount = 0;
                errorProvider1.Clear();
                DialogResult dr = MessageBox.Show("Are you sure you want to add this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        newstrand.executeSQL("INSERT INTO TABLE_VIOLATIONS(code, description, status, violationtype, createdby, datecreated) VALUES('" + validatecode + "', '" + tb_description.Text + "','ACTIVE','" + cmb_violationtype.SelectedItem + "','" + username + "','" + DateTime.Now.ToShortDateString() + "')");
                        if (newstrand.rowAffected > 0)
                        {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            newstrand.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','ADD','VIOLATION MANAGEMENT','" + tb_violationcode.Text + "','" + username + "')");
                            MessageBox.Show("New violation added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
