
namespace Setup
{
    partial class SetupForm // Driving Licenses Managment System Setup Wizard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbHeaderIcon = new System.Windows.Forms.PictureBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlStep0 = new System.Windows.Forms.Panel();
            this.chkAgree = new System.Windows.Forms.CheckBox();
            this.rtbTerms = new System.Windows.Forms.RichTextBox();
            this.lblStep0Title = new System.Windows.Forms.Label();
            this.pnlStep1 = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtInstallationPath = new System.Windows.Forms.TextBox();
            this.rbCustomPath = new System.Windows.Forms.RadioButton();
            this.rbDefaultPath = new System.Windows.Forms.RadioButton();
            this.lblStep1Description = new System.Windows.Forms.Label();
            this.lblStep1Title = new System.Windows.Forms.Label();
            this.pnlStep2 = new System.Windows.Forms.Panel();
            this.lblDBStatus = new System.Windows.Forms.Label();
            this.pbDBInstallation = new System.Windows.Forms.ProgressBar();
            this.lblStep2Description = new System.Windows.Forms.Label();
            this.lblStep2Title = new System.Windows.Forms.Label();
            this.pnlStep3 = new System.Windows.Forms.Panel();
            this.lblAppStatus = new System.Windows.Forms.Label();
            this.pbAppInstallation = new System.Windows.Forms.ProgressBar();
            this.lblStep3Description = new System.Windows.Forms.Label();
            this.lblStep3Title = new System.Windows.Forms.Label();
            this.pnlStep4 = new System.Windows.Forms.Panel();
            this.lblPasswordValue = new System.Windows.Forms.Label();
            this.lblUsernameValue = new System.Windows.Forms.Label();
            this.lblPasswordLabel = new System.Windows.Forms.Label();
            this.lblUsernameLabel = new System.Windows.Forms.Label();
            this.lblStep4Description = new System.Windows.Forms.Label();
            this.lblStep4Title = new System.Windows.Forms.Label();
            this.pnlStep5 = new System.Windows.Forms.Panel();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            this.lblStep5Title = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeaderIcon)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlStep0.SuspendLayout();
            this.pnlStep1.SuspendLayout();
            this.pnlStep2.SuspendLayout();
            this.pnlStep3.SuspendLayout();
            this.pnlStep4.SuspendLayout();
            this.pnlStep5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.pbHeaderIcon);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(80, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(384, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "DVLD Setup Wizard - Step 1 of 5";
            // 
            // pbHeaderIcon
            // 
            this.pbHeaderIcon.Image = global::Setup.Properties.Resources.DVLD1;
            this.pbHeaderIcon.Location = new System.Drawing.Point(20, 12);
            this.pbHeaderIcon.Name = "pbHeaderIcon";
            this.pbHeaderIcon.Size = new System.Drawing.Size(50, 50);
            this.pbHeaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHeaderIcon.TabIndex = 0;
            this.pbHeaderIcon.TabStop = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlFooter.Controls.Add(this.lblUserName);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnNext);
            this.pnlFooter.Controls.Add(this.btnBack);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 380);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 70);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(20, 28);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(197, 17);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "By: Ahmed Ramadan Abd El-Rady";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(680, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(570, 20);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 35);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Next >";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(460, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "< Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlStep0
            // 
            this.pnlStep0.Controls.Add(this.chkAgree);
            this.pnlStep0.Controls.Add(this.rtbTerms);
            this.pnlStep0.Controls.Add(this.lblStep0Title);
            this.pnlStep0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep0.Location = new System.Drawing.Point(0, 70);
            this.pnlStep0.Name = "pnlStep0";
            this.pnlStep0.Size = new System.Drawing.Size(800, 310);
            this.pnlStep0.TabIndex = 5;
            // 
            // chkAgree
            // 
            this.chkAgree.AutoSize = true;
            this.chkAgree.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAgree.Location = new System.Drawing.Point(54, 270);
            this.chkAgree.Name = "chkAgree";
            this.chkAgree.Size = new System.Drawing.Size(233, 21);
            this.chkAgree.TabIndex = 2;
            this.chkAgree.Text = "I agree to the terms and conditions";
            this.chkAgree.UseVisualStyleBackColor = true;
            // 
            // rtbTerms
            // 
            this.rtbTerms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbTerms.Location = new System.Drawing.Point(50, 70);
            this.rtbTerms.Name = "rtbTerms";
            this.rtbTerms.ReadOnly = true;
            this.rtbTerms.Size = new System.Drawing.Size(700, 190);
            this.rtbTerms.TabIndex = 1;
            this.rtbTerms.Text = "Please read the following terms and conditions carefully...";
            // 
            // lblStep0Title
            // 
            this.lblStep0Title.AutoSize = true;
            this.lblStep0Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep0Title.Location = new System.Drawing.Point(50, 30);
            this.lblStep0Title.Name = "lblStep0Title";
            this.lblStep0Title.Size = new System.Drawing.Size(226, 25);
            this.lblStep0Title.TabIndex = 0;
            this.lblStep0Title.Text = "1. Terms and Conditions";
            // 
            // pnlStep1
            // 
            this.pnlStep1.Controls.Add(this.btnBrowse);
            this.pnlStep1.Controls.Add(this.txtInstallationPath);
            this.pnlStep1.Controls.Add(this.rbCustomPath);
            this.pnlStep1.Controls.Add(this.rbDefaultPath);
            this.pnlStep1.Controls.Add(this.lblStep1Description);
            this.pnlStep1.Controls.Add(this.lblStep1Title);
            this.pnlStep1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep1.Location = new System.Drawing.Point(0, 70);
            this.pnlStep1.Name = "pnlStep1";
            this.pnlStep1.Size = new System.Drawing.Size(800, 310);
            this.pnlStep1.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBrowse.Enabled = false;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(470, 190);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 30);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtInstallationPath
            // 
            this.txtInstallationPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallationPath.Location = new System.Drawing.Point(200, 190);
            this.txtInstallationPath.Name = "txtInstallationPath";
            this.txtInstallationPath.ReadOnly = true;
            this.txtInstallationPath.Size = new System.Drawing.Size(260, 25);
            this.txtInstallationPath.TabIndex = 4;
            // 
            // rbCustomPath
            // 
            this.rbCustomPath.AutoSize = true;
            this.rbCustomPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCustomPath.Location = new System.Drawing.Point(180, 160);
            this.rbCustomPath.Name = "rbCustomPath";
            this.rbCustomPath.Size = new System.Drawing.Size(149, 21);
            this.rbCustomPath.TabIndex = 3;
            this.rbCustomPath.Text = "Choose custom path:";
            this.rbCustomPath.UseVisualStyleBackColor = true;
            // 
            // rbDefaultPath
            // 
            this.rbDefaultPath.AutoSize = true;
            this.rbDefaultPath.Checked = true;
            this.rbDefaultPath.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDefaultPath.Location = new System.Drawing.Point(180, 130);
            this.rbDefaultPath.Name = "rbDefaultPath";
            this.rbDefaultPath.Size = new System.Drawing.Size(209, 21);
            this.rbDefaultPath.TabIndex = 2;
            this.rbDefaultPath.TabStop = true;
            this.rbDefaultPath.Text = "Install to default path (C:\\DVLD)";
            this.rbDefaultPath.UseVisualStyleBackColor = true;
            // 
            // lblStep1Description
            // 
            this.lblStep1Description.AutoSize = true;
            this.lblStep1Description.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1Description.Location = new System.Drawing.Point(50, 70);
            this.lblStep1Description.Name = "lblStep1Description";
            this.lblStep1Description.Size = new System.Drawing.Size(435, 17);
            this.lblStep1Description.TabIndex = 1;
            this.lblStep1Description.Text = "Please choose the installation path for the DVLD application components.";
            // 
            // lblStep1Title
            // 
            this.lblStep1Title.AutoSize = true;
            this.lblStep1Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1Title.Location = new System.Drawing.Point(50, 30);
            this.lblStep1Title.Name = "lblStep1Title";
            this.lblStep1Title.Size = new System.Drawing.Size(174, 25);
            this.lblStep1Title.TabIndex = 0;
            this.lblStep1Title.Text = "2. Select Directory";
            // 
            // pnlStep2
            // 
            this.pnlStep2.Controls.Add(this.lblDBStatus);
            this.pnlStep2.Controls.Add(this.pbDBInstallation);
            this.pnlStep2.Controls.Add(this.lblStep2Description);
            this.pnlStep2.Controls.Add(this.lblStep2Title);
            this.pnlStep2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep2.Location = new System.Drawing.Point(0, 70);
            this.pnlStep2.Name = "pnlStep2";
            this.pnlStep2.Size = new System.Drawing.Size(800, 310);
            this.pnlStep2.TabIndex = 3;
            // 
            // lblDBStatus
            // 
            this.lblDBStatus.AutoSize = true;
            this.lblDBStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBStatus.Location = new System.Drawing.Point(50, 170);
            this.lblDBStatus.Name = "lblDBStatus";
            this.lblDBStatus.Size = new System.Drawing.Size(118, 17);
            this.lblDBStatus.TabIndex = 3;
            this.lblDBStatus.Text = "Status: Not Started";
            // 
            // pbDBInstallation
            // 
            this.pbDBInstallation.Location = new System.Drawing.Point(50, 130);
            this.pbDBInstallation.Name = "pbDBInstallation";
            this.pbDBInstallation.Size = new System.Drawing.Size(700, 25);
            this.pbDBInstallation.TabIndex = 2;
            // 
            // lblStep2Description
            // 
            this.lblStep2Description.AutoSize = true;
            this.lblStep2Description.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2Description.Location = new System.Drawing.Point(50, 70);
            this.lblStep2Description.Name = "lblStep2Description";
            this.lblStep2Description.Size = new System.Drawing.Size(383, 17);
            this.lblStep2Description.TabIndex = 1;
            this.lblStep2Description.Text = "The setup wizard will now install the DVLD database component.";
            // 
            // lblStep2Title
            // 
            this.lblStep2Title.AutoSize = true;
            this.lblStep2Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2Title.Location = new System.Drawing.Point(50, 30);
            this.lblStep2Title.Name = "lblStep2Title";
            this.lblStep2Title.Size = new System.Drawing.Size(172, 25);
            this.lblStep2Title.TabIndex = 0;
            this.lblStep2Title.Text = "3. Install Database";
            // 
            // pnlStep3
            // 
            this.pnlStep3.Controls.Add(this.lblAppStatus);
            this.pnlStep3.Controls.Add(this.pbAppInstallation);
            this.pnlStep3.Controls.Add(this.lblStep3Description);
            this.pnlStep3.Controls.Add(this.lblStep3Title);
            this.pnlStep3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep3.Location = new System.Drawing.Point(0, 70);
            this.pnlStep3.Name = "pnlStep3";
            this.pnlStep3.Size = new System.Drawing.Size(800, 310);
            this.pnlStep3.TabIndex = 4;
            // 
            // lblAppStatus
            // 
            this.lblAppStatus.AutoSize = true;
            this.lblAppStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppStatus.Location = new System.Drawing.Point(50, 170);
            this.lblAppStatus.Name = "lblAppStatus";
            this.lblAppStatus.Size = new System.Drawing.Size(118, 17);
            this.lblAppStatus.TabIndex = 3;
            this.lblAppStatus.Text = "Status: Not Started";
            // 
            // pbAppInstallation
            // 
            this.pbAppInstallation.Location = new System.Drawing.Point(50, 130);
            this.pbAppInstallation.Name = "pbAppInstallation";
            this.pbAppInstallation.Size = new System.Drawing.Size(700, 25);
            this.pbAppInstallation.TabIndex = 2;
            // 
            // lblStep3Description
            // 
            this.lblStep3Description.AutoSize = true;
            this.lblStep3Description.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep3Description.Location = new System.Drawing.Point(50, 70);
            this.lblStep3Description.Name = "lblStep3Description";
            this.lblStep3Description.Size = new System.Drawing.Size(445, 17);
            this.lblStep3Description.TabIndex = 1;
            this.lblStep3Description.Text = "The setup wizard will now install the main DVLD application and log viewer.";
            // 
            // lblStep3Title
            // 
            this.lblStep3Title.AutoSize = true;
            this.lblStep3Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep3Title.Location = new System.Drawing.Point(50, 30);
            this.lblStep3Title.Name = "lblStep3Title";
            this.lblStep3Title.Size = new System.Drawing.Size(201, 25);
            this.lblStep3Title.TabIndex = 0;
            this.lblStep3Title.Text = "4. Install Applications";
            // 
            // pnlStep4
            // 
            this.pnlStep4.Controls.Add(this.lblPasswordValue);
            this.pnlStep4.Controls.Add(this.lblUsernameValue);
            this.pnlStep4.Controls.Add(this.lblPasswordLabel);
            this.pnlStep4.Controls.Add(this.lblUsernameLabel);
            this.pnlStep4.Controls.Add(this.lblStep4Description);
            this.pnlStep4.Controls.Add(this.lblStep4Title);
            this.pnlStep4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep4.Location = new System.Drawing.Point(0, 70);
            this.pnlStep4.Name = "pnlStep4";
            this.pnlStep4.Size = new System.Drawing.Size(800, 310);
            this.pnlStep4.TabIndex = 6;
            // 
            // lblPasswordValue
            // 
            this.lblPasswordValue.AutoSize = true;
            this.lblPasswordValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordValue.Location = new System.Drawing.Point(280, 170);
            this.lblPasswordValue.Name = "lblPasswordValue";
            this.lblPasswordValue.Size = new System.Drawing.Size(95, 21);
            this.lblPasswordValue.TabIndex = 5;
            this.lblPasswordValue.Text = "admin1234";
            // 
            // lblUsernameValue
            // 
            this.lblUsernameValue.AutoSize = true;
            this.lblUsernameValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameValue.Location = new System.Drawing.Point(280, 130);
            this.lblUsernameValue.Name = "lblUsernameValue";
            this.lblUsernameValue.Size = new System.Drawing.Size(59, 21);
            this.lblUsernameValue.TabIndex = 4;
            this.lblUsernameValue.Text = "admin";
            // 
            // lblPasswordLabel
            // 
            this.lblPasswordLabel.AutoSize = true;
            this.lblPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordLabel.Location = new System.Drawing.Point(180, 170);
            this.lblPasswordLabel.Name = "lblPasswordLabel";
            this.lblPasswordLabel.Size = new System.Drawing.Size(79, 21);
            this.lblPasswordLabel.TabIndex = 3;
            this.lblPasswordLabel.Text = "Password:";
            // 
            // lblUsernameLabel
            // 
            this.lblUsernameLabel.AutoSize = true;
            this.lblUsernameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameLabel.Location = new System.Drawing.Point(180, 130);
            this.lblUsernameLabel.Name = "lblUsernameLabel";
            this.lblUsernameLabel.Size = new System.Drawing.Size(84, 21);
            this.lblUsernameLabel.TabIndex = 2;
            this.lblUsernameLabel.Text = "Username:";
            // 
            // lblStep4Description
            // 
            this.lblStep4Description.AutoSize = true;
            this.lblStep4Description.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep4Description.Location = new System.Drawing.Point(50, 70);
            this.lblStep4Description.Name = "lblStep4Description";
            this.lblStep4Description.Size = new System.Drawing.Size(486, 17);
            this.lblStep4Description.TabIndex = 1;
            this.lblStep4Description.Text = "You can now try the application using the following credentials for the admin use" +
    "r.";
            // 
            // lblStep4Title
            // 
            this.lblStep4Title.AutoSize = true;
            this.lblStep4Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep4Title.Location = new System.Drawing.Point(50, 30);
            this.lblStep4Title.Name = "lblStep4Title";
            this.lblStep4Title.Size = new System.Drawing.Size(178, 25);
            this.lblStep4Title.TabIndex = 0;
            this.lblStep4Title.Text = "5. Application Trial";
            // 
            // pnlStep5
            // 
            this.pnlStep5.Controls.Add(this.btnTranslate);
            this.pnlStep5.Controls.Add(this.rtbAbout);
            this.pnlStep5.Controls.Add(this.lblStep5Title);
            this.pnlStep5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep5.Location = new System.Drawing.Point(0, 70);
            this.pnlStep5.Name = "pnlStep5";
            this.pnlStep5.Size = new System.Drawing.Size(800, 310);
            this.pnlStep5.TabIndex = 7;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnTranslate.FlatAppearance.BorderSize = 0;
            this.btnTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTranslate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranslate.ForeColor = System.Drawing.Color.White;
            this.btnTranslate.Location = new System.Drawing.Point(650, 30);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(100, 30);
            this.btnTranslate.TabIndex = 2;
            this.btnTranslate.Text = "العربية";
            this.btnTranslate.UseVisualStyleBackColor = false;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // rtbAbout
            // 
            this.rtbAbout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAbout.Location = new System.Drawing.Point(50, 70);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.ReadOnly = true;
            this.rtbAbout.Size = new System.Drawing.Size(700, 220);
            this.rtbAbout.TabIndex = 1;
            this.rtbAbout.Text = "";
            // 
            // lblStep5Title
            // 
            this.lblStep5Title.AutoSize = true;
            this.lblStep5Title.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep5Title.Location = new System.Drawing.Point(50, 30);
            this.lblStep5Title.Name = "lblStep5Title";
            this.lblStep5Title.Size = new System.Drawing.Size(192, 25);
            this.lblStep5Title.TabIndex = 0;
            this.lblStep5Title.Text = "About DVLD System";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlStep0);
            this.Controls.Add(this.pnlStep1);
            this.Controls.Add(this.pnlStep2);
            this.Controls.Add(this.pnlStep3);
            this.Controls.Add(this.pnlStep4);
            this.Controls.Add(this.pnlStep5);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DVLD Setup Wizard";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeaderIcon)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlStep0.ResumeLayout(false);
            this.pnlStep0.PerformLayout();
            this.pnlStep1.ResumeLayout(false);
            this.pnlStep1.PerformLayout();
            this.pnlStep2.ResumeLayout(false);
            this.pnlStep2.PerformLayout();
            this.pnlStep3.ResumeLayout(false);
            this.pnlStep3.PerformLayout();
            this.pnlStep4.ResumeLayout(false);
            this.pnlStep4.PerformLayout();
            this.pnlStep5.ResumeLayout(false);
            this.pnlStep5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbHeaderIcon;
        private System.Windows.Forms.Panel pnlStep0;
        private System.Windows.Forms.Label lblStep0Title;
        private System.Windows.Forms.RichTextBox rtbTerms;
        private System.Windows.Forms.CheckBox chkAgree;
        private System.Windows.Forms.Panel pnlStep1;
        private System.Windows.Forms.Label lblStep1Title;
        private System.Windows.Forms.Label lblStep1Description;
        private System.Windows.Forms.RadioButton rbCustomPath;
        private System.Windows.Forms.RadioButton rbDefaultPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtInstallationPath;
        private System.Windows.Forms.Panel pnlStep2;
        private System.Windows.Forms.Label lblStep2Title;
        private System.Windows.Forms.Label lblStep2Description;
        private System.Windows.Forms.ProgressBar pbDBInstallation;
        private System.Windows.Forms.Label lblDBStatus;
        private System.Windows.Forms.Panel pnlStep3;
        private System.Windows.Forms.Label lblAppStatus;
        private System.Windows.Forms.ProgressBar pbAppInstallation;
        private System.Windows.Forms.Label lblStep3Description;
        private System.Windows.Forms.Label lblStep3Title;
        private System.Windows.Forms.Panel pnlStep4;
        private System.Windows.Forms.Label lblStep4Title;
        private System.Windows.Forms.Label lblStep4Description;
        private System.Windows.Forms.Label lblPasswordValue;
        private System.Windows.Forms.Label lblUsernameValue;
        private System.Windows.Forms.Label lblPasswordLabel;
        private System.Windows.Forms.Label lblUsernameLabel;
        private System.Windows.Forms.Panel pnlStep5;
        private System.Windows.Forms.Label lblStep5Title;
        private System.Windows.Forms.RichTextBox rtbAbout;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblUserName;
    }
}
