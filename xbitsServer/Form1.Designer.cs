namespace xbitsServer
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelIPadd = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelPath = new System.Windows.Forms.LinkLabel();
            this.buttonChooseFolder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBoxComport = new System.Windows.Forms.ComboBox();
            this.radioButtonComport = new System.Windows.Forms.RadioButton();
            this.radioButtonWiFi = new System.Windows.Forms.RadioButton();
            this.buttonOpenCom = new System.Windows.Forms.Button();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.statusStrips = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonEnumComport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrips.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP Address:";
            // 
            // labelIPadd
            // 
            this.labelIPadd.AutoSize = true;
            this.labelIPadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIPadd.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelIPadd.Location = new System.Drawing.Point(239, 20);
            this.labelIPadd.Name = "labelIPadd";
            this.labelIPadd.Size = new System.Drawing.Size(111, 25);
            this.labelIPadd.TabIndex = 1;
            this.labelIPadd.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Folder to Store Data:";
            // 
            // linkLabelPath
            // 
            this.linkLabelPath.AutoSize = true;
            this.linkLabelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelPath.Location = new System.Drawing.Point(156, 141);
            this.linkLabelPath.Name = "linkLabelPath";
            this.linkLabelPath.Size = new System.Drawing.Size(31, 20);
            this.linkLabelPath.TabIndex = 7;
            this.linkLabelPath.TabStop = true;
            this.linkLabelPath.Text = "C:\\";
            this.linkLabelPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPath_LinkClicked);
            // 
            // buttonChooseFolder
            // 
            this.buttonChooseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChooseFolder.Location = new System.Drawing.Point(242, 95);
            this.buttonChooseFolder.Name = "buttonChooseFolder";
            this.buttonChooseFolder.Size = new System.Drawing.Size(105, 33);
            this.buttonChooseFolder.TabIndex = 6;
            this.buttonChooseFolder.Text = "Choose Folder";
            this.buttonChooseFolder.UseVisualStyleBackColor = true;
            this.buttonChooseFolder.Click += new System.EventHandler(this.buttonChooseFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "View Stored Data:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.richTextBox1.Location = new System.Drawing.Point(39, 271);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(838, 387);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(359, 181);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(122, 33);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "Clear Output";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Tomato;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(376, 686);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(95, 33);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "E&xit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Location = new System.Drawing.Point(376, 95);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(105, 33);
            this.buttonPrint.TabIndex = 6;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Controls.Add(this.buttonEnumComport);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.comboBoxComport);
            this.groupBox1.Controls.Add(this.radioButtonComport);
            this.groupBox1.Controls.Add(this.radioButtonWiFi);
            this.groupBox1.Controls.Add(this.buttonOpenCom);
            this.groupBox1.Controls.Add(this.buttonStartServer);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(505, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 245);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Interface:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.panel1.Location = new System.Drawing.Point(191, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 63);
            this.panel1.TabIndex = 4;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(21, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 28);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "9600";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 34);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 28);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "115200";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // comboBoxComport
            // 
            this.comboBoxComport.FormattingEnabled = true;
            this.comboBoxComport.Location = new System.Drawing.Point(191, 21);
            this.comboBoxComport.Name = "comboBoxComport";
            this.comboBoxComport.Size = new System.Drawing.Size(151, 28);
            this.comboBoxComport.TabIndex = 3;
            // 
            // radioButtonComport
            // 
            this.radioButtonComport.AutoSize = true;
            this.radioButtonComport.Location = new System.Drawing.Point(29, 75);
            this.radioButtonComport.Name = "radioButtonComport";
            this.radioButtonComport.Size = new System.Drawing.Size(110, 24);
            this.radioButtonComport.TabIndex = 2;
            this.radioButtonComport.Text = "COM PORT";
            this.radioButtonComport.UseVisualStyleBackColor = true;
            this.radioButtonComport.Click += new System.EventHandler(this.radioButtonClicked);
            // 
            // radioButtonWiFi
            // 
            this.radioButtonWiFi.AutoSize = true;
            this.radioButtonWiFi.Checked = true;
            this.radioButtonWiFi.Location = new System.Drawing.Point(29, 25);
            this.radioButtonWiFi.Name = "radioButtonWiFi";
            this.radioButtonWiFi.Size = new System.Drawing.Size(58, 24);
            this.radioButtonWiFi.TabIndex = 2;
            this.radioButtonWiFi.TabStop = true;
            this.radioButtonWiFi.Text = "WiFi";
            this.radioButtonWiFi.UseVisualStyleBackColor = true;
            this.radioButtonWiFi.Click += new System.EventHandler(this.radioButtonClicked);
            // 
            // buttonOpenCom
            // 
            this.buttonOpenCom.BackColor = System.Drawing.Color.LightGreen;
            this.buttonOpenCom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpenCom.Location = new System.Drawing.Point(191, 189);
            this.buttonOpenCom.Name = "buttonOpenCom";
            this.buttonOpenCom.Size = new System.Drawing.Size(151, 38);
            this.buttonOpenCom.TabIndex = 1;
            this.buttonOpenCom.Text = "Open Com Port";
            this.buttonOpenCom.UseVisualStyleBackColor = false;
            this.buttonOpenCom.Click += new System.EventHandler(this.buttonOpenCom_Click);
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.BackColor = System.Drawing.Color.LightBlue;
            this.buttonStartServer.Location = new System.Drawing.Point(29, 189);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(151, 38);
            this.buttonStartServer.TabIndex = 1;
            this.buttonStartServer.Text = "START SERVER";
            this.buttonStartServer.UseVisualStyleBackColor = false;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // statusStrips
            // 
            this.statusStrips.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.status});
            this.statusStrips.Location = new System.Drawing.Point(0, 722);
            this.statusStrips.Name = "statusStrips";
            this.statusStrips.Size = new System.Drawing.Size(907, 22);
            this.statusStrips.TabIndex = 17;
            this.statusStrips.Text = "Status:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonEnumComport
            // 
            this.buttonEnumComport.Location = new System.Drawing.Point(191, 75);
            this.buttonEnumComport.Name = "buttonEnumComport";
            this.buttonEnumComport.Size = new System.Drawing.Size(156, 31);
            this.buttonEnumComport.TabIndex = 5;
            this.buttonEnumComport.Text = "Enum Com Port";
            this.buttonEnumComport.UseVisualStyleBackColor = true;
            this.buttonEnumComport.Click += new System.EventHandler(this.buttonEnumComport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 744);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrips);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonChooseFolder);
            this.Controls.Add(this.linkLabelPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelIPadd);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xbits Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrips.ResumeLayout(false);
            this.statusStrips.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelIPadd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabelPath;
        private System.Windows.Forms.Button buttonChooseFolder;
        private System.Windows.Forms.Label label4;
        public  System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonPrint;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.ComboBox comboBoxComport;
        private System.Windows.Forms.RadioButton radioButtonComport;
        private System.Windows.Forms.RadioButton radioButtonWiFi;
        private System.Windows.Forms.Button buttonOpenCom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.StatusStrip statusStrips;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Button buttonEnumComport;
    }
}

