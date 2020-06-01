using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public static class GF
    {
        public static main mainPage = null;
        public static String userID = "";
        public static Boolean isAdmin = false;
        public static List<string> cultureList = null;
        public static loading loadingPage;
        public static force_close forceClosePage;
        public static int rowsPerPage = 25;
        public static ComboItem[] payment_type = { new ComboItem(0, "เงินสด"), new ComboItem(1, "บัตร") };
        public static Image tmpImg = null;
        public static int margin_left = 0;
        public static int margin_right = 30;
        public static int SSH_Port = 22;
        
        static Form loadingSender = null;
        static StreamWriter sw;

        public static void printError(string debugText)
        {
            try
            {
                sw = new StreamWriter(GF.Settings("tmp_path") + "error.txt", true);
                sw.WriteLine("[ " + NOW() + " ] " + debugText);
                sw.Close();
            }
            catch (Exception e)
            {
                GF.Error(e.Message);
            }
        }

        public static void closeChildren(Form mdiChild)
        {
            foreach(Form form in mainPage.MdiChildren)
            {
                form.Dispose();
            }
            if (mdiChild != null)
            {
                mdiChild.MdiParent = mainPage;
                mdiChild.Dock = DockStyle.Fill;
                mdiChild.Show();
            }
        }

        public static void Error(String ErrorMessage, String Title = "ERROR")
        {
            MessageBox.Show(ErrorMessage, Title);
        }

        public static void initLoading()
        {
            loadingPage = new loading();
            //forceClosePage = new force_close();
        }
        public static void showLoading(Form sender)
        {
            if (loadingPage == null || loadingPage.IsDisposed)
                loadingPage = new loading();

            /*if (forceClosePage == null || forceClosePage.IsDisposed)
                forceClosePage = new force_close();*/

            loadingSender = sender;
            loadingPage.loadingContent.Visible = true;
            //loadingPage.loadingContent.animated_loading_box.Update();
            loadingPage.Visible = true;

            /*forceClosePage.Height = 30;
            forceClosePage.Width = Screen.PrimaryScreen.WorkingArea.Width;
            forceClosePage.Top = Screen.PrimaryScreen.WorkingArea.Height - forceClosePage.Height;
            forceClosePage.Show();*/
        }
        public static void closeLoading()
        {
            if (loadingPage != null)
            {
                loadingPage.loadingContent.Visible = false;
                loadingPage.Visible = false;
            }
            if (loadingSender != null)
            {
                loadingSender.BringToFront();
                loadingSender.Activate();
            }
            //forceClosePage.Hide();
        }
        public static int? toInt(String strToInt)
        {
            int value;
            if (Int32.TryParse(strToInt, out value)) return value;
            else return null;
        }

        public static void resizeComboBox(ComboBox cb)
        {
            int temp = 0;
            int maxWidth = 0;

            foreach (var obj in cb.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), cb.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            if (maxWidth > 0) cb.DropDownWidth = maxWidth;
        }

        public static int getKey(ComboBox cmb)
        {
            return (int)((ComboItem)cmb.SelectedItem).Key;
        }

        public static String getStringFromDT(DateTimePicker DT, Boolean getOnlyMonthYear = false)
        {
            if (getOnlyMonthYear) return DT.Value.Month.ToString("00") + "/" + DT.Value.Year.ToString("0000");
            else return DT.Value.Day.ToString("00") + "/" + DT.Value.Month.ToString("00") + "/" + DT.Value.Year.ToString("0000");
        }

        public static Boolean isNumber(String text)
        {
            int tmp;
            return Int32.TryParse(text, out tmp);
        }

        public static void initDGV(DataGridView DGV)
        {
            DGV.Paint += (sender, e) =>
            {
                DataGridView sndr = (DataGridView)sender;

                if (sndr.Rows.Count == 0) // <-- if there are no rows in the DataGridView when it paints, then it will create your message
                {
                    using (Graphics grfx = e.Graphics)
                    {
                        // create a white rectangle so text will be easily readable
                        grfx.FillRectangle(Brushes.Gray, new Rectangle(new Point(), new Size(sndr.Width, sndr.Height)));
                        // write text on top of the white rectangle just created
                        using (Font font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold))
                        {
                            String text = "--- NO DATA ---";
                            SizeF stringSize = e.Graphics.MeasureString(text, font);
                            grfx.DrawString(text, font, Brushes.Black, new PointF((sndr.Width / 2) - 100, (sndr.Height / 2) - stringSize.Height));
                        }
                    }
                }
            };
        }

        public static Boolean validateDateTime(MaskedTextBox MTB)
        {
            if (MTB.Text.Trim().Length == 4)
                return true;

            if (!MTB.MaskFull)
            {
                GF.Error("กรุณากรอก 'วันที่' ให้ครบ !!");
                MTB.Select();
                return false;
            }

            String[] tmp = MTB.Text.Split('/');
            int day = Convert.ToInt32(tmp[0]);
            int month = Convert.ToInt32(tmp[1]);
            int year = Convert.ToInt32(tmp[2]) - 543;

            if(day <= 0) 
            {
                GF.Error("วันที่ ต้องมากกว่า 1 !!");
                MTB.Select();
                return false;
            }

            if (month <= 0 || month > 12)
            {
                GF.Error("เดือน ต้องอยู่ระหว่าง 1-12 !!");
                MTB.Select();
                return false;
            }

            if (year <= 0 || year > 9999)
            {
                GF.Error("ปี ต้องอยู่ระหว่าง 1-9999 !!");
                MTB.Select();
                return false;
            }

            if(day > DateTime.DaysInMonth(year, month))
            {
                GF.Error("ปี " + (year + 543).ToString() + " เดือน " + month.ToString("00") + " มี " + DateTime.DaysInMonth(year, month).ToString("00") + " วัน !!");
                MTB.Select();
                return false;
            }
            return true;
        }

        public static Boolean validateTime(MaskedTextBox MTB)
        {
            if (MTB.Text.Trim().Length == 1)
                return true;

            if (!MTB.MaskFull)
            {
                GF.Error("กรุณากรอก 'เวลา' ให้ครบ !!");
                MTB.Select();
                return false;
            }

            String[] tmp = MTB.Text.Split(':');
            int hours = Convert.ToInt32(tmp[0]);
            int mins = Convert.ToInt32(tmp[1]);

            if (hours < 0 || hours > 23)
            {
                GF.Error("ชั่วโมง ต้องอยู่ระหว่าง 00 ถึง 23 !!");
                MTB.Select();
                return false;
            }

            if (mins < 0 || mins > 59)
            {
                GF.Error("นาที ต้องอยู่ระหว่าง 00 ถึง 59 !!");
                MTB.Select();
                return false;
            }

            return true;
        }

        public static Boolean validateCardExpiry(MaskedTextBox MTB)
        {
            if (!MTB.MaskFull)
            {
                GF.Error("กรุณากรอก 'วันหมดอายุบัตร' ให้ครบ !!");
                MTB.Select();
                return false;
            }

            String[] tmp = MTB.Text.Split('/');
            int month = Convert.ToInt32(tmp[0]);
            int year = Convert.ToInt32(tmp[1]);

            if (month <= 0 || month > 12)
            {
                GF.Error("เดือน ต้องอยู่ระหว่าง 1-12 !!");
                MTB.Select();
                return false;
            }

            return true;
        }

        public static string formatNumber(int number)
        {
            return number.ToString("#,##0");
        }

        public static string formatNumber(String number)
        {
            if (number.Trim() == "" || number == null) return null;
            
            return Convert.ToInt32(number).ToString("#,##0");
        }

        public static string removeCommaDotFromNumber(String numberStr)
        {
            return numberStr.Replace(",", "").Replace(".00","");
        }

        public static string formatDBDateTime(String DateTime, Boolean onlyDay = false)
        {
            if (DateTime.Trim() == String.Empty) return String.Empty;
            if (DateTime.IndexOf(":") == -1) onlyDay = true;
            if (DateTime.IndexOf('.') > -1)
                DateTime = DateTime.Substring(0, DateTime.IndexOf('.'));
            String[] tmp = DateTime.Split(' ');

            String returnStr = "";

            if (tmp[0].IndexOf('-') != -1)
            {
                String[] date = tmp[0].Split('-');
                returnStr = date[2] + "/" + date[1] + "/" + date[0];
            }
            else returnStr = tmp[0];

            if (onlyDay)
                return returnStr;
            else
            {
                String[] time = tmp[1].Split(':');
                return returnStr + " " + time[0] + ":" + time[1];
            }
        }

        public static void enableBtn(Button btn, Color BackColor)
        {
            btn.Enabled = true;
            btn.BackColor = BackColor;
            btn.ForeColor = Color.White;
        }

        public static void disableBtn(Button btn)
        {
            btn.Enabled = false;
            btn.BackColor = SystemColors.Control;
            btn.ForeColor = Color.Gray;
        }

        public static void listCountryInComboBox(ComboBox cmb)
        {
            cmb.Items.Clear();
            foreach (String culture in cultureList)
            {
                cmb.Items.Add(culture);
            }
            cmb.Sorted = true;
            resizeComboBox(cmb);
            cmb.SelectedIndex = 0;
        }

        public static void resizeConfigForm(Form form, Panel btn_panel, DataGridView DGV, Button bottomMost_btn)
        {
            int totalWidth = btn_panel.Width;
            foreach (DataGridViewColumn DGVC in DGV.Columns)
            {
                if (DGVC.Visible) totalWidth += DGVC.Width;
            }

            if (totalWidth > Screen.PrimaryScreen.WorkingArea.Width) form.Width = Screen.PrimaryScreen.WorkingArea.Width - 10;
            else form.Width = totalWidth + 40;

            int totalHeight = DGV.ColumnHeadersHeight;
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                totalHeight += DGVR.Height;
            }

            if (totalHeight > Screen.PrimaryScreen.WorkingArea.Height) form.Height = Screen.PrimaryScreen.WorkingArea.Height;
            else
            {
                if (totalHeight < bottomMost_btn.Bottom + 10) form.Height = bottomMost_btn.Bottom + 10;
                else form.Height = totalHeight;

                form.Height += 65;
            }
        }

        public static string calculateAge(String birthday)
        {
            if (birthday.Trim() == String.Empty) return String.Empty;
            String[] date = birthday.Split('/');
            DateTime myDate = new DateTime(Convert.ToInt32(date[2]) - 543, Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
            DateTime ToDate = DateTime.Now;

            FAMS.Global.DateDifference dDiff = new FAMS.Global.DateDifference(myDate, ToDate);
            return dDiff.ToString();

        }

        public static void DGV_Paint(object sender, PaintEventArgs e)
        {
            DataGridView sndr = (DataGridView)sender;

            if (sndr.Rows.Count == 0) // <-- if there are no rows in the DataGridView when it paints, then it will create your message
            {
                using (Graphics grfx = e.Graphics)
                {
                    // create a white rectangle so text will be easily readable
                    grfx.FillRectangle(Brushes.LightYellow, new Rectangle(new Point(), new Size(sndr.Width, sndr.Height)));
                    // write text on top of the white rectangle just created
                    using (Font font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold))
                    {
                        grfx.DrawString("--- ไม่มีข้อมูล ---", font, new SolidBrush(Color.FromArgb(255, 128, 0)), new PointF((sndr.ClientSize.Width / 2) - 90, (sndr.ClientSize.Height / 2)));
                    }
                }
            }
        }

        public static void rerunRowNum(DataGridView DGV)
        {
            if (DGV.RowHeadersVisible)
            {
                foreach (DataGridViewRow DGVR in DGV.Rows)
                {
                    DGVR.HeaderCell.Value = (DGVR.Index + 1).ToString();
                }
            }
        }

        public static void getImage(String pictureFile, ref PictureBox picture, String FTPfolderName)
        {
            if (File.Exists(pictureFile))
            {
                tmpImg = Image.FromFile(pictureFile);
                picture.Image = tmpImg;
            }
            else
            {
                picture.Image = FTP.download(FTPfolderName, pictureFile);
                if (picture.Image == null)
                    GF.Error("ไม่พบไฟล์รูป บน Server !!\r\nกรุณาถ่ายรูปอีกครั้ง !!");
            }
        }

        public static void addPaymentRow(DataGridView DGV, String[] Data, String payment_type_int)
        {
            int index = -1;
            String payment_type_colName = "";

            foreach (DataGridViewColumn DGVC in DGV.Columns)
            {
                if (DGVC.Name.IndexOf("payment_type") != -1 && DGVC.Index > 0)
                {
                    payment_type_colName = DGVC.Name;
                    break;
                }
            }
            
            foreach (DataGridViewRow DGVR in DGV.Rows)
            {
                if (payment_type_int == "0" && DGVR.Cells[payment_type_colName].Value.ToString() == payment_type_int)
                {
                    index = DGVR.Index;
                    break;
                }

                if (payment_type_int == "1" && Data[2] != String.Empty && Data[3] != String.Empty && (DGVR.Cells[payment_type_colName].Value ?? "").ToString() == payment_type_int)
                {
                    if ((DGVR.Cells[2].Value ?? "").ToString() == Data[2] && (DGVR.Cells[3].Value ?? "").ToString() == Data[3])
                    {
                        index = DGVR.Index;
                        break;
                    }
                }
            }

            if (index == -1)
                DGV.Rows.Add(Data);
            else
            {
                DataGridViewRow DGVR = DGV.Rows[index];
                DGVR.Cells[1].Value = (Convert.ToInt32(GF.removeCommaDotFromNumber(DGVR.Cells[1].Value.ToString())) + Convert.ToInt32(GF.removeCommaDotFromNumber(Data[1]))).ToString();
            }
        }

        public static string TODAY()
        {
            string day = DateTime.Now.Day.ToString("00");
            string month = DateTime.Now.Month.ToString("00");
            string year = DateTime.Now.Year.ToString("00");

            return day + "/" + month + "/" + year;
        }

        public static string NOW()
        {
            string hour = DateTime.Now.Hour.ToString("00");
            string min = DateTime.Now.Minute.ToString("00");
            string sec = DateTime.Now.Second.ToString("00");

            return TODAY() + " " + hour + ":" + min + ":" + sec;
        }

        public static string TODAY_DB()
        {
            string day = DateTime.Now.Day.ToString("00");
            string month = DateTime.Now.Month.ToString("00");
            string year = DateTime.Now.Year.ToString("0000");

            return year + "-" + month + day;
        }

        public static string NOW_DB()
        {
            string hour = DateTime.Now.Hour.ToString("00");
            string min = DateTime.Now.Minute.ToString("00");
            string sec = DateTime.Now.Second.ToString("00");
            string microtime = DateTime.Now.Millisecond.ToString("000000");

            return TODAY_DB() + " " + hour + ":" + min + ":" + sec + "." + microtime;
        }

        public static void submitErrorLog()
        {
            return;
            //12, 0
            if (GF.userID == "-1"/* || Environment.MachineName.ToString().ToUpper().IndexOf("CLOUD") != -1*/)
            {
                Program.waitHandle.Set();
                return;
            }
            try
            {
                //GF.doDebug("========== SEND EMAIL ==========");
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("fams.error@gmail.com", "Fams1234");

                client.Timeout = 10000;

                MailAddress from = new MailAddress("fams.error@gmail.com", "Error Log", System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress("cloud_live@windowslive.com");

                MailMessage message = new MailMessage(from, to);
                message.Body = "System Error on " + GF.NOW() + Environment.NewLine;
                message.Body += Environment.NewLine;

                string[] lines = File.ReadAllLines(GF.Settings("tmp_path") + "error.txt");
                foreach (string line in lines)
                {
                    if (line.IndexOf("xDSLInternetStatus.asp") != -1)
                    {
                        client.Dispose();
                        return;
                    }
                    message.Body += line + Environment.NewLine;
                }

                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("user_id", GF.userID);

                Dictionary<String, Object> Obj = DB.Post("Error/get_last_query_string/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                    message.Body += Environment.NewLine;
                    message.Body += "LAST QUERY STRING : " + Environment.NewLine;

                    message.Body += Item["queryString"].ToString() + Environment.NewLine;
                }

                message.Body += Environment.NewLine;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "FAMS ERROR !! @ " + Environment.MachineName;
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                GF.printError("SENDING E-MAIL");

                client.SendCompleted += (ss, ee) =>
                {
                    if (ee.Cancelled == false)
                    {
                        if (ee.Error != null)
                        {
                            GF.Error(ee.Error.Message);
                        }
                        else
                        {
                            GF.printError("E-MAIL SENT");
                        }

                        // CLEAN UP
                        GF.printError("========== CLEAN UP ===========");
                        message.Dispose();

                        //MessageBox.Show("E-MAIL SENT !!");
                        Program.waitHandle.Set();

                        client.Dispose();
                    }
                };

                client.SendAsync(message, "SEND E-MAIL");
                //client.Send(message);
            }
            catch (SmtpException ee)
            {
                MessageBox.Show(ee.Message, "SEND EMAIL ERROR");
            }
        }

        public static Boolean hasReceiptPrinter()
        {
            if (GF.Settings("receipt_printer") == "ไม่มี")
            {
                GF.Error("ใบเสร็จจะถูกพิมพ์ก็ต่อเมื่อมีการตั้งค่าเครื่องพิมพ์เท่านั้น !!");
                return false;
            }
            return true;
        }

        public static void checkPaperSize(System.Drawing.Printing.PrintDocument pd)
        {
            GF.printError("********** PAPER SIZE **********");
            foreach (System.Drawing.Printing.PaperSize size in pd.PrinterSettings.PaperSizes)
            {
                GF.printError("**** [" + size.RawKind.ToString() + "][" + size.Kind.ToString() + "] " + size.Width.ToString() + "x" + size.Height.ToString());
            }
        }

        public static void checkPaperSource(System.Drawing.Printing.PrintDocument pd)
        {
            GF.printError("********** PAPER SOURCE **********");
            foreach (System.Drawing.Printing.PaperSource source in pd.PrinterSettings.PaperSources)
            {
                GF.printError("**** [" + source.RawKind.ToString() + "][" + source.Kind.ToString() + "] " + source.SourceName);
            }
        }

        public static string Settings(string key)
        {
            String value = "";
            using (Microsoft.Win32.RegistryKey Reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("FAMS_Settings"))
            {
                value = (Reg.GetValue(key) ?? "").ToString();
                Reg.Close();
            }
            return value;
        }

        public static void Settings(string key, String value)
        {
            using (Microsoft.Win32.RegistryKey Reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("FAMS_Settings", true))
            {
                Reg.SetValue(key, value);
                Reg.Close();
            }
        }
    }
}
