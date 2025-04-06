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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cs311_rabina_net_framework
{
    public partial class UpdateStudent_form : Form
    {
        string editstudentid, editlastname, editfirstname, editmiddlename, editlevel, editcoursestrand ,selectedlevel, username;
        private string selectedCourseCode;
        private string selectedCourseName;
        private DataTable courseDataTable;
        public event EventHandler DataAdded;
        Class1 updatestudent = new Class1("localhost", "cs311c", "kenneth", "rabina");
        int errorcount;



        public UpdateStudent_form(string editstudentid, string editlastname, string editfirstname, string editmiddlename, string editlevel, string editcoursestrand, string username)
        {
            InitializeComponent();
            this.editstudentid = editstudentid;
            this.editlastname = editlastname;
            this.editfirstname = editfirstname;
            this.editmiddlename = editmiddlename;
            this.editlevel = editlevel;
            
            this.editcoursestrand = editcoursestrand;
            this.username = username;


        }

        
        private void UpdateStudent_form_Load(object sender, EventArgs e)
        {
            tb_studentid.Text = editstudentid;
            tb_lastname.Text = editlastname;
            tb_firstname.Text = editfirstname;
            tb_middlename.Text = editmiddlename;
            if(editlevel == "college")
            {
                rb_college.Checked = true;
                try
                {
                    // Fetch data from the TABLE_COURSES and get coursecode and description
                    courseDataTable = updatestudent.GetData("SELECT coursecode, description FROM TABLE_COURSES");

                    // Bind the ComboBox to the DataTable
                    cmb_course.DataSource = courseDataTable;
                    cmb_course.DisplayMember = "description";
                    cmb_course.ValueMember = "coursecode";
                    cmb_course.SelectedValue = editcoursestrand;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error fetching courses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (editlevel == "senior high")
            {
                rb_seniorhigh.Checked = true;
                try
                {
                    // Fetch data from the TABLE_COURSES and get coursecode and description
                    courseDataTable = updatestudent.GetData("SELECT strandcode, description FROM TABLE_STRANDS");

                    // Bind the ComboBox to the DataTable
                    cmb_course.DataSource = courseDataTable;
                    cmb_course.DisplayMember = "description";
                    cmb_course.ValueMember = "strandcode";
                    cmb_course.SelectedValue = editcoursestrand;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error fetching courses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (editlevel == "junior high")
            {
                rb_juniorhigh.Checked= true;
            }
            else
            {
                rb_elem.Checked = true;
            }

            cmb_course.SelectedItem = editcoursestrand;

            


        }

       

        private void validate_form()
        {
            errorProvider1.Clear();
            errorcount = 0;
            
            

            if (string.IsNullOrEmpty(tb_studentid.Text))
            {
                errorProvider1.SetError(tb_studentid, "Student ID is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(tb_firstname.Text))
            {
                errorProvider1.SetError(tb_firstname, "First Name is empty");
                errorcount++;
            }
            if (string.IsNullOrEmpty(tb_lastname.Text))
            {
                errorProvider1.SetError(tb_lastname, "Last name is empty");
                errorcount++;
            }

            /*
            if (tb_password.TextLength < 6)
            {
                errorProvider1.SetError(tb_password, "Password must be atleast 6 characters");
                errorcount++;
            }
            */






            if (cmb_course.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmb_course, "Select a course");
                errorcount++;
            }
        }
        private void rb_elem_CheckedChanged(object sender, EventArgs e)
        {
            cmb_course.DataSource = null;

            // Add custom items
            cmb_course.Items.Clear();   // Optional, to ensure the ComboBox is empty
            cmb_course.Items.Add("N/A");
            cmb_course.SelectedIndex = 0;

            // Disable the ComboBox
            cmb_course.Enabled = false;
        }

        private void rb_juniorhigh_CheckedChanged(object sender, EventArgs e)
        {
            cmb_course.DataSource = null;

            // Add custom items
            cmb_course.Items.Clear();   // Optional, to ensure the ComboBox is empty
            cmb_course.Items.Add("N/A");
            cmb_course.SelectedIndex = 0;

            // Disable the ComboBox
            cmb_course.Enabled = false;
        }


        private void rb_college_CheckedChanged(object sender, EventArgs e)
        {
            cmb_course.Enabled = true;


            try
            {
                // Fetch data from the TABLE_COURSES and get coursecode and description
                courseDataTable = updatestudent.GetData("SELECT coursecode, description FROM TABLE_COURSES");

                // Bind the ComboBox to the DataTable
                cmb_course.DataSource = courseDataTable;
                cmb_course.DisplayMember = "description";
                cmb_course.ValueMember = "coursecode";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error fetching courses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rb_seniorhigh_CheckedChanged(object sender, EventArgs e)
        {
            cmb_course.Enabled = true;


            try
            {
                // Fetch data from the TABLE_COURSES and get coursecode and description
                courseDataTable = updatestudent.GetData("SELECT strandcode, description FROM TABLE_STRANDS");

                // Bind the ComboBox to the DataTable
                cmb_course.DataSource = courseDataTable;
                cmb_course.DisplayMember = "description";
                cmb_course.ValueMember = "strandcode";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error fetching courses", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tb_firstname.Clear();
            tb_lastname.Clear();
            tb_middlename.Clear();
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            validate_form();

            // Determine selected level
            if (rb_college.Checked)
            {
                selectedlevel = "college";
            }
            else if (rb_seniorhigh.Checked)
            {
                selectedlevel = "senior high";
            }
            else if (rb_juniorhigh.Checked)
            {
                selectedlevel = "junior high";
            }
            else
            {
                selectedlevel = "elementary";
            }

            if (errorcount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        // Get the selected course code
                        string selectedCourseCode = cmb_course.SelectedValue != null ? cmb_course.SelectedValue.ToString() : "";

                        DataRow[] selectedRows = null; // Declare selectedRows here

                        // Retrieve the corresponding row from the DataTable
                        if (rb_college.Checked)
                        {
                            selectedRows = courseDataTable.Select($"coursecode = '{selectedCourseCode}'");
                        }
                        else if (rb_seniorhigh.Checked)
                        {
                            selectedRows = courseDataTable.Select($"strandcode = '{selectedCourseCode}'");
                        }

                      
                     

                        
                            // Get the second column value (description)
                            string courseDescription = null;
                            if (rb_college.Checked)
                            {
                                courseDescription = selectedRows[0]["coursecode"].ToString();
                                updatestudent.executeSQL($"UPDATE TABLE_STUDENTS SET lastname = '{tb_lastname.Text}', firstname = '{tb_firstname.Text}', middlename = '{tb_middlename.Text}', level = '{selectedlevel}', [strand/course] = '{courseDescription}' WHERE studentid = '{tb_studentid.Text}'");
                            }
                            else if (rb_seniorhigh.Checked)
                            {

                                courseDescription = selectedRows[0]["strandcode"].ToString();
                                updatestudent.executeSQL($"UPDATE TABLE_STUDENTS SET lastname = '{tb_lastname.Text}', firstname = '{tb_firstname.Text}', middlename = '{tb_middlename.Text}', level = '{selectedlevel}', [strand/course] = '{courseDescription}' WHERE studentid = '{tb_studentid.Text}'");
                            } else
                            {
                                updatestudent.executeSQL($"UPDATE TABLE_STUDENTS SET lastname = '{tb_lastname.Text}', firstname = '{tb_firstname.Text}', middlename = '{tb_middlename.Text}', level = '{selectedlevel}', [strand/course] = 'N/A' WHERE studentid = '{tb_studentid.Text}'");
                            }

                            // Update the student data in TABLE_STUDENTS
                            

                            if (updatestudent.rowAffected > 0)
                            {
                                // Log the action
                                DataAdded?.Invoke(this, EventArgs.Empty);
                                updatestudent.executeSQL($"INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('{DateTime.Now.ToShortDateString()}', '{DateTime.Now.ToShortTimeString()}', 'UPDATE', 'STUDENT MANAGEMENT', '{tb_studentid.Text}', '{username}')");

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

    }
}

