using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    public class myTreeView : TreeView
    {
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203) // identified double click
                m.Result = IntPtr.Zero;
            else
                base.WndProc(ref m);
        }
    }
}