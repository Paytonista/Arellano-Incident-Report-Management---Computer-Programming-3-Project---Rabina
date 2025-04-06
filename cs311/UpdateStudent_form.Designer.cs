namespace cs311_rabina_net_framework
{
    partial class UpdateStudent_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rb_college = new System.Windows.Forms.RadioButton();
            this.rb_seniorhigh = new System.Windows.Forms.RadioButton();
            this.cmb_course = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_middlename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_firstname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_lastname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_studentid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rb_juniorhigh = new System.Windows.Forms.RadioButton();
            this.rb_elem = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Centaur", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(165, 310);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 54);
            this.btn_delete.TabIndex = 32;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Centaur", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(70, 310);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 54);
            this.btn_save.TabIndex = 31;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Centaur", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(72, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 23);
            this.label7.TabIndex = 30;
            this.label7.Text = "Update Student";
            // 
            // rb_college
            // 
            this.rb_college.AutoSize = true;
            this.rb_college.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_college.Location = new System.Drawing.Point(137, 201);
            this.rb_college.Name = "rb_college";
            this.rb_college.Size = new System.Drawing.Size(76, 24);
            this.rb_college.TabIndex = 29;
            this.rb_college.Text = "College";
            this.rb_college.UseVisualStyleBackColor = true;
            this.rb_college.CheckedChanged += new System.EventHandler(this.rb_college_CheckedChanged);
            // 
            // rb_seniorhigh
            // 
            this.rb_seniorhigh.AutoSize = true;
            this.rb_seniorhigh.Checked = true;
            this.rb_seniorhigh.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_seniorhigh.Location = new System.Drawing.Point(28, 201);
            this.rb_seniorhigh.Name = "rb_seniorhigh";
            this.rb_seniorhigh.Size = new System.Drawing.Size(105, 24);
            this.rb_seniorhigh.TabIndex = 28;
            this.rb_seniorhigh.TabStop = true;
            this.rb_seniorhigh.Text = "Senior High";
            this.rb_seniorhigh.UseVisualStyleBackColor = true;
            this.rb_seniorhigh.CheckedChanged += new System.EventHandler(this.rb_seniorhigh_CheckedChanged);
            // 
            // cmb_course
            // 
            this.cmb_course.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_course.FormattingEnabled = true;
            this.cmb_course.Items.AddRange(new object[] {
            "ABM",
            "STEM",
            "HUMMS"});
            this.cmb_course.Location = new System.Drawing.Point(165, 261);
            this.cmb_course.Name = "cmb_course";
            this.cmb_course.Size = new System.Drawing.Size(121, 28);
            this.cmb_course.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "Course/Strand: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Level: ";
            // 
            // tb_middlename
            // 
            this.tb_middlename.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_middlename.Location = new System.Drawing.Point(165, 145);
            this.tb_middlename.Name = "tb_middlename";
            this.tb_middlename.Size = new System.Drawing.Size(121, 27);
            this.tb_middlename.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Middle Name: ";
            // 
            // tb_firstname
            // 
            this.tb_firstname.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_firstname.Location = new System.Drawing.Point(165, 117);
            this.tb_firstname.Name = "tb_firstname";
            this.tb_firstname.Size = new System.Drawing.Size(121, 27);
            this.tb_firstname.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "First Name: ";
            // 
            // tb_lastname
            // 
            this.tb_lastname.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_lastname.Location = new System.Drawing.Point(165, 89);
            this.tb_lastname.Name = "tb_lastname";
            this.tb_lastname.Size = new System.Drawing.Size(121, 27);
            this.tb_lastname.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Last Name: ";
            // 
            // tb_studentid
            // 
            this.tb_studentid.Enabled = false;
            this.tb_studentid.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_studentid.Location = new System.Drawing.Point(165, 61);
            this.tb_studentid.Name = "tb_studentid";
            this.tb_studentid.Size = new System.Drawing.Size(121, 27);
            this.tb_studentid.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Student ID:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // rb_juniorhigh
            // 
            this.rb_juniorhigh.AutoSize = true;
            this.rb_juniorhigh.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_juniorhigh.Location = new System.Drawing.Point(138, 231);
            this.rb_juniorhigh.Name = "rb_juniorhigh";
            this.rb_juniorhigh.Size = new System.Drawing.Size(104, 24);
            this.rb_juniorhigh.TabIndex = 34;
            this.rb_juniorhigh.Text = "Junior High";
            this.rb_juniorhigh.UseVisualStyleBackColor = true;
            this.rb_juniorhigh.CheckedChanged += new System.EventHandler(this.rb_juniorhigh_CheckedChanged);
            // 
            // rb_elem
            // 
            this.rb_elem.AutoSize = true;
            this.rb_elem.Font = new System.Drawing.Font("Centaur", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_elem.Location = new System.Drawing.Point(28, 231);
            this.rb_elem.Name = "rb_elem";
            this.rb_elem.Size = new System.Drawing.Size(99, 24);
            this.rb_elem.TabIndex = 33;
            this.rb_elem.Text = "Elementary";
            this.rb_elem.UseVisualStyleBackColor = true;
            this.rb_elem.CheckedChanged += new System.EventHandler(this.rb_elem_CheckedChanged);
            // 
            // UpdateStudent_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cs311_rabina_net_framework.Properties.Resources._6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(301, 401);
            this.Controls.Add(this.rb_juniorhigh);
            this.Controls.Add(this.rb_elem);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rb_college);
            this.Controls.Add(this.rb_seniorhigh);
            this.Controls.Add(this.cmb_course);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_middlename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_firstname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_lastname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_studentid);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UpdateStudent_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Student";
            this.Load += new System.EventHandler(this.UpdateStudent_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rb_college;
        private System.Windows.Forms.RadioButton rb_seniorhigh;
        private System.Windows.Forms.ComboBox cmb_course;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_middlename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_firstname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_lastname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_studentid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.RadioButton rb_juniorhigh;
        private System.Windows.Forms.RadioButton rb_elem;
    }
}