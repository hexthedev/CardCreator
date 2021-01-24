using System;
using System.Drawing;

namespace CardCreator.Resolvers.String
{
    public class NormalStringResolver : IStringResolver
    {
        public void DrawString(Graphics graphics, string str, Font font, Brush brush, PointF point)
        {
            graphics.DrawString(str, font, brush, point);
        }

        public SizeF MesureString(Graphics graphics, string str, Font font)
        {
            return graphics.MeasureString(str, font);
        }
    }
}
