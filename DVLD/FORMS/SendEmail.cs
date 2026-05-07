using DVLD_Business_Layer;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Driving_License_Management
{
    public partial class SendEmail : Form
    {
        private class SecureAppConfig
        {
            public static bool SavePassword(string plainPassword)
            {
                bool success = true;
                try
                {
                    if (string.IsNullOrEmpty(plainPassword)) return false;

                    byte[] data = Encoding.UTF8.GetBytes(plainPassword);

                    // تشفير البايتات باستخدام بصمة المستخدم الحالي
                    // لا يمكن فكها إلا على نفس الجهاز وبنفس المستخدم
                    byte[] encryptedData = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

                    string base64Encrypted = Convert.ToBase64String(encryptedData);

                    // حفظ النص المشفر في إعدادات التطبيق
                    var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    if (config.AppSettings.Settings["AppPasswordEncrypted"] != null)
                    {
                        config.AppSettings.Settings["AppPasswordEncrypted"].Value = base64Encrypted;
                    }
                    else
                    {
                        config.AppSettings.Settings.Add("AppPasswordEncrypted", base64Encrypted);
                    }
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                catch (Exception ex)
                {
                    DVLDProgram.Show("Error", $"Failed to save password securely: {ex.Message}", MessageBoxIcon.Error);
                    success = false;
                }
                return success;
            }
            public static bool SaveEmail(string plainEmail)
            {
                try
                {
                    if (string.IsNullOrEmpty(plainEmail)) return false;
                    byte[] data = Encoding.UTF8.GetBytes(plainEmail);
                    byte[] encryptedData = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
                    string base64Encrypted = Convert.ToBase64String(encryptedData);

                    var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    if (config.AppSettings.Settings["AppEmailEncrypted"] != null)
                    {
                        config.AppSettings.Settings["AppEmailEncrypted"].Value = base64Encrypted;
                    }
                    else
                    {
                        config.AppSettings.Settings.Add("AppEmailEncrypted", base64Encrypted);
                    }
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");


                }
                catch (Exception ex)
                {
                    DVLDProgram.Show("Error", $"Failed to save email securely: {ex.Message}", MessageBoxIcon.Error);
                }
                return true;
            }
            public static (string Mail, string Password) GetMailAndPassword()
            {
                try
                {
                    var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                    string base64Encrypted = config.AppSettings.Settings["AppPasswordEncrypted"]?.Value;
                    string base64EncryptedEmail = config.AppSettings.Settings["AppEmailEncrypted"]?.Value;


                    if (string.IsNullOrEmpty(base64Encrypted) || string.IsNullOrEmpty(base64EncryptedEmail))
                        return (null, null);

                    byte[] encryptedData = Convert.FromBase64String(base64Encrypted);
                    byte[] encryptedEmailData = Convert.FromBase64String(base64EncryptedEmail);

                    byte[] data = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                    byte[] emailData = ProtectedData.Unprotect(encryptedEmailData, null, DataProtectionScope.CurrentUser);

                    return (Encoding.UTF8.GetString(emailData), Encoding.UTF8.GetString(data));
                }
                catch
                {
                    return (null, null);
                }
            }
        }

        public enum SendEmailMode
        {
            VerifyOnly,
            PasswordReset,
            SendEmail
        }
        SendEmailMode _currentMode;
        int _userID = -1;

        public delegate void VerifyCredentialsCompletedHandler(bool isValid);
        public VerifyCredentialsCompletedHandler VerifyCredentialsCompleted;

        public SendEmail(string recipientEmail, SendEmailMode mode = SendEmailMode.SendEmail, int UserID = -1)
        {
            if (mode == SendEmailMode.PasswordReset && UserID == -1)
                throw new ArgumentException("userID is required when mode is PasswordReset.", nameof(UserID));

            InitializeComponent();
            _currentMode = mode;
            toEmail.Text = recipientEmail;
            _userID = UserID;
            InitializeSenderEmail();
        }        

        public SendEmail()
        {
            InitializeComponent();
            _currentMode = SendEmailMode.SendEmail;
            InitializeSenderEmail();
        }

        private void InitializeSenderEmail()
        {
            pnlSend.Visible = false;
            pnlContactInfo.Visible = false;
            pnlVerify.Visible = false;

            var (email, pass) = SecureAppConfig.GetMailAndPassword();
            bool hasCredentials = !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pass);

            if (!hasCredentials)
            {
                title.Text = "Set Sender Email";
                pnlContactInfo.Visible = true;
                btnSave.Text = "Save";
            }
            else
            {
                switch (_currentMode)
                {
                    case SendEmailMode.VerifyOnly:
                        title.Text = "Verify Credentials";
                        txtPass.Visible = false;
                        lblPass.Visible = false;
                        txtConfirmPass.Visible = false;
                        lblConfirmPass.Visible = false;
                        lblVerificationCode.Location = new Point(lblPass.Location.X, lblPass.Location.Y);
                        txtVerificationCode.Location = new Point(txtPass.Location.X, txtPass.Location.Y);
                        break;
                    case SendEmailMode.PasswordReset:
                        title.Text = "First, Verify Credentials";
                        txtPass.Enabled = false;
                        txtConfirmPass.Enabled = false;
                        break;
                    case SendEmailMode.SendEmail:
                        title.Text = "Send Email";
                        pnlSend.Visible = true;
                        btnSave.Text = "Send";
                        break;
                }

                if (_currentMode == SendEmailMode.VerifyOnly || _currentMode == SendEmailMode.PasswordReset)
                {
                    pnlVerify.Visible = true;
                    btnSave.Text = "Verify";
                    SendVerificationCode();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Send_Click(object sender, EventArgs e)
        {
            bool EnabledButton = true;
            btnSave.Enabled = false; // تعطيل زر الإرسال أثناء محاولة الإرسال
            if (btnSave.Text == "Save")
            {
                SaveSenderInfo();
            }
            else
            {
                switch (_currentMode)
                {
                    case SendEmailMode.VerifyOnly:
                        VerifyCredentials();
                        break;
                    case SendEmailMode.PasswordReset:
                        EnabledButton = !PasswordReset();
                        break;
                    case SendEmailMode.SendEmail:
                        SendNewEmail();
                        break;
                }
            }
            btnSave.Enabled = EnabledButton; // إعادة تمكين الزر بعد العملية
        }

        private void SaveSenderInfo()
        {
            string email = txtEmail.Text.Trim();
            string password = txtAppPassword.Text.Trim();
            if (!IsValidEmail(email))
            {
                DVLDProgram.Show("Error", "Please enter a valid email address.", MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                DVLDProgram.Show("Error", "Please enter the app password.", MessageBoxIcon.Error);
                return;
            }

            Cursor = Cursors.WaitCursor;
            bool isValid = VerifyMail(email, password);
            Cursor = Cursors.Default;

            if (isValid)
            {
                DVLDProgram.Show("Success", "Credentials verified successfully!", MessageBoxIcon.Information);
            }
            else
            {
                DVLDProgram.Show("Login Error", "Failed to connect to email!\n\nPlease ensure:\n1. You have an active internet connection.\n2. The email is entered correctly.\n3. You are using the 'App Password' (16 characters) and not your regular account password.", MessageBoxIcon.Warning);
                return;
            }

            if (SecureAppConfig.SaveEmail(email) && SecureAppConfig.SavePassword(password))
            {
                InitializeSenderEmail();
            }
        }

        private bool VerifyMail(string email, string password)
        {
            try 
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(email, password),
                    EnableSsl = true,
                    Timeout = 5000 // تعيين مهلة قصيرة للتحقق بسرعة
                };
                smtpClient.Send(new MailMessage(email, email, "Test Email", "This is a test email to verify credentials."));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void VerifyCredentials()
        {
            if (txtVerificationCode.Text.Trim() != VerificationCode.ToString())
            {
                DVLDProgram.Show("Verification Failed", "Incorrect verification code. Please try again.", MessageBoxIcon.Error);
                return;
            }

            reSendCode.Enabled = false;
            txtVerificationCode.Enabled = false;
            timer1.Stop();
            txtPass.Enabled = true;
            txtConfirmPass.Enabled = true;

            VerifyCredentialsCompleted?.Invoke(true);

            if (_currentMode == SendEmailMode.VerifyOnly)
            {
                this.Close();
            }
            else if (_currentMode == SendEmailMode.PasswordReset)
            {
                title.Text = "Now, Reset Password";
                btnSave.Text = "Reset";
            }
        }

        private bool PasswordReset()
        {
            if (txtVerificationCode.Enabled)
            {
                VerifyCredentials();
                return false;
            }

            string newPassword = txtPass.Text.Trim();
            string confirmPassword = txtConfirmPass.Text.Trim();
            if (newPassword != confirmPassword)
            {
                DVLDProgram.Show("Error", "New password and confirmation do not match.", MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                DVLDProgram.Show("Error", "Please enter a new password.", MessageBoxIcon.Error);
                return false;
            }
            string hashedPassword = UsersBusinessLayer.HashPassword(newPassword);
            bool Changed = UsersBusinessLayer.ChangePassword(_userID, hashedPassword);
            if (!Changed)
            {
                DVLDProgram.Show("Error", "Failed to change password. Please try again.", MessageBoxIcon.Error);
                return false;
            }

            DVLDProgram.Show("Success", "Password changed successfully!", MessageBoxIcon.Information);
            return true;
        }

        int VerificationCode = -1;
        private void SendVerificationCode()
        {
            Random rand = new Random();
            VerificationCode = rand.Next(1000000, 9999999);
            SendMessage(toEmail.Text, "Verification Code", $"Your verification code is: {VerificationCode}", false);
            timer1.Start();
            lblTimer.Text = lblTimer.Tag.ToString();
        }

        private void SendNewEmail()
        {
            if (string.IsNullOrWhiteSpace(toEmail.Text) ||
                string.IsNullOrWhiteSpace(Subject.Text) ||
                string.IsNullOrWhiteSpace(Message.Text))
            {
                DVLDProgram.Show("Send Error", "Please fill in all fields before sending the email.", MessageBoxIcon.Error);
                return;
            }

            string recipientEmail = toEmail.Text.Trim();

            if (!IsValidEmail(recipientEmail))
            {
                DVLDProgram.Show("Invalid Email", "Please enter a valid email address.", MessageBoxIcon.Error);
                return;
            }

            string emailSubject = Subject.Text.Trim();
            string emailBody = Message.Text.Trim();
            SendMessage(recipientEmail, emailSubject, emailBody);
        }

        public static bool SendMessage(string toEmail, string subject, string body, bool ShowSuccessMessage = true)
        {
            bool isSent = true;
            // --- بيانات المُرسِل ---
            string fromEmail;
            string fromPassword;
            (fromEmail, fromPassword) = SecureAppConfig.GetMailAndPassword();

           // ---إعدادات خادم SMTP الخاص بـ Gmail-- -
           SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
           {
               Port = 587, // المنفذ القياسي للاتصال المشفر
               Credentials = new NetworkCredential(fromEmail, fromPassword), // استخدام بيانات الدخول
               EnableSsl = true, // تفعيل التشفير
           };

            // --- إنشاء رسالة البريد ---
            MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body);
            mailMessage.IsBodyHtml = false; // اجعلها 'true' لو كان محتوى الرسالة بصيغة HTML


            // --- إرسال البريد ---
            try
            {
                smtpClient.Send(mailMessage);

                if (ShowSuccessMessage)
                    DVLDProgram.Show("Success", "Email sent successfully!", MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DVLDProgram.Show("Error", $"Failed to send email: {ex.Message}", MessageBoxIcon.Error);
                isSent = false;
            }
            return isSent;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // استخدام فئة MailAddress المدمجة للتحقق من صحة الصيغة
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtAppPassword.UseSystemPasswordChar = !txtAppPassword.UseSystemPasswordChar;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !txtPass.UseSystemPasswordChar;
            txtConfirmPass.UseSystemPasswordChar = !txtConfirmPass.UseSystemPasswordChar;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = (int.Parse(lblTimer.Text) - 1).ToString();
            if (lblTimer.Text == "0")
            {
                timer1.Stop();
                reSendCode.Enabled = true;
            }
        }

        private void reSendCode_Click(object sender, EventArgs e)
        {
            SendVerificationCode();
            reSendCode.Enabled = false;
        }
    }
}


