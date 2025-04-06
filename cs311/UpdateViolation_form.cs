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
    public partial class UpdateViolation_form : Form
    {
        string editcode, editdescription, editstatus, edittype, username;
        public event EventHandler DataAdded;



        int errorcount;

        private void btn_delete_Click(object sender, EventArgs e)
        {
            UpdateViolation_form_Load(sender, e);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            validate_form();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        connection.executeSQL("UPDATE TABLE_VIOLATIONS SET description = '" + tb_description.Text + "', status = '" + cmb_status.SelectedItem +"', violationtype = '" + cmb_violationtype.SelectedItem + "' WHERE code = '" + tb_violationcode.Text + "'");
                        if (connection.rowAffected > 0)
                        {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            connection.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','UPDATE','VIOLATION MANAGEMENT','" + tb_violationcode.Text + "','" + username + "')");
                            MessageBox.Show("Violation updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        Class1 connection = new Class1("localhost", "cs311c", "kenneth", "rabina");
        public UpdateViolation_form(string editcode, string editdescription, string editstatus, string edittype, string username)
        {
            InitializeComponent();
            this.editcode = editcode;
            this.editdescription = editdescription;
            this.editstatus = editstatus;
            this.edittype = edittype;
            this.username = username;
        }
        private void UpdateViolation_form_Load(object sender, EventArgs e)
        {
            tb_violationcode.Text = editcode;
            tb_description.Text = editdescription;
            if (editstatus == "ACTIVE")
            {
                cmb_status.SelectedIndex = 0;
            } else
            {
                cmb_status.SelectedIndex = 1;
            }
            if (edittype == "minor offense")
            {
                cmb_violationtype.SelectedIndex = 0;
            }
            else {
                cmb_violationtype.SelectedIndex = 1;
            }

        }
        private void validate_form()
        {
            errorProvider1.Clear();
            errorcount = 0;
            if (string.IsNullOrEmpty(tb_description.Text))
            {
                errorProvider1.SetError(tb_description, "Violation Description is empty");
                errorcount++;
            }










        }
    }
}
