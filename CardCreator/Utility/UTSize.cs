﻿using System.Drawing;

namespace CardCreator.Utility
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

        /// <summary>
        /// Changes the target size so that one of the dimensions (width or height)
        /// is the same as the width or height of the parent, such that the target
        /// size has an area <= parent area. Matched height says whether or not the height was matched or width was matched
        /// </summary>
        public static Size ScaleTo(this Size target, Size parent, out bool matchedHeight)
        {
            float heightRatio = (float)target.Height / parent.Height;
            float widthRatio = (float)target.Width / parent.Width;

            // Get the size of the image box
            matchedHeight = heightRatio < widthRatio;
            float sizeRatio = matchedHeight ? heightRatio : widthRatio;
            return new Size((int)(parent.Width * sizeRatio), (int)(parent.Height * sizeRatio));
        }
    }
}
