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
    class preview_bill_header
    {
        static string _branch_id = "";
        static Image _imageData = null;
        static Form _Sender = null;
        static PrintDocument _pd = null;
        static string _printerName = "";
        static PrinterResolution _printerResolution;
        static PaperSize _paperSize = null;
        static int _rawKind = 0;

        static PrintPreviewDialog PPD;

        static string branch_id { get { return _branch_id; } set { _branch_id = value; } }
        static Image imageData { get { return _imageData; } set { _imageData = value; } }
        static Form Sender { get { return _Sender; } set { _Sender = value; } }
        static PrintDocument pd { get { return _pd; } set { _pd = value; } }
        static string printerName { get { return _printerName; } set { _printerName = value; } }
        static PrinterResolution printerResolution { get { return _printerResolution; } set { _printerResolution = value; } }
        static PaperSize paperSize { get { return _paperSize; } set { _paperSize = value; } } // paperSize width and height = cm or mm convert to inch then x 100
        static int rawKind { get { return _rawKind; } set { _rawKind = value; } } // for custom paper size = 999
        public static void initPrint(Form Sender, string branch_id)
        {
            preview_bill_header.Sender = Sender;
            preview_bill_header.branch_id = branch_id;

            doPrint();
        }

        static void doPrint()
        {
            try
            {
                preview_bill_header.printerResolution = new PrinterResolution();
                Console.WriteLine("INIT PRINT DOCUMENT FOR 'RECEIPT' ...");

                if (GF.Settings("receipt_printer") == "")
                {
                    GF.Error("ไม่พบ PRINTER สำหรับออกใบเสร็จ !!");
                    GF.closeLoading();
                }
                else
                {
                    preview_bill_header.printerName = GF.Settings("receipt_printer");
                    Console.WriteLine("PRINTER : " + preview_bill_header.printerName);
                }

                initPrintDocument();
            }
            catch (Exception e)
            {
                GF.Error(e.Message, "PRINTER ERROR !!");
                GF.closeLoading();
            }
        }

        static void initPrintDocument()
        {
            using (pd = new PrintDocument())
            {
                pd.DocumentName = "หัวใบเสร็จ";
                pd.PrinterSettings.PrinterName = printerName;

                //checkPaperSize(pd);
                //checkPaperSource(pd);

                Console.WriteLine("THIS RAW KIND : " + rawKind);
                Console.WriteLine("THIS PAPER SIZE : " + paperSize);

                if (rawKind != 0) pd.DefaultPageSettings.PaperSize.RawKind = rawKind;
                if (paperSize != null) pd.DefaultPageSettings.PaperSize = paperSize;

                Console.WriteLine(pd.DefaultPageSettings.PaperSize.Width.ToString() + " x " + pd.DefaultPageSettings.PaperSize.Height.ToString());

                Console.WriteLine("PD RAW KIND : " + pd.DefaultPageSettings.PaperSize.RawKind);
                Console.WriteLine("PD PAPER SIZE : " + pd.DefaultPageSettings.PaperSize);

                if (printerResolution != null) pd.DefaultPageSettings.PrinterResolution = printerResolution;

                pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

                pd.PrintPage += (sender, e) =>
                {
                    int top = 10;
                    print_bill_header.draw(e, branch_id, out top);

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

                    PPD.ShowDialog();
                }
            }
        }
    }
}
