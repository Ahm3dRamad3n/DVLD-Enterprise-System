namespace Driving_License_Management
{
    partial class LD_LicenseInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LD_LicenseInfo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DriverID = new System.Windows.Forms.Label();
            this.IsActive = new System.Windows.Forms.Label();
            this.IsDetained = new System.Windows.Forms.Label();
            this.Notes = new System.Windows.Forms.Label();
            this.DateOfBirth = new System.Windows.Forms.Label();
            this.ExpirationDate = new System.Windows.Forms.Label();
            this.ClassName = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.Label();
            this.LicenseID = new System.Windows.Forms.Label();
            this.NationalNo = new System.Windows.Forms.Label();
            this.Gender = new System.Windows.Forms.Label();
            this.IssueDate = new System.Windows.Forms.Label();
            this.IssueReason = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.DriverImage = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriverImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DriverID);
            this.groupBox1.Controls.Add(this.IsActive);
            this.groupBox1.Controls.Add(this.IsDetained);
            this.groupBox1.Controls.Add(this.Notes);
            this.groupBox1.Controls.Add(this.DateOfBirth);
            this.groupBox1.Controls.Add(this.ExpirationDate);
            this.groupBox1.Controls.Add(this.ClassName);
            this.groupBox1.Controls.Add(this.Name);
            this.groupBox1.Controls.Add(this.LicenseID);
            this.groupBox1.Controls.Add(this.NationalNo);
            this.groupBox1.Controls.Add(this.Gender);
            this.groupBox1.Controls.Add(this.IssueDate);
            this.groupBox1.Controls.Add(this.IssueReason);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.DriverImage);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.groupBox1.Size = new System.Drawing.Size(644, 308);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Local License Information";
            // 
            // DriverID
            // 
            this.DriverID.AutoSize = true;
            this.DriverID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.DriverID.Location = new System.Drawing.Point(402, 107);
            this.DriverID.Name = "DriverID";
            this.DriverID.Size = new System.Drawing.Size(40, 17);
            this.DriverID.TabIndex = 42;
            this.DriverID.Text = "[???]";
            // 
            // IsActive
            // 
            this.IsActive.AutoSize = true;
            this.IsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.IsActive.Location = new System.Drawing.Point(127, 153);
            this.IsActive.Name = "IsActive";
            this.IsActive.Size = new System.Drawing.Size(40, 17);
            this.IsActive.TabIndex = 41;
            this.IsActive.Text = "[???]";
            // 
            // IsDetained
            // 
            this.IsDetained.AutoSize = true;
            this.IsDetained.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.IsDetained.Location = new System.Drawing.Point(402, 148);
            this.IsDetained.Name = "IsDetained";
            this.IsDetained.Size = new System.Drawing.Size(40, 17);
            this.IsDetained.TabIndex = 40;
            this.IsDetained.Text = "[???]";
            // 
            // Notes
            // 
            this.Notes.AutoEllipsis = true;
            this.Notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Notes.Location = new System.Drawing.Point(402, 270);
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(228, 25);
            this.Notes.TabIndex = 39;
            this.Notes.Text = "[???]";
            this.Notes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Notes.TextChanged += new System.EventHandler(this.Notes_TextChanged);
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.AutoSize = true;
            this.DateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.DateOfBirth.Location = new System.Drawing.Point(402, 189);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(40, 17);
            this.DateOfBirth.TabIndex = 38;
            this.DateOfBirth.Text = "[???]";
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.AutoSize = true;
            this.ExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.ExpirationDate.Location = new System.Drawing.Point(402, 230);
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.Size = new System.Drawing.Size(40, 17);
            this.ExpirationDate.TabIndex = 37;
            this.ExpirationDate.Text = "[???]";
            // 
            // ClassName
            // 
            this.ClassName.AutoSize = true;
            this.ClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.ClassName.ForeColor = System.Drawing.Color.Purple;
            this.ClassName.Location = new System.Drawing.Point(127, 71);
            this.ClassName.Name = "ClassName";
            this.ClassName.Size = new System.Drawing.Size(40, 17);
            this.ClassName.TabIndex = 36;
            this.ClassName.Text = "[???]";
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Name.ForeColor = System.Drawing.Color.Blue;
            this.Name.Location = new System.Drawing.Point(127, 31);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(40, 17);
            this.Name.TabIndex = 35;
            this.Name.Text = "[???]";
            // 
            // LicenseID
            // 
            this.LicenseID.AutoSize = true;
            this.LicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LicenseID.Location = new System.Drawing.Point(127, 112);
            this.LicenseID.Name = "LicenseID";
            this.LicenseID.Size = new System.Drawing.Size(40, 17);
            this.LicenseID.TabIndex = 34;
            this.LicenseID.Text = "[???]";
            // 
            // NationalNo
            // 
            this.NationalNo.AutoSize = true;
            this.NationalNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.NationalNo.Location = new System.Drawing.Point(127, 194);
            this.NationalNo.Name = "NationalNo";
            this.NationalNo.Size = new System.Drawing.Size(40, 17);
            this.NationalNo.TabIndex = 33;
            this.NationalNo.Text = "[???]";
            // 
            // Gender
            // 
            this.Gender.AutoSize = true;
            this.Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.Gender.Location = new System.Drawing.Point(590, 232);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(40, 17);
            this.Gender.TabIndex = 32;
            this.Gender.Text = "[???]";
            // 
            // IssueDate
            // 
            this.IssueDate.AutoSize = true;
            this.IssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.IssueDate.Location = new System.Drawing.Point(127, 235);
            this.IssueDate.Name = "IssueDate";
            this.IssueDate.Size = new System.Drawing.Size(40, 17);
            this.IssueDate.TabIndex = 31;
            this.IssueDate.Text = "[???]";
            // 
            // IssueReason
            // 
            this.IssueReason.AutoEllipsis = true;
            this.IssueReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.IssueReason.Location = new System.Drawing.Point(127, 274);
            this.IssueReason.Name = "IssueReason";
            this.IssueReason.Size = new System.Drawing.Size(119, 25);
            this.IssueReason.TabIndex = 30;
            this.IssueReason.Text = "[???]";
            this.IssueReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IssueReason.TextChanged += new System.EventHandler(this.IssueReason_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.Location = new System.Drawing.Point(526, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "Driver Image  ";
            // 
            // DriverImage
            // 
            this.DriverImage.Location = new System.Drawing.Point(493, 87);
            this.DriverImage.Name = "DriverImage";
            this.DriverImage.Size = new System.Drawing.Size(140, 140);
            this.DriverImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DriverImage.TabIndex = 13;
            this.DriverImage.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label13.Image = ((System.Drawing.Image)(resources.GetObject("label13.Image")));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(263, 230);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label13.Size = new System.Drawing.Size(140, 25);
            this.label13.TabIndex = 12;
            this.label13.Text = "Expiration Date:        ";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label12.Image = ((System.Drawing.Image)(resources.GetObject("label12.Image")));
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(264, 147);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label12.Size = new System.Drawing.Size(140, 25);
            this.label12.TabIndex = 11;
            this.label12.Text = "Is Detained?";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(264, 189);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label11.Size = new System.Drawing.Size(140, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "Date Of Birth: ";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(8, 152);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label10.Size = new System.Drawing.Size(122, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "Is Active?";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label9.Image = global::Driving_License_Management.Properties.Resources.driver;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(265, 106);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label9.Size = new System.Drawing.Size(140, 30);
            this.label9.TabIndex = 8;
            this.label9.Text = "Driver ID: ";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.Image = global::Driving_License_Management.Properties.Resources.notes;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(264, 270);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label8.Size = new System.Drawing.Size(140, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Notes: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.Image = global::Driving_License_Management.Properties.Resources.equipement;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(7, 276);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label7.Size = new System.Drawing.Size(122, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Issue Reason:      ";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(8, 234);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Issue Date:         ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Image = global::Driving_License_Management.Properties.Resources.anonymous;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(490, 230);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gender: ";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Image = global::Driving_License_Management.Properties.Resources.network;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(7, 194);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label4.Size = new System.Drawing.Size(122, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "National No: ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(8, 111);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "License ID: ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Image = global::Driving_License_Management.Properties.Resources.anonymity_2;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name: ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Image = global::Driving_License_Management.Properties.Resources.certificate;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(8, 70);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class: ";
            // 
            // LD_LicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            //this.Name = "LD_LicenseInfo";
            this.Size = new System.Drawing.Size(654, 318);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriverImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox DriverImage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label DriverID;
        private System.Windows.Forms.Label IsActive;
        private System.Windows.Forms.Label IsDetained;
        private System.Windows.Forms.Label Notes;
        private System.Windows.Forms.Label DateOfBirth;
        private System.Windows.Forms.Label ExpirationDate;
        private System.Windows.Forms.Label ClassName;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.Label LicenseID;
        private System.Windows.Forms.Label NationalNo;
        private System.Windows.Forms.Label Gender;
        private System.Windows.Forms.Label IssueDate;
        private System.Windows.Forms.Label IssueReason;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
