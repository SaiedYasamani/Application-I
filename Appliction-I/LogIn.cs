using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appliction_I
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "03061369")
            {
                MainForm oMainForm = this.MdiParent as MainForm;
                oMainForm.StatusLable.Text = "Welcome!";
                this.Close();
            }
            

        }
    }
}
