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
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm oMainForm = this.MdiParent as MainForm;
            System.Windows.Forms.DialogResult
                oResault = MessageBox.Show(
                            text: "Do you want save?",
                            caption: "Editor",
                            buttons: MessageBoxButtons.YesNo,
                            defaultButton: MessageBoxDefaultButton.Button1,
                            icon: MessageBoxIcon.Question
                            );
            if (oResault == DialogResult.Yes)
            {
                oMainForm.SaveText();
            }

            oMainForm.EditorForm = null;
            oMainForm.saveToolStripMenuItem.Enabled = false;
        }
    }
}
