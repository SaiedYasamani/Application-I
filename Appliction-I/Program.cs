using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appliction_I
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //ایجاد و رفع فرم اصلی
            MainForm frm = new MainForm();
            Application.Run(frm);
            if (frm != null)
            {
                frm.Dispose();
                frm = null;
            }
        }
    }
}
