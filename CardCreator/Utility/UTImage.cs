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
        public static void DrawCentered(this Image target, Graphics graphics, Rectangle dest)
        {
            Size s = target.Size.ScaleTo(dest.Size, out bool matchedHeight);

            // Where is the box placed
            Point p = new Point(
                matchedHeight ? 0 : (target.Width - s.Width),
                matchedHeight ?  (target.Height-s.Height) / 2 : 0
            );

            graphics.DrawImage(
                target,
                dest,
                new Rectangle(p, s),
                GraphicsUnit.Pixel
            );
        }
    }
}
