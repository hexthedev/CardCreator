using System.Drawing;

namespace CardCreator.Utility
{
    public static class UTRectangle
    {
        /// <summary>
        /// Returns a rectangle with the same width as target, but with a height height/division * span and 
        /// a location of start * height
        /// height
        /// </summary>
        public static Rectangle YDivision(this Rectangle target, int span, int start = 0, int divisons = 12)
        {
            int spanHeight = target.Height / divisons;
            return new Rectangle(0, spanHeight * start, target.Width, spanHeight * span); 
        }

        /// <summary>
        /// Returns a rectangle with the same height as target, but with a width width/division * span and 
        /// a location of start * width
        /// height
        /// </summary>
        public static Rectangle XDivision(this Rectangle target, int span, int start = 0, int divisons = 12)
        {
            int spanWidth = target.Width / divisons;
            return new Rectangle(spanWidth * start, 0, spanWidth * span, target.Height);
        }

        /// <summary>
        /// Returns a rect that is inside the target rect and centered
        /// </summary>
        /// <param name="margin"></param>
        /// <returns></returns>
        public static Rectangle InnerRect(this Rectangle target, int margin)
        {
            return new Rectangle(
                margin,
                margin, 
                target.Width - margin * 2,
                target.Height - margin * 2
            );
        }

        /// <summary>
        /// Get a float rect from a rect
        /// </summary>
        public static RectangleF AsRectF(this Rectangle target)
        {
            return new RectangleF(target.X, target.Y, target.Width, target.Height);
        }
    }
}
