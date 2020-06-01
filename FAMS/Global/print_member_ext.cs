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
    class print_member_ext
    {
        static Dictionary<String, String> _bill_detail = new Dictionary<string, string>();
        static Boolean _hasVat = false;
        static string _member_name = "";
        static string _member_type_name = "";
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

        static Dictionary<String, String> bill_detail { get { return _bill_detail; } set { _bill_detail = value; } }
        static Boolean hasVat { get { return _hasVat; } set { _hasVat = value; } }
        static string member_name { get { return _member_name; } set { _member_name = value; } }
        static string member_type_name { get { return _member_type_name; } set { _member_type_name = value; } }
        static Image imageData { get { return _imageData; } set { _imageData = value; } }
        static Boolean isPreview { get { return _isPreview; } set { _isPreview = value; } }
        static Form Sender { get { return _Sender; } set { _Sender = value; } }
        static PrintDocument pd { get { return _pd; } set { _pd = value; } }
        static string printerName { get { return _printerName; } set { _printerName = value; } }
        static PrinterResolution printerResolution { get { return _printerResolution; } set { _printerResolution = value; } }
        static PaperSize paperSize { get { return _paperSize; } set { _paperSize = value; } } // paperSize width and height = cm or mm convert to inch then x 100
        static int rawKind { get { return _rawKind; } set { _rawKind = value; } } // for custom paper size = 999

        public static void initPrint(Form Sender, string member_ext_id, Boolean hasVat, Boolean isPreview = false)
        {
            print_member_ext.Sender = Sender;
            print_member_ext.isPreview = isPreview;
            print_member_ext.hasVat = hasVat;

            GF.showLoading(Sender);

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "member_ext_id" , member_ext_id },
                { "issue_vat", (hasVat ? "1" : "0") }
            };

            Dictionary<String, Object> Obj = DB.Post("Member/getExtBillDetail/", values);

            if (Obj != null)
            {
                bill_detail = new Dictionary<string, string>();
                Dictionary<String, Object> Item = (Dictionary<String, Object>)Obj["result"];

                foreach (KeyValuePair<string, Object> data in Item)
                {
                    // do something with entry.Value or entry.Key
                    bill_detail.Add(data.Key, (data.Value ?? "").ToString());
                }
            }

            doPrint();
        }

        static void doPrint()
        {
            try
            {
                print_member_ext.printerResolution = new PrinterResolution();
                GF.printError("INIT PRINT DOCUMENT FOR 'MEMBER EXT. RECEIPT' ...");

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
                    print_member_ext.printerName = GF.Settings("receipt_printer");
                    GF.printError("PRINTER : " + print_member_ext.printerName);
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
                pd.DocumentName = "ใบเสร็จ";
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
                    int top = 10;

                    Font small = new Font(FontName, 6);

                    int width = e.MarginBounds.Width;

                    print_bill_header.draw(e, bill_detail["branch_id"], out top);

                    top += 65;
                    e.Graphics.DrawString("ใบเสร็จรับเงิน / ใบกำกับภาษีอย่างย่อ", boldUnderline, brush, new PointF((float)(((width - GF.margin_right) / 2) - (e.Graphics.MeasureString("ใบเสร็จรับเงิน / ใบกำกับภาษีอย่างย่อ", boldUnderline).Width / 2)), top));

                    String bill_no = String.Empty;
                    if (bill_detail["is_paid"] == "0") bill_no = bill_detail["deposit_bill_no"];
                    else bill_no = bill_detail["full_bill_no"];

                    String bill_datetime = String.Empty;
                    if (bill_detail["is_paid"] == "0") bill_datetime = bill_detail["deposit_bill_datetime"];
                    else bill_datetime = bill_detail["full_bill_datetime"];

                    top += 25;
                    e.Graphics.DrawString("หมายเลขใบเสร็จ", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + bill_no, regular).Width - e.Graphics.MeasureString("หมายเลขใบเสร็จ", bold).Width - GF.margin_right + GF.margin_left, top));
                    e.Graphics.DrawString(": " + bill_no, regular, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                    top += 20;
                    e.Graphics.DrawString("วันที่", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + GF.formatDBDateTime(bill_datetime), regular).Width - e.Graphics.MeasureString("วันที่", bold).Width - GF.margin_right + GF.margin_left, top));
                    e.Graphics.DrawString(": " + GF.formatDBDateTime(bill_datetime), regular, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                    string seps = "";
                    while (e.Graphics.MeasureString(seps, regular).Width < e.MarginBounds.Width)
                    {
                        seps += "-";
                    }

                    /*top += 25;
                    e.Graphics.DrawString(seps, regular, brush, new PointF(left, top));*/

                    top += 40;
                    String item_name = String.Empty;
                    if (bill_detail["is_paid"] == "0") item_name = "มัดจำค่าสมาชิก";
                    else item_name = "ชำระค่าสมาชิก ";
                    item_name += bill_detail["member_type_name"];

                    e.Graphics.DrawString(item_name, bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - 20, 15));

                    top += 20;
                    item_name = "ระหว่างวันที่ " + bill_detail["start_date"] + " ถึง " + bill_detail["expiry_date"];
                    e.Graphics.DrawString(item_name, regular, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - 20, 15));

                    if (bill_detail["is_paid"] == "1")
                    {
                        top += 20;
                        item_name = "เลขที่สัญญา : " + bill_detail["contract_no"];
                        e.Graphics.DrawString(item_name, regular, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - 20, 15));
                    }

                    /*top += 20;
                    e.Graphics.DrawString(GF.formatNumber(bill_header["full_amount"]) + ".00", regular, brush, new RectangleF(left, top, e.MarginBounds.Width - 20, 15), alignRight);*/

                    //======================================= TOTAL ======================================//

                    top += 40;
                    e.Graphics.DrawString("รวมเป็นเงิน", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + GF.formatNumber(bill_detail["full_amount"]) + ".00", bold).Width - e.Graphics.MeasureString("รวมเป็นเงิน :", bold).Width - GF.margin_right + GF.margin_left, top));
                    e.Graphics.DrawString(": " + GF.formatNumber(bill_detail["full_amount"]) + ".00", bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                    //======================================= DISCOUNT ======================================//
                    if (bill_detail["discount_amount"] != "" && bill_detail["is_paid"] == "1")
                    {
                        if (Convert.ToInt32(bill_detail["discount_amount"]) > 0)
                        {
                            top += 20;
                            e.Graphics.DrawString("ส่วนลด (" + bill_detail["discount_note"] + ")", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": -" + GF.formatNumber(bill_detail["discount_amount"]) + ".00", bold).Width - e.Graphics.MeasureString("ส่วนลด (" + bill_detail["discount_note"] + ") :", bold).Width - GF.margin_right + GF.margin_left, top));
                            e.Graphics.DrawString(": -" + GF.formatNumber(bill_detail["discount_amount"]) + ".00", bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);
                        }
                    }

                    //======================================= DEPOSIT ======================================//
                    if (bill_detail["total_deposit_amount"] != "" && bill_detail["is_paid"] == "1")
                    {
                        if (Convert.ToInt32(bill_detail["total_deposit_amount"]) > 0)
                        {
                            top += 20;
                            e.Graphics.DrawString("มัดจำ", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": -" + GF.formatNumber(bill_detail["total_deposit_amount"]) + ".00", bold).Width - e.Graphics.MeasureString("มัดจำ :", bold).Width - GF.margin_right + GF.margin_left, top));
                            e.Graphics.DrawString(": -" + GF.formatNumber(bill_detail["total_deposit_amount"]) + ".00", bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);
                            top += 20;
                            e.Graphics.DrawString("หมายเลขใบเสร็จมัดจำ", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": -" + ((bill_detail["deposit_bill_no"] ?? String.Empty) == String.Empty ? "-" : bill_detail["deposit_bill_no"]), bold).Width - e.Graphics.MeasureString("หมายเลขใบเสร็จมัดจำ :", bold).Width - GF.margin_right + GF.margin_left, top));
                            e.Graphics.DrawString(": " + ((bill_detail["deposit_bill_no"] ?? String.Empty) == String.Empty ? "-" : bill_detail["deposit_bill_no"]), bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);
                        }
                    }

                    //======================================= GRAND TOTAL ======================================//
                    top += 20;
                    e.Graphics.DrawString("รวมเป็นเงินสุทธิ", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + GF.formatNumber(bill_detail["total_full_payment_amount"]) + ".00", bold).Width - e.Graphics.MeasureString("รวมเป็นเงินสุทธิ :", bold).Width - GF.margin_right + GF.margin_left, top));
                    e.Graphics.DrawString(": " + GF.formatNumber(bill_detail["total_full_payment_amount"]) + ".00", bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                    if (hasVat)
                    {
                        //======================================= SUB TOTAL ======================================//
                        top += 15;
                        e.Graphics.DrawString(seps, regular, brush, new PointF(GF.margin_left, top));

                        top += 20;
                        e.Graphics.DrawString("ราคารวมก่อนภาษี", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + bill_detail["net_price_before_vat"], bold).Width - e.Graphics.MeasureString("ราคารวมก่อนภาษี :", bold).Width - GF.margin_right + GF.margin_left, top));
                        e.Graphics.DrawString(": " + bill_detail["net_price_before_vat"], bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                        top += 20;
                        e.Graphics.DrawString("ภาษี " + string.Format("{0:f2}", Convert.ToDouble(bill_detail["vat"])) + "%", bold, brush, new PointF((e.MarginBounds.Width) - e.Graphics.MeasureString(": " + bill_detail["vat_amount"], bold).Width - e.Graphics.MeasureString("ภาษี " + string.Format("{0:f2}", Convert.ToDouble(bill_detail["vat"])) + "% : ", bold).Width - GF.margin_right + GF.margin_left, top));
                        e.Graphics.DrawString(": " + bill_detail["vat_amount"], bold, brush, new RectangleF(GF.margin_left, top, e.MarginBounds.Width - GF.margin_right, 15), alignRight);

                    }

                    top += 15;
                    e.Graphics.DrawString(seps, regular, brush, new PointF(GF.margin_left, top));

                    //======================================= PAYMENT ======================================//
                    String Payment_Data = bill_detail["payment_data"].ToString();
                    String[] tmp_data = Payment_Data.Split(new String[] { "!!" }, StringSplitOptions.None);
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

                    top += (13 * 3);
                    e.Graphics.DrawString("ผู้รับเงิน : " + bill_detail["cashier_name"], bold, brush, new PointF((float)(((width - GF.margin_right) / 2) - (e.Graphics.MeasureString("ผู้รับเงิน : " + bill_detail["cashier_name"], bold).Width / 2)), top));

                    top += (20);
                    string print_datetime = GF.NOW();
                    e.Graphics.DrawString("พิมพ์เมื่อ : " + print_datetime, bold, brush, new PointF((float)(((width - GF.margin_right) / 2) - (e.Graphics.MeasureString("พิมพ์เมื่อ : " + print_datetime, bold).Width / 2)), top));

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
    }
}
