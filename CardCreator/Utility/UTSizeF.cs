using System.Drawing;
namespace CardCreator.Utility
{
    public static class UTSizeF
    {
        /// <summary>
        /// Gets the size as a rect starting at 0,0
        /// </summary>
        public static RectangleF RectF(this SizeF target)
        {
            return new RectangleF(0, 0, target.Width - 1, target.Height - 1);
        }

        /// <summary>
        /// Get the size as rect start at x,y
        /// </summary>
        public static RectangleF RectF(this SizeF target, int x, int y)
        {
            return new RectangleF(x, y, target.Width - 1, target.Height - 1);
        }

        /// <summary>
        /// Get the size as rect start at Point
        /// </summary>
        public static RectangleF RectF(this SizeF target, PointF point)
        {
            return new RectangleF(point.X, point.Y, target.Width - 1, target.Height - 1);
        }

        /// <summary>
        /// Changes the target size so that one of the dimensions (width or height)
        /// is the same as the width or height of the parent, such that the target
        /// size has an area <= parent area
        /// </summary>
        public static SizeF ScaleTo(this SizeF target, SizeF parent)
        {
            float heightRatio = target.Height / parent.Height;
            float widthRatio = target.Width / parent.Width;

            // Get the size of the image box
            float sizeRatio = heightRatio < widthRatio ? heightRatio : widthRatio;
            return new SizeF(parent.Width * sizeRatio, parent.Height * sizeRatio);
        }
    }
}
