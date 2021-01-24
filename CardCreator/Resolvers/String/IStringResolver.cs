using System.Drawing;

namespace CardCreator.Resolvers.String
{
    public interface IStringResolver
    {
        /// <summary>
        /// Get the size the string will take up when printed
        /// </summary>
        SizeF MesureString(Graphics graphics, string str, Font font);

        /// <summary>
        /// Draw the string to the given graphic and the point
        /// </summary>
        void DrawString(Graphics graphics, string str, Font font, Brush brush, PointF point);
    }
}
