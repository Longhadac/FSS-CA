namespace AutoCA
{
    partial class AutoCA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoCA));
            this.label1 = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbGroup = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ckbAutoClose = new System.Windows.Forms.CheckBox();
            this.txbAffected = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbAssignee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbReportUserLevel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.txbReportName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbReportUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.calToDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.calFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            // 
            // txbUserName
            // 
            this.txbUserName.Location = new System.Drawing.Point(94, 28);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(106, 20);
            this.txbUserName.TabIndex = 1;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(94, 54);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(106, 20);
            this.txbPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(410, 36);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(106, 20);
            this.txbName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name (suggest)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txbUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txbPassword);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SignIn Information";
            // 
            // txbGroup
            // 
            this.txbGroup.Location = new System.Drawing.Point(410, 66);
            this.txbGroup.Name = "txbGroup";
            this.txbGroup.Size = new System.Drawing.Size(106, 20);
            this.txbGroup.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Group (level)";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(20, 129);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(215, 23);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "Select File And Create CA";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Solution for closing ticket";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(221, 216);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(295, 20);
            this.txtResult.TabIndex = 11;
            this.txtResult.Text = "Đã thực hiện.";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(20, 168);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(215, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close Chrome";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ckbAutoClose
            // 
            this.ckbAutoClose.AutoSize = true;
            this.ckbAutoClose.Checked = true;
            this.ckbAutoClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbAutoClose.Location = new System.Drawing.Point(321, 168);
            this.ckbAutoClose.Name = "ckbAutoClose";
            this.ckbAutoClose.Size = new System.Drawing.Size(74, 17);
            this.ckbAutoClose.TabIndex = 13;
            this.ckbAutoClose.Text = "AutoClose";
            this.ckbAutoClose.UseVisualStyleBackColor = true;
            // 
            // txbAffected
            // 
            this.txbAffected.Location = new System.Drawing.Point(489, 101);
            this.txbAffected.Name = "txbAffected";
            this.txbAffected.Size = new System.Drawing.Size(27, 20);
            this.txbAffected.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Affected End User Position";
            // 
            // txbAssignee
            // 
            this.txbAssignee.Location = new System.Drawing.Point(489, 132);
            this.txbAssignee.Name = "txbAssignee";
            this.txbAssignee.Size = new System.Drawing.Size(27, 20);
            this.txbAssignee.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(318, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Assignee Position";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbReportUserLevel);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.btnGenerateReport);
            this.groupBox2.Controls.Add(this.txbReportName);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txbReportUserName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.calToDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.calFromDate);
            this.groupBox2.Location = new System.Drawing.Point(20, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 127);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report";
            // 
            // txbReportUserLevel
            // 
            this.txbReportUserLevel.Location = new System.Drawing.Point(360, 70);
            this.txbReportUserLevel.Name = "txbReportUserLevel";
            this.txbReportUserLevel.Size = new System.Drawing.Size(121, 20);
            this.txbReportUserLevel.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(287, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "User Level";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(89, 96);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(392, 23);
            this.btnGenerateReport.TabIndex = 10;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // txbReportName
            // 
            this.txbReportName.Location = new System.Drawing.Point(360, 45);
            this.txbReportName.Name = "txbReportName";
            this.txbReportName.Size = new System.Drawing.Size(121, 20);
            this.txbReportName.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(287, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(287, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "UserName";
            // 
            // txbReportUserName
            // 
            this.txbReportUserName.Location = new System.Drawing.Point(360, 19);
            this.txbReportUserName.Name = "txbReportUserName";
            this.txbReportUserName.Size = new System.Drawing.Size(121, 20);
            this.txbReportUserName.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "To Date";
            // 
            // calToDate
            // 
            this.calToDate.Location = new System.Drawing.Point(89, 47);
            this.calToDate.Name = "calToDate";
            this.calToDate.Size = new System.Drawing.Size(164, 20);
            this.calToDate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "From Date";
            // 
            // calFromDate
            // 
            this.calFromDate.Location = new System.Drawing.Point(89, 19);
            this.calFromDate.Name = "calFromDate";
            this.calFromDate.Size = new System.Drawing.Size(164, 20);
            this.calFromDate.TabIndex = 0;
            // 
            // AutoCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 410);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txbAssignee);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbAffected);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ckbAutoClose);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txbGroup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoCA";
            this.Text = "AutoCA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox ckbAutoClose;
        private System.Windows.Forms.TextBox txbAffected;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbAssignee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.TextBox txbReportName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbReportUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker calToDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker calFromDate;
        private System.Windows.Forms.TextBox txbReportUserLevel;
        private System.Windows.Forms.Label label12;
    }
}

