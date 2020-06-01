using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TouchlessLib;

namespace FAMS
{
    public partial class camera_list : Form
    {
        public camera_list()
        {
            InitializeComponent();

            using (TouchlessMgr mgr = new TouchlessMgr())
            {
                int index = -1;
                foreach (Camera cam in mgr.Cameras)
                {
                    index++;
                    cam_index.Items.Add(new ComboItem(index, cam.ToString()));
                }
            }

            cam_index.SelectedIndex = 0;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            (this.Owner as member_picture).CamIndex = (cam_index.SelectedItem as ComboItem).Key.Value;
            this.Close();
        }
    }
}
