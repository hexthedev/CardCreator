using CardCreator.Resolvers.String;

using System.Drawing;


namespace CardCreator.Utility
{
    public static class UTString
    {
        public static readonly IStringResolver DefaultStringResolver = new AlexGamesStringResolver();

        public static Image DrawBrickLay(this string target, Size size, Font font, Brush brush)
        {
            string[] words = target.Split(' ');

            using (Graphics g =  UTGraphics.MakeEditableImage(size, out Image draw))
            {
                float fontHeight = g.MeasureString(words[0], font).Height;

                float curX = 0;
                float curY = 0;

                foreach (string word in words)
                {
                    PointF wordPoint = new PointF(curX, curY);
                    SizeF wordSize = DefaultStringResolver.MesureString(g, word, font);

                    if(curX + wordSize.Width > size.Width)
                    {
                        curX = 0;
                        curY = curY + fontHeight;
                        wordPoint = new PointF(curX, curY);
                    }

                    DefaultStringResolver.DrawString(g, word, font, brush, wordPoint);
                    curX += wordSize.Width;
                }

                return draw;

            }
        } 
    }
}
