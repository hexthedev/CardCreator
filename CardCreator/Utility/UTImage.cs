using System.Drawing;

namespace CardCreator.Utility
{
    public static class UTImage
    {
        /// <summary>
        /// Draws an image to a destination centered, and resized so that the shortest size
        /// fits the destination box
        /// </summary>
        /// <returns></returns>
        public static Image DrawCentered(this Image target, Size dest)
        {
            float heightRatio = (float)target.Height / dest.Height;
            float widthRatio = (float)target.Width / dest.Width;

            // Get the size of the image box
            float sizeRatio = heightRatio < widthRatio ? heightRatio : widthRatio;
            Size s = new Size((int)(dest.Width * sizeRatio), (int)(dest.Height * sizeRatio));

            // Where is the box placed
            Point p = new Point(
                widthRatio < heightRatio ? 0 : (target.Width - s.Width),
                widthRatio < heightRatio ?  (target.Height-s.Height) / 2 : 0
            );

            using (Graphics g = UTGraphics.MakeEditableImage(dest, out Image draw))
            {
                g.FillRectangle(Brushes.Gray, dest.Rect());

                g.DrawImage(
                    target,
                    dest.Rect(),
                    new Rectangle(p, s),
                    GraphicsUnit.Pixel
                );

                return draw;
            }
        }
    }
}
