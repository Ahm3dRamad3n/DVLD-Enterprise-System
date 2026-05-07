namespace Driving_License_Management
{
    partial class AddOrEditApplication
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
            this.Title = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PersonInfo = new System.Windows.Forms.TabPage();
            this.findPerson1 = new Driving_License_Management.FindPerson();
            this.next = new System.Windows.Forms.Button();
            this.AppInfo = new System.Windows.Forms.TabPage();
            this.AppID = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AppLID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.PersonInfo.SuspendLayout();
            this.AppInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Title.Location = new System.Drawing.Point(44, 15);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(511, 31);
            this.Title.TabIndex = 18;
            this.Title.Text = "New Local Driving License Application";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PersonInfo);
            this.tabControl1.Controls.Add(this.AppInfo);
            this.tabControl1.Location = new System.Drawing.Point(12, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(575, 385);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // PersonInfo
            // 
            this.PersonInfo.Controls.Add(this.findPerson1);
            this.PersonInfo.Controls.Add(this.next);
            this.PersonInfo.Location = new System.Drawing.Point(4, 22);
            this.PersonInfo.Name = "PersonInfo";
            this.PersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.PersonInfo.Size = new System.Drawing.Size(567, 359);
            this.PersonInfo.TabIndex = 0;
            this.PersonInfo.Text = "Person Info";
            this.PersonInfo.UseVisualStyleBackColor = true;
            // 
            // findPerson1
            // 
            this.findPerson1.Location = new System.Drawing.Point(4, 4);
            this.findPerson1.Name = "findPerson1";
            this.findPerson1.Size = new System.Drawing.Size(563, 314);
            this.findPerson1.TabIndex = 2;
            this.findPerson1.Load += new System.EventHandler(this.findPerson1_Load);
            // 
            // next
            // 
            this.next.Enabled = false;
            this.next.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.next.Image = global::Driving_License_Management.Properties.Resources.next;
            this.next.Location = new System.Drawing.Point(478, 317);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(82, 40);
            this.next.TabIndex = 1;
            this.next.Text = "Next";
            this.next.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // AppInfo
            // 
            this.AppInfo.Controls.Add(this.AppID);
            this.AppInfo.Controls.Add(this.comboBox2);
            this.AppInfo.Controls.Add(this.label9);
            this.AppInfo.Controls.Add(this.label7);
            this.AppInfo.Controls.Add(this.label6);
            this.AppInfo.Controls.Add(this.AppLID);
            this.AppInfo.Controls.Add(this.label11);
            this.AppInfo.Controls.Add(this.label10);
            this.AppInfo.Controls.Add(this.label8);
            this.AppInfo.Controls.Add(this.label2);
            this.AppInfo.Controls.Add(this.label3);
            this.AppInfo.Controls.Add(this.label5);
            this.AppInfo.Location = new System.Drawing.Point(4, 22);
            this.AppInfo.Name = "AppInfo";
            this.AppInfo.Padding = new System.Windows.Forms.Padding(3);
            this.AppInfo.Size = new System.Drawing.Size(567, 359);
            this.AppInfo.TabIndex = 1;
            this.AppInfo.Text = "App Info";
            this.AppInfo.UseVisualStyleBackColor = true;
            // 
            // AppID
            // 
            this.AppID.AutoSize = true;
            this.AppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.AppID.Location = new System.Drawing.Point(199, 30);
            this.AppID.Name = "AppID";
            this.AppID.Size = new System.Drawing.Size(48, 18);
            this.AppID.TabIndex = 37;
            this.AppID.Text = "[????]";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(202, 162);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(223, 23);
            this.comboBox2.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label9.Location = new System.Drawing.Point(199, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 18);
            this.label9.TabIndex = 33;
            this.label9.Text = "[????]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label7.Location = new System.Drawing.Point(199, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 31;
            this.label7.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(199, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 18);
            this.label6.TabIndex = 30;
            this.label6.Text = "[????]";
            // 
            // AppLID
            // 
            this.AppLID.AutoSize = true;
            this.AppLID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.AppLID.Location = new System.Drawing.Point(199, 75);
            this.AppLID.Name = "AppLID";
            this.AppLID.Size = new System.Drawing.Size(48, 18);
            this.AppLID.TabIndex = 29;
            this.AppLID.Text = "[????]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label11.Image = global::Driving_License_Management.Properties.Resources.AppID;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(31, 27);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 6, 0, 7);
            this.label11.Size = new System.Drawing.Size(162, 30);
            this.label11.TabIndex = 36;
            this.label11.Text = "Application ID:                ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label10.Image = global::Driving_License_Management.Properties.Resources.certificate;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(31, 164);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 6, 0, 7);
            this.label10.Size = new System.Drawing.Size(159, 30);
            this.label10.TabIndex = 34;
            this.label10.Text = "License Class:               ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.Image = global::Driving_License_Management.Properties.Resources.administrator;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(31, 258);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 6, 0, 7);
            this.label8.Size = new System.Drawing.Size(162, 30);
            this.label8.TabIndex = 32;
            this.label8.Text = "Created By:                    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Image = global::Driving_License_Management.Properties.Resources.money;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(30, 211);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 7);
            this.label2.Size = new System.Drawing.Size(160, 30);
            this.label2.TabIndex = 28;
            this.label2.Text = "Application Fees:           ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Image = global::Driving_License_Management.Properties.Resources.date;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(31, 116);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 7);
            this.label3.Size = new System.Drawing.Size(163, 30);
            this.label3.TabIndex = 26;
            this.label3.Text = "Application Date:            ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Image = global::Driving_License_Management.Properties.Resources.id_level;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(31, 72);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 7);
            this.label5.Size = new System.Drawing.Size(162, 30);
            this.label5.TabIndex = 27;
            this.label5.Text = "Application.L ID:             ";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button2.Image = global::Driving_License_Management.Properties.Resources.diskette;
            this.button2.Location = new System.Drawing.Point(500, 456);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 43);
            this.button2.TabIndex = 17;
            this.button2.Text = "Save";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.Image = global::Driving_License_Management.Properties.Resources.close;
            this.button1.Location = new System.Drawing.Point(397, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "Close";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddOrEditApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 509);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddOrEditApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add OR Edit Application";
            this.tabControl1.ResumeLayout(false);
            this.PersonInfo.ResumeLayout(false);
            this.AppInfo.ResumeLayout(false);
            this.AppInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PersonInfo;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.TabPage AppInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label AppLID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label AppID;
        private System.Windows.Forms.Label label11;
        private FindPerson findPerson1;
    }
}