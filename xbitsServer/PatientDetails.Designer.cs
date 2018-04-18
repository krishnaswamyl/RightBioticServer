namespace xbitsServer
{
    partial class PatientDetails
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
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonMarging = new System.Windows.Forms.Button();
            this.textBoxBott = new System.Windows.Forms.TextBox();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.textBoxTop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPid = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxSex = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxDocName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxPname = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonEmail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxToemail = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSelect
            // 
            this.buttonSelect.BackColor = System.Drawing.SystemColors.Info;
            this.buttonSelect.Location = new System.Drawing.Point(300, 410);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(138, 36);
            this.buttonSelect.TabIndex = 16;
            this.buttonSelect.Text = "Select File to Print";
            this.buttonSelect.UseVisualStyleBackColor = false;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Salmon;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(603, 410);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(89, 36);
            this.buttonExit.TabIndex = 17;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(847, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(340, 415);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(193, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Patient ID:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.textBoxPid);
            this.panel1.Controls.Add(this.textBoxAge);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.comboBoxSex);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.textBoxDocName);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.textBoxPname);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 317);
            this.panel1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.buttonMarging);
            this.groupBox1.Controls.Add(this.textBoxBott);
            this.groupBox1.Controls.Add(this.textBoxRight);
            this.groupBox1.Controls.Add(this.textBoxLeft);
            this.groupBox1.Controls.Add(this.textBoxTop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(631, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 188);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PDF Marging Settings";
            // 
            // buttonMarging
            // 
            this.buttonMarging.Location = new System.Drawing.Point(88, 146);
            this.buttonMarging.Name = "buttonMarging";
            this.buttonMarging.Size = new System.Drawing.Size(75, 23);
            this.buttonMarging.TabIndex = 15;
            this.buttonMarging.Text = "Save";
            this.buttonMarging.UseVisualStyleBackColor = true;
            this.buttonMarging.Click += new System.EventHandler(this.buttonMargin_Click);
            // 
            // textBoxBott
            // 
            this.textBoxBott.Location = new System.Drawing.Point(98, 118);
            this.textBoxBott.Name = "textBoxBott";
            this.textBoxBott.Size = new System.Drawing.Size(57, 22);
            this.textBoxBott.TabIndex = 14;
            // 
            // textBoxRight
            // 
            this.textBoxRight.Location = new System.Drawing.Point(98, 90);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(57, 22);
            this.textBoxRight.TabIndex = 13;
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.Location = new System.Drawing.Point(98, 62);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(57, 22);
            this.textBoxLeft.TabIndex = 12;
            // 
            // textBoxTop
            // 
            this.textBoxTop.Location = new System.Drawing.Point(98, 34);
            this.textBoxTop.Name = "textBoxTop";
            this.textBoxTop.Size = new System.Drawing.Size(57, 22);
            this.textBoxTop.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "BOTTOM:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "RIGHT:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "LEFT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "TOP:";
            // 
            // textBoxPid
            // 
            this.textBoxPid.Enabled = false;
            this.textBoxPid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPid.Location = new System.Drawing.Point(292, 13);
            this.textBoxPid.Name = "textBoxPid";
            this.textBoxPid.Size = new System.Drawing.Size(243, 29);
            this.textBoxPid.TabIndex = 1;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAge.Location = new System.Drawing.Point(292, 57);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(68, 29);
            this.textBoxAge.TabIndex = 2;
            this.textBoxAge.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(96, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Enter Patient\'s Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(112, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "Enter Patient\'s Age:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(292, 148);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(238, 31);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(366, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Years";
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.Items.AddRange(new object[] {
            "MALE",
            "FEMALE",
            "OTHERS"});
            this.comboBoxSex.Location = new System.Drawing.Point(292, 101);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(121, 32);
            this.comboBoxSex.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(181, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 24);
            this.label11.TabIndex = 1;
            this.label11.Text = "Select Sex:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(54, 246);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(232, 24);
            this.label12.TabIndex = 1;
            this.label12.Text = "Referal Doctor\'s Name: Dr.";
            // 
            // textBoxDocName
            // 
            this.textBoxDocName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDocName.Location = new System.Drawing.Point(292, 241);
            this.textBoxDocName.Name = "textBoxDocName";
            this.textBoxDocName.Size = new System.Drawing.Size(498, 29);
            this.textBoxDocName.TabIndex = 6;
            this.textBoxDocName.Text = "Doctor Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(22, 151);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(264, 24);
            this.label13.TabIndex = 1;
            this.label13.Text = "Select Sample collection Date:";
            // 
            // textBoxPname
            // 
            this.textBoxPname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPname.Location = new System.Drawing.Point(292, 197);
            this.textBoxPname.Name = "textBoxPname";
            this.textBoxPname.Size = new System.Drawing.Size(498, 29);
            this.textBoxPname.TabIndex = 5;
            this.textBoxPname.Text = "Patient Name";
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.OliveDrab;
            this.buttonPrint.Location = new System.Drawing.Point(444, 410);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(138, 36);
            this.buttonPrint.TabIndex = 6;
            this.buttonPrint.Text = "PRINT";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonEmail
            // 
            this.buttonEmail.BackColor = System.Drawing.SystemColors.Info;
            this.buttonEmail.Location = new System.Drawing.Point(156, 410);
            this.buttonEmail.Name = "buttonEmail";
            this.buttonEmail.Size = new System.Drawing.Size(138, 36);
            this.buttonEmail.TabIndex = 10;
            this.buttonEmail.Text = "Send by E-mail";
            this.buttonEmail.UseVisualStyleBackColor = false;
            this.buttonEmail.Click += new System.EventHandler(this.buttonEmail_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Gmail User Name:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxUserName.Location = new System.Drawing.Point(157, 343);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(257, 23);
            this.textBoxUserName.TabIndex = 7;
            this.textBoxUserName.Text = "abhi@abhisystems.com";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(68, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxPassword.Location = new System.Drawing.Point(157, 376);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(187, 23);
            this.textBoxPassword.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(431, 346);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 17);
            this.label14.TabIndex = 10;
            this.label14.Text = "To E-mail Address:";
            // 
            // textBoxToemail
            // 
            this.textBoxToemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxToemail.Location = new System.Drawing.Point(583, 343);
            this.textBoxToemail.Name = "textBoxToemail";
            this.textBoxToemail.Size = new System.Drawing.Size(257, 23);
            this.textBoxToemail.TabIndex = 8;
            this.textBoxToemail.Text = "krishnaswamy@microlab.co.in";
            // 
            // PatientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 458);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxToemail);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonEmail);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.panel1);
            this.Name = "PatientDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter PatientDetails";
            this.Load += new System.EventHandler(this.PatientDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxPid;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDocName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxPname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonMarging;
        private System.Windows.Forms.TextBox textBoxBott;
        private System.Windows.Forms.TextBox textBoxRight;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxToemail;
    }
}