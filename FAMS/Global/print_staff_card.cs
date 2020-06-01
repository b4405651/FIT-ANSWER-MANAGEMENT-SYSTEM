using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenCode128;

namespace FAMS
{
    class print_staff_card
    {
        static Dictionary<String, String> _staff_data = new Dictionary<string, string>();

        static PrintDocument _pd = null;
        static string _printerName = "";
        static PrinterResolution _printerResolution;
        static PaperSize _paperSize = null;
        static int _rawKind = 0;
        static Image _imageData = null;
        static String _filename = "";

        static Font regular1, regular2;
        static StringFormat alignRight;

        static Form senderForm;

        private static Image imageData { get { return _imageData; } set { _imageData = value; } }

        private static String filename { get { return _filename; } set { _filename = value; } }

        static Dictionary<String, String> staff_data { get { return _staff_data; } set { _staff_data = value; } }
        static PrintDocument pd { get { return _pd; } set { _pd = value; } }
        static string printerName { get { return _printerName; } set { _printerName = value; } }
        static PrinterResolution printerResolution { get { return _printerResolution; } set { _printerResolution = value; } }
        static PaperSize paperSize { get { return _paperSize; } set { _paperSize = value; } } // paperSize width and height = cm or mm convert to inch then x 100
        static int rawKind { get { return _rawKind; } set { _rawKind = value; } } // for custom paper size = 999

        static PrintPreviewDialog PPD;

        public static void initPrint(Form sender, String emp_id)
        {
            if (GF.Settings("card_printer") == "")
            {
                GF.Error("ไม่พบ PRINTER สำหรับพิมพ์บัตร !!");
                GF.closeLoading();
            }
            else if (GF.Settings("card_printer") == "ไม่มี")
            {
                GF.Error("ไม่สามารถพิมพ์บัตรได้ จนกว่าจะตั้งค่า PRINTER สำหรับพิมพ์บัตร !!");
                GF.closeLoading();
                return;
            }
            else
            {
                printerName = GF.Settings("card_printer");
                GF.printError("PRINTER : " + printerName);
            }

            senderForm = sender;
            GF.showLoading(sender);

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "user_id" , GF.userID }
            };

            Dictionary<String, Object> Obj = DB.Post("Employee/getEmpCardFileName/", values);

            if (Obj != null)
            {
                Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                filename = Item["filename"].ToString();

                getFile(filename);
            }
            else
                GF.Error("เกิดความผิดพลาดในการรับชื่อไฟล์จาก Server !");

            values = new Dictionary<string, string>()
            {
                { "emp_id" , emp_id.Trim() }
            };

            Obj = DB.Post("Employee/getEmployeeData/", values);

            if (Obj != null)
            {
                staff_data = new Dictionary<string, string>();
                Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                foreach (KeyValuePair<string, Object> data in Item)
                {
                    // do something with entry.Value or entry.Key
                    staff_data.Add(data.Key, (data.Value ?? "").ToString());
                }
            }

