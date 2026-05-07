using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;
using DVLD_Business_Layer;
namespace Driving_License_Management
{
    public partial class PersonDetails : Form
    {
        public class cmdEnterEventArgs : EventArgs
        {
            public Keys KeyData { get;}
            public clsPerson person { get; set; }
            public cmdEnterEventArgs(Keys keyData)
            {
                KeyData = keyData;
            }
        }
        public event EventHandler<cmdEnterEventArgs> MoveTo;
        public PersonDetails(clsPerson Person)
        {
            InitializeComponent();
            personInfo1.LoadData(Person);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down)
            {
                cmdEnterEventArgs args = new cmdEnterEventArgs(keyData);
                MoveTo?.Invoke(this, args);
                if (args.person != null)
                {
                    personInfo1.LoadData(args.person);
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
