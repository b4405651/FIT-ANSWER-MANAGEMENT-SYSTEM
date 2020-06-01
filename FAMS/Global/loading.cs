using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FAMS
{
    public partial class loading : Form
    {
        public loading_content loadingContent = null;

        public loading()
        {
            InitializeComponent();

            loadingContent = new loading_content();
            this.AddOwnedForm(loadingContent);
        }

        private void loading_Load(object sender, EventArgs e)
        {
            this.Left = this.Top = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            loadingContent.Location = new Point(
            this.ClientSize.Width / 2 - loadingContent.Size.Width / 2,
            this.ClientSize.Height / 2 - loadingContent.Size.Height / 2);
            loadingContent.Anchor = AnchorStyles.None;
        }
    }
}
