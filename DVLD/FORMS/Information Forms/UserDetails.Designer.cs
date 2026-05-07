namespace Driving_License_Management
{
    partial class UserDetails
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
            this.user_Perm1 = new Driving_License_Management.User_Perm();
            this.personInfo1 = new Driving_License_Management.PersonInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // user_Perm1
            // 
            this.user_Perm1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.user_Perm1.Location = new System.Drawing.Point(9, 299);
            this.user_Perm1.Name = "user_Perm1";
            this.user_Perm1.Size = new System.Drawing.Size(567, 70);
            this.user_Perm1.TabIndex = 1;
            // 
            // personInfo1
            // 
            this.personInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.personInfo1.Location = new System.Drawing.Point(9, 37);
            this.personInfo1.Name = "personInfo1";
            this.personInfo1.Size = new System.Drawing.Size(567, 256);
            this.personInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(206, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current User Info";
            // 
            // UserDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 374);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.user_Perm1);
            this.Controls.Add(this.personInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PersonInfo personInfo1;
        private User_Perm user_Perm1;
        private System.Windows.Forms.Label label1;
    }
}