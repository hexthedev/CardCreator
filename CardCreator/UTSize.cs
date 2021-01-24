using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCreator
{
    public static class UTSize
    {
        /// <summary>
        /// Gets the size as a rect starting at 0,0
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Rectangle Rect(this Size target)
        {
            return new Rectangle(0, 0, target.Width - 1, target.Height - 1);
        }

        /// <summary>
        /// Get the size as rect start at x,y
        /// </summary>
        /// <param name="target"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Rectangle Rect(this Size target, int x, int y)
        {
            return new Rectangle(x, y, target.Width - 1, target.Height - 1);
        }
    }
}
