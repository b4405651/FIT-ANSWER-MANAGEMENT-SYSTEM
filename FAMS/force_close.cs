using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public partial class force_close : Form
    {
        public force_close()
        {
            InitializeComponent();
        }

        private void force_close_btn_Click(object sender, EventArgs e)
        {
            GF.Error("ABC");
        }
    }
}
