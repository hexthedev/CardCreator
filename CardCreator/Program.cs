using CardCreator.WarBuilder;

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CardCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bitmap bm = new Bitmap(1001, 1001, PixelFormat.Format32bppArgb);

            //Graphics g = Graphics.FromImage(bm);

            //Pen p = new Pen(Color.FromArgb(255, 100, 100, 100), 3);
            //Brush b = Brushes.AliceBlue;

            //Point pt = new Point(20, 20);
            //Size s = new Size(40, 40);
            //Rectangle r = new Rectangle(pt, s);
            //g.DrawEllipse(p, r);

            //Point pt2 = new Point(0, 0);
            //Size s2 = new Size(1000, 1000);
            //Rectangle r2 = new Rectangle(pt2, s2);
            //g.DrawRectangle(p, r2);

            //Font f = new Font(FontFamily.GenericSansSerif, 20);
            //g.DrawString("string is something I really want to", f, b, r2);

            //Image fl = Image.FromFile(@"C:\Users\james\Desktop\Test\snapshot.png");
            //g.DrawImage(fl, r2, new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);

            //// Use mesure string and brick laying to right text
            //g.MeasureString("test", f);

            //bm.Save(@"C:\Users\james\Desktop\Test\test.png", ImageFormat.Png);

            WarBuilderDrawer d = new WarBuilderDrawer();

            Image card = d.DrawCard(UTSize.cMagicCard, UTMargin.cAlexGameDefault);

            card.Save("C:\\Users\\james\\Desktop\\test.png");


            //Image test = ValueIconBox1Drawer("1", "C:\\Users\\james\\Desktop\\lightning.png", new Size(35, 20));


            //TitleBarDrawer(test, "Spy", new Size(150, 20)).Save("C:\\Users\\james\\Desktop\\test.png", ImageFormat.Png);
        }


        private static Image TitleBarDrawer(Image energy, string name, Size size)
        {
            Bitmap img = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(img);

            Pen p = new Pen(Color.FromArgb(255, 100, 100, 100), 2);
            Brush b = Brushes.Black;

            g.FillRectangle(
                Brushes.Purple,
                new Rectangle(0, 0, size.Width, size.Height)
            );

            Rectangle imgRect = new Rectangle(0, 0, (size.Width - 1) / 5, size.Height - 1);
            g.DrawImage(energy, imgRect);

            g.DrawString(
                name,
                new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold), Brushes.White,
                new PointF(size.Width/5, 0)
            );

            return img;
        }

        private static Image ValueIconBox1Drawer(string value, string iconPath, Size size)
        {
            Bitmap img = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(img);

            Pen p = new Pen(Color.FromArgb(255, 100, 100, 100), 2);
            Brush b = Brushes.Black;

            g.FillRectangle(
                Brushes.Yellow,
                new Rectangle(0,0,size.Width,size.Height)
            );

            g.DrawRectangle(
                p, new Rectangle(0, 0, size.Width-1, size.Height-1)
            );

            Rectangle t1 = new Rectangle(0, 0, size.Width / 2, size.Height);
            g.DrawString(value, new Font(FontFamily.GenericSansSerif, 10), b, t1);

            Rectangle t2 = new Rectangle(size.Width / 2, 0, size.Width / 2, size.Height);
            g.DrawImage(Image.FromFile(iconPath), t2);

            return img;
        }
    }
}
