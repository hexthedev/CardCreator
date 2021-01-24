using CardCreator.Utility;

using System;
using System.Collections.Generic;
using System.Drawing;

namespace CardCreator.Resolvers.String
{
    public class IconStringResolver : IStringResolver
    {
        private Dictionary<string, string> _iconCodes = new Dictionary<string, string>()
        {
            { "sword", @"C:\Users\james\Desktop\CardCreatorResources\Icons\icon1.png" }
        };

        public void DrawString(Graphics graphics, string str, Font font, Brush brush, PointF point)
        {
            SizeF f = MesureString(graphics, str, font);

            Image icon = Image.FromFile(_iconCodes[str.Substring(1)]);

            graphics.DrawImage(
                icon, f.RectF(point), icon.Size.Rect(), GraphicsUnit.Pixel
            );
        }

        public SizeF MesureString(Graphics graphics, string str, Font font)
        {
            return graphics.MeasureString("A", font);
        }
    }
}
