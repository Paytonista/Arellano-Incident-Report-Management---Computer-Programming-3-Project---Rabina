using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cs311_rabina_net_framework
{
    public partial class NewStudent_form : Form
    {


        Class1 newstudent = new Class1("localhost", "cs311c", "kenneth", "rabina");

        private string username;
        private string selectedCourseCode;
        private string selectedCourseName;
        private DataTable courseDataTable;
        public event EventHandler DataAdded;

        public NewStudent_form(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        int errorcount;
        string selectedlevel;

        private void validate_form()
        {
            errorProvider1.Clear();
            errorcount = 0;
            try
            {
                DataTable dt = newstudent.GetData("SELECT * FROM TABLE_STUDENTS WHERE studentID = '" + tb_studentid.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(tb_studentid, "Student ID already used");
                    errorcount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validate student id", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void button1_Click(object sender, EventArgs e)
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
                errorcount = 0;
                errorProvider1.Clear();
                DialogResult dr = MessageBox.Show("Are you sure you want to add this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        // Get the selected course code
                        string selectedCourseCode = cmb_course.SelectedValue != null ? cmb_course.SelectedValue.ToString() : "";

                        DataRow[] selectedRows = null; // Declare selectedRows here

                        // Retrieve the corresponding row from the DataTable
                        if (rb_college.Checked  )
                        {
                            selectedRows = courseDataTable.Select($"coursecode = '{selectedCourseCode}'");
                        }

                        else if (rb_seniorhigh.Checked)
                        {
                            selectedRows = courseDataTable.Select($"strandcode = '{selectedCourseCode}'");
                        }

                       


                        
                            string courseDescription = null;
                            if (rb_college.Checked)
                            {
                                courseDescription = selectedRows[0]["coursecode"].ToString();
                                newstudent.executeSQL($"INSERT INTO TABLE_STUDENTS(studentID, lastname, firstname, middlename, level, [strand/course]) VALUES('{tb_studentid.Text}', '{tb_lastname.Text}', '{tb_firstname.Text}', '{tb_middlename.Text}', '{selectedlevel}', '{courseDescription}')");

                            }
                            else if (rb_seniorhigh.Checked) {

                                courseDescription = selectedRows[0]["strandcode"].ToString();
                                newstudent.executeSQL($"INSERT INTO TABLE_STUDENTS(studentID, lastname, firstname, middlename, level, [strand/course]) VALUES('{tb_studentid.Text}', '{tb_lastname.Text}', '{tb_firstname.Text}', '{tb_middlename.Text}', '{selectedlevel}', '{courseDescription}')");

                            }
                            else if (rb_elem.Checked) {
                            
                                string elem = "N/A";
                                newstudent.executeSQL($"INSERT INTO TABLE_STUDENTS(studentID, lastname, firstname, middlename, level, [strand/course]) VALUES('{tb_studentid.Text}', '{tb_lastname.Text}', '{tb_firstname.Text}', '{tb_middlename.Text}', '{selectedlevel}', '{elem}')");

                            } 
                                else if (rb_juniorhigh.Checked) {
                                string elem = "N/A";
                                newstudent.executeSQL($"INSERT INTO TABLE_STUDENTS(studentID, lastname, firstname, middlename, level, [strand/course]) VALUES('{tb_studentid.Text}', '{tb_lastname.Text}', '{tb_firstname.Text}', '{tb_middlename.Text}', '{selectedlevel}', '{elem}')");
                            }

                            // Get the second column value (description)


                            // Insert the student data into TABLE_STUDENTS, including the course description
                            

                            if (newstudent.rowAffected > 0)
                            {
                                // Log the action
                                DataAdded?.Invoke(this, EventArgs.Empty);
                                newstudent.executeSQL($"INSERT INTO TABLE_LOGS(datelog, timelog, action, module, id, performedby) VALUES('{DateTime.Now.ToShortDateString()}', '{DateTime.Now.ToShortTimeString()}', 'ADD', 'STUDENT MANAGEMENT', '{tb_studentid.Text}', '{username}')");

                                MessageBox.Show("New student added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void rb_college_CheckedChanged(object sender, EventArgs e)
        {
            cmb_course.Enabled = true;


            try
            {
                // Fetch data from the TABLE_COURSES and get coursecode and description
                courseDataTable = newstudent.GetData("SELECT coursecode, description FROM TABLE_COURSES");

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
                courseDataTable = newstudent.GetData("SELECT strandcode, description FROM TABLE_STRANDS");

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
            tb_studentid.Clear();
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
            // Clear the DataSource before modifying the Items collection
            cmb_course.DataSource = null;

            // Add custom items
            cmb_course.Items.Clear();   // Optional, to ensure the ComboBox is empty
            cmb_course.Items.Add("N/A");
            cmb_course.SelectedIndex = 0;

            // Disable the ComboBox
            cmb_course.Enabled = false;
        }

        private void NewStudent_form_Load(object sender, EventArgs e)
        {
            try
            {
                // Fetch data from the TABLE_COURSES and get coursecode and description
                courseDataTable = newstudent.GetData("SELECT strandcode, description FROM TABLE_STRANDS");

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
    }



    }
