using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs311_rabina_net_framework
{
    public partial class NewCase_form : Form
    {
        private string studentid, username;
        private int errorcount;
        string violationcounts;
        public event EventHandler DataAdded;

        Class1 connection = new Class1("localhost", "cs311c", "kenneth", "rabina");
        public NewCase_form(string username, string studentid)
        {
            InitializeComponent();
            this.studentid = studentid;
            this.username = username;
        }

        private void PopulateComboBox()
        {
            try
            {
                // Step 1: Fetch data from the database table
                DataTable dt = connection.GetData("SELECT code FROM TABLE_VIOLATIONS");

                

                // Step 3: Loop through the fetched rows and add each item to the ComboBox
                foreach (DataRow row in dt.Rows)
                {
                    // Assuming 'coursename' is the column you want to add to the ComboBox
                    cmb_violationcode.Items.Add(row["code"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Populating ComboBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validate_form()
        {
            errorcount = 0;
            errorProvider1.Clear();
            if (cmb_violationcode.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmb_violationcode, "No Violation code selected");
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            validate_form();

            if (errorcount == 0)
            {
                errorcount = 0;
                errorProvider1.Clear();
                DialogResult dr = MessageBox.Show("Are you sure you want to add this case?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        // Get the selected violation code
                        string violationCode = cmb_violationcode.SelectedItem.ToString();

                        // Check how many times the violation code exists for this student ID
                        DataTable checkDt = connection.GetData($"SELECT COUNT(*) FROM TABLE_CASES WHERE studentID = '{studentid}' AND violationcode = '{violationCode}'");

                        // Get the count
                        int count = checkDt.Rows.Count > 0 ? Convert.ToInt32(checkDt.Rows[0][0]) : 0;

                        // Inform the user about the count
                        
                        
                        if (count == 0)
                        {
                            violationcounts = "First Offense";
                        }
                        else if (count == 1)
                        {
                            violationcounts = "Second Offense";
                        }
                        else if (count >= 2) {
                            violationcounts = "Repeat Offense";

                        }




                        // Proceed with the insertion regardless of the existing count
                        string query = $"INSERT INTO TABLE_CASES (caseid, studentID,  schoolyear, concernlevel, [procedure],  violationcode, violationcount, status, action, createdby, datecreated) VALUES ('{lb_caseid.Text}', '{studentid}', '{tb_schoolyear.Text}', '{cmb_concern.SelectedItem}', '{rtb_procedure.Text}' , '{violationCode}', '{violationcounts}', 'On Going', '', '{username}', '{DateTime.Now.ToShortDateString()}')";
                        connection.executeSQL(query);

                        if (connection.rowAffected > 0)
                        {
                            DataAdded?.Invoke(this, EventArgs.Empty);
                            connection.executeSQL("INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "','ADD','CASES MANAGEMENT','" + lb_caseid.Text + "','" + username + "')");
                            MessageBox.Show("New Case added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btn_delete_Click(object sender, EventArgs e)
        {
            NewCase_form_Load(sender, e);
        }

        private void cmb_violationcode_SelectedIndexChanged(object sender, EventArgs e)
        {

            string violationCode = cmb_violationcode.SelectedItem.ToString();

            DataTable dt = connection.GetData($"SELECT description  FROM TABLE_VIOLATIONS WHERE code = '{violationCode}' ORDER BY code");
            string violationDescription = dt.Rows[0]["description"].ToString();

            lb_description.Text = violationDescription;

            // Check how many times the violation code exists for this student ID
            DataTable checkDt = connection.GetData($"SELECT COUNT(*) FROM TABLE_CASES WHERE studentID = '{studentid}' AND violationcode = '{violationCode}'");

            // Get the count
            int count = checkDt.Rows.Count > 0 ? Convert.ToInt32(checkDt.Rows[0][0]) : 0;

            if (count == 0)
            {
                lb_count.Text = "First Offense";
            }
            else if (count == 1)
            {
                lb_count.Text = "Second Offense";
            }
            else if (count == 2)
            {
                lb_count.Text = "Repeat Offense";

            }
            else if (count >= 3)
            {
                lb_count.Text = "Repeat Offense";

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void NewCase_form_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            
            string timestamp = now.ToString("yyyyMMddHHmmss");
            lb_caseid.Text = "caseid-" + timestamp;
            lb_studentid.Text = studentid;
            PopulateComboBox();
        }
    }
}
