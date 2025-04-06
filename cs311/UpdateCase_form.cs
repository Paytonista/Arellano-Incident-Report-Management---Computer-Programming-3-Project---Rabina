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
    public partial class UpdateCase_form : Form
    {
        string editstatus, editaction, editcaseid, username, editschoolyear, editconcernlevel, editprocedure;
        int errorcount;
        public event EventHandler DataAdded;

        Class1 connection = new Class1("localhost", "cs311c", "kenneth", "rabina");

        private void btn_save_Click(object sender, EventArgs e)
        {
            validate_form();
            errorProvider1.Clear();
            if(errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this case?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                       

                            // Update the student data in TABLE_STUDENTS
                            connection.executeSQL($"UPDATE TABLE_CASES SET status = '{cmb_status.SelectedItem}', action = '{rtb_action.Text}' , schoolyear = '{tb_schoolyear.Text}' , concernlevel = '{cmb_concern.SelectedItem}', [procedure] = '{rtb_procedure.Text}' WHERE caseid = '{editcaseid}'");

                            if (connection.rowAffected > 0)
                            {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            // Log the action
                            connection.executeSQL($"INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('{DateTime.Now.ToShortDateString()}', '{DateTime.Now.ToShortTimeString()}', 'UPDATE', 'CASE MANAGEMENT', '{editcaseid}', '{username}')");

                                MessageBox.Show("Student information updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void validate_form()
        {
            errorcount = 0;
            if (cmb_status.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmb_status, "No Status selected");
                errorcount++;
            }
            if (cmb_concern.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmb_concern, "No Concern level selected");
                errorcount++;
            }
            if (string.IsNullOrEmpty(tb_schoolyear.Text))
            {
                errorProvider1.SetError(tb_schoolyear, "School year is empty");
                errorcount++;
            }

            if (string.IsNullOrEmpty(rtb_procedure.Text))
            {
                errorProvider1.SetError(rtb_procedure, "Procedure is empty");
                errorcount++;
            }

        }

        private void cmb_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_status.SelectedIndex == 0)
            {
                rtb_action.Enabled = false;
            } else
            {
                rtb_action.Enabled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            UpdateCase_form_Load(sender, e);
        }

        public UpdateCase_form(string editcaseid, string editstatus, string editaction, string username, string editschoolyear, string editconcernlevel, string editprocedure)
        {
            InitializeComponent();
            this.editstatus = editstatus;
            this.editaction = editaction;
            this.editcaseid = editcaseid;
            this.username = username;
            this.editprocedure = editprocedure;
            this.editschoolyear = editschoolyear;
            this.editprocedure = editprocedure;
            this.editconcernlevel = editconcernlevel;
        }

        private void UpdateCase_form_Load(object sender, EventArgs e)
        {
            if(editstatus == "On Going")
            {
                cmb_status.SelectedIndex = 0;
                rtb_action.Enabled = false;
            } else
            {
                cmb_status.SelectedIndex = 1;
                rtb_action.Enabled = true;
            }

            rtb_procedure.Text = editprocedure;
            cmb_concern.SelectedItem = editconcernlevel;
            tb_schoolyear.Text = editschoolyear;
            rtb_action.Text = editaction;
            lb_caseid.Text = editcaseid;

        }
    }
}
