using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Setup
{
    public partial class SetupForm : Form
    {
        private int _currentStep = 0;
        private string _installationPath = "C:\\DVLD"; // Default installation path
        private bool _isArabic = false; // For translation toggle
        private bool _isDBInstalled = false; 
        private bool _isAppInstalled = false; 
        private string _databaseName = null;
        private class Components
        {
            public const string GlobalUrl = "https://github.com/Ahm3dRamad3n/DVLD-Enterprise-System/releases/download/Component_Installation/";
            public static (string name, string url) DatabaseBackup => ("DVLD.bak", GlobalUrl + "DVLD.bak");
            public static (string name, string url) DVLDExecutable => ("Driving.License.Management.exe", GlobalUrl + "Driving.License.Management.exe");
            public static (string name, string url) LogsExecutable => ("Logs.exe", GlobalUrl + "Logs.exe");
            public static (string name, string url) DVLDConfigFile => ("Driving.License.Management.exe.config", GlobalUrl + "Driving.License.Management.exe.config");
            public static (string name, string url) LogsConfigFile => ("Logs.exe.config", GlobalUrl + "Logs.exe.config");
            public static (string name, string url) DTOs => ("DTOs.dll", GlobalUrl + "DTOs.dll");
            public static (string name, string url) BusinessLayer => ("DVLD Business Layer.dll", GlobalUrl + "DVLD.Business.Layer.dll");
            public static (string name, string url) DataAccessLayer => ("DVLD Data Access Layer.dll", GlobalUrl + "DVLD.Data.Access.Layer.dll");
            public static (string name, string url) ProtectedData => ("System.Security.Cryptography.ProtectedData.dll", GlobalUrl + "System.Security.Cryptography.ProtectedData.dll");
        }
        public SetupForm()
        {
            InitializeComponent();
            InitializeWizard();
            PopulateAboutContent();
            PopulateTermsAndConditions();
        }

        private void InitializeWizard()
        {
            // Set initial state for Step 0 (Terms and Conditions)
            pnlStep0.Visible = true;
            chkAgree.CheckedChanged += chkAgree_CheckedChanged;
            btnNext.Enabled = false; // Next button disabled until terms are agreed

            // Set initial state for Step 1
            rbDefaultPath.Checked = true;
            rbDefaultPath.CheckedChanged += rbDefaultPath_CheckedChanged;
            rbCustomPath.CheckedChanged += rbCustomPath_CheckedChanged;
            txtInstallationPath.Text = _installationPath;
            txtInstallationPath.Enabled = false;

            // Hide other panels
            pnlStep1.Visible = false;
            pnlStep2.Visible = false;
            pnlStep3.Visible = false;
            pnlStep4.Visible = false;
            pnlStep5.Visible = false;

            // Update navigation buttons
            btnBack.Enabled = false;
            btnNext.Text = "Next >";
            UpdateHeaderTitle();
        }

        private void UpdateHeaderTitle()
        {
            lblTitle.Text = $"DVLD Setup Wizard - Step {_currentStep + 1} of 6"; 
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            switch (_currentStep)
            {
                case 0:
                    if (chkAgree.Checked)
                    {
                        _currentStep++;
                        ShowStep(_currentStep);
                    }
                    else
                    {
                        MessageBox.Show("You must agree to the terms and conditions to proceed.", "Terms and Conditions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case 1:
                    if (ValidateStep1())
                    {
                        _currentStep++;
                        ShowStep(_currentStep);
                    }
                    break;
                case 2:
                    _currentStep++;
                    ShowStep(_currentStep);
                    break;
                case 3:
                    _currentStep++;
                    ShowStep(_currentStep);
                    break;
                case 4:
                    _currentStep++;
                    ShowStep(_currentStep);
                    break;
                case 5:
                    // Finish installation
                    MessageBox.Show("DVLD Setup completed successfully!", "Setup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;
            }
            UpdateNavigationButtons();
            UpdateHeaderTitle();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_currentStep > 0)
            {
                _currentStep--;
                ShowStep(_currentStep);
            }
            UpdateNavigationButtons();
            UpdateHeaderTitle();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel the setup?", "Cancel Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ShowStep(int step)
        {
            pnlStep0.Visible = false;
            pnlStep1.Visible = false;
            pnlStep2.Visible = false;
            pnlStep3.Visible = false;
            pnlStep4.Visible = false;
            pnlStep5.Visible = false;

            switch (step)
            {
                case 0:
                    pnlStep0.Visible = true;
                    break;
                case 1:
                    pnlStep1.Visible = true;
                    SimulatePathCreation();
                    break;
                case 2:
                    pnlStep2.Visible = true;
                    if (!_isDBInstalled) SimulateDatabaseInstallation();
                    break;
                case 3:
                    pnlStep3.Visible = true;
                    if (!_isAppInstalled) SimulateApplicationInstallation();
                    break;
                    case 4:
                    pnlStep4.Visible = true;
                    break;
                    case 5:
                    pnlStep5.Visible = true;
                    break;
            }
        }

        private void UpdateNavigationButtons()
        {
            btnBack.Enabled = (_currentStep > 0);
            btnNext.Text = (_currentStep == 5) ? "Finish" : "Next >";
            if (_currentStep == 0) // For Terms and Conditions, Next button depends on checkbox
            {
                btnNext.Enabled = chkAgree.Checked;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }

        private bool ValidateStep1()
        {
            if (rbCustomPath.Checked && string.IsNullOrWhiteSpace(txtInstallationPath.Text))
            {
                MessageBox.Show("Please select a valid installation path.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            _installationPath = txtInstallationPath.Text;
            return true;
        }

        private void rbDefaultPath_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDefaultPath.Checked)
            {
                txtInstallationPath.Text = "C:\\DVLD";
                txtInstallationPath.Enabled = false;
                btnBrowse.Enabled = false;
            }
        }

        private void rbCustomPath_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCustomPath.Checked)
            {
                txtInstallationPath.Enabled = true;
                btnBrowse.Enabled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInstallationPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SimulatePathCreation()
        {
            try
            {
                if (!Directory.Exists(_installationPath))
                {
                    Directory.CreateDirectory(_installationPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating installation path: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void SimulateDatabaseInstallation()
        {
            pbDBInstallation.Value = 0;
            lblDBStatus.Text = "Status: Initializing...";
            await Task.Delay(1000);

            for (int i = 0; i <= 100; i += 10)
            {
                pbDBInstallation.Value = i;
                lblDBStatus.Text = $"Status: Installing Database... {i}%";
                await SimulateDBInstallationStep(i);
                await Task.Delay(300);
            }

            lblDBStatus.Text = "Status: Database Installation Complete.";
            _isDBInstalled = true;
        }

        private (string DataName, string LogName) GetLogicalNames(string backupFilePath, string connectionString)
        {
            (string DataName, string LogName) names = (null, null);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "RESTORE FILELISTONLY FROM DISK = @backupFilePath";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@backupFilePath", backupFilePath);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string type = reader["Type"].ToString(); // D = Data, L = Log
                            string logicalName = reader["LogicalName"].ToString();

                            if (type == "D")
                            {
                                names.DataName = logicalName;
                            }
                            else if (type == "L")
                            {
                                names.LogName = logicalName;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving logical names: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return names;
        }

        private async Task SimulateDBInstallationStep(int progress)
        {
            string localFilePath = Path.Combine(_installationPath, Components.DatabaseBackup.name);
            string availableDBName = $"DVLD_{DateTime.Now:yyyyMMddHHmmss}";
            string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";

            // Simulate different steps of database installation based on progress
            switch (progress)
            {
                // Install database backup file from GitHub at 30% progress
                case 30:
                    string filePath = Components.DatabaseBackup.url;
                    bool isFileDownloaded = true;
                    using (var client = new System.Net.WebClient())
                    {
                        try
                        {
                            await client.DownloadFileTaskAsync(new Uri(filePath), localFilePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error downloading database backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isFileDownloaded = false;
                        }
                    }
                    if (!isFileDownloaded) this.Close();
                    break;
                // Restore database from backup file at 70% progress
                case 70:
                    bool isRestoreSuccessful = true;
                    (string DataName, string LogName) logicalNames = GetLogicalNames(localFilePath, connectionString);
                    if (logicalNames.DataName == null || logicalNames.LogName == null)
                    {
                        this.Close();
                        return;
                    }
                    using (var connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            await connection.OpenAsync();

                            string restoreQuery = $@"
                                    RESTORE DATABASE {availableDBName}
                                    FROM DISK = '{localFilePath}'
                                    WITH 
                                    MOVE '{logicalNames.DataName}' TO '{_installationPath}\\{availableDBName}.mdf',
                                    MOVE '{logicalNames.LogName}' TO '{_installationPath}\\{availableDBName}_Log.ldf'";

                            using (var command = new SqlCommand(restoreQuery, connection))
                            {
                                await command.ExecuteNonQueryAsync();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error restoring database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isRestoreSuccessful = false;
                        }
                    }
                    if (!isRestoreSuccessful) this.Close();
                    _databaseName = availableDBName; // Store the database name for later use
                    break;
                case 90:
                    lblDBStatus.Text = "Status: Finalizing Database Installation...";
                    break;

            }
        }

        private async void SimulateApplicationInstallation()
        {
            pbAppInstallation.Value = 0;
            lblAppStatus.Text = "Status: Initializing...";
            await Task.Delay(1000);

            for (int i = 0; i <= 100; i += 10)
            {
                pbAppInstallation.Value = i;
                lblAppStatus.Text = $"Status: Installing Application Components... {i}%";
                await SimulateAppComponentInstallationStep(i);
                await Task.Delay(300);
            }
            lblAppStatus.Text = "Status: Application Installation Complete.";
            _isAppInstalled = true;
        }

        private async Task SimulateAppComponentInstallationStep(int progress)
        {
            // Simulate different steps of application installation based on progress
            switch (progress)
            {
                // Install application config files from GitHub
                case 20:
                    var configFilesToDownload = new (string name, string url)[]
                    {
                        Components.DVLDConfigFile,
                        Components.LogsConfigFile,
                    };
                    foreach (var file in configFilesToDownload)
                    {
                        string fileName = file.name;
                        string fileUrl = file.url;
                        string localFilePath = Path.Combine(_installationPath, fileName);
                        using (var client = new System.Net.WebClient())
                        {
                            try
                            {
                                await client.DownloadFileTaskAsync(new Uri(fileUrl), localFilePath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error downloading {fileName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                                return;
                            }
                        }
                    }
                    break;
                // Install application executable files from GitHub
                case 40:
                    var filesToDownload = new (string name, string url)[]
                    {
                        Components.DVLDExecutable,
                        Components.LogsExecutable,
                    };
                    foreach (var file in filesToDownload)
                    {
                        string fileName = file.name;
                        string fileUrl = file.url;
                        string localFilePath = Path.Combine(_installationPath, fileName);
                        using (var client = new System.Net.WebClient())
                        {
                            try
                            {
                                await client.DownloadFileTaskAsync(new Uri(fileUrl), localFilePath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error downloading {fileName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                                return;
                            }
                        }
                    }
                    break;
                // Modify the connection string path in the config files to the new database path
                case 60:
                    string dvldConfigPath = Path.Combine(_installationPath, Components.DVLDExecutable.name);
                    string logsConfigPath = Path.Combine(_installationPath, Components.LogsExecutable.name);
                    string newConnectionString = $"Server=.;Database={_databaseName};Trusted_Connection=True;";
                    try
                    {
                        // Update DVLD config file
                        var dvldConfig = ConfigurationManager.OpenExeConfiguration(dvldConfigPath);
                        dvldConfig.ConnectionStrings.ConnectionStrings["DVLD"].ConnectionString = newConnectionString;
                        dvldConfig.Save();
                        // Update Logs config file
                        var logsConfig = ConfigurationManager.OpenExeConfiguration(logsConfigPath);
                        logsConfig.ConnectionStrings.ConnectionStrings["DVLD"].ConnectionString = newConnectionString;
                        logsConfig.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating config files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                    break;
                // Install application DLLs from GitHub
                case 90:
                    var dllsToDownload = new (string name, string url)[]
                    {
                        Components.DTOs,
                        Components.BusinessLayer,
                        Components.DataAccessLayer,
                        Components.ProtectedData
                    };
                    foreach (var dll in dllsToDownload)
                    {
                        string fileName = dll.name;
                        string fileUrl = dll.url;
                        string localFilePath = Path.Combine(_installationPath, fileName);
                        using (var client = new System.Net.WebClient())
                        {
                            try
                            {
                                await client.DownloadFileTaskAsync(new Uri(fileUrl), localFilePath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error downloading {fileName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                                return;
                            }
                        }
                    }
                    break;
                
            }
        }

        private void chkAgree_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = chkAgree.Checked;
        }

        private void PopulateAboutContent()
        {
            // English Content extracted from DVLD_Info.txt
            string englishContent = "DVLD Application Information:\n" +
                                    "- Full Name: Driving & Vehicle License Department (DVLD)\n" +
                                    "- Purpose: Manage the process of issuing driving licenses, ensuring road safety, and simplifying service requirements.\n" +
                                    "- Main Services:\n" +
                                    "  1. Issuing driving license for the first time.\n" +
                                    "  2. Retaking tests.\n" +
                                    "  3. Renewing driving licenses.\n" +
                                    "  4. Replacing lost licenses.\n" +
                                    "  5. Replacing damaged licenses.\n" +
                                    "  6. Releasing detained licenses.\n" +
                                    "  7. Issuing international driving licenses.\n" +
                                    "- Application Details:\n" +
                                    "  - Tracks application number, date, type, status, and paid fees.\n" +
                                    "  - Linked to a person\'s National No.\n" +
                                    "- License Categories:\n" +
                                    "  1. Small Motorcycle (Class 1) - Age 18+, Fee $15, Valid 5 years.\n" +
                                    "  2. Heavy Motorcycle (Class 2) - Age 21+, Fee $30, Valid 5 years.\n" +
                                    "  3. Ordinary Driving License (Class 3) - Age 18+, Fee $20, Valid 10 years.\n" +
                                    "  4. Commercial License (Taxi/Limo) (Class 4) - Age 21+, Fee $200, Valid 10 years.\n" +
                                    "  5. Agricultural License (Class 5) - Age 21+, Fee $50, Valid 10 years.\n" +
                                    "  6. Small/Medium Bus License (Class 6) - Age 21+, Fee $250, Valid 10 years.\n" +
                                    "  7. Truck/Heavy Vehicle License (Class 7) - Age 21+, Fee $300, Valid 10 years.\n" +
                                    "- Requirements: Age check, previous license check, valid ID, medical/vision test, theoretical test, and practical test.\n" +
                                    "- Test Types: Vision, Theory, Practical.\n" +
                                    "- License Information: License number, holder photo, name, national no, birth date, class, issue date, expiry date, notes, and status (New, Renewed, Lost, Damaged).\n";

            // Arabic Content (translated from the PDF)
            string arabicContent = "معلومات تطبيق DVLD:\n" +
                                   "- الاسم الكامل: إدارة تراخيص السواقة والمركبات (DVLD)\n" +
                                   "- الغرض: إدارة عملية إصدار تراخيص القيادة، ضمان السلامة على الطرق، وتبسيط متطلبات الخدمة.\n" +
                                   "- الخدمات الرئيسية:\n" +
                                   "  1. إصدار رخصة قيادة لأول مرة.\n" +
                                   "  2. إعادة الاختبارات.\n" +
                                   "  3. تجديد رخص القيادة.\n" +
                                   "  4. استبدال الرخص المفقودة.\n" +
                                   "  5. استبدال الرخص التالفة.\n" +
                                   "  6. الإفراج عن الرخص المحتجزة.\n" +
                                   "  7. إصدار رخص قيادة دولية.\n" +
                                   "- تفاصيل التطبيق:\n" +
                                   "  - يتتبع رقم الطلب، التاريخ، النوع، الحالة، والرسوم المدفوعة.\n" +
                                   "  - مرتبط بالرقم الوطني للشخص.\n" +
                                   "- فئات الرخص:\n" +
                                   "  1. دراجة نارية صغيرة (فئة 1) - العمر 18+، الرسوم 15 دولار، صالحة لمدة 5 سنوات.\n" +
                                   "  2. دراجة نارية ثقيلة (فئة 2) - العمر 21+، الرسوم 30 دولار، صالحة لمدة 5 سنوات.\n" +
                                   "  3. رخصة قيادة عادية (فئة 3) - العمر 18+، الرسوم 20 دولار، صالحة لمدة 10 سنوات.\n" +
                                   "  4. رخصة تجارية (تاكسي/ليموزين) (فئة 4) - العمر 21+، الرسوم 200 دولار، صالحة لمدة 10 سنوات.\n" +
                                   "  5. رخصة زراعية (فئة 5) - العمر 21+، الرسوم 50 دولار، صالحة لمدة 10 سنوات.\n" +
                                   "  6. رخصة حافلة صغيرة/متوسطة (فئة 6) - العمر 21+، الرسوم 250 دولار، صالحة لمدة 10 سنوات.\n" +
                                   "  7. رخصة شاحنة/مركبة ثقيلة (فئة 7) - العمر 21+، الرسوم 300 دولار، صالحة لمدة 10 سنوات.\n" +
                                   "- المتطلبات: التحقق من العمر، التحقق من الرخص السابقة، هوية صالحة، فحص طبي/بصري، اختبار نظري، واختبار عملي.\n" +
                                   "- أنواع الاختبارات: بصري، نظري، عملي.\n" +
                                   "- معلومات الرخصة: رقم الرخصة، صورة حامل الرخصة، الاسم، الرقم الوطني، تاريخ الميلاد، الفئة، تاريخ الإصدار، تاريخ الانتهاء، ملاحظات، والحالة (جديدة، مجددة، مفقودة، تالفة).\n";

            rtbAbout.Tag = new string[] { englishContent, arabicContent }; // Store both contents
            rtbAbout.Text = englishContent; // Default to English
        }

        private void PopulateTermsAndConditions()
        {
            rtbTerms.Text = "Welcome to the Driving License Management System Setup Wizard.\n\n" +
                            "Please read the following Terms and Conditions carefully before proceeding with the installation.\n\n" +
                            "1. License Agreement: This software is provided under a limited license. You may not redistribute, modify, or reverse engineer this software without explicit written permission.\n" +
                            "2. Data Usage: By installing, you agree that the application may collect anonymous usage data to improve future versions. Personal data will not be collected.\n" +
                            "3. Disclaimer: The software is provided \'as is\' without warranty of any kind, either express or implied. The developers are not liable for any damages arising from the use of this software.\n" +
                            "4. System Requirements: Ensure your system meets the minimum requirements for .NET Framework and SQL Server. Refer to the documentation for details.\n" +
                            "5. Support: For technical support, please refer to the official documentation or contact our support team.\n\n" +
                            "By checking the \'I agree\' box and clicking \'Next\', you acknowledge that you have read, understood, and agree to be bound by these Terms and Conditions.";
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            string[] contents = rtbAbout.Tag as string[];
            if (contents != null && contents.Length == 2)
            {
                _isArabic = !_isArabic;
                if (_isArabic)
                {
                    rtbAbout.Text = contents[1]; // Show Arabic content
                    btnTranslate.Text = "English";
                }
                else
                {
                    rtbAbout.Text = contents[0]; // Show English content
                    btnTranslate.Text = "العربية";
                }
            }
        }
    }
}
