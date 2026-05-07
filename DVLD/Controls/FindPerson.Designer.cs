namespace Driving_License_Management
{
    partial class FindPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindPerson));
            this.button4 = new System.Windows.Forms.Button();
            this.AddPerson = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.personInfo1 = new Driving_License_Management.PersonInfo();
            this.groupBoxFillter = new System.Windows.Forms.GroupBox();
            this.groupBoxFillter.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(360, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(49, 40);
            this.button4.TabIndex = 36;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // AddPerson
            // 
            this.AddPerson.Image = ((System.Drawing.Image)(resources.GetObject("AddPerson.Image")));
            this.AddPerson.Location = new System.Drawing.Point(415, 8);
            this.AddPerson.Name = "AddPerson";
            this.AddPerson.Size = new System.Drawing.Size(49, 40);
            this.AddPerson.TabIndex = 35;
            this.AddPerson.UseVisualStyleBackColor = true;
            this.AddPerson.Click += new System.EventHandler(this.AddPerson_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(221, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 20);
            this.textBox1.TabIndex = 34;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "PersonID",
            "NationalNo"});
            this.comboBox1.Location = new System.Drawing.Point(82, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Find By: ";
            // 
            // personInfo1
            // 
            this.personInfo1.Location = new System.Drawing.Point(3, 54);
            this.personInfo1.Name = "personInfo1";
            this.personInfo1.Size = new System.Drawing.Size(554, 256);
            this.personInfo1.TabIndex = 31;
            // 
            // groupBoxFillter
            // 
            this.groupBoxFillter.Controls.Add(this.comboBox1);
            this.groupBoxFillter.Controls.Add(this.button4);
            this.groupBoxFillter.Controls.Add(this.label1);
            this.groupBoxFillter.Controls.Add(this.AddPerson);
            this.groupBoxFillter.Controls.Add(this.textBox1);
            this.groupBoxFillter.Location = new System.Drawing.Point(3, 3);
            this.groupBoxFillter.Name = "groupBoxFillter";
            this.groupBoxFillter.Size = new System.Drawing.Size(554, 51);
            this.groupBoxFillter.TabIndex = 37;
            this.groupBoxFillter.TabStop = false;
            this.groupBoxFillter.Text = "Fillter";
            // 
            // FindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxFillter);
            this.Controls.Add(this.personInfo1);
            this.Name = "FindPerson";
            this.Size = new System.Drawing.Size(563, 314);
            this.groupBoxFillter.ResumeLayout(false);
            this.groupBoxFillter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button AddPerson;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private PersonInfo personInfo1;
        private System.Windows.Forms.GroupBox groupBoxFillter;
    }
}
