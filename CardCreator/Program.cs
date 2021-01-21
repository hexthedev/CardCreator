using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CardCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bm = new Bitmap(1001, 1001, PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(bm);

            Pen p = new Pen(Color.FromArgb(255, 100, 100, 100), 3);
            Brush b = Brushes.AliceBlue;

            Point pt = new Point(20, 20);
            Size s = new Size(40, 40);
            Rectangle r = new Rectangle(pt, s);
            g.DrawEllipse(p, r);

            Point pt2 = new Point(0, 0);
            Size s2 = new Size(1000, 1000);
            Rectangle r2 = new Rectangle(pt2, s2);
            g.DrawRectangle(p, r2);

            Font f = new Font(FontFamily.GenericSansSerif, 20);
            g.DrawString("string is something I really want to", f, b, r2);

            Image fl = Image.FromFile(@"C:\Users\james\Desktop\Test\snapshot.png");
            g.DrawImage(fl, r2, new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);

            // Use mesure string and brick laying to right text
            g.MeasureString("test", f);

            bm.Save(@"C:\Users\james\Desktop\Test\test.png", ImageFormat.Png);
        }

    }
}
