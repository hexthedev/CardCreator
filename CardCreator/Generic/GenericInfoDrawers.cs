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
        public Image DrawValueIconBox1(Size size, string value, string iconPath)
        {
            Rectangle boxRect = size.Rect();

            using (Graphics g = UTGraphics.MakeEditableImage(size, out Image img))
            {
                g.FillRectangle(_brushBackground, boxRect);
                g.DrawRectangle(_penContent, boxRect);

                Rectangle textRect = boxRect.XDivision(6);
                g.DrawString(value, new Font(FontFamily.GenericSansSerif, 24), Brushes.Black, textRect);

                Rectangle iconRect = boxRect.XDivision(6, 6);
                g.DrawImage(Image.FromFile(iconPath), iconRect);

                return img;
            }
        }
    }



}


