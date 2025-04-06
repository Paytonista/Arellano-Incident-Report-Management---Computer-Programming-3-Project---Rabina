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
    public partial class CasesManagement_form : Form
    {
        string username, studentid;
        private int row;
        

        Class1 connection = new Class1("localhost", "cs311c", "kenneth", "rabina");
        public CasesManagement_form(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void CasesManagement_form_Load(object sender, EventArgs e)
        {

        }

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

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(studentid))
            {
                NewCase_form newcase = new NewCase_form(username, studentid);
                newcase.DataAdded += new EventHandler(btn_refresh_Click);

                newcase.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a student before adding a new case.",
                        "No Student Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
            }
            
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

            lb_firstname.Text = "__________";
            lb_course.Text = "__________";
            lb_lastname.Text = "__________";
            lb_middlename.Text = "__________";
            lb_level.Text = "__________";
            studentid = null;
            tb_search.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();




        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(studentid))
            {
                string editcaseid = dataGridView1.Rows[row].Cells[0].Value.ToString();
                string editschoolyear = dataGridView1.Rows[row].Cells[2].Value.ToString();
                string editconcernlevel = dataGridView1.Rows[row].Cells[3].Value.ToString();
                string editprocedure = dataGridView1.Rows[row].Cells[4].Value.ToString();
                string editstatus = dataGridView1.Rows[row].Cells[5].Value.ToString();
                string editaction = dataGridView1.Rows[row].Cells[7].Value.ToString();
                UpdateCase_form updatecase = new UpdateCase_form(editcaseid, editstatus, editaction, username, editschoolyear, editconcernlevel, editprocedure);
                updatecase.DataAdded += new EventHandler(btn_refresh_Click);

                updatecase.ShowDialog();

            } else 
            {
                MessageBox.Show("Please select a student before updating a case.",
                        "No Student Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
            }
        }

        private void CasesManagement_form_Activated(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            studentid = tb_search.Text;
            try
            {
                DataTable dt = connection.GetData($"SELECT studentID, lastname, firstname, middlename, level, [strand/course] FROM TABLE_STUDENTS WHERE studentID = '{studentid}' ORDER BY studentID");
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lb_lastname.Text = row["lastname"].ToString();
                    lb_firstname.Text = row["firstname"].ToString();
                    lb_middlename.Text = row["middlename"].ToString();
                    lb_level.Text = row["level"].ToString();
                    lb_course.Text = row["strand/course"].ToString();

                    // Retrieve case details along with violation details
                    string query = $@"
                SELECT 
                    c.caseid, 
                    c.studentID,
                    c.schoolyear,
                    c.concernlevel,
                    c.[procedure],
                    v.code,
                    v.description,
                    v.violationtype,
                    c.status, 
                    c.violationcount, 
                    c.action, 
                    c.createdby, 
                    c.datecreated
                    
                FROM 
                    TABLE_CASES c
                JOIN 
                    TABLE_VIOLATIONS v ON c.violationcode = v.code
                WHERE 
                    c.studentID = '{studentid}'
                ORDER BY 
                    c.caseid DESC";

                    // Execute the query
                    DataTable dt2 = connection.GetData(query);
                    dataGridView1.DataSource = dt2;
                }
                else
                {
                    MessageBox.Show("No student found with the given ID.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    studentid = null;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }
    }
}
