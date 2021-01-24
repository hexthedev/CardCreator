using System.Drawing;

namespace CardCreator.Utility
{
    public static class UTPens
    {
        public const float WidthThin = 1;
        public const float WidthNormal = 2;
        public const float WidthThick = 4;

        public static readonly Pen Black = new Pen(Color.FromArgb(255, 100, 100, 100), WidthNormal);
    }

    public static class UTPens_Text
    {
        public static readonly Pen Black = new Pen(Color.FromArgb(255, 100, 100, 100), UTPens.WidthThin);
    }
}
