using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace JH
{
    internal class CustomApplicationContext : ApplicationContext
    {
        public NotifyIcon notifyIcon;

        public MainForm mainForm;
        public AboutForm aboutForm;

        public Thread workerThread;

        private TrayManager trayManager;

        public CustomApplicationContext()
        {
            InitializeContext();
        }

        private void InitializeContext()
        {
            trayManager = new TrayManager(this);

            workerThread = new Thread(new ThreadStart(WorkerThread));
            workerThread.Start();
        }

        #region Thread Worker

        /// <summary>
        /// Runs the work in a seperate thread
        /// </summary>
        public void WorkerThread()
        {
            try
            {
                while (true)
                {
                    // Sleep for 20 Seconds
                    Thread.Sleep(20000);
                }
            }
            catch (ThreadAbortException e)
            {
                throw;
            }
        }

        #endregion
    }
}