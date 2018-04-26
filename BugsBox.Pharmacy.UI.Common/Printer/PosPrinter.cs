using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace BugsBox.Pharmacy.UI.Common.Printer
{
    public class PosPrinter
    {

        private PosPrinterModel posPrinterModel = new PosPrinterModel();
        private System.Windows.Forms.PrintPreviewDialog printv_pos = null;
        private System.Drawing.Printing.PrintDocument printd_pos = null;

        
        public PosPrinter()
        {
            this.printv_pos = new System.Windows.Forms.PrintPreviewDialog();
            this.printd_pos = new System.Drawing.Printing.PrintDocument();


            this.printv_pos.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printv_pos.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printv_pos.ClientSize = new System.Drawing.Size(400, 300);
            this.printv_pos.Document = this.printd_pos;
            this.printv_pos.Enabled = true;
            // this.printv_pos.Icon = ((System.Drawing.Icon)(resources.GetObject("printv_pos.Icon")));
            this.printv_pos.Name = "printPreviewDialog1";
            this.printv_pos.Visible = false;
            // 
            // printd_pos
            // 
            this.printd_pos.DocumentName = "零售POS小票";
            this.printd_pos.OriginAtMargins = true;
            this.printd_pos.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printd_pos_PrintPage);

        }

        public PosPrinter(PosPrinterModel model)
        {
            posPrinterModel = model;
            this.printv_pos = new System.Windows.Forms.PrintPreviewDialog();
            this.printd_pos = new System.Drawing.Printing.PrintDocument();


            this.printv_pos.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printv_pos.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printv_pos.ClientSize = new System.Drawing.Size(400, 300);
            this.printv_pos.Document = this.printd_pos;
            this.printv_pos.Enabled = true;

            this.printv_pos.Name = "printPreviewDialog1";
            this.printv_pos.Visible = false;

            this.printd_pos.DocumentName = "零售POS小票";
            this.printd_pos.OriginAtMargins = true;
            this.printd_pos.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printd_pos_PrintPage);

        }

        private int getYc(double cm)
        {
            return (int)(cm / 25.4) * 100;
        }

        public string GetPrintStr()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("    " + posPrinterModel.Header + "\n\n");

            sb.Append("流水号:" + posPrinterModel.SaildID + "\n");
            sb.Append("日  期:" + posPrinterModel.Datas + "\n");
            sb.Append("药品代码" + " " + "数量" + " " + "单价" + " " + "金额" + "\n");
            for (int i = 0; i < this.posPrinterModel.Datas.Count; i++)
            {
                List<string> ilist = posPrinterModel.Datas[i];
                sb.Append(ilist[0] + "     " + ilist[1] + " " + ilist[2] + " " + ilist[3]);
                sb.Append("\n");
            }

            sb.Append("数量: " + posPrinterModel.Nums + "    合计:   " + posPrinterModel.TotalPrice + "\n");


            sb.Append("优惠金额：" + posPrinterModel.Discount + "\n");
            sb.Append("应收金额：" + posPrinterModel.ActualCash + "\n");
            sb.Append("收款金额：" + posPrinterModel.ReceiveCash + "\n");
            sb.Append("找零金额：" + posPrinterModel.RetCash + "\n");
            sb.Append("                         \n");
            sb.Append("会员卡号：" + posPrinterModel.CardNo + "\n");
            sb.Append("本次积分：" + posPrinterModel.MarkIn + "\n");
            sb.Append("可用积分：" + posPrinterModel.MarkAvailable + "\n");
            sb.Append("卡 消 费：" + posPrinterModel.CardConsume + "\n");
            sb.Append("可用余额：" + posPrinterModel.CardAvailable + "\n");

            string myfoot = string.Format("{0}     \n", posPrinterModel.Footer);
            sb.Append(myfoot);
            return sb.ToString();
        }

        public void print_view(IWin32Window win)
        {
            /*
             this.printDocument1.PrintController = new System.Drawing.Printing.StandardPrintController();
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            this.printDocument1.Print();
             */

            this.printd_pos.PrintController = new System.Drawing.Printing.StandardPrintController();
            this.printd_pos.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printd_pos_PrintPage);

            //设置边距
            Margins margins = new Margins(32, 5, 30, 5);
            this.printd_pos.DefaultPageSettings.Margins = margins;

            this.printd_pos.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("First custom size", getYc(78), 600);
            //this.printDocument1.PrinterSettings.PrinterName = "";
            //Margins margins = new Margins(




            //this.printv_pos.Document = this.printd_pos;

            printv_pos.PrintPreviewControl.AutoZoom = false;
            printv_pos.PrintPreviewControl.Zoom = 1;

            this.printv_pos.ShowDialog(win);

            //try
            //{
            //    printd_pos.Print();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    printd_pos.PrintController.OnEndPrint(printd_pos, new PrintEventArgs());
            //}

        }

        public void print()
        {
            this.printd_pos.PrintController = new System.Drawing.Printing.StandardPrintController();
            this.printd_pos.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printd_pos_PrintPage);

            //设置边距
            Margins margins = new Margins(32, 5, 30, 5);
            this.printd_pos.DefaultPageSettings.Margins = margins;

            this.printd_pos.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("First custom size", getYc(78), 600);
            //this.printDocument1.PrinterSettings.PrinterName = "";
            //Margins margins = new Margins(

            //this.printv_pos.Document = this.printd_pos;

            printv_pos.PrintPreviewControl.AutoZoom = false;
            printv_pos.PrintPreviewControl.Zoom = 1;

            // this.printv_pos.ShowDialog(win);

            try
            {
                printd_pos.Print();
            }
            catch (Exception ex)
            {
                printd_pos.PrintController.OnEndPrint(printd_pos, new PrintEventArgs());
            }

        }

        private void printd_pos_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            string strFile = GetPrintStr();
            Font ft = new Font("宋体", 9.0F, FontStyle.Regular);
            Point pt = new Point(0, 0);
            g.DrawString(strFile, ft, new SolidBrush(Color.Black), pt);
        }

    }
}
