using System.Drawing;
using System.Drawing.Imaging;

namespace CardCreator.Generic
{
    public static class GenericInfoDrawers
    {
        /// <summary>
        /// Creates a box of size and puts a value on the left and icon on the right. 
        /// Normally from single digit numbers and a small square icon
        /// </summary>
        /// <param name="value"></param>
        /// <param name="iconPath"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private static Image ValueIconBox1Drawer(string value, string iconPath, Size size, Brush backgroundBrush, Pen contentPen)
        {
            using (Graphics g = UTGraphics.MakeEditableImage(size, out Image img))
            {
                g.FillRectangle(backgroundBrush, size.Rect());
                g.DrawRectangle( contentPen, size.Rect() );

                Rectangle t1 = new Rectangle(0, 0, size.Width / 2, size.Height);
                g.DrawString(value, new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, t1);

                Rectangle t2 = new Rectangle(size.Width / 2, 0, size.Width / 2, size.Height);
                g.DrawImage(Image.FromFile(iconPath), t2);

                return img;
            }
        }
    }



}


