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
            this.groupBox1.SuspendLayout();
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
            // AutoCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 265);
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
    }
}

