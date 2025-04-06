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
    public partial class UpdateStrand_form : Form
    {

        Class1 updatestrand = new Class1("localhost", "cs311c", "kenneth", "rabina");
        string editstrandcode, editstranddescription, username;
        int errorcount;
        public event EventHandler DataAdded;


        public UpdateStrand_form(string editstrandcode, string editstranddescription, string username)
        {
            InitializeComponent();
            this.editstrandcode = editstrandcode;
            this.editstranddescription = editstranddescription;
            this.username = username;
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            tb_description.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            validate_form();
            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this strand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updatestrand.executeSQL("UPDATE TABLE_STRANDS SET description = '" + tb_description.Text + "' WHERE strandcode = '" + tb_strandcode.Text + "'");
                        if (updatestrand.rowAffected > 0)
                        {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            updatestrand.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','UPDATE','STRAND MANAGEMENT','" + tb_strandcode.Text + "','" + username + "')");
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

        private void UpdateStrand_form_Load(object sender, EventArgs e)
        {
            tb_strandcode.Text = editstrandcode;
            tb_description.Text = editstranddescription;
        }

        private void validate_form()
        {
            errorProvider1.Clear();
            errorcount = 0;



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


    }
}
