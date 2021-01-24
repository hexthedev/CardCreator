using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCreator
{
    public static class UTGraphics
    {
        public static Graphics MakeEditableImage(Size size, out Image img)
        {
            img = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppArgb);
            return Graphics.FromImage(img);
        }
    }
}
