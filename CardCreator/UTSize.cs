using System.Drawing;

namespace CardCreator
{
    public static class UTSize
    {
        public static readonly Size cAlexGameCardDefault = new Size(178,294);
        public static readonly Size cMagicCard = new Size(750, 1050);

        /// <summary>
        /// Returns a size with the same width as target, but with a height height/division * span
        /// height
        /// </summary>
        public static Size YDivision(this Size target, int span, int divisons = 12)
        {
            return new Size(target.Width, target.Height / divisons * span);
        }

        /// <summary>
        /// Returns a size with the same height as target, but with a width width/division * span
        /// height
        /// </summary>
        public static Size XDivision(this Size target, int span, int divisons = 12)
        {
            return new Size(target.Width / divisons * span, target.Height);
        }

        /// <summary>
        /// Gets the size as a rect starting at 0,0
        /// </summary>
        public static Rectangle Rect(this Size target)
        {
            return new Rectangle(0, 0, target.Width - 1, target.Height - 1);
        }

        /// <summary>
        /// Get the size as rect start at x,y
        /// </summary>
        public static Rectangle Rect(this Size target, int x, int y)
        {
            return new Rectangle(x, y, target.Width - 1, target.Height - 1);
        }
    }
}
