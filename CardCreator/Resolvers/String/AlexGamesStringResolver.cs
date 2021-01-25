using System.Collections.Generic;
using System.Drawing;

namespace CardCreator.Resolvers.String
{
    public class AlexGamesStringResolver : IStringResolver
    {
        private NormalStringResolver _normalRes = new NormalStringResolver();
        private IconStringResolver _iconRes;

        public AlexGamesStringResolver(Dictionary<string, string> iconPaths)
        {
            _iconRes = new IconStringResolver(iconPaths);
        }

        public void DrawString(Graphics graphics, string str, Font font, Brush brush, PointF point)
        {
            switch (GetType(str))
            {
                case EStringType.Normal: 
                    _normalRes.DrawString(graphics, str, font, brush, point);
                    break;
                case EStringType.Icon:
                    _iconRes.DrawString(graphics, str, font, brush, point);
                    break;
            }
        }

        public SizeF MesureString(Graphics graphics, string str, Font font)
        {
            switch (GetType(str))
            {
                case EStringType.Normal: return _normalRes.MesureString(graphics, str, font);
                case EStringType.Icon: return _iconRes.MesureString(graphics, str, font);
            }

            return new SizeF(-1, -1);
        }

        private EStringType GetType(string str)
        {
            if (str.StartsWith("/"))
            {
                return EStringType.Icon;
            }

            return EStringType.Normal;
        }

        private enum EStringType
        {
            Normal, 
            Icon
        }
    }
}
