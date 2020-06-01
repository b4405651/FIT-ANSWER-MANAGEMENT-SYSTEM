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
    public partial class member_picture : Form
    {
        String member_no = "";
        TouchlessMgr manager;
        Boolean isCameraRunning = false;
        int processCount = 1;
        public int CamIndex = -1;
        public member_picture(String _member_no)
        {
            InitializeComponent();
            this.member_no = _member_no;

            manager = new TouchlessMgr();

            if (manager.Cameras.Count >= 1)
            {
                using (camera_list cam_list = new camera_list())
                {
                    cam_list.Owner = this;
                    cam_list.ShowDialog();
                    this.BringToFront();
                    this.Activate();
                }
            }
            else
                CamIndex = 0;

            if (CamIndex == -1)
            {
                GF.Error("ต้องเลือกกล้อง WebCam ก่อน !");
                return;
            }
            manager.CurrentCamera = manager.Cameras[CamIndex];
            manager.CurrentCamera.Fps = 30;

            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;

            this.Width = manager.CurrentCamera.CaptureWidth;
            this.Height = manager.CurrentCamera.CaptureHeight + titleHeight;

            //Console.WriteLine(manager.CurrentCamera.CaptureWidth.ToString() + " x " + manager.CurrentCamera.CaptureHeight.ToString());
            manager.CurrentCamera.OnImageCaptured += CurrentCamera_OnImageCaptured;
            isCameraRunning = true;
        }

        private void member_picture_Load(object sender, EventArgs e)
        {
            if (CamIndex == -1)
                this.Close();
        }

        private void picture_Click(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                manager.CurrentCamera.OnImageCaptured -= CurrentCamera_OnImageCaptured;
                picture.Image = manager.CurrentCamera.GetCurrentImage();
                isCameraRunning = false;
            }
            else
            {
                manager.CurrentCamera.OnImageCaptured += CurrentCamera_OnImageCaptured;
                isCameraRunning = true;
            }
        }

        private void member_picture_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (processCount == 1)
            {
                if (manager.CurrentCamera != null)
                    manager.CurrentCamera.Dispose();

                if (manager != null)
                    manager.Dispose();

                if (isCameraRunning) return;
                String pictureFilename = String.Empty;
                if (picture.Image != null)
                {
                    pictureFilename = member_no.Trim() + "_" + new Random().Next(100000, 999999).ToString("000000") + ".jpg";

                    var destRect = new Rectangle(0, 0, 240, 180);
                    var destImage = new Bitmap(240, 180);

                    destImage.SetResolution(picture.Image.HorizontalResolution, picture.Image.VerticalResolution);

                    using (var graphics = Graphics.FromImage(destImage))
                    {
                        graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                        using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                        {
                            wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                            graphics.DrawImage(picture.Image, destRect, 0, 0, picture.Image.Width, picture.Image.Height, GraphicsUnit.Pixel, wrapMode);
                        }
                    }


                    destImage.Save(GF.Settings("tmp_path") + pictureFilename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    processCount++;

                    (this.Owner as member_manage).picture.Image = destImage;
                    (this.Owner as member_manage).pictureFilename = pictureFilename;
                    (this.Owner as member_manage).isPictureChanged = true;
                    this.Close();
                }
            }
        }

        private void CurrentCamera_OnImageCaptured(object sender, CameraEventArgs e)
        {
            //Giving the feed of the camera to the picturepox
            picture.Image = manager.CurrentCamera.GetCurrentImage();
        }
    }
}
