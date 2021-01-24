﻿using CardCreator.Generic;

using System.Drawing;

namespace CardCreator.WarBuilder
{
    public class WarBuilderDrawer
    {
        private Font _fontContent = new Font(FontFamily.GenericSansSerif, 24);

        private Brush _brushBackground = Brushes.White;
        private Brush _brushContent = Brushes.Black;

        private Pen _penContent = Pens.Black;

        public WarBuilderDrawer() { }

        public WarBuilderDrawer(Brush backgroundBrush, Brush contentBrush, Font contentFont)
        {
            _brushBackground = backgroundBrush;
            _brushContent = contentBrush;
            _fontContent = contentFont;
        }

        public Image DrawCard(Size size, int margin)
        {
            Rectangle cardRect = size.Rect();

            using (Graphics g = UTGraphics.MakeEditableImage(size, out Image card))
            {
                g.FillRectangle(_brushBackground, size.Rect());

                Rectangle layoutRect = cardRect.InnerRect(margin);
                g.DrawImage( DrawLayout1(layoutRect.Size), layoutRect.Location );

                return card;
            }
        }


        public Image DrawLayout1(Size size)
        {
            Rectangle layoutRect = size.Rect();
            
            using (Graphics g = UTGraphics.MakeEditableImage(size, out Image layout))
            {
                // Full background color
                g.FillRectangle(Brushes.Red, layoutRect);

                // Top bar
                Rectangle topBarRect = layoutRect.YDivision(1);
                g.FillRectangle(Brushes.Blue, topBarRect);
                g.DrawImage(DrawTopBar1(topBarRect.Size), topBarRect);

                // Image space
                Rectangle imageRect = layoutRect.YDivision(5, 1);

                Image ig = UTImage.DrawCentered(
                    Image.FromFile(@"C:\Users\james\Desktop\CardCreatorResources\Longhaired-Dachshund-standing-outdoors.jpg"),
                    imageRect.Size
                );

                g.DrawImage(ig, imageRect);

                return layout;
            }
        }

        public Image DrawTopBar1(Size size)
        {
            Rectangle barRect = size.Rect();

            using (Graphics g = UTGraphics.MakeEditableImage(size, out Image bar))
            {
                Rectangle energyRect = barRect.XDivision(2);
                GenericInfoDrawer energyDrawer = new GenericInfoDrawer(Brushes.Yellow, Pens.Black);
                g.DrawImage(
                    energyDrawer.DrawValueIconBox1(energyRect.Size, "1", "C:\\Users\\james\\Desktop\\lightning.png"), 
                    energyRect
                );

                Rectangle textRect = barRect.XDivision(10, 2);
                g.DrawString("This is a test", _fontContent, _brushContent, textRect.AsRectF());

                return bar;
            }
        }
    }
}