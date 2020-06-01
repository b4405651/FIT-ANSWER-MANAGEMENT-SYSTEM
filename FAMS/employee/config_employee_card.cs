using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public partial class config_employee_card : Form
    {
        int minHeight = 85; //top_panel.Height
        int maxHeight = 411; //this.Height
        String targetFileName = "";
        Image thePicture;
        public config_employee_card()
        {
            InitializeComponent();

            GF.disableBtn(save_btn);
        }

        private void config_employee_card_Load(object sender, EventArgs e)
        {
            GF.showLoading(this);
            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id" , GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("Employee/getEmpCardFileName/", values);

            if (Obj != null)
            {
                Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];
                //!Directory.EnumerateFileSystemEntries(GF.Settings("emp_card")).Any() || 
                if (Item["filename"].ToString() == String.Empty)
                    this.Height = minHeight;
                else
                {
                    Boolean isFTPPicture = false;
                    if (File.Exists(GF.Settings("emp_card") + Item["filename"].ToString()))
                        thePicture = Image.FromFile(GF.Settings("emp_card") + Item["filename"].ToString());
                    else
                    {
                        isFTPPicture = true;
                        thePicture = FTP.download("emp_card", Item["filename"].ToString());
                    }

                    var destRect = new Rectangle(0, 0, 502, 325);
                    var destImage = new Bitmap(502, 325);

                    destImage.SetResolution(thePicture.HorizontalResolution, thePicture.VerticalResolution);

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
                            graphics.DrawImage(thePicture, destRect, 0, 0, thePicture.Width, thePicture.Height, GraphicsUnit.Pixel, wrapMode);
                        }
                    }

                    if (isFTPPicture)
                    {
                        DirectoryInfo downloadedMessageInfo = new DirectoryInfo(GF.Settings("emp_card"));

                        foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                        {
                            file.Delete();
                        }
                        destImage.Save(GF.Settings("emp_card") + Item["filename"].ToString(), System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    pictureBox.Image = destImage;
                }
            }
            else
            {
                this.Height = minHeight;
                GF.closeLoading();
                GF.Error("เกิดความผิดพลาดในการรับชื่อไฟล์จาก Server !");
            }
            this.CenterToScreen();
            GF.closeLoading();
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                if (OFD.ShowDialog() == DialogResult.OK) // Test result.
                {
                    targetFileName = OFD.FileName;
                    using (Image tmpImg = Image.FromFile(targetFileName))
                    {
                        var destRect = new Rectangle(0, 0, 502, 325);
                        var destImage = new Bitmap(502, 325);

                        destImage.SetResolution(tmpImg.HorizontalResolution, tmpImg.VerticalResolution);

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
                                graphics.DrawImage(tmpImg, destRect, 0, 0, tmpImg.Width, tmpImg.Height, GraphicsUnit.Pixel, wrapMode);
                            }
                        }

                        pictureBox.Image = destImage;
                    }

                    this.Height = maxHeight;
                    GF.enableBtn(save_btn, Color.Green);
                    this.CenterToScreen();
                }
            }
        }

        private void config_employee_card_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thePicture != null) thePicture.Dispose();
            if (pictureBox.Image != null) pictureBox.Image.Dispose();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            GF.showLoading(this);
            String newFileName = (DateTime.Now.Year + 543).ToString() + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Hour.ToString("00") + "-" + DateTime.Now.Minute.ToString("00") + "-" + DateTime.Now.Second.ToString("00") + ".jpg";

            List<string> FileList = FTP.getFTPFileList("emp_card");
            foreach (String FTPfilename in FileList)
            {
                if (!FTP.delete("emp_card", FTPfilename))
                {
                    GF.Error("เกิดความผิดพลาดในการลบไฟล์บน Server !!");
                    return;
                }
            }

            if (!FTP.upload("emp_card", targetFileName, newFileName))
            {
                GF.closeLoading();
                GF.Error("เกิดความผิดพลาดในการ upload ไฟล์รูปภาพไปยัง server !!");
                return;
            }

            Dictionary<string, string> values = new Dictionary<string, string>();

            values = new Dictionary<string, string>
            {
                { "filename", newFileName }
            };

            Dictionary<String, Object> result = DB.Post("Employee/manageEmpCard/", values);

            if (result == null)
            {
                GF.closeLoading();
                GF.Error("เกิดความผิดพลาด !!");
                return;
            }

            GF.closeLoading();
            this.Close();
        }
    }
}
