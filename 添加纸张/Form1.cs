using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrinterAPI;
namespace 添加纸张
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


           // PrintDocument prdoc = new PrintDocument();

            foreach (string s in PrinterSettings.InstalledPrinters)
            {
                listBox1.Items.Add(s);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           string s= Printer.GetPrinterStatus(listBox1.Text);//获取打印机状态
           label1.Text = s;
           PrintDocument prdoc = new PrintDocument();//创建文档
           prdoc.DefaultPageSettings.PrinterSettings.PrinterName = listBox1.Text;//指定打印机

           foreach (PaperSize ps in prdoc.PrinterSettings.PaperSizes)
           {
               
           }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Printer.SetDefaultPrinter("EPSON LQ-2680K ESC/P2");
            //string pn = "EPSON LQ-2680K ESC/P2";
            //Printer.AddCustomPaperSize(pn,"农行凭证",228,114);
            string print_name = "";
            print_name = listBox1.SelectedItem.ToString();
            Printer.SetDefaultPrinter(print_name);
            Printer.AddCustomPaperSize(print_name, "农行凭证", 228, 114);
            MessageBox.Show("打印机设置成功");


        }
    }
}
