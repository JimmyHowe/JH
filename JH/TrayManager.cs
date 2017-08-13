using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JH
{
    /// <summary>
    /// Manages the Tray Object
    /// </summary>
    class TrayManager
    {
        /// <summary>
        /// Application Context
        /// </summary>
        TrayApplicationContext context;

        /// <summary>
        /// Active Icon
        /// </summary>
        Icon activeIcon;
        
        /// <summary>
        /// Error Icon
        /// </summary>
        Icon errorIcon;

        /// <summary>
        /// Constructs a new TrayManager instance.
        /// </summary>
        /// <param name="context">The TrayApplicationContext instance</param>
        public TrayManager(TrayApplicationContext context)
        {
            activeIcon = new Icon("icons\\active.ico");
            errorIcon = new Icon("icons\\error.ico");

            this.context = context;

            BuildSystemTray();
        }

        /// <summary>
        /// Builds the nitification tray object.
        /// </summary>
        private void BuildSystemTray()
        {
            context.notifyIcon = new NotifyIcon();
            context.notifyIcon.Icon = activeIcon;
            context.notifyIcon.Visible = true;
            context.notifyIcon.ContextMenu = getContextMenu();
        }

        /// <summary>
        /// Builds the context menu.
        /// </summary>
        /// <returns></returns>
        private ContextMenu getContextMenu()
        {
            ContextMenu contextMenu = new ContextMenu();

            MenuItem aboutMenuItem = new MenuItem("About");
            aboutMenuItem.Click += AboutMenuItem_Click;

            MenuItem quitMenuItem = new MenuItem("Quit");
            quitMenuItem.Click += QuitMenuItem_Click;

            contextMenu.MenuItems.Add(aboutMenuItem);
            contextMenu.MenuItems.Add(quitMenuItem);

            return contextMenu;
        }

        /// <summary>
        /// Fires when the about menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            if( context.aboutForm == null)
            {
                context.aboutForm = new AboutForm();
            }

            context.aboutForm.Show();
        }

        /// <summary>
        /// Fires when the quit menu item is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            // Abort Thread
            context.workerThread.Abort();

            // Dispose Notification icon
            context.notifyIcon.Dispose();

            // Close Window
            Application.Exit();
        }
    }
}
