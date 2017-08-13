using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JH
{
    public partial class MainForm : Form
    {
        #region Main Form Stuff

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Flips the Window State
        /// </summary>
        /// <param name="v">True to force hide</param>
        private void FlipWindowState(bool v = false)
        {
            if( v || (this.WindowState == FormWindowState.Normal))
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            } else
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }
    }
}
