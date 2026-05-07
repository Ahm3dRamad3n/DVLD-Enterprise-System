namespace Driving_License_Management
{
    partial class SendEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendEmail));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toEmail = new System.Windows.Forms.TextBox();
            this.Subject = new System.Windows.Forms.TextBox();
            this.Message = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.pnlSend = new System.Windows.Forms.Panel();
            this.pnlContactInfo = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtAppPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pnlVerify = new System.Windows.Forms.Panel();
            this.lblTimer = new System.Windows.Forms.Label();
            this.reSendCode = new System.Windows.Forms.PictureBox();
            this.txtVerificationCode = new System.Windows.Forms.TextBox();
            this.lblVerificationCode = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.lblConfirmPass = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlSend.SuspendLayout();
            this.pnlContactInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlVerify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reSendCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subject: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Message: ";
            // 
            // toEmail
            // 
            this.toEmail.Location = new System.Drawing.Point(91, 10);
            this.toEmail.Name = "toEmail";
            this.toEmail.Size = new System.Drawing.Size(218, 20);
            this.toEmail.TabIndex = 3;
            // 
            // Subject
            // 
            this.Subject.Location = new System.Drawing.Point(91, 47);
            this.Subject.Name = "Subject";
            this.Subject.Size = new System.Drawing.Size(218, 20);
            this.Subject.TabIndex = 4;
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(91, 87);
            this.Message.Multiline = true;
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(218, 70);
            this.Message.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(222, 199);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 27);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "{.......}";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Send_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(100, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.title.Location = new System.Drawing.Point(1, 2);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(328, 31);
            this.title.TabIndex = 8;
            this.title.Text = "Send Email ";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSend
            // 
            this.pnlSend.Controls.Add(this.Subject);
            this.pnlSend.Controls.Add(this.label1);
            this.pnlSend.Controls.Add(this.label2);
            this.pnlSend.Controls.Add(this.label3);
            this.pnlSend.Controls.Add(this.Message);
            this.pnlSend.Controls.Add(this.toEmail);
            this.pnlSend.Location = new System.Drawing.Point(9, 32);
            this.pnlSend.Name = "pnlSend";
            this.pnlSend.Size = new System.Drawing.Size(320, 160);
            this.pnlSend.TabIndex = 9;
            this.pnlSend.Visible = false;
            // 
            // pnlContactInfo
            // 
            this.pnlContactInfo.Controls.Add(this.pictureBox2);
            this.pnlContactInfo.Controls.Add(this.label7);
            this.pnlContactInfo.Controls.Add(this.pictureBox1);
            this.pnlContactInfo.Controls.Add(this.txtAppPassword);
            this.pnlContactInfo.Controls.Add(this.label5);
            this.pnlContactInfo.Controls.Add(this.label6);
            this.pnlContactInfo.Controls.Add(this.txtEmail);
            this.pnlContactInfo.Location = new System.Drawing.Point(9, 32);
            this.pnlContactInfo.Name = "pnlContactInfo";
            this.pnlContactInfo.Size = new System.Drawing.Size(320, 160);
            this.pnlContactInfo.TabIndex = 10;
            this.pnlContactInfo.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::Driving_License_Management.Properties.Resources.info;
            this.pictureBox2.Location = new System.Drawing.Point(257, 118);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, resources.GetString("pictureBox2.ToolTip"));
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(26, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(225, 32);
            this.label7.TabIndex = 10;
            this.label7.Text = " The required password is your \r\n app-specific password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Driving_License_Management.Properties.Resources.hide;
            this.pictureBox1.Location = new System.Drawing.Point(286, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtAppPassword
            // 
            this.txtAppPassword.Location = new System.Drawing.Point(95, 68);
            this.txtAppPassword.Name = "txtAppPassword";
            this.txtAppPassword.Size = new System.Drawing.Size(185, 20);
            this.txtAppPassword.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Email: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Password: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(95, 31);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(218, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // pnlVerify
            // 
            this.pnlVerify.Controls.Add(this.lblTimer);
            this.pnlVerify.Controls.Add(this.reSendCode);
            this.pnlVerify.Controls.Add(this.txtVerificationCode);
            this.pnlVerify.Controls.Add(this.lblVerificationCode);
            this.pnlVerify.Controls.Add(this.txtConfirmPass);
            this.pnlVerify.Controls.Add(this.lblConfirmPass);
            this.pnlVerify.Controls.Add(this.pictureBox3);
            this.pnlVerify.Controls.Add(this.txtPass);
            this.pnlVerify.Controls.Add(this.lblPass);
            this.pnlVerify.Location = new System.Drawing.Point(6, 32);
            this.pnlVerify.Name = "pnlVerify";
            this.pnlVerify.Size = new System.Drawing.Size(323, 164);
            this.pnlVerify.TabIndex = 12;
            this.pnlVerify.Visible = false;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Blue;
            this.lblTimer.Location = new System.Drawing.Point(286, 16);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(23, 16);
            this.lblTimer.TabIndex = 18;
            this.lblTimer.Tag = "30";
            this.lblTimer.Text = "30";
            // 
            // reSendCode
            // 
            this.reSendCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reSendCode.Enabled = false;
            this.reSendCode.Image = global::Driving_License_Management.Properties.Resources.refresh1;
            this.reSendCode.Location = new System.Drawing.Point(253, 13);
            this.reSendCode.Name = "reSendCode";
            this.reSendCode.Size = new System.Drawing.Size(27, 20);
            this.reSendCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.reSendCode.TabIndex = 17;
            this.reSendCode.TabStop = false;
            this.reSendCode.Click += new System.EventHandler(this.reSendCode_Click);
            // 
            // txtVerificationCode
            // 
            this.txtVerificationCode.Location = new System.Drawing.Point(59, 36);
            this.txtVerificationCode.Name = "txtVerificationCode";
            this.txtVerificationCode.Size = new System.Drawing.Size(221, 20);
            this.txtVerificationCode.TabIndex = 16;
            // 
            // lblVerificationCode
            // 
            this.lblVerificationCode.AutoSize = true;
            this.lblVerificationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerificationCode.Location = new System.Drawing.Point(7, 17);
            this.lblVerificationCode.Name = "lblVerificationCode";
            this.lblVerificationCode.Size = new System.Drawing.Size(128, 16);
            this.lblVerificationCode.TabIndex = 15;
            this.lblVerificationCode.Text = "Verification code:";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(59, 124);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(221, 20);
            this.txtConfirmPass.TabIndex = 14;
            // 
            // lblConfirmPass
            // 
            this.lblConfirmPass.AutoSize = true;
            this.lblConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPass.Location = new System.Drawing.Point(7, 105);
            this.lblConfirmPass.Name = "lblConfirmPass";
            this.lblConfirmPass.Size = new System.Drawing.Size(139, 16);
            this.lblConfirmPass.TabIndex = 13;
            this.lblConfirmPass.Text = "Confirm Password: ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = global::Driving_License_Management.Properties.Resources.hide;
            this.pictureBox3.Location = new System.Drawing.Point(286, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(59, 79);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(221, 20);
            this.txtPass.TabIndex = 11;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(7, 60);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(83, 16);
            this.lblPass.TabIndex = 10;
            this.lblPass.Text = "Password: ";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 232);
            this.Controls.Add(this.pnlVerify);
            this.Controls.Add(this.pnlContactInfo);
            this.Controls.Add(this.pnlSend);
            this.Controls.Add(this.title);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SendEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send Email";
            this.pnlSend.ResumeLayout(false);
            this.pnlSend.PerformLayout();
            this.pnlContactInfo.ResumeLayout(false);
            this.pnlContactInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlVerify.ResumeLayout(false);
            this.pnlVerify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reSendCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox toEmail;
        private System.Windows.Forms.TextBox Subject;
        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel pnlSend;
        private System.Windows.Forms.Panel pnlContactInfo;
        private System.Windows.Forms.TextBox txtAppPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlVerify;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label lblConfirmPass;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtVerificationCode;
        private System.Windows.Forms.Label lblVerificationCode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox reSendCode;
        private System.Windows.Forms.Label lblTimer;
    }
}