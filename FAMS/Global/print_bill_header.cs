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
    public class print_bill_header
    {
        public static void draw(PrintPageEventArgs e, String branch_id, out int top)
        {
            int FontSize = 10;
            string FontName = "Calibri";
            Font regular = new Font(FontName, FontSize);
            Font boldUnderline = new Font(FontName, FontSize, (FontStyle.Bold | FontStyle.Underline));
            Font bold = new Font(FontName, FontSize, FontStyle.Bold);
            Font boldSmall = new Font(FontName, 8, FontStyle.Bold);
            Font boldSmallUnderline = new Font(FontName, 8, (FontStyle.Bold | FontStyle.Underline));
            Font small = new Font(FontName, 8);
            Brush brush = new SolidBrush(Color.Black);
            top = 10;

            int width = e.MarginBounds.Width;

            using (Image imageData = Properties.Resources.logo_small)
            {
                //e.Graphics.DrawImage(imageData, (width / 2) - ((imageData.Width * 100 / imageData.HorizontalResolution) / 2) + left, top);

                Dictionary<string, string> values = new Dictionary<string, string>()
                {
                    { "branch_id" , branch_id }
                };

                Dictionary<String, Object> Obj = DB.Post("Branch/getBranchData/", values);

                if (Obj != null)
                {
                    Dictionary<String, Object> item = (Dictionary<String, Object>)Obj["result"];

                    //top += 80;
                    //e.Graphics.DrawString("สาขา : " + item["branch_name"].ToString(), bold, brush, new PointF((float)((width / 2) - (e.Graphics.MeasureString("สาขา : " + item["branch_name"].ToString(), bold).Width / 2)) + left, top));

                    //top += 20;
                    e.Graphics.DrawString(item["company_name"].ToString(), boldSmallUnderline, brush, new PointF((float)(((width - GF.margin_right) / 2) - (e.Graphics.MeasureString(item["company_name"].ToString(), boldSmallUnderline).Width / 2)) + GF.margin_left, top));

                    top += 15;
                    e.Graphics.DrawString(item["address"].ToString(), small, brush, new RectangleF(GF.margin_left, top, (e.MarginBounds.Width - GF.margin_right) - GF.margin_left, e.Graphics.MeasureString(item["address"].ToString(), small).Height), new StringFormat { Alignment = StringAlignment.Center });

                    float total_width = e.Graphics.MeasureString("เลขประจำตัวผู้เสียภาษี", boldSmallUnderline).Width;
                    total_width += e.Graphics.MeasureString(" : ", boldSmall).Width;
                    total_width += e.Graphics.MeasureString(item["tax_id"].ToString(), small).Width;

                    float pos = ((e.MarginBounds.Width - GF.margin_right) - GF.margin_left - total_width) / 2;
                    e.Graphics.DrawString("เลขประจำตัวผู้เสียภาษี", boldSmallUnderline, brush, new PointF(pos, top + e.Graphics.MeasureString(item["address"].ToString(), small).Height));

                    pos += e.Graphics.MeasureString("เลขประจำตัวผู้เสียภาษี", boldSmallUnderline).Width;
                    e.Graphics.DrawString(" : ", boldSmall, brush, new PointF(pos, top + e.Graphics.MeasureString(item["address"].ToString(), small).Height));

                    pos += e.Graphics.MeasureString(" : ", boldSmall).Width;
                    e.Graphics.DrawString(item["tax_id"].ToString(), small, brush, new PointF(pos, top + e.Graphics.MeasureString(item["address"].ToString(), small).Height));

                    // top = 125;
                }
            }
        }
    }
}
