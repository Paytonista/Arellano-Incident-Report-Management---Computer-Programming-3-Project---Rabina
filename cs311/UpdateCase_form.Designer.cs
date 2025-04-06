namespace cs311_rabina_net_framework
{
    partial class UpdateCase_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.rtb_action = new System.Windows.Forms.RichTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_caseid = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_concern = new System.Windows.Forms.ComboBox();
            this.rtb_procedure = new System.Windows.Forms.RichTextBox();
            this.tb_schoolyear = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Action";
            // 
            // cmb_status
            // 
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Items.AddRange(new object[] {
            "On Going",
            "Resolved"});
            this.cmb_status.Location = new System.Drawing.Point(127, 101);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(121, 24);
            this.cmb_status.TabIndex = 2;
            this.cmb_status.SelectedIndexChanged += new System.EventHandler(this.cmb_status_SelectedIndexChanged);
            // 
            // rtb_action
            // 
            this.rtb_action.Location = new System.Drawing.Point(30, 156);
            this.rtb_action.Name = "rtb_action";
            this.rtb_action.Size = new System.Drawing.Size(304, 221);
            this.rtb_action.TabIndex = 3;
            this.rtb_action.Text = "";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(382, 401);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Font = new System.Drawing.Font("Centaur", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(98, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 23);
            this.label7.TabIndex = 41;
            this.label7.Text = "Update Case";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(511, 401);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 42;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "Case ID: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lb_caseid
            // 
            this.lb_caseid.AutoSize = true;
            this.lb_caseid.Location = new System.Drawing.Point(124, 77);
            this.lb_caseid.Name = "lb_caseid";
            this.lb_caseid.Size = new System.Drawing.Size(44, 16);
            this.lb_caseid.TabIndex = 44;
            this.lb_caseid.Text = "label4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(458, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 69;
            this.label8.Text = "Concern Level: ";
            // 
            // cmb_concern
            // 
            this.cmb_concern.FormattingEnabled = true;
            this.cmb_concern.Items.AddRange(new object[] {
            "Prospect of Discipline",
            "Branch OSA",
            "Dean of Student Affairs",
            "Council of Discipline"});
            this.cmb_concern.Location = new System.Drawing.Point(573, 101);
            this.cmb_concern.Name = "cmb_concern";
            this.cmb_concern.Size = new System.Drawing.Size(214, 24);
            this.cmb_concern.TabIndex = 68;
            // 
            // rtb_procedure
            // 
            this.rtb_procedure.Location = new System.Drawing.Point(359, 156);
            this.rtb_procedure.Name = "rtb_procedure";
            this.rtb_procedure.Size = new System.Drawing.Size(490, 221);
            this.rtb_procedure.TabIndex = 67;
            this.rtb_procedure.Text = "";
            // 
            // tb_schoolyear
            // 
            this.tb_schoolyear.Location = new System.Drawing.Point(573, 77);
            this.tb_schoolyear.Name = "tb_schoolyear";
            this.tb_schoolyear.Size = new System.Drawing.Size(100, 22);
            this.tb_schoolyear.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(466, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 16);
            this.label9.TabIndex = 65;
            this.label9.Text = "School Year: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "Procedure for Disciplinary Action";
            // 
            // UpdateCase_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cs311_rabina_net_framework.Properties.Resources._6;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(943, 445);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_concern);
            this.Controls.Add(this.rtb_procedure);
            this.Controls.Add(this.tb_schoolyear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_caseid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.rtb_action);
            this.Controls.Add(this.cmb_status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UpdateCase_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateCase_form";
            this.Load += new System.EventHandler(this.UpdateCase_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.RichTextBox rtb_action;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lb_caseid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_concern;
        private System.Windows.Forms.RichTextBox rtb_procedure;
        private System.Windows.Forms.TextBox tb_schoolyear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
    }
}