namespace Driving_License_Management
{
    partial class ReplacedLicenseApp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Damaged = new System.Windows.Forms.RadioButton();
            this.Lost = new System.Windows.Forms.RadioButton();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnReplace = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.replacementLicenseApp1 = new Driving_License_Management.ReplacementLicenseApp();
            this.lD_LicenseInfo1 = new Driving_License_Management.LD_LicenseInfo();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 62);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Fill using License ID: ";
            // 
            // button1
            // 
            this.button1.Image = global::Driving_License_Management.Properties.Resources.id_search;
            this.button1.Location = new System.Drawing.Point(369, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 45);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Title.Location = new System.Drawing.Point(23, 5);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(624, 31);
            this.Title.TabIndex = 33;
            this.Title.Text = "Replacement For Lost License";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Damaged);
            this.groupBox2.Controls.Add(this.Lost);
            this.groupBox2.Location = new System.Drawing.Point(456, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 62);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replacement For: ";
            // 
            // Damaged
            // 
            this.Damaged.AutoSize = true;
            this.Damaged.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Damaged.Location = new System.Drawing.Point(18, 35);
            this.Damaged.Name = "Damaged";
            this.Damaged.Size = new System.Drawing.Size(140, 21);
            this.Damaged.TabIndex = 1;
            this.Damaged.Text = "Damaged License";
            this.Damaged.UseVisualStyleBackColor = true;
            this.Damaged.CheckedChanged += new System.EventHandler(this.Damaged_CheckedChanged);
            // 
            // Lost
            // 
            this.Lost.AutoSize = true;
            this.Lost.Checked = true;
            this.Lost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Lost.Location = new System.Drawing.Point(18, 13);
            this.Lost.Name = "Lost";
            this.Lost.Size = new System.Drawing.Size(106, 21);
            this.Lost.TabIndex = 0;
            this.Lost.TabStop = true;
            this.Lost.Text = "Lost License";
            this.Lost.UseVisualStyleBackColor = true;
            this.Lost.CheckedChanged += new System.EventHandler(this.Lost_CheckedChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Enabled = false;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.linkLabel2.Location = new System.Drawing.Point(193, 639);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(153, 17);
            this.linkLabel2.TabIndex = 42;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Show New License Info";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.linkLabel1.Location = new System.Drawing.Point(12, 639);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(150, 17);
            this.linkLabel1.TabIndex = 41;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Show Licenses History";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnReplace
            // 
            this.btnReplace.Enabled = false;
            this.btnReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnReplace.Image = global::Driving_License_Management.Properties.Resources.replace;
            this.btnReplace.Location = new System.Drawing.Point(492, 635);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(162, 33);
            this.btnReplace.TabIndex = 44;
            this.btnReplace.Text = "Issue Replacement";
            this.btnReplace.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button3.Image = global::Driving_License_Management.Properties.Resources.close24;
            this.button3.Location = new System.Drawing.Point(406, 635);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 33);
            this.button3.TabIndex = 43;
            this.button3.Text = "Close";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // replacementLicenseApp1
            // 
            this.replacementLicenseApp1.Location = new System.Drawing.Point(4, 425);
            this.replacementLicenseApp1.Name = "replacementLicenseApp1";
            this.replacementLicenseApp1.Size = new System.Drawing.Size(647, 211);
            this.replacementLicenseApp1.TabIndex = 37;
            // 
            // lD_LicenseInfo1
            // 
            this.lD_LicenseInfo1.Location = new System.Drawing.Point(4, 109);
            this.lD_LicenseInfo1.Name = "lD_LicenseInfo1";
            this.lD_LicenseInfo1.Size = new System.Drawing.Size(654, 310);
            this.lD_LicenseInfo1.TabIndex = 35;
            // 
            // ReplacedLicenseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 673);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.replacementLicenseApp1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lD_LicenseInfo1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReplacedLicenseApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacement Local License ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LD_LicenseInfo lD_LicenseInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Damaged;
        private System.Windows.Forms.RadioButton Lost;
        private ReplacementLicenseApp replacementLicenseApp1;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}