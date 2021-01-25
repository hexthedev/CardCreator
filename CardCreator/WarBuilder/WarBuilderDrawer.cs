using CardCreator.Generic;
using CardCreator.Resolvers.String;
using CardCreator.Utility;

using System.Collections.Generic;
using System.Drawing;

namespace CardCreator.WarBuilder
{
    public class WarBuilderIcons : Dictionary<string, string> { }

    public class WarBuilderBrushes
    {
        public Brush Content = Brushes.Black;

        public Brush CardBackground = Brushes.White;
        public Brush EnergyBackground = Brushes.Yellow;
        public Brush DefenceBackground = Brushes.AliceBlue;
    }

    public class WarBuilderCardArgs
    {
        public string ImagePath;
        public string CardText;
    }

    public class WarBuilderDrawer
    {
        private Graphics _graphics;

        private WarBuilderIcons _icons;
        private WarBuilderBrushes _brushes;

        IStringResolver _stringResolver;

        private Font _fontContent;
        
        public WarBuilderDrawer(
            Graphics graphics, 
            WarBuilderIcons icons, 
            WarBuilderBrushes brushes = null, 
            Font contentFont = null)
        {
            _graphics = graphics;
            _icons = icons;
            _brushes = brushes ?? new WarBuilderBrushes();
            _fontContent = contentFont ?? new Font(FontFamily.GenericSansSerif, 24);

            _stringResolver = new AlexGamesStringResolver(icons);
        }

        public void DrawCard(Rectangle rect, int margin, WarBuilderCardArgs args)
        {
            _graphics.FillRectangle(_brushes.CardBackground, rect);
            DrawLayout1(rect.InnerRect(margin), args);
        }

        public void DrawLayout1(Rectangle rect, WarBuilderCardArgs args)
        {   
            DrawTopBar1(rect.YDivision(1));
            Image.FromFile(args.ImagePath).DrawCentered(_graphics, rect.YDivision(5, 1));
            args.CardText.DrawBrickLay(_graphics, rect.YDivision(5, 6), _fontContent, _brushes.Content, _stringResolver);
            DrawBottomBar1(rect.YDivision(1, 11));
        }
        

        public void DrawTopBar1(Rectangle rect)
        {
            GenericInfoDrawer energyDrawer = new GenericInfoDrawer(Brushes.Yellow, Pens.Black);
            energyDrawer.DrawValueIconBox1(_graphics, rect.XDivision(2), "1", _icons["lightning"]); 
            _graphics.DrawString("This is a test", _fontContent, _brushes.Content, rect.XDivision(10, 2));
        }

        public void DrawBottomBar1(Rectangle rect)
        {
            _graphics.FillRectangle(Brushes.AliceBlue, rect);

            // attack and gems
            "1 /sword + 1 /sword".DrawBrickLay(_graphics, rect.XDivision(6), _fontContent, _brushes.Content, _stringResolver);

            // icons
            "/sword /sword".DrawBrickLay(_graphics, rect.XDivision(3, 6), _fontContent, _brushes.Content, _stringResolver);

            // Defence
            GenericInfoDrawer draw = new GenericInfoDrawer();
            draw.DrawValueIconBox1(_graphics, rect.XDivision(3, 9), "3", _icons["lightning"]);              
        }
    }
}
