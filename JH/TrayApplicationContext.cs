using SpeakToMe;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace JH
{
    internal class TrayApplicationContext : ApplicationContext
    {
        public NotifyIcon notifyIcon;

        public MainForm mainForm;
        public AboutForm aboutForm;

        public Thread workerThread;

        private TrayManager trayManager;

        public Narrator narrator = new Narrator();

        /// <summary>
        /// Constructs the TrayApplicationInstance instance.
        /// </summary>
        public TrayApplicationContext()
        {
            InitializeContext();
        }

        /// <summary>
        /// Initializes the Application Context.
        /// </summary>
        private void InitializeContext()
        {
            trayManager = new TrayManager(this);

            workerThread = new Thread(new ThreadStart(WorkerThread));
            workerThread.Start();
        }

        #region Thread Worker

        /// <summary>
        /// Runs the work in a seperate thread.
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
            catch (ThreadAbortException)
            {
                throw;
            }
        }

        #endregion
    }
}