            doPrintDocument();
        }

        static void doPrintDocument()
        {
            using (pd = new PrintDocument())
            {
                using (imageData = Image.FromFile(GF.Settings("emp_card") + filename))
                {
                    pd.DocumentName = "บัตร Staff";
                    pd.PrinterSettings.PrinterName = printerName;

                    GF.checkPaperSize(pd);
                    GF.checkPaperSource(pd);

                    GF.printError("THIS RAW KIND : " + rawKind);
                    GF.printError("THIS PAPER SIZE : " + paperSize);

                    rawKind = 98765;
                    paperSize = new PaperSize("CARD", 335, 217);

                    printerResolution = new PrinterResolution();
                    printerResolution.Kind = PrinterResolutionKind.Custom;
                    printerResolution.X = 300;
                    printerResolution.Y = 300;

                    if (rawKind != 0) pd.DefaultPageSettings.PaperSize.RawKind = rawKind;
                    if (paperSize != null) pd.DefaultPageSettings.PaperSize = paperSize;

                    GF.printError(pd.DefaultPageSettings.PaperSize.Width.ToString() + " x " + pd.DefaultPageSettings.PaperSize.Height.ToString());

                    GF.printError("PD RAW KIND : " + pd.DefaultPageSettings.PaperSize.RawKind);
                    GF.printError("PD PAPER SIZE : " + pd.DefaultPageSettings.PaperSize);

                    if (printerResolution != null) pd.DefaultPageSettings.PrinterResolution = printerResolution;

                    pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                    pd.PrintPage += (sender, e) =>
                    {
                        string FontName = "Calibri";
                        regular1 = new Font(FontName, 20);
                        regular2 = new Font(FontName, 12);
                        alignRight = new StringFormat();
                        alignRight.Alignment = StringAlignment.Far;

                        Font small = new Font(FontName, 6);

                        int width = e.MarginBounds.Width;

                        //e.Graphics.DrawImage(imageData, new Point(0, 0));
                        e.Graphics.DrawImage(imageData, e.MarginBounds);

                        e.Graphics.DrawString(staff_data["nickname"].ToString(), regular1, new SolidBrush(Color.Yellow), new PointF(width - 4 - e.Graphics.MeasureString(staff_data["nickname"].ToString(), regular1).Width, e.MarginBounds.Height - 55 - e.Graphics.MeasureString(staff_data["nickname"].ToString(), regular1).Height));

                        //e.Graphics.DrawString(staff_data["fullname"].ToString(), regular2, new SolidBrush(Color.White), new PointF(width - 5 - e.Graphics.MeasureString(staff_data["fullname"].ToString(), regular2).Width, 135f));

                        e.Graphics.DrawString(staff_data["emp_code"].ToString(), regular2, new SolidBrush(Color.White), new PointF(width - 5 - e.Graphics.MeasureString(staff_data["emp_code"].ToString(), regular2).Width, 155f));

                        CreateBarcode(staff_data["emp_code"].ToString(), e);

                        e.Graphics.Dispose();
                    };

                    pd.EndPrint += (sender, e) =>
                    {
                        if (e.PrintAction == PrintAction.PrintToPrinter)
                        {
                            if (PPD != null && !PPD.IsDisposed)
                                PPD.Close();

                            senderForm.Activate();

                            GF.closeLoading();
                        }
                    };
                    GF.closeLoading();
                    using (PPD = new PrintPreviewDialog())
                    {
                        ((Form)PPD).FormClosed += (ss, ee) =>
                        {
                            senderForm.Activate();
                        };
                        ((Form)PPD).TopMost = true;
                        ((Form)PPD).WindowState = FormWindowState.Maximized;
                        ((Form)PPD).FormBorderStyle = FormBorderStyle.None;
                        PPD.Document = pd;
                        PPD.PrintPreviewControl.Zoom = 2;
                        PPD.PrintPreviewControl.UseAntiAlias = true;
                        PPD.Document.OriginAtMargins = false;

                        PPD.ShowDialog();
                    }
                }
            }
        }

        private static void CreateBarcode(string code, PrintPageEventArgs e)
        {
            int height = 20;
            int width = -1;

            // BARCODE
            using (StringFormat strFormat = new StringFormat { Alignment = StringAlignment.Center })
            {
                using (Image image = Code128Rendering.MakeBarcodeImage(code, 2, true))
                {
                    float modifier = ((float)height) / ((float)image.Height);
                    width = Convert.ToInt32(((float)image.Width) * modifier);

                    e.Graphics.FillRectangle(Brushes.White, new Rectangle(new Point(e.MarginBounds.Width - 12 - width, e.MarginBounds.Height - 12 - image.Height), new Size(width + 4, 34)));
                    e.Graphics.DrawImage(image, e.MarginBounds.Width - 10 - width, e.MarginBounds.Height - 10 - image.Height, width, 30);
                }
            }
        }

        static void getFile(String filename)
        {
            if (filename.Trim() != String.Empty)
            {
                String card_path = GF.Settings("emp_card");

                if (!Directory.Exists(card_path))
                {
                    GF.printError("NO CARD FOLDER !");
                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(@"Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                    Directory.CreateDirectory(card_path, securityRules);
                }
                else
                {
                    if (!File.Exists(GF.Settings("emp_card") + filename))
                    {
                        GF.printError("TRUNCATING CARD FOLDER ...");
                        DirectoryInfo downloadedMessageInfo = new DirectoryInfo(card_path);

                        try
                        {
                            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
                            {
                                file.Delete();
                            }
                            foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
                            {
                                dir.Delete(true);
                            }
                        }
                        catch (Exception e)
                        {
                            GF.Error(e.Message);
                            return;
                        }

                        GF.closeLoading();
                        GF.printError("MISSING fileName : " + filename);
                        GF.Error("ยังไม่มีไฟล์รูปภาพที่เครื่องนี้ !!\r\nหรือไฟล์อาจจะถูกเปลี่ยนแปลง ...\r\n\r\nกำลังดึงไฟล์จาก Server ...");

                        GF.showLoading(senderForm);
                        using (progress progressPage = new progress())
                        {
                            progressPage.isOpening = false;
                            progressPage.ShowDialog();
                        }
                    }
                }
            }
        }
    }
}
