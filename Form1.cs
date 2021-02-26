using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BarcodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            generateBarcode();
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                generateBarcode();
            }
        }



        public void generateBarcode()
        {
            string barCode = textBox1.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode =
                Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = brCode.Draw(barCode, 60);

            }
            catch (Exception)
            {
                
            }

            label1.Text = textBox1.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.PrinterSettings = printDialog1.PrinterSettings;
            printDocument1.Print();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            label1.Text = "";
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save(@"D:\sample.png");
            
        }

        private void Print_Page(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 100, 100, 200, 100);
            e.Graphics.DrawString(textBox1.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(100, 250));
        }

       
    }
}
