using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FAMS
{
    public partial class accounting_report : Form
    {
        Boolean isReady = true;
        String report_type = String.Empty;
        public accounting_report()
        {
            InitializeComponent();

            month_range.Items.Clear();
            month_range.Items.Add(new ComboItem(0, "1 ม.ค. - 30 มิ.ย."));
            month_range.Items.Add(new ComboItem(1, "1 ม.ค. - 31 ธ.ค."));

            year_txt.Text = (DateTime.Now.Year + 543).ToString();
        }

        private void year_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void month_range_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isReady)
            {
                isReady = false;
                GF.showLoading(this);
                if (e.NewValue == CheckState.Checked)
                {
                    for (int i = 0; i < month_range.Items.Count; i++)
                        month_range.SetItemCheckState(i, CheckState.Unchecked);
                }
                isReady = true;
                GF.closeLoading();
            }
        }

        private void get_excel_btn_Click(object sender, EventArgs e)
        {
            if (year_txt.Text.Trim() == String.Empty)
            {
                GF.Error("ยังไม่ได้ระบุ 'ปี พ.ศ.' !");
                return;
            }

            // month_range
            report_type = String.Empty;
            for (int i = 0; i < month_range.Items.Count; i++)
                if (month_range.GetItemCheckState(i) == CheckState.Checked)
                {
                    report_type = (month_range.Items[i] as ComboItem).Key.ToString();
                }

            if (report_type == String.Empty)
            {
                GF.Error("ยังไม่ได้เลือก 'ช่วงเดือน' !");
                return;
            }
            generate();
        }

        void generate()
        {
            GF.showLoading(this);
            object missing = Type.Missing;

            Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = false;

            Dictionary<string, string> values = new Dictionary<string, string>()
            {
                { "report_year" , year_txt.Text.Trim() },
                { "report_type", report_type },
                { "branch_id", GF.Settings("branch_id") }
            };

            Dictionary<String, Object> Obj = DB.Post("Account/", values);

            if (Obj != null)
            {
                String[] month_name = { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฏาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };

                Workbook oWB = oXL.Workbooks.Add(missing);
                
                for (int i = oWB.Sheets.Count; i > 1; i--)
                {
                    (oWB.Sheets[i] as Worksheet).Delete();
                }

                Dictionary<string, int> lastRow = new Dictionary<string, int>();
                Worksheet oSheet = oWB.ActiveSheet as Worksheet;
                Range Rng = null;
                
                int sheetCount = 0;
                foreach (Dictionary<String, Object> Item in (Array)Obj["result"])
                {
                    if(sheetCount > 0)
                        oSheet = oWB.Sheets.Add(missing, missing, 1, missing) as Microsoft.Office.Interop.Excel.Worksheet;

                    if (oSheet != null)
                    {
                        // HEADER OF EACH MONTH
                        oSheet.Name = month_name[Convert.ToInt32(Item["month"].ToString()) - 1] + "_" + year_txt.Text.Trim();
                        // Cells[Row, Column]
                        oSheet.Cells[1, 1] = "#";
                        oSheet.Cells[1, 2] = "หมายเลขบิล";
                        oSheet.Cells[1, 3] = "ประเภทบิล";
                        oSheet.Cells[1, 4] = "จำนวนเงิน";
                        oSheet.Cells[1, 5] = "เป็นบิลVat";

                        // FORMAT MONTH's HEADER
                        Rng = oSheet.get_Range("A1", "E1");
                        Rng.Font.Size = 14;
                        Rng.Borders.LineStyle = XlLineStyle.xlContinuous;
                        Rng.Borders.Weight = XlBorderWeight.xlMedium;
                        Rng.Borders.Color = Color.Black;
                        Rng.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                        Rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                        // FILL THE DATA INTO THE MONTH's BODY
                        int rowNum = 1;
                        foreach (Dictionary<String, Object> Data in (Array)Item["data"])
                        {
                            rowNum++;
                            String bill_type = String.Empty;
                            switch (Data["bill_type"].ToString())
                            {
                                case "MEMBER_EXT_DEPOSIT":
                                    bill_type = "มัดจำค่าสมาชิก";
                                    break;
                                case "MEMBER_EXT_FULL":
                                    bill_type = "ชำระค่าสมาชิกเต็มจำนวน / ส่วนที่เหลือ";
                                    break;
                                case "MEMBER_PT":
                                    bill_type = "ซื้อ PT";
                                    break;
                                case "SHOP":
                                    bill_type = "ขายของ";
                                    break;
                            }
                            oSheet.Cells[rowNum, 1] = (rowNum - 1).ToString();
                            oSheet.Cells[rowNum, 2] = Data["bill_no"].ToString();
                            oSheet.Cells[rowNum, 3] = bill_type;
                            oSheet.Cells[rowNum, 4] = Data["amount"].ToString();
                            oSheet.Cells[rowNum, 4].NumberFormat = "#,##0";
                            oSheet.Cells[rowNum, 5] = (Data["issue_vat"].ToString() == "1" ? "ใช่" : "ไม่ใช่");
                            if (Data["issue_vat"].ToString() == "1")
                            {
                                Rng = oSheet.get_Range("A" + rowNum.ToString(), "E" + rowNum.ToString());
                                Rng.Interior.Color = ColorTranslator.ToOle(Color.LightCoral);
                            }

                            // FORMAT MONTH's BODY
                            Rng = oSheet.get_Range("A2", "E" + rowNum.ToString());
                            Rng.Font.Size = 14;
                            Rng.Borders.LineStyle = XlLineStyle.xlContinuous;
                            Rng.Borders.Weight = XlBorderWeight.xlMedium;
                            Rng.Borders.Color = Color.Black;
                        }

                        // FORMAT 'ISSUE VAT' COLUMN => CENTER
                        Rng = oSheet.get_Range("E2", "E" + rowNum.ToString());
                        Rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                        // LAST ROW IN MONTH
                        oSheet.Cells[rowNum + 1, 3] = "รวม";

                        // RECORD LAST ROW OF THIS MONTH
                        lastRow.Add(month_name[Convert.ToInt32(Item["month"].ToString()) - 1] + "_" + year_txt.Text.Trim(), rowNum + 1);

                        // FORMAT SUMMARY ROW
                        if (rowNum > 1)
                        {
                            oSheet.Cells[rowNum + 1, 4].Formula = string.Format("=SUM(D2:D{0})", rowNum);
                            oSheet.Cells[rowNum + 1, 4].NumberFormat = "#,##0";
                        }
                        else oSheet.Cells[rowNum + 1, 4] = "0";

                        Rng = oSheet.get_Range("A" + (rowNum + 1).ToString(), "E" + (rowNum + 1).ToString());
                        Rng.Font.Size = 14;
                        Rng.Interior.Color = ColorTranslator.ToOle(Color.LightGray);

                        // FORMAT MONTH's BODY
                        Rng = oSheet.get_Range("A" + (rowNum + 1).ToString(), "E" + (rowNum + 1).ToString());
                        Rng.Font.Size = 14;
                        Rng.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, Color.Black);
                        Rng.Interior.Color = ColorTranslator.ToOle(Color.LightGray);

                        // FORMAT 'SUMMARY' ROW => RIGHT
                        Rng = oSheet.get_Range("C" + (rowNum + 1).ToString(), "C" + (rowNum + 1).ToString());
                        Rng.HorizontalAlignment = XlHAlign.xlHAlignRight;

                        // AUTOFIT ALL COLUMNS
                        oSheet.Columns["A"].AutoFit();
                        oSheet.Columns["B"].AutoFit();
                        oSheet.Columns["C"].AutoFit();
                        oSheet.Columns["D"].AutoFit();
                        oSheet.Columns["E"].AutoFit();
                    }

                    sheetCount++;
                }

                /* SUMMARY */
                oSheet = oWB.Sheets.Add(missing, missing, 1, missing) as Microsoft.Office.Interop.Excel.Worksheet;
                oSheet.Name = "ยอดรวม";

                // SUMMARY HEADER
                // Cells[Row, Column]
                oSheet.Cells[1, 1] = "#";
                oSheet.Cells[1, 2] = "เดือน";
                oSheet.Cells[1, 3] = "ยอดเงิน";

                // FORMAT SUMMARY HEADER
                Rng = oSheet.get_Range("A1", "C1");
                Rng.Font.Size = 14;
                Rng.Borders.LineStyle = XlLineStyle.xlContinuous;
                Rng.Borders.Weight = XlBorderWeight.xlMedium;
                Rng.Borders.Color = Color.Black;
                Rng.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                Rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // PUT MONTHS NAME
                int max_month = 6;
                if (report_type == "1") max_month = 12;

                for (int i = 1; i < max_month + 1; i++)
                {
                    oSheet.Cells[i + 1, 1] = i.ToString();
                    oSheet.Cells[i + 1, 2] = month_name[i - 1];
                    oSheet.Cells[i + 1, 3].NumberFormat = "#,##0";

                    oSheet.Cells[i + 1, 3].Formula = "=" + month_name[i - 1] + "_" + year_txt.Text.Trim() + "!D" + lastRow[month_name[i - 1] + "_" + year_txt.Text.Trim()];
                }

                // FORMAT SUMMARY BODY
                Rng = oSheet.get_Range("A2", "C" + (max_month + 1).ToString());
                Rng.Font.Size = 14;
                Rng.Borders.LineStyle = XlLineStyle.xlContinuous;
                Rng.Borders.Weight = XlBorderWeight.xlMedium;
                Rng.Borders.Color = Color.Black;

                // LAST SUMMARY ROW
                oSheet.Cells[max_month + 2, 2] = "รวม";
                oSheet.Cells[max_month + 2, 3].Formula = String.Format("=SUM(C2:C{0})", max_month + 1);
                //sheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing)

                // FORMAT LAST ROW
                Rng = oSheet.get_Range("A" + (max_month + 2).ToString(), "C" + (max_month + 2).ToString());
                Rng.Font.Size = 14;
                Rng.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, Color.Black);
                Rng.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                Rng.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                // FORMAT 'SUMMARY' COLUMN IN LAST ROW
                Rng = oSheet.get_Range("B" + (max_month + 2).ToString(), "B" + (max_month + 2).ToString());
                Rng.HorizontalAlignment = XlHAlign.xlHAlignRight;

                // AUTOFIT
                oSheet.Columns["A"].AutoFit();
                oSheet.Columns["B"].AutoFit();
                oSheet.Columns["C"].AutoFit();

                GF.closeLoading();

                string fileName = String.Empty;

                using (SaveFileDialog saveDlg = new SaveFileDialog())
                {
                    saveDlg.Filter = "excel files (*.xlsx)|*.xlsx";
                    saveDlg.FilterIndex = 2;
                    saveDlg.RestoreDirectory = true;

                    if (saveDlg.ShowDialog() == DialogResult.OK)
                        fileName = saveDlg.FileName.ToString();
                }

                if (fileName != String.Empty)
                {
                    oWB.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook,
                        missing, missing, missing, missing,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        missing, missing, missing, missing, missing);
                    oWB.Close(missing, missing, missing);
                    oXL.UserControl = true;
                    oXL.Quit();

                    foreach (Process theProcess in Process.GetProcessesByName("EXCEL"))
                        theProcess.Kill();

                    this.Close();
                }
            }
        }
    }
}
