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
            Size s = target.Size.ScaleTo(dest, out bool matchedHeight);

            // Where is the box placed
            Point p = new Point(
                matchedHeight ? 0 : (target.Width - s.Width),
                matchedHeight ?  (target.Height-s.Height) / 2 : 0
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
