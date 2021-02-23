using GetGoPOS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetGoPOS
{
    static class Program
    {
        public static string Version { get; private set; }
        private static Mutex mutex = new Mutex(false, Application.ProductName);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.FromSeconds(1), false))
            {
                MessageBox.Show("Application is already running!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Helpers.DataBaseHelper.CreateDatabase();

            Application.ThreadException += Application_ThreadException;

            if (!ConfigGetter.GetConfigDetails())
            {
                MessageBox.Show("[Config Getter] Unable to load configuration details.");
                return;
            }
            GenerateReport.GenerateUngeneratedReport();
            Application.Run(new MainForm());
            mutex.ReleaseMutex();
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
