using SpeakToMe;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Tocsin;

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

        public PingPong pingPong = new PingPong();

        /// <summary>
        /// Constructs the TrayApplicationInstance instance.
        /// </summary>
        public TrayApplicationContext()
        {
            InitializeContext();

            // pinger.Ping("http://jimmyhowe.com");            
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
                    bool jimmyhowe = pingPong.Ping("http://jimmyhowe.com");
                    bool greensavenue = pingPong.Ping("http://greensavenue.co.uk");

                    if ( ! (jimmyhowe || greensavenue) )
                    {
                        narrator.saySomething("One of your sites is down.");
                    }

                    // Sleep for 2 Seconds
                    Thread.Sleep(2000);
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