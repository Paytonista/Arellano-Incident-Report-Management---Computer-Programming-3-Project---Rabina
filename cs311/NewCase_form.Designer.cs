namespace cs311_rabina_net_framework
{
    partial class NewCase_form
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
            this.label7 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.cmb_violationcode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_caseid = new System.Windows.Forms.Label();
            this.lb_studentid = new System.Windows.Forms.Label();
            this.lb_count = new System.Windows.Forms.Label();
            this.lb_description = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_schoolyear = new System.Windows.Forms.TextBox();
            this.rtb_procedure = new System.Windows.Forms.RichTextBox();
            this.cmb_concern = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Font = new System.Drawing.Font("Centaur", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(197, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 23);
            this.label7.TabIndex = 40;
            this.label7.Text = "Add New Case";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(195, 396);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 41;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cmb_violationcode
            // 
            this.cmb_violationcode.FormattingEnabled = true;
            this.cmb_violationcode.Location = new System.Drawing.Point(165, 138);
            this.cmb_violationcode.Name = "cmb_violationcode";
            this.cmb_violationcode.Size = new System.Drawing.Size(121, 24);
            this.cmb_violationcode.TabIndex = 44;
            this.cmb_violationcode.SelectedIndexChanged += new System.EventHandler(this.cmb_violationcode_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "Violation Code: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(162, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "On Going";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 51;
            this.label6.Text = "Status: ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(289, 396);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 53;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Case ID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Student ID: ";
            // 
            // lb_caseid
            // 
            this.lb_caseid.AutoSize = true;
            this.lb_caseid.Location = new System.Drawing.Point(162, 76);
            this.lb_caseid.Name = "lb_caseid";
            this.lb_caseid.Size = new System.Drawing.Size(70, 16);
            this.lb_caseid.TabIndex = 46;
            this.lb_caseid.Text = "_________";
            // 
            // lb_studentid
            // 
            this.lb_studentid.AutoSize = true;
            this.lb_studentid.Location = new System.Drawing.Point(162, 108);
            this.lb_studentid.Name = "lb_studentid";
            this.lb_studentid.Size = new System.Drawing.Size(70, 16);
            this.lb_studentid.TabIndex = 47;
            this.lb_studentid.Text = "_________";
            // 
            // lb_count
            // 
            this.lb_count.AutoSize = true;
            this.lb_count.Location = new System.Drawing.Point(428, 108);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(70, 16);
            this.lb_count.TabIndex = 57;
            this.lb_count.Text = "_________";
            // 
            // lb_description
            // 
            this.lb_description.AutoSize = true;
            this.lb_description.Location = new System.Drawing.Point(428, 76);
            this.lb_description.Name = "lb_description";
            this.lb_description.Size = new System.Drawing.Size(70, 16);
            this.lb_description.TabIndex = 56;
            this.lb_description.Text = "_________";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 16);
            this.label10.TabIndex = 55;
            this.label10.Text = "Violation Count: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(286, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 16);
            this.label11.TabIndex = 54;
            this.label11.Text = "Violation Description: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "Procedure for Disciplinary Action";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(58, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 59;
            this.label9.Text = "School Year: ";
            // 
            // tb_schoolyear
            // 
            this.tb_schoolyear.Location = new System.Drawing.Point(165, 203);
            this.tb_schoolyear.Name = "tb_schoolyear";
            this.tb_schoolyear.Size = new System.Drawing.Size(100, 22);
            this.tb_schoolyear.TabIndex = 60;
            // 
            // rtb_procedure
            // 
            this.rtb_procedure.Location = new System.Drawing.Point(47, 277);
            this.rtb_procedure.Name = "rtb_procedure";
            this.rtb_procedure.Size = new System.Drawing.Size(490, 96);
            this.rtb_procedure.TabIndex = 61;
            this.rtb_procedure.Text = "";
            // 
            // cmb_concern
            // 
            this.cmb_concern.FormattingEnabled = true;
            this.cmb_concern.Items.AddRange(new object[] {
            "Prospect of Discipline",
            "Branch OSA",
            "Dean of Student Affairs",
            "Council of Discipline"});
            this.cmb_concern.Location = new System.Drawing.Point(323, 167);
            this.cmb_concern.Name = "cmb_concern";
            this.cmb_concern.Size = new System.Drawing.Size(214, 24);
            this.cmb_concern.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(323, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 63;
            this.label8.Text = "Concern Level: ";
            // 
            // NewCase_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cs311_rabina_net_framework.Properties.Resources._6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(592, 446);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_concern);
            this.Controls.Add(this.rtb_procedure);
            this.Controls.Add(this.tb_schoolyear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_count);
            this.Controls.Add(this.lb_description);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_studentid);
            this.Controls.Add(this.lb_caseid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_violationcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label7);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "NewCase_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewCase_form";
            this.Load += new System.EventHandler(this.NewCase_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cmb_violationcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label lb_count;
        private System.Windows.Forms.Label lb_description;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lb_studentid;
        private System.Windows.Forms.Label lb_caseid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_schoolyear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_procedure;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_concern;
    }
}