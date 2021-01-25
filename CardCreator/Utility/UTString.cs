using CardCreator.Resolvers.String;

using System.Drawing;


namespace CardCreator.Utility
{
    public static class UTString
    {
        public static void DrawBrickLay(this string target, Graphics graphics, Rectangle rect, Font font, Brush brush, IStringResolver resolver)
        {
            string[] words = target.Split(' ');

            float fontHeight = graphics.MeasureString(words[0], font).Height;

            float curX = 0;
            float curY = 0;

            foreach (string word in words)
            {
                PointF wordPoint = new PointF(curX, curY);
                SizeF wordSize = resolver.MesureString(graphics, word, font);

                if(curX + wordSize.Width > rect.Size.Width)
                {
                    curX = 0;
                    curY = curY + fontHeight;
                    wordPoint = new PointF(curX, curY);
                }

                PointF wordPointOffset = new PointF(rect.X + wordPoint.X, rect.Y + wordPoint.Y);
                resolver.DrawString(graphics, word, font, brush, wordPointOffset);
                curX += wordSize.Width;
            }
        } 
    }
}
