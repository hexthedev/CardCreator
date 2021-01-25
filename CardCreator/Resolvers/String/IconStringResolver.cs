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
            SizeF f = MesureIcon(graphics, str, font);

            Image icon = Image.FromFile(_iconCodes[str.Substring(1)]);

            graphics.DrawImage(
                icon, f.RectF(point), icon.Size.Rect(), GraphicsUnit.Pixel
            );

            graphics.DrawString(" ", font, brush, point + f);
        }

        public SizeF MesureString(Graphics graphics, string str, Font font)
        {
            return MesureIcon(graphics, str, font) + graphics.MeasureString(" ", font);
        }

        private SizeF MesureIcon(Graphics graphics, string str, Font font)
        {
            SizeF fontsize = graphics.MeasureString("A", font);

            Image icon = Image.FromFile(_iconCodes[str.Substring(1)]);
            SizeF iconTestSize = new SizeF(icon.Width, fontsize.Height);

            return icon.Size.ScaleTo(iconTestSize.ToSize(), out bool matchedHeight);
        }
    }
}
