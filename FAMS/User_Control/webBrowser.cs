using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAMS
{
    public class webBrowser : WebBrowser
    {
        public webBrowser(Panel wb_panel)
        {
            this.AllowNavigation = false;
            this.AllowWebBrowserDrop = false;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IsWebBrowserContextMenuEnabled = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(20, 20);
            this.Name = "webBrowser";
            this.Size = new System.Drawing.Size(468, 357);
            this.TabIndex = 2;
            this.WebBrowserShortcutsEnabled = false;

            wb_panel.Controls.Clear();
            wb_panel.Controls.Add(this);
        }
    }
}
