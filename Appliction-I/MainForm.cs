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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public Editor EditorForm { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //ایجاد یک فرم لاگ این به هنگام لود فرم اصلی
            LogIn frm = new LogIn();
            frm.MdiParent = this;
            frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //نمایش فرم درباره ما
            AboutBox frm = new AboutBox();
            frm.Show();
        }

        //کد گزینه های منوی فایل
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditorForm != null)
            {
                System.Windows.Forms.DialogResult 
                oResault =  MessageBox.Show(
                            text:"Do you want save?", 
                            caption:"Editor", 
                            buttons: MessageBoxButtons.YesNoCancel, 
                            defaultButton: MessageBoxDefaultButton.Button1, 
                            icon: MessageBoxIcon.Question
                            );
                if (oResault == DialogResult.Yes)
                {
                    SaveText();
                }
                if (oResault == DialogResult.No)
                {
                    EditorForm.txtEditor.Text = string.Empty;
                }
            }
            else
            {
                Editor frm = new Editor();
                frm.MdiParent = this;
                EditorForm = frm;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
                editToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
            }

            StatusLable.Text = "Ready";
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditorForm != null)
            {
                System.Windows.Forms.DialogResult
                oResault = MessageBox.Show(
                            text: "Do you want save?",
                            caption: "Editor",
                            buttons: MessageBoxButtons.YesNoCancel,
                            defaultButton: MessageBoxDefaultButton.Button1,
                            icon: MessageBoxIcon.Question
                            );
                if (oResault == DialogResult.Yes)
                {
                    SaveText();
                }
                if (oResault == DialogResult.Cancel)
                {
                    return;
                }
                System.Windows.Forms.OpenFileDialog Dialog = new OpenFileDialog();
                Dialog.ShowDialog();
                if (Dialog.FileName == "")
                {
                    return;
                }
                EditorForm.txtEditor.Text = string.Empty;
                ReadText(Dialog.FileName);
            }
            else
            {
                System.Windows.Forms.OpenFileDialog Dialog = new OpenFileDialog();
                Dialog.ShowDialog();
                if (Dialog.FileName == "")
                {
                    return;
                }
                Editor frm = new Editor();
                frm.MdiParent = this;
                EditorForm = frm;
                frm.Show();
                editToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                ReadText(Dialog.FileName);
            }

            StatusLable.Text = "Ready";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveText();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //کد گزینه های منو ادیت
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditorForm.txtEditor.SelectedText.Length > 0)
            {
                EditorForm.txtEditor.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditorForm.txtEditor.SelectedText.Length > 0)
            {
                EditorForm.txtEditor.Copy();
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                EditorForm.txtEditor.Paste();
            }
        }
        public void SaveText()
        {
            System.Windows.Forms.SaveFileDialog Dialog = new SaveFileDialog();
            Dialog.ShowDialog();
            if (Dialog.FileName == "")
            {
                return;
            }
            System.IO.StreamWriter oStream = new System.IO.StreamWriter(path:Dialog.FileName, append: false, encoding: Encoding.UTF8);
            oStream.Write(EditorForm.txtEditor.Text);
            oStream.Flush();
            oStream.Close();
        }

        private void ReadText(string path)
        {
            System.IO.StreamReader oStream = new System.IO.StreamReader(path: path, encoding: Encoding.UTF8);
            EditorForm.txtEditor.Text = oStream.ReadToEnd();
            oStream.Close();
        }


    }
}
