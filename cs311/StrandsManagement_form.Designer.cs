namespace cs311_rabina_net_framework
{
    partial class StrandsManagement_form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_refresh2 = new System.Windows.Forms.Button();
            this.btn_delete2 = new System.Windows.Forms.Button();
            this.btn_update2 = new System.Windows.Forms.Button();
            this.btn_add2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tb_search2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_refresh2
            // 
            this.btn_refresh2.BackColor = System.Drawing.Color.Blue;
            this.btn_refresh2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_refresh2.Location = new System.Drawing.Point(45, 308);
            this.btn_refresh2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_refresh2.Name = "btn_refresh2";
            this.btn_refresh2.Size = new System.Drawing.Size(125, 68);
            this.btn_refresh2.TabIndex = 29;
            this.btn_refresh2.Text = "&Refresh";
            this.btn_refresh2.UseVisualStyleBackColor = false;
            this.btn_refresh2.Click += new System.EventHandler(this.btn_refresh2_Click);
            // 
            // btn_delete2
            // 
            this.btn_delete2.BackColor = System.Drawing.Color.Blue;
            this.btn_delete2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_delete2.Location = new System.Drawing.Point(45, 244);
            this.btn_delete2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_delete2.Name = "btn_delete2";
            this.btn_delete2.Size = new System.Drawing.Size(125, 68);
            this.btn_delete2.TabIndex = 28;
            this.btn_delete2.Text = "&Delete";
            this.btn_delete2.UseVisualStyleBackColor = false;
            this.btn_delete2.Click += new System.EventHandler(this.btn_delete2_Click);
            // 
            // btn_update2
            // 
            this.btn_update2.BackColor = System.Drawing.Color.Blue;
            this.btn_update2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_update2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_update2.Location = new System.Drawing.Point(45, 178);
            this.btn_update2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_update2.Name = "btn_update2";
            this.btn_update2.Size = new System.Drawing.Size(125, 68);
            this.btn_update2.TabIndex = 27;
            this.btn_update2.Text = "&Update";
            this.btn_update2.UseVisualStyleBackColor = false;
            this.btn_update2.Click += new System.EventHandler(this.btn_update2_Click);
            // 
            // btn_add2
            // 
            this.btn_add2.BackColor = System.Drawing.Color.Blue;
            this.btn_add2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_add2.Location = new System.Drawing.Point(45, 111);
            this.btn_add2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btn_add2.Name = "btn_add2";
            this.btn_add2.Size = new System.Drawing.Size(125, 68);
            this.btn_add2.TabIndex = 26;
            this.btn_add2.Text = "&Add";
            this.btn_add2.UseVisualStyleBackColor = false;
            this.btn_add2.Click += new System.EventHandler(this.btn_add2_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(169, 111);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(648, 263);
            this.dataGridView2.TabIndex = 30;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // tb_search2
            // 
            this.tb_search2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_search2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search2.Location = new System.Drawing.Point(169, 66);
            this.tb_search2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tb_search2.Name = "tb_search2";
            this.tb_search2.Size = new System.Drawing.Size(648, 38);
            this.tb_search2.TabIndex = 31;
            this.tb_search2.TextChanged += new System.EventHandler(this.tb_search2_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.BackgroundImage = global::cs311_rabina_net_framework.Properties.Resources.Delete_Red_X_Button_PNG_Pic;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(803, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(46, 42);
            this.panel1.TabIndex = 32;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // StrandsManagement_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::cs311_rabina_net_framework.Properties.Resources.Blue_Modern_Project_Presentation__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(861, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tb_search2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btn_refresh2);
            this.Controls.Add(this.btn_delete2);
            this.Controls.Add(this.btn_update2);
            this.Controls.Add(this.btn_add2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StrandsManagement_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Strands Management";
            this.Load += new System.EventHandler(this.StrandsManagement_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_refresh2;
        private System.Windows.Forms.Button btn_delete2;
        private System.Windows.Forms.Button btn_update2;
        private System.Windows.Forms.Button btn_add2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox tb_search2;
        private System.Windows.Forms.Panel panel1;
    }
}