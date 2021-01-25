using CardCreator.Utility;

using System.Drawing;

namespace CardCreator.Generic
{
    public class GenericInfoDrawer
    {
        private Brush _brushBackground = Brushes.White;

        private Pen _penContent = Pens.Black;

        public GenericInfoDrawer() { }

        public GenericInfoDrawer(Brush backgroundBrush, Pen contentPen)
        {
            _brushBackground = backgroundBrush;
            _penContent = contentPen;
        }

        /// <summary>
        /// Creates a box of size and puts a value on the left and icon on the right. 
        /// Normally from single digit numbers and a small square icon
        /// </summary>
        public void DrawValueIconBox1(Graphics graphics, Rectangle rect, string value, string iconPath)
        {
            graphics.FillRectangle(_brushBackground, rect);
            graphics.DrawRectangle(_penContent, rect);

            Rectangle textRect = rect.XDivision(6);
            graphics.DrawString(value, new Font(FontFamily.GenericSansSerif, 24), Brushes.Black, textRect);

            Rectangle iconRect = rect.XDivision(6, 6);
            graphics.DrawImage(Image.FromFile(iconPath), iconRect);
        }
    }



}


