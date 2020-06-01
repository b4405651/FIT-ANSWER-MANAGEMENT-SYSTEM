using GenCode128;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public static class print_receipt
    {
        static string _bill_id = "";
        static string _bill_no = "";
        static Boolean _hasVat = false;
        static Image _imageData = null;
        static Boolean _isPreview = false;
        static Form _Sender = null;
        static PrintDocument _pd = null;
        static string _printerName = "";
        static PrinterResolution _printerResolution;
        static PaperSize _paperSize = null;
        static int _rawKind = 0;

        static Font regular;
        static Font boldUnderline;
        static Font bold;
        static Brush brush;
        static StringFormat alignRight;

        static PrintPreviewDialog PPD;

        static string bill_id { get { return _bill_id; } set { _bill_id = value; } }
        static string bill_no { get { return _bill_no; } set { _bill_no = value; } }
        static Boolean hasVat { get { return _hasVat; } set { _hasVat = value; } }
        static Image imageData { get { return _imageData; } set { _imageData = value; } }
        static Boolean isPreview { get { return _isPreview; } set { _isPreview = value; } }
        static Form Sender { get { return _Sender; } set { _Sender = value; } }
        static PrintDocument pd { get { return _pd; } set { _pd = value; } }
        static string printerName { get { return _printerName; } set { _printerName = value; } }
        static PrinterResolution printerResolution { get { return _printerResolution; } set { _printerResolution = value; } }
        static PaperSize paperSize { get { return _paperSize; } set { _paperSize = value; } } // paperSize width and height = cm or mm convert to inch then x 100
        static int rawKind { get { return _rawKind; } set { _rawKind = value; } } // for custom paper size = 999
        public static void initPrint(Form Sender, string bill_id, Boolean hasVat, Boolean isPreview = false)
        {
            print_receipt.Sender = Sender;
            print_receipt.isPreview = isPreview;
            print_receipt.hasVat = hasVat;

            print_receipt.bill_id = bill_id;

            GF.showLoading(Sender);

            doPrint();
        }

        static void doPrint()
        {
            try
            {
                print_receipt.printerResolution = new PrinterResolution();
                GF.printError("INIT PRINT DOCUMENT FOR 'SHOP RECEIPT' ...");

                if (GF.Settings("receipt_printer") == "")
                {
                    GF.Error("ไม่พบ PRINTER สำหรับออกใบเสร็จ !!");
                    GF.closeLoading();
                }
                else if (GF.Settings("receipt_printer") == "ไม่มี")
                {
                    GF.Error("ไม่สามารถพิมพ์ใบเสร็จได้ จนกว่าจะตั้งค่า PRINTER สำหรับออกใบเสร็จ !!");
                    GF.closeLoading();
                    return;
                }
                else
                {
                    print_receipt.printerName = GF.Settings("receipt_printer");
                    GF.printError("PRINTER : " + print_receipt.printerName);
                }

                initPrintDocument();
            }
            catch (Exception e)
            {
                GF.printError(e.Message + "\r\n\r\n" + e.StackTrace.ToString());
                GF.Error(e.Message, "PRINTER ERROR !!");
                GF.closeLoading();
            }
        }

        static void initPrintDocument()
        {
            using (pd = new PrintDocument())
            {
                pd.DocumentName = "ใบเสร็จค่าสินค้า";
                pd.PrinterSettings.PrinterName = printerName;

                GF.checkPaperSize(pd);
                GF.checkPaperSource(pd);

                GF.printError("THIS RAW KIND : " + rawKind);
                GF.printError("THIS PAPER SIZE : " + paperSize);

                if (rawKind != 0) pd.DefaultPageSettings.PaperSize.RawKind = rawKind;
                if (paperSize != null) pd.DefaultPageSettings.PaperSize = paperSize;
                
                GF.printError(pd.DefaultPageSettings.PaperSize.Width.ToString() + " x " + pd.DefaultPageSettings.PaperSize.Height.ToString());

                GF.printError("PD RAW KIND : " + pd.DefaultPageSettings.PaperSize.RawKind);
                GF.printError("PD PAPER SIZE : " + pd.DefaultPageSettings.PaperSize);

                if (printerResolution != null) pd.DefaultPageSettings.PrinterResolution = printerResolution;

                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                pd.PrintPage += (sender, e) =>
                {
                    int FontSize = 8;
                    string FontName = "Calibri";
                    regular = new Font(FontName, FontSize);
                    boldUnderline = new Font(FontName, FontSize, (FontStyle.Bold | FontStyle.Underline));
                    bold = new Font(FontName, FontSize, FontStyle.Bold);
                    brush = new SolidBrush(Color.Black);
                    alignRight = new StringFormat();
                    alignRight.Alignment = StringAlignment.Far;

                    int width = e.MarginBounds.Width;

                    String vat = "";
                    String net_price_before_vat = "";
                    String vat_amount = "";
                    String total_amount = "";
                    String cashier_name = "";

                    Dictionary<string, string> values = new Dictionary<string, string>()
                    {
                        { "bill_id" , bill_id },
                        { "issue_vat", (hasVat ? "1" : "0") }
                    };

                    Dictionary<String, Object> Obj = DB.Post("Shop/getBillHeader/", values);

                    int top = 10;
                    if (Obj != null)
                    {
                        Dictionary<String, Object> item = (Dictionary<String, Object>)Obj["result"];
                        bill_no = item["bill_no"].ToString();

                        print_bill_header.draw(e, item["branch_id"].ToString(), out top);

                        top += 65;
                        e.Graphics.DrawString("ใบเสร็จรับเงิน / ใบกำกับภาษีอย่างย่อ", boldUnderline, brush, new PointF((float)(((width - GF.margin_right) / 2) - (e.Graphics.MeasureString("ใบเสร็จรับเงิน / ใบกำกับภาษีอย่างย่อ", boldUnderline).Width / 2)), top));

                        top += 25;
                        e.Graphics.DrawString("หมายเลขใบเสร็จ", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + bill_no, regular).Width - e.Graphics.MeasureString("หมายเลขใบเสร็จ", bold).Width - GF.margin_right + GF.margin_left, top));
                        e.Graphics.DrawString(": " + bill_no, regular, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                        top += 20;
                        e.Graphics.DrawString("วันที่", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + GF.formatDBDateTime(item["bill_datetime"].ToString()), regular).Width - e.Graphics.MeasureString("วันที่", bold).Width - GF.margin_right + GF.margin_left, top));
                        e.Graphics.DrawString(": " + GF.formatDBDateTime(item["bill_datetime"].ToString()), regular, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                        vat = item["vat"].ToString();
                        vat_amount = item["vat_amount"].ToString();
                        net_price_before_vat = item["net_price_before_vat"].ToString();
                        total_amount = item["total_price"].ToString();
                        cashier_name = item["receive_by"].ToString();
                    }

                    string seps = "";
                    while (e.Graphics.MeasureString(seps, regular).Width < e.MarginBounds.Width)
                    {
                        seps += "-";
                    }

                    /*top += 25;
                    e.Graphics.DrawString(seps, regular, brush, new PointF(left, top));*/

                    values = new Dictionary<string, string>()
                    {
                        { "bill_no" , bill_no }
                    };

                    Obj = DB.Post("Shop/getDataByBillNo/", values);

                    if (Obj != null)
                    {
                        Dictionary<String, Object> item = (Dictionary<String, Object>)Obj["result"];
                        String Product_Data = item["product_data"].ToString();

                        String[] tmp_data = Product_Data.Split(new String[] { "!!" }, StringSplitOptions.None);
                        foreach (String product in tmp_data)
                        {
                            String[] Item = product.Split(new String[] { "##" }, StringSplitOptions.None);

                            top += 20;
                            String item_name = Item[3].ToString() + " x " + Item[0].ToString() + " @" + Item[1].ToString() + ".00";
                            e.Graphics.DrawString(item_name, regular, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - e.Graphics.MeasureString(item_name, regular).Width - GF.margin_right, 15));
                            e.Graphics.DrawString(GF.formatNumber(Item[4].ToString()) + ".00", regular, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);
                        }

                        //======================================= SUB TOTAL ======================================//
                        top += 20;
                        e.Graphics.DrawString("ราคารวมก่อนภาษี", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + net_price_before_vat, bold).Width - e.Graphics.MeasureString("ราคารวมก่อนภาษี :", bold).Width - GF.margin_right + GF.margin_left, top));
                        e.Graphics.DrawString(": " + net_price_before_vat, bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                        top += 20;
                        e.Graphics.DrawString("ภาษี " + string.Format("{0:f2}", Convert.ToDouble(vat)) + "%", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + vat_amount, bold).Width - e.Graphics.MeasureString("ภาษี " + string.Format("{0:f2}", Convert.ToDouble(vat)) + "% : ", bold).Width - GF.margin_right + GF.margin_left, top));
                        e.Graphics.DrawString(": " + vat_amount, bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                        top += 20;
                        e.Graphics.DrawString("รวมเป็นเงิน", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + GF.formatNumber(total_amount) + ".00", bold).Width - e.Graphics.MeasureString("รวมเป็นเงิน :", bold).Width - GF.margin_right + GF.margin_left, top));
                        e.Graphics.DrawString(": " + GF.formatNumber(total_amount) + ".00", bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                        top += 15;
                        e.Graphics.DrawString(seps, regular, brush, new PointF(GF.margin_left, top));

                        //======================================= PAYMENT ======================================//
                        String Payment_Data = item["payment_data"].ToString();
                        tmp_data = Payment_Data.Split(new String[] { "!!" }, StringSplitOptions.None);
                        foreach (String payment in tmp_data)
                        {
                            String[] Item = payment.Split(new String[] { "##" }, StringSplitOptions.None);

                            top += 20;
                            if (Item[0].ToString() == "0")
                            {
                                // CASH
                                e.Graphics.DrawString("เงินสด", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + GF.formatNumber(Item[1].ToString()) + ".00", bold).Width - e.Graphics.MeasureString("เงินสด", bold).Width - GF.margin_right + GF.margin_left, top));
                            }
                            else if (Item[0].ToString() == "1")
                            {
                                // CARD
                                String last4Digits = Item[2].ToString().Substring(Item[2].ToString().Length - 4, 4);
                                e.Graphics.DrawString("บัตร XXXX-XXXX-XXXX-" + last4Digits, bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + GF.formatNumber(Item[1].ToString()) + ".00", bold).Width - e.Graphics.MeasureString("บัตร XXXX-XXXX-XXXX-" + last4Digits, bold).Width - GF.margin_right + GF.margin_left, top));
                            }
                            e.Graphics.DrawString(": " + GF.formatNumber(Item[1].ToString()) + ".00", bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);
                        }
                    }

                    top += (13 * 3);
                    e.Graphics.DrawString("ผู้รับเงิน : " + cashier_name, bold, brush, new PointF((float)(((width - GF.margin_right) / 2) - (e.Graphics.MeasureString("ผู้รับเงิน : " + cashier_name, bold).Width / 2)), top));

                    top += (20);
                    string print_datetime = GF.NOW();
                    e.Graphics.DrawString("พิมพ์เมื่อ : " + print_datetime, bold, brush, new PointF((float)(((width - GF.margin_right) / 2) - (e.Graphics.MeasureString("พิมพ์เมื่อ : " + print_datetime, bold).Width / 2)), top));

                    top += (13 * 2);
                    CreateBarcode(bill_no, e, 0, top);

                    e.Graphics.Dispose();
                };

                pd.EndPrint += (sender, e) =>
                {
                    if (e.PrintAction == PrintAction.PrintToPrinter)
                    {
                        if (PPD != null && !PPD.IsDisposed)
                            PPD.Close();

                        Sender.Activate();

                        GF.closeLoading();
                    }
                };
                GF.closeLoading();
                using (PPD = new PrintPreviewDialog())
                {
                    ((Form)PPD).FormClosed += (ss, ee) =>
                    {
                        Sender.Activate();
                    };
                    ((Form)PPD).TopMost = true;
                    ((Form)PPD).WindowState = FormWindowState.Maximized;
                    ((Form)PPD).FormBorderStyle = FormBorderStyle.None;
                    PPD.Document = pd;
                    PPD.PrintPreviewControl.Zoom = 1;
                    PPD.PrintPreviewControl.UseAntiAlias = true;
                    PPD.Document.OriginAtMargins = false;

                    if (isPreview) PPD.ShowDialog();
                    else pd.Print();
                }
            }
        }

        private static void CreateBarcode(string code, PrintPageEventArgs e, int x = 0, int y = 0)
        {
            int height = 35;
            int width = -1;

            // BARCODE
            using (StringFormat strFormat = new StringFormat { Alignment = StringAlignment.Center })
            {
                using (Image image = Code128Rendering.MakeBarcodeImage(code, 2, true))
                {
                    width = 200; // 2 Inch
                    if ((image.Width * 100 / image.HorizontalResolution) > width)
                    {
                        float modifier = width / ((float)(image.Width * 100 / image.HorizontalResolution));
                        height = Convert.ToInt32(((float)(image.Height * 100 / image.VerticalResolution)) * modifier);
                    }
                    else height = (int)(image.Height * 100 / image.VerticalResolution);

                    x = (e.MarginBounds.Width / 2) - (width / 2);

                    e.Graphics.DrawImage(image, x, y, width, height);


                    Font font = null;

                    // CODE
                    font = new Font("Calibri", 10);

                    SizeF stringSize;
                    stringSize = e.Graphics.MeasureString(code, font);

                    x = x + (width / 2) - (Convert.ToInt32(stringSize.Width) / 2);

                    e.Graphics.DrawString(code, font, Brushes.Black, new RectangleF(x, y + height, stringSize.Width, stringSize.Height), strFormat);

                    font.Dispose();
                }
            }
        }
    }
}
