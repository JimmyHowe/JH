using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JH
{
    class TrayManager
    {
        TrayApplicationContext context;

        Icon activeIcon;
        Icon errorIcon;

        public TrayManager(TrayApplicationContext context)
        {
            activeIcon = new Icon("icons\\active.ico");
            errorIcon = new Icon("icons\\error.ico");

            this.context = context;

            BuildSystemTray();
        }

        private void BuildSystemTray()
        {
            context.notifyIcon = new NotifyIcon();
            context.notifyIcon.Icon = activeIcon;
            context.notifyIcon.Visible = true;
            context.notifyIcon.ContextMenu = getContextMenu();
        }

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

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            if( context.aboutForm == null)
            {
                context.aboutForm = new AboutForm();
            }

            context.aboutForm.Show();
        }

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
