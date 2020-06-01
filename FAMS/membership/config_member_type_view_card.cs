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
    public partial class config_member_type_view_card : Form
    {
        public config_member_type_view_card(String fileName)
        {
            InitializeComponent();

            GF.getImage(fileName, ref pictureBox, "member_card");

            this.Width = pictureBox.Image.Width;
            this.Height = pictureBox.Image.Height;

            this.CenterToScreen();
        }

        private void config_member_type_view_card_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox.Image.Dispose();
        }
    }
}